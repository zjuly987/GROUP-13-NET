using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fhdonnhap
{
    public partial class frmHoaDonNhap : Form
    {
        // Chuỗi kết nối – thay lại cho phù hợp với bạn
        private string connectionString = @"Data Source=LAPTOP-UKHEH49R;Initial Catalog=btlon;Integrated Security=True;Encrypt=False";

        // DataTable chứa chi tiết các mặt hàng trên DataGridView
        private DataTable dtDetails = new DataTable();

        public frmHoaDonNhap()
        {
            InitializeComponent();
            Load += frmHoaDonNhap_Load;
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            ;
            LoadGridData();
            // Nạp dữ liệu cho các ComboBox
            LoadComboBoxes();

            // Reset form về trạng thái ban đầu
            ResetForm();

            // Gắn event cho các điều khiển cần tính tự động
            cboMaNV.SelectedIndexChanged += cboMaNV_SelectedIndexChanged;
            cboMaNCC.SelectedIndexChanged += cboMaNCC_SelectedIndexChanged;
            cboMaquanao.SelectedIndexChanged += cboMaQuanAo_SelectedIndexChanged;

            txtDongianhap.Leave += (s, ev) => CalculateLineTotal();
            txtSoluong.Leave += (s, ev) => CalculateLineTotal();
            txtGiamgia.Leave += (s, ev) => CalculateLineTotal();

            btnThemmoi.Click += btnThemMoi_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnDong.Click += btnDong_Click;
            btnTimkiem.Click += btnTimKiem_Click;
            btnInHD.Click += btnInHD_Click;
        }


        #region ———— Load & Reset ————

        private void LoadComboBoxes()
        {
            cboMaNV.DataSource = GetData("SELECT MaNV, TenNV FROM tblNhanVien");
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = -1;

            cboMaNCC.DataSource = GetData("SELECT MaNCC, TenNCC FROM tblNhaCungCap");
            cboMaNCC.DisplayMember = "MaNCC";
            cboMaNCC.ValueMember = "MaNCC";
            cboMaNCC.SelectedIndex = -1;

            cboMaquanao.DataSource = GetData("SELECT MaQuanAo, TenQuanAo FROM tblSanpham");
            cboMaquanao.DisplayMember = "MaQuanAo";
            cboMaquanao.ValueMember = "MaQuanAo";
            cboMaquanao.SelectedIndex = -1;

            cboSoHDNhap.DataSource = GetData("SELECT SoHDN FROM tblHoaDonNhap");
            cboSoHDNhap.DisplayMember = "SoHDN";
            cboSoHDNhap.ValueMember = "SoHDN";
            cboSoHDNhap.SelectedIndex = -1;
        }

        private void ResetForm()
        {
            txtSoHDNhap.Clear();
            mskNgaynhap.Clear();
            cboMaNV.SelectedIndex = -1;
            txtTenNV.Clear();
            cboMaNCC.SelectedIndex = -1;
            txtTenNCC.Clear();

            cboMaquanao.SelectedIndex = -1;
            txtTenquanao.Clear();
            txtDongianhap.Clear();
            txtSoluong.Clear();
            txtGiamgia.Clear();
            txtThanhtien.Clear();

            dtDetails.Clear();
            txtTongtien.Clear();
            lblBangchu.Text = "";
        }

        #endregion

        #region ———— Helpers chung ————

        private DataTable GetData(string sql)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private static readonly string[] ChuSo =
        {
            "không", "một", "hai", "ba", "bốn",
            "năm", "sáu", "bảy", "tám", "chín"
        };

        /// <summary>
        /// Chuyển số thành chữ tiếng Việt (kèm "đồng").
        /// </summary>
        private string ConvertNumberToWords(long number)
        {
            if (number == 0)
                return "Không đồng";

            var sb = new System.Text.StringBuilder();
            string[] units = { "", " nghìn", " triệu", " tỷ" };
            int unitIndex = 0;

            while (number > 0)
            {
                int chunk = (int)(number % 1000);
                if (chunk > 0)
                {
                    var chunkText = ReadThreeDigits(chunk);
                    sb.Insert(0, chunkText + units[unitIndex] + " ");
                }
                number /= 1000;
                unitIndex++;
            }

            var result = sb.ToString().Trim();
            result = char.ToUpper(result[0]) + result.Substring(1);
            return result + " đồng";
        }

        /// <summary>
        /// Đọc 3 chữ số (0–999) thành chữ.
        /// </summary>
        private string ReadThreeDigits(int number)
        {
            int hundreds = number / 100;
            int tens = (number % 100) / 10;
            int ones = number % 10;
            var sb = new System.Text.StringBuilder();

            // Hàng trăm
            if (hundreds > 0)
                sb.Append(ChuSo[hundreds] + " trăm");

            // Hàng chục
            if (tens > 1)
            {
                sb.Append((sb.Length > 0 ? " " : "") + ChuSo[tens] + " mươi");
                if (ones > 0)
                    sb.Append(ones == 5 ? " lăm" : " " + ChuSo[ones]);
            }
            else if (tens == 1)
            {
                sb.Append((sb.Length > 0 ? " " : "") + "mười");
                if (ones > 0)
                    sb.Append(ones == 5 ? " lăm" : " " + ChuSo[ones]);
            }
            else if (tens == 0 && ones > 0)
            {
                if (hundreds > 0)
                    sb.Append(" linh " + ChuSo[ones]);
                else
                    sb.Append(ChuSo[ones]);
            }

            return sb.ToString();
        }


        #endregion

        #region ———— Tính Thành Tiền & Bằng Chữ ————

        private void CalculateLineTotal()
        {
            // 1) Nếu thiếu ô nào (Đơn giá, SL hoặc Giảm giá) thì thoát luôn
            if (string.IsNullOrWhiteSpace(txtDongianhap.Text) ||
                string.IsNullOrWhiteSpace(txtSoluong.Text) ||
                string.IsNullOrWhiteSpace(txtGiamgia.Text))
                return;

            // 2) Khi cả 3 đã có dữ liệu, parse và tính
            if (decimal.TryParse(txtDongianhap.Text, out var dg) &&
                int.TryParse(txtSoluong.Text, out var sl) &&
                decimal.TryParse(txtGiamgia.Text, out var gg))
            {
                var tt = dg * sl * (1 - gg);
                txtThanhtien.Text = tt.ToString("N0");
            }
            else
            {
                // Chỉ gán 0 khi parse thất bại
                txtThanhtien.Text = "0";
            }
        }



        private void UpdateTotalHeader()
        {
            decimal sum = 0;
            foreach (DataRow r in dtDetails.Rows)
                sum += (decimal)r["ThanhTien"];

            txtTongtien.Text = sum.ToString("N0");
            lblBangchu.Text = ConvertNumberToWords((long)sum);
        }

        #endregion

        #region ———— Sự kiện ComboBox => điền Tên tương ứng ————

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex >= 0)
                txtTenNV.Text = ((DataRowView)cboMaNV.SelectedItem)["TenNV"].ToString();
        }

        private void cboMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNCC.SelectedIndex >= 0)
                txtTenNCC.Text = ((DataRowView)cboMaNCC.SelectedItem)["TenNCC"].ToString();
        }

        private void cboMaQuanAo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaquanao.SelectedIndex >= 0)
                txtTenquanao.Text = ((DataRowView)cboMaquanao.SelectedItem)["TenQuanAo"].ToString();
        }

        #endregion

        #region ———— Validate ————

        private bool ValidateHeader()
        {
            if (string.IsNullOrWhiteSpace(txtSoHDNhap.Text))
            {
                MessageBox.Show("Số hóa đơn không được để trống.");
                txtSoHDNhap.Focus();
                return false;
            }

            if (!DateTime.TryParseExact(mskNgaynhap.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out _))
            {
                MessageBox.Show("Ngày nhập không hợp lệ.");
                mskNgaynhap.Focus();
                return false;
            }

            if (cboMaNV.SelectedIndex < 0)
            {
                MessageBox.Show("Phải chọn mã nhân viên hợp lệ.");
                cboMaNV.Focus();
                return false;
            }

            if (cboMaNCC.SelectedIndex < 0)
            {
                MessageBox.Show("Phải chọn mã nhà cung cấp hợp lệ.");
                cboMaNCC.Focus();
                return false;
            }

            if (!decimal.TryParse(txtTongtien.Text, out _))
            {
                MessageBox.Show("Tổng tiền không hợp lệ.");
                txtTongtien.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateDetail()
        {
            if (cboMaquanao.SelectedIndex < 0)
            {
                MessageBox.Show("Phải chọn mã quần áo hợp lệ.");
                cboMaquanao.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDongianhap.Text, out _))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                txtDongianhap.Focus();
                return false;
            }

            if (!int.TryParse(txtSoluong.Text, out _))
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                txtSoluong.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiamgia.Text, out _))
            {
                MessageBox.Show("Giảm giá không hợp lệ.");
                txtGiamgia.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region ———— Các nút chức năng ————

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (dtDetails.Rows.Count > 0 || !string.IsNullOrEmpty(txtSoHDNhap.Text))
            {
                var r = MessageBox.Show(
                    "Dữ liệu chưa lưu, bạn có chắc muốn tạo mới?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (r == DialogResult.No) return;
            }
            ResetForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            RecalculateTotalFromGrid();

            if (!ValidateHeader()) return;
            if (dtDetails.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm để lưu.");
                return;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var tran = conn.BeginTransaction();
                try
                {
                    // 1) Lưu header
                    var sqlHD = @"
                        INSERT INTO tblHoaDonNhap
                          (SoHDN, NgayNhap, MaNV, MaNCC, TongTien)
                        VALUES
                          (@SoHD, @Ngay, @MaNV, @MaNCC, @Tong)";
                    using (var cmd = new SqlCommand(sqlHD, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", txtSoHDNhap.Text);
                        cmd.Parameters.AddWithValue("@Ngay",
                            DateTime.ParseExact(mskNgaynhap.Text,
                                                "dd/MM/yyyy",
                                                CultureInfo.InvariantCulture));
                        cmd.Parameters.AddWithValue("@MaNV", cboMaNV.SelectedValue);
                        cmd.Parameters.AddWithValue("@MaNCC", cboMaNCC.SelectedValue);
                        cmd.Parameters.AddWithValue("@Tong", decimal.Parse(txtTongtien.Text));
                        cmd.ExecuteNonQuery();
                    }

                    // 2) Lưu chi tiết
                    var sqlCT = @"
                        INSERT INTO tblChiTietHDNhap
                          (SoHDN, MaQuanAo, SoLuong, DonGia, GiamGia, ThanhTien)
                        VALUES
                          (@SoHD, @MaQA, @SL, @DG, @GG, @TT)";
                    foreach (DataRow r in dtDetails.Rows)
                    {
                        using (var cmd = new SqlCommand(sqlCT, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@SoHD", txtSoHDNhap.Text);
                            cmd.Parameters.AddWithValue("@MaQA", r["MaQuanAo"]);
                            cmd.Parameters.AddWithValue("@SL", r["SoLuong"]);
                            cmd.Parameters.AddWithValue("@DG", r["DonGia"]);
                            cmd.Parameters.AddWithValue("@GG", r["GiamGia"]);
                            cmd.Parameters.AddWithValue("@TT", r["ThanhTien"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("Lưu hóa đơn thành công.", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // refresh lại danh sách hóa đơn để tìm kiếm
                    LoadComboBoxes();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(
                "Bạn có muốn hủy bỏ các thay đổi chưa lưu?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
                ResetForm();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(
                "Bạn có muốn đóng form?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
                Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboSoHDNhap.SelectedIndex < 0)
            {
                MessageBox.Show("Phải chọn số hóa đơn hợp lệ để tìm kiếm.");
                cboSoHDNhap.Focus();
                return;
            }

            var sohd = cboSoHDNhap.SelectedValue.ToString();
            // mới
            var dtH = GetData($"SELECT * FROM tblHoaDonNhap WHERE SoHDN = '{sohd}'");
            if (dtH.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn.");
                return;
            }

            // Hiển thị header
            // Hiển thị header
            var rh = dtH.Rows[0];
            txtSoHDNhap.Text = rh["SoHDN"].ToString();           // <-- dùng đúng tên cột
            mskNgaynhap.Text = Convert.ToDateTime(rh["NgayNhap"])
                                    .ToString("dd/MM/yyyy");
            cboMaNV.SelectedValue = rh["MaNV"];
            cboMaNCC.SelectedValue = rh["MaNCC"];
            txtTongtien.Text = rh["TongTien"].ToString();
            // …

            lblBangchu.Text = ConvertNumberToWords((long)Convert.ToDecimal(rh["TongTien"]));

            // Hiển thị chi tiết
            // Hiển thị chi tiết nhập hàng từ database, đúng tên bảng + cột:
            var dtC = new DataTable();
            var sql = @"
              SELECT
                c.MaQuanAo    AS MaQuanAo,
                sp.TenQuanAo  AS TenQuanAo,
                c.SoLuong     AS SoLuong,
                c.DonGia      AS DonGia,
                c.GiamGia     AS GiamGia,
                (c.DonGia * c.SoLuong * (1 - c.GiamGia)) AS ThanhTien
              FROM tblChiTietHDNhap AS c
              LEFT JOIN tblSanpham    AS sp
                ON c.MaQuanAo = sp.MaQuanAo
              WHERE c.SoHDN = @sohd";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@sohd", sohd);
                da.Fill(dtC);
            }

            // Gán lên DataGridView
            dataGridViewHDNhap.AutoGenerateColumns = true;
            dataGridViewHDNhap.DataSource = dtC;
            RecalculateTotalFromGrid();


            // Cập nhật tổng tiền + chữ
            decimal sum = 0;
            foreach (DataRow r in dtC.Rows)
                sum += Convert.ToDecimal(r["ThanhTien"]);
            txtTongtien.Text = sum.ToString("N0");
            lblBangchu.Text = ConvertNumberToWords((long)sum);

            RecalculateTotalFromGrid();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng In hóa đơn chưa được triển khai.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        /// <summary>
        /// Load toàn bộ chi tiết hóa đơn (tblCTHDNhap) kèm tên sản phẩm lên DataGridView khi Form khởi động.
        /// </summary>
        private void LoadGridData()
        {
            var dt = new DataTable();
            var sql = @"
            SELECT
                c.SoHDN       AS SoHDN,
                c.MaQuanAo    AS MaQuanAo,
                sp.TenQuanAo  AS TenQuanAo,
                c.SoLuong     AS SoLuong,
                c.DonGia      AS DonGia,
                c.GiamGia     AS GiamGia,
                (c.DonGia * c.SoLuong * (1 - c.GiamGia)) AS ThanhTien
            FROM tblChiTietHDNhap AS c
            LEFT JOIN tblSanpham AS sp
                ON c.MaQuanAo = sp.MaQuanAo
            ";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            dataGridViewHDNhap.AutoGenerateColumns = true;
            dataGridViewHDNhap.DataSource = dt;
            RecalculateTotalFromGrid();



            // Cập nhật tổng tiền
            decimal sum = 0;
            foreach (DataRow r in dt.Rows)
                sum += Convert.ToDecimal(r["ThanhTien"]);
            txtTongtien.Text = sum.ToString("N0");
            lblBangchu.Text = ConvertNumberToWords((long)sum);
        }
        /// <summary>
        /// Tính tổng cột ThanhTien từ DataGridView và cập nhật txtTongtien + lblBangchu
        /// </summary>
        private void RecalculateTotalFromGrid()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dataGridViewHDNhap.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["ThanhTien"].Value != null &&
                    decimal.TryParse(row.Cells["ThanhTien"].Value.ToString(),
                                     NumberStyles.Any,
                                     CultureInfo.InvariantCulture,
                                     out var tt))
                {
                    sum += tt;
                }
            }
            txtTongtien.Text = sum.ToString("N0");
            lblBangchu.Text = ConvertNumberToWords((long)sum);
        }

    }
}
