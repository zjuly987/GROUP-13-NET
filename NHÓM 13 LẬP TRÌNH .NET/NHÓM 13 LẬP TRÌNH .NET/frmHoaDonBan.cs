using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace hdonban
{
    public partial class frmHoaDonBan : Form
    {
        private string connectionString = @"Data Source=LAPTOP-UKHEH49R;Initial Catalog=btlon;Integrated Security=True;Encrypt=False";

        public frmHoaDonBan()
        {
            InitializeComponent();
            Load += frmHoaDonBan_Load;
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            // Load grid và combobox
            LoadComboBoxes();
            ResetForm();
            LoadGridData();

            // Events
            cboMaNV.SelectedIndexChanged += cboMaNV_SelectedIndexChanged;
            cboMaKH.SelectedIndexChanged += cboMaKH_SelectedIndexChanged;
            cboMaquanao.SelectedIndexChanged += cboMaQuanAo_SelectedIndexChanged;

            txtDongiaban.Leave += (s, ev) => CalculateLineTotal();
            txtSoluong.Leave += (s, ev) => CalculateLineTotal();
            txtGiamgia.Leave += (s, ev) => CalculateLineTotal();

            btnThemmoi.Click += btnThemMoi_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnDong.Click += btnDong_Click;
            btnTimkiem.Click += btnTimKiem_Click;
            btnInHD.Click += btnInHD_Click;
        }

        #region Load & Reset
        private void LoadComboBoxes()
        {
            cboMaNV.DataSource = GetData("SELECT MaNV, TenNV FROM tblNhanVien");
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = -1;

            cboMaKH.DataSource = GetData("SELECT MaKhach, TenKhach FROM tblKhachHang");
            cboMaKH.DisplayMember = "MaKhach";
            cboMaKH.ValueMember = "MaKhach";
            cboMaKH.SelectedIndex = -1;

            cboMaquanao.DataSource = GetData("SELECT MaQuanAo, TenQuanAo, DonGiaBan FROM tblSanpham");
            cboMaquanao.DisplayMember = "MaQuanAo";
            cboMaquanao.ValueMember = "MaQuanAo";
            cboMaquanao.SelectedIndex = -1;

            cboSoHDBan.DataSource = GetData("SELECT SoHDB FROM tblHoaDonBan");
            cboSoHDBan.DisplayMember = "SoHDB";
            cboSoHDBan.ValueMember = "SoHDB";
            cboSoHDBan.SelectedIndex = -1;
        }

        private void ResetForm()
        {
            txtSoHDBan.Clear();
            mskNgayban.Clear();
            cboMaNV.SelectedIndex = -1;
            txtTenNV.Clear();
            cboMaKH.SelectedIndex = -1;
            txtTenKH.Clear();

            cboMaquanao.SelectedIndex = -1;
            txtTenquanao.Clear();
            txtDongiaban.Clear();
            txtSoluong.Clear();
            txtGiamgia.Clear();
            txtThanhtien.Clear();

            dataGridViewHDBan.DataSource = null;
            txtTongtien.Clear();
            lblBangchu.Text = string.Empty;
        }
        #endregion

        #region Helpers
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

        private static readonly string[] ChuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

        private string ConvertNumberToWords(long number)
        {
            if (number == 0) return "Không đồng";
            var sb = new System.Text.StringBuilder();
            string[] units = { "", " nghìn", " triệu", " tỷ" };
            int unitIndex = 0;
            while (number > 0)
            {
                int chunk = (int)(number % 1000);
                if (chunk > 0)
                {
                    var text = ReadThreeDigits(chunk);
                    sb.Insert(0, text + units[unitIndex] + " ");
                }
                number /= 1000;
                unitIndex++;
            }
            var res = sb.ToString().Trim();
            res = char.ToUpper(res[0]) + res.Substring(1) + " đồng";
            return res;
        }

        private string ReadThreeDigits(int num)
        {
            int h = num / 100;
            int t = (num % 100) / 10;
            int o = num % 10;
            var sb = new System.Text.StringBuilder();
            if (h > 0) sb.Append(ChuSo[h] + " trăm");
            if (t > 1)
            {
                sb.Append((sb.Length > 0 ? " " : "") + ChuSo[t] + " mươi");
                if (o > 0) sb.Append(o == 5 ? " lăm" : " " + ChuSo[o]);
            }
            else if (t == 1)
            {
                sb.Append((sb.Length > 0 ? " " : "") + "mười");
                if (o > 0) sb.Append(o == 5 ? " lăm" : " " + ChuSo[o]);
            }
            else if (o > 0)
            {
                if (h > 0) sb.Append(" linh " + ChuSo[o]);
                else sb.Append(ChuSo[o]);
            }
            return sb.ToString();
        }
        #endregion

        #region Tính tiền
        private void CalculateLineTotal()
        {
            if (string.IsNullOrWhiteSpace(txtDongiaban.Text) ||
                string.IsNullOrWhiteSpace(txtSoluong.Text) ||
                string.IsNullOrWhiteSpace(txtGiamgia.Text))
            {
                return;
            }

            if (decimal.TryParse(txtDongiaban.Text, out var dg) &&
                int.TryParse(txtSoluong.Text, out var sl) &&
                decimal.TryParse(txtGiamgia.Text, out var gg))
            {
                var tt = dg * sl * (1 - gg);
                txtThanhtien.Text = tt.ToString("N0");
            }
            else
            {
                txtThanhtien.Text = "0";
            }
        }


        private void RecalculateTotalFromGrid()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dataGridViewHDBan.Rows)
            {
                if (row.IsNewRow) continue;
                if (decimal.TryParse(row.Cells["ThanhTien"].Value?.ToString(), out var v))
                    sum += v;
            }
            txtTongtien.Text = sum.ToString("N0");
            lblBangchu.Text = ConvertNumberToWords((long)sum);
        }
        #endregion

        #region Sự kiện ComboBox
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex < 0) return;
            txtTenNV.Text = ((DataRowView)cboMaNV.SelectedItem)["TenNV"].ToString();
        }
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaKH.SelectedIndex < 0) return;
            txtTenKH.Text = ((DataRowView)cboMaKH.SelectedItem)["TenKhach"].ToString();
        }
        private void cboMaQuanAo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaquanao.SelectedIndex < 0) return;
            txtTenquanao.Text = ((DataRowView)cboMaquanao.SelectedItem)["TenQuanAo"].ToString();
            // nếu muốn lấy giá bán từ Sanpham
            var drv = (DataRowView)cboMaquanao.SelectedItem;
            txtDongiaban.Text = string.Format("{0:N0}", drv["DonGiaBan"]);
            // thêm dòng chi tiết nếu có tồn tại
        }
        #endregion

        #region Các nút chức năng
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoHDBan.Text) == false)
            {
                if (MessageBox.Show("Dữ liệu chưa lưu, tạo mới?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            ResetForm();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            RecalculateTotalFromGrid();
            // validate header
            if (string.IsNullOrWhiteSpace(txtSoHDBan.Text))
            {
                MessageBox.Show("Số HĐ không được trống"); return;
            }
            if (!DateTime.TryParseExact(mskNgayban.Text, "dd/MM/yyyy", null,
               DateTimeStyles.None, out _))
            {
                MessageBox.Show("Ngày bán không hợp lệ"); return;
            }
            if (cboMaNV.SelectedIndex < 0) { MessageBox.Show("Chọn NV"); return; }
            if (cboMaKH.SelectedIndex < 0) { MessageBox.Show("Chọn KH"); return; }
            // header
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open(); var tran = conn.BeginTransaction();
                try
                {
                    var sqlH = "INSERT INTO tblHoaDonBan(SoHDB,MaNV,NgayBan,MaKhach,TongTien)" +
                             "VALUES(@so,@nv,@ng,@kh,@tong)";
                    using (var cmd = new SqlCommand(sqlH, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@so", txtSoHDBan.Text);
                        cmd.Parameters.AddWithValue("@nv", cboMaNV.SelectedValue);
                        cmd.Parameters.AddWithValue("@ng", DateTime.ParseExact(mskNgayban.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        cmd.Parameters.AddWithValue("@kh", cboMaKH.SelectedValue);
                        cmd.Parameters.AddWithValue("@tong", decimal.Parse(txtTongtien.Text));
                        cmd.ExecuteNonQuery();
                    }
                    // chi tiết
                    var sqlD = "INSERT INTO tblChiTietHDBan(SoHDB,MaQuanAo,SoLuong,DonGia,GiamGia,ThanhTien)" +
                             "VALUES(@so,@qa,@sl,@dg,@gg,@tt)";
                    foreach (DataGridViewRow row in dataGridViewHDBan.Rows)
                    {
                        if (row.IsNewRow) continue;
                        using (var cmd = new SqlCommand(sqlD, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@so", txtSoHDBan.Text);
                            cmd.Parameters.AddWithValue("@qa", row.Cells["MaQuanAo"].Value);
                            cmd.Parameters.AddWithValue("@sl", row.Cells["SoLuong"].Value);
                            cmd.Parameters.AddWithValue("@gg", row.Cells["GiamGia"].Value);
                            cmd.Parameters.AddWithValue("@tt", row.Cells["ThanhTien"].Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComboBoxes(); ResetForm();
                }
                catch (Exception ex) { tran.Rollback(); MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy bỏ thay đổi?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                ResetForm();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đóng form?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboSoHDBan.SelectedIndex < 0) { MessageBox.Show("Chọn số HĐ"); return; }
            var so = cboSoHDBan.SelectedValue.ToString();
            var dtH = GetData($"SELECT * FROM tblHoaDonBan WHERE SoHDB='{so}'");
            if (dtH.Rows.Count == 0) { MessageBox.Show("Không tìm thấy"); return; }
            var r = dtH.Rows[0];
            txtSoHDBan.Text = r["SoHDB"].ToString();
            mskNgayban.Text = Convert.ToDateTime(r["NgayBan"]).ToString("dd/MM/yyyy");
            cboMaNV.SelectedValue = r["MaNV"];
            cboMaKH.SelectedValue = r["MaKhach"];
            txtTongtien.Text = r["TongTien"].ToString();
            lblBangchu.Text = ConvertNumberToWords((long)Convert.ToDecimal(r["TongTien"]));
            // chi tiết
            var dtD = new DataTable();
            var sqlD = @"SELECT c.MaQuanAo, sp.TenQuanAo, c.SoLuong, sp.DonGiaBan, c.GiamGia, (sp.DonGiaBan * c.SoLuong * (1 - c.GiamGia)) AS ThanhTien" +
                      " FROM tblChiTietHDBan c LEFT JOIN tblSanpham sp on c.MaQuanAo=sp.MaQuanAo" +
                      " WHERE c.SoHDB=@so";
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sqlD, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@so", so);
                da.Fill(dtD);
            }
            dataGridViewHDBan.AutoGenerateColumns = true;
            dataGridViewHDBan.DataSource = dtD;
            RecalculateTotalFromGrid();
        }
        private void btnInHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In hóa đơn bán chưa triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        /// <summary>
        /// Load toàn bộ chi tiết hóa đơn bán lên grid
        /// </summary>
        private void LoadGridData()
        {
            var dt = new DataTable();
            var sql = @"
            SELECT
               c.SoHDB,
               c.MaQuanAo,
               sp.TenQuanAo,
               c.SoLuong,
               sp.DonGiaBan AS DonGia,
               c.GiamGia,
               (sp.DonGiaBan * c.SoLuong * (1 - c.GiamGia)) AS ThanhTien
               FROM tblChiTietHDBan c
               JOIN tblSanpham    sp ON c.MaQuanAo = sp.MaQuanAo";

            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            dataGridViewHDBan.AutoGenerateColumns = true;
            dataGridViewHDBan.DataSource = dt;
            RecalculateTotalFromGrid();
        }

    }
}
