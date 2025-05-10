using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHÓM_13_LẬP_TRÌNH.NET
{
    public partial class frmDMQuanAo : Form
    {
        public frmDMQuanAo()
        {
            InitializeComponent();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            if (txtMaquanao.Text == "")
            {
                MessageBox.Show("Chọn dữ liệu cần xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblSanpham WHERE Maquanao = N'" + txtMaquanao.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, DAO.conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    LoadDataToGridview();
                    MessageBox.Show("Xóa thành công!");
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void frmDMHang_Load(object sender, EventArgs e)
        {
            dataGridViewSP.CellClick += new DataGridViewCellEventHandler(dataGridViewSP_CellClick);
            try
            {
                DAO.Connect();
                LoadDataToGridview();
                cboMachatlieu.Items.AddRange(new object[] { "37L", "18M", "65F" });
                cboMaco.Items.AddRange(new object[] { "M", "L", "XL" });
                cboMadoituong.Items.AddRange(new object[] { "2543F", "125K", "65P" });
                cboMaloai.Items.AddRange(new object[] { "25AP", "21AL", "22ASM" });
                cboMamau.Items.AddRange(new object[] { "Trắng", "Hồng", "Đen" });
                cboMamua.Items.AddRange(new object[] { "2025AP", "2021AL", "2025ASM" });
                cboMaNSX.Items.AddRange(new object[] { "25N", "19Uni", "25Uni" });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataToGridview()
        {
            string sql = "select * from tblSanpham ";
            DataTable dt = new DataTable();
            dt = DAO.LoadDataToTable(sql);
            dataGridViewSP.DataSource = dt;
        }

        private void dataGridViewSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSP.Rows.Count > 0)
            {
                txtMaquanao.Text = dataGridViewSP.CurrentRow.Cells[0].Value.ToString();
                txtTenquanao.Text = dataGridViewSP.CurrentRow.Cells[1].Value.ToString();
                cboMachatlieu.SelectedItem = dataGridViewSP.CurrentRow.Cells[2].Value.ToString();
                cboMaloai.SelectedItem = dataGridViewSP.CurrentRow.Cells[3].Value.ToString();
                cboMaco.SelectedItem = dataGridViewSP.CurrentRow.Cells[4].Value.ToString();
                cboMamau.SelectedItem = dataGridViewSP.CurrentRow.Cells[5].Value.ToString();
                cboMadoituong.SelectedItem = dataGridViewSP.CurrentRow.Cells[6].Value.ToString();
                cboMamua.SelectedItem = dataGridViewSP.CurrentRow.Cells[7].Value.ToString();
                cboMaNSX.SelectedItem = dataGridViewSP.CurrentRow.Cells[8].Value.ToString();
                txtSoluong.Text = dataGridViewSP.CurrentRow.Cells[9].Value.ToString();
                txtDongianhap.Text = dataGridViewSP.CurrentRow.Cells[10].Value.ToString();
                txtDongiaban.Text = dataGridViewSP.CurrentRow.Cells[11].Value.ToString();
                string imagePath = dataGridViewSP.CurrentRow.Cells[12].Value.ToString();
                txtMaquanao.Enabled = false;
            }
        }

        private void clear()
        {
            txtMaquanao.Text = "";
            txtTenquanao.Text = "";
            txtDongianhap.Text = "";
            txtDongiaban.Text = "";
            txtSoluong.Text = "";
            txtAnh.Text = "";
            cboMaloai.SelectedItem = -1;
            cboMachatlieu.SelectedItem = -1;
            cboMaco.SelectedItem = -1;
            cboMadoituong.SelectedItem = -1;
            cboMamau.SelectedItem = -1;
            cboMamua.SelectedItem = -1;
            cboMaNSX.SelectedItem = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            btnBoqua.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMaquanao.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // kiem tra dl
            if (txtMaquanao.Text == "")
            {
                MessageBox.Show("chua nhap ma");
            }
            // luu

            string sql = "INSERT INTO tblSanpham (Maquanao, Tenquanao, Soluong, Dongianhap, Dongiaban, Machatlieu, Maco, Madoituong, Maloai, Mamau, Mamua, MaNSX, Anh) " +
            "VALUES (N'" + txtMaquanao.Text.Trim() + "', N'" + txtTenquanao.Text.Trim() + "', N'" + txtSoluong.Text.Trim() +
            "', N'" + txtDongianhap.Text.Trim() + "', N'" + txtDongiaban.Text.Trim() +
            "', N'" + cboMachatlieu.SelectedItem + "', N'" + cboMaco.SelectedItem +
            "', N'" + cboMadoituong.SelectedItem + "', N'" + cboMaloai.SelectedItem +
            "', N'" + cboMamau.SelectedItem + "', N'" + cboMamua.SelectedItem +
            "', N'" + cboMaNSX.SelectedItem + "', N'" + txtAnh.Text.Trim() + "')";

            SqlCommand cmd = new SqlCommand(sql, DAO.conn);
            try
            {
                cmd.ExecuteNonQuery();
                LoadDataToGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clear();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            if (txtMaquanao.Text == "")
            {
                MessageBox.Show("Chọn dữ liệu cần sửa");
                return;
            }

            string sql = "UPDATE tblSanpham SET " +
                 "Tenquanao = N'" + txtTenquanao.Text.Trim() + "', " +
                 "Soluong = " + txtSoluong.Text.Trim() + ", " +
                 "Dongianhap = " + txtDongianhap.Text.Trim() + ", " +
                 "Dongiaban = " + txtDongiaban.Text.Trim() + ", " +
                 "Machatlieu = N'" + cboMachatlieu.SelectedItem + "', " +
                 "Maco = N'" + cboMaco.SelectedItem + "', " +
                 "Madoituong = N'" + cboMadoituong.SelectedItem + "', " +
                 "Maloai = N'" + cboMaloai.SelectedItem + "', " +
                 "Mamau = N'" + cboMamau.SelectedItem + "', " +
                 "Mamua = N'" + cboMamua.SelectedItem + "', " +
                 "MaNSX = N'" + cboMaNSX.SelectedItem + "', " +
                 "Anh = N'" + txtAnh.Text.Trim() + "' " +
                 "WHERE Maquanao = N'" + txtMaquanao.Text.Trim() + "'";

            DAO.Connect();
            SqlCommand cmd = new SqlCommand(sql, DAO.conn);

            try
            {
                cmd.ExecuteNonQuery();
                LoadDataToGridview();
                MessageBox.Show("Sửa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            clear();
            txtMaquanao.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = false;
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            LoadDataToGridview();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa cần tìm!", "Thông báo");
                return;
            }

            string sql = "SELECT * FROM tblSanpham WHERE Tenquanao LIKE N'%" + keyword + "%'";
            DataTable dt = DAO.LoadDataToTable(sql);
            dataGridViewSP.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.", "Kết quả tìm kiếm");
            }
        }
    }
}
