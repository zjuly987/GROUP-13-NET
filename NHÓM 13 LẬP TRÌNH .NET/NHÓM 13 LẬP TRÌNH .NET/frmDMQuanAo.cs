using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NHÓM_13_LẬP_TRÌNH.NET
{
    public partial class frmDMQuanAo : Form
    {
        public frmDMQuanAo()
        {
            InitializeComponent();
        }

        private void frmDMQuanAo_Load(object sender, EventArgs e)
        {
            txtDongianhap.TextChanged += txtDongianhap_TextChanged;
            txtDongianhap.Leave += txtDongianhap_Leave;

            try
            {
                Functions.Connect();
                LoadComboBox();
                LoadDataToGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataToGridView()
        {
            string sql = "SELECT * FROM tblSanpham";
            dataGridViewSP.DataSource = Functions.LoadDataToTable(sql);
        }

        private void HienThiDanhSachSanPham()
        {
            string sql = "SELECT MaQuanAo, TenQuanAo FROM tblSanpham";
            SqlDataAdapter da = new SqlDataAdapter(sql, Functions.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSP.DataSource = dt;
        }

        private void bindComboBox(ComboBox cbo, string tableName, string valueField)
        {
            string sql = $"SELECT {valueField} FROM {tableName}";
            cbo.DataSource = Functions.layDuLieu(sql);
            cbo.ValueMember = valueField;
        }

        private void LoadComboBox()
        {
            bindComboBox(cboMachatlieu, "tblChatLieu", "MaChatLieu");
            bindComboBox(cboMaloai, "tblTheLoai", "MaLoai");
            bindComboBox(cboMaco, "tblCo", "MaCo");
            bindComboBox(cboMamau, "tblMau", "MaMau");
            bindComboBox(cboMadoituong, "tblDoiTuong", "MaDoiTuong");
            bindComboBox(cboMamua, "tblMua", "MaMua");
            bindComboBox(cboMaNSX, "tblNoiSanXuat", "MaNSX");
        }
        private void CapNhatDonGiaBan()
        {
            if (decimal.TryParse(txtDongianhap.Text.Trim(), out decimal donGiaNhap))
            {
                decimal donGiaBan = donGiaNhap * 1.1m;
                txtDongiaban.Text = donGiaBan.ToString("N0");
            }
            else txtDongiaban.Text = "";
        }

        private void txtDongianhap_TextChanged(object sender, EventArgs e)
        {
            CapNhatDonGiaBan();
        }

        private void txtDongianhap_Leave(object sender, EventArgs e)
        {
            CapNhatDonGiaBan();
        }

        private void dataGridViewSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (dataGridViewSP.Rows.Count == 0) return;
                DataGridViewRow row = dataGridViewSP.CurrentRow;
                txtMaquanao.Text = row.Cells[0].Value.ToString();
                txtTenquanao.Text = row.Cells[1].Value.ToString();
                cboMachatlieu.SelectedValue = row.Cells[2].Value.ToString();
                cboMaloai.SelectedValue = row.Cells[3].Value.ToString();
                cboMaco.SelectedValue = row.Cells[4].Value.ToString();
                cboMamau.SelectedValue = row.Cells[5].Value.ToString();
                cboMadoituong.SelectedValue = row.Cells[6].Value.ToString();
                cboMamua.SelectedValue = row.Cells[7].Value.ToString();
                cboMaNSX.SelectedValue = row.Cells[8].Value.ToString();
                txtSoluong.Text = row.Cells[9].Value.ToString();
                txtDongianhap.Text = row.Cells[10].Value.ToString();
                txtDongiaban.Text = row.Cells[11].Value.ToString();
                txtAnh.Text = row.Cells[12].Value.ToString();
                txtMaquanao.Enabled = false;         
        }

        private void ResetValues()
        {
            txtMaquanao.Text = "";
            txtTenquanao.Text = "";
            txtDongianhap.Text = "";
            txtDongiaban.Text = "";
            txtSoluong.Text = "";
            txtAnh.Text = "";
            cboMaloai.SelectedValue = -1;
            cboMachatlieu.SelectedValue = -1;
            cboMaco.SelectedValue = -1;
            cboMadoituong.SelectedValue = -1;
            cboMamau.SelectedValue = -1;
            cboMamua.SelectedValue = -1;
            cboMaNSX.SelectedValue = -1;
            picAnh.Image = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMaquanao.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaquanao.Text == "") { MessageBox.Show("Chọn dữ liệu cần xóa"); return; }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblSanpham WHERE MaQuanAo = @MaQuanAo";
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@MaQuanAo", txtMaquanao.Text.Trim());
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridView();
                    MessageBox.Show("Xóa thành công!");
                    ResetValues();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaquanao.Text == "") { MessageBox.Show("Chọn dữ liệu cần sửa"); return; }
            if (!int.TryParse(txtSoluong.Text.Trim(), out int soLuong)) 
            { MessageBox.Show("Số lượng không hợp lệ!"); return; }
            if (!decimal.TryParse(txtDongianhap.Text.Trim(), out decimal donGiaNhap)) { MessageBox.Show("Đơn giá nhập không hợp lệ!"); return; }

            decimal donGiaBan = donGiaNhap * 1.1m;

            string sql = @"UPDATE tblSanpham SET TenQuanAo=@TenQuanAo, SoLuong=@SoLuong, DonGiaNhap=@DonGiaNhap, DonGiaBan=@DonGiaBan,
                            MaChatLieu=@MaChatLieu, MaCo=@MaCo, MaDoiTuong=@MaDoiTuong, MaLoai=@MaLoai,
                            MaMau=@MaMau, MaMua=@MaMua, MaNSX=@MaNSX, Anh=@Anh WHERE MaQuanAo=@MaQuanAo";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@TenQuanAo", txtTenquanao.Text.Trim());
                cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                cmd.Parameters.AddWithValue("@DonGiaNhap", donGiaNhap);
                cmd.Parameters.AddWithValue("@DonGiaBan", donGiaBan);
                cmd.Parameters.AddWithValue("@MaChatLieu", cboMachatlieu.SelectedValue);
                cmd.Parameters.AddWithValue("@MaCo", cboMaco.SelectedValue);
                cmd.Parameters.AddWithValue("@MaDoiTuong", cboMadoituong.SelectedValue);
                cmd.Parameters.AddWithValue("@MaLoai", cboMaloai.SelectedValue);
                cmd.Parameters.AddWithValue("@MaMau", cboMamau.SelectedValue);
                cmd.Parameters.AddWithValue("@MaMua", cboMamua.SelectedValue);
                cmd.Parameters.AddWithValue("@MaNSX", cboMaNSX.SelectedValue);
                cmd.Parameters.AddWithValue("@Anh", txtAnh.Text.Trim());
                cmd.Parameters.AddWithValue("@MaQuanAo", txtMaquanao.Text.Trim());

                cmd.ExecuteNonQuery();
                LoadDataToGridView();
                MessageBox.Show("Sửa thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaquanao.Text == "") { MessageBox.Show("Chưa nhập mã"); return; }
            decimal.TryParse(txtDongianhap.Text.Trim(), out decimal donGiaNhap);
            decimal donGiaBan = donGiaNhap * 1.1m;

            string sql = @"INSERT INTO tblSanpham (Maquanao, Tenquanao, Soluong, Dongianhap, DonGiaBan, Machatlieu, Maco,
                            Madoituong, Maloai, Mamau, Mamua, MaNSX, Anh) VALUES
                            (@Maquanao, @Tenquanao, @Soluong, @Dongianhap, @DonGiaBan, @Machatlieu, @Maco,
                            @Madoituong, @Maloai, @Mamau, @Mamua, @MaNSX, @Anh)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, Functions.conn);
                cmd.Parameters.AddWithValue("@Maquanao", txtMaquanao.Text.Trim());
                cmd.Parameters.AddWithValue("@Tenquanao", txtTenquanao.Text.Trim());
                cmd.Parameters.AddWithValue("@Soluong", txtSoluong.Text.Trim());
                cmd.Parameters.AddWithValue("@Dongianhap", donGiaNhap);
                cmd.Parameters.AddWithValue("@DonGiaBan", donGiaBan);
                cmd.Parameters.AddWithValue("@Machatlieu", cboMachatlieu.SelectedValue);
                cmd.Parameters.AddWithValue("@Maco", cboMaco.SelectedValue);
                cmd.Parameters.AddWithValue("@Madoituong", cboMadoituong.SelectedValue);
                cmd.Parameters.AddWithValue("@Maloai", cboMaloai.SelectedValue);
                cmd.Parameters.AddWithValue("@Mamau", cboMamau.SelectedValue);
                cmd.Parameters.AddWithValue("@Mamua", cboMamua.SelectedValue);
                cmd.Parameters.AddWithValue("@MaNSX", cboMaNSX.SelectedValue);
                cmd.Parameters.AddWithValue("@Anh", txtAnh.Text.Trim());

                cmd.ExecuteNonQuery();
                LoadDataToGridView();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            ResetValues();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            txtMaquanao.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = false;
            LoadDataToGridView();
            picAnh.Image = null;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                // Hiển thị ảnh lên PictureBox
                picAnh.Image = Image.FromFile(filePath);
                picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                // Lưu đường dẫn vào textbox
                txtAnh.Text = filePath;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa cần tìm!", "Thông báo");
                return;
            }
            string sql = "SELECT * FROM tblSanpham WHERE Tenquanao LIKE N'%" + keyword + "%'";
            DataTable dt = Functions.LoadDataToTable(sql);
            dataGridViewSP.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.", "Kết quả tìm kiếm");
            }
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            try
            {
                Functions.Connect(); // đảm bảo đã kết nối
                HienThiDanhSachSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
        }
    }
}
