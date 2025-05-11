using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHÓM_13_LẬP_TRÌNH.NET
{
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }


        private void frmDMNhaCungCap_Load(object sender, EventArgs e)
        {
            QuanLyCuaHang.Class.Functions.Connect();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=pc\SQLEXPRESS01;Initial Catalog=QuanLyCuaHang;Integrated Security=True;";
            con.Open();
            string sql = "Select * from tblNhaCungCap";
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(ds);
            dgvNhaCungCap.DataSource = ds.Tables[0];
            dgvNhaCungCap.Refresh();
            con.Close();



        }
        private void dataGridViewNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow != null)
            {
                txtMancc.Text = dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value.ToString();
                txtTenncc.Text = dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value.ToString();
                txtDiachi.Text = dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value.ToString();
                mskDienthoai.Text = dgvNhaCungCap.CurrentRow.Cells["DienThoai"].Value.ToString();
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNCC = txtMancc.Text.Trim();
            string tenNCC = txtTenncc.Text.Trim();
            string diaChi = txtDiachi.Text.Trim();
            string dienThoai = mskDienthoai.Text.Trim();

            // Kiểm tra thông tin bắt buộc
            if (maNCC == "" || tenNCC == "" || diaChi == "" || dienThoai == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!KiemTraSoDienThoai(dienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }

            // Kiểm tra trùng Mã nhà cung cấp và Số điện thoại
            foreach (DataGridViewRow row in dgvNhaCungCap.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["MaNCC"].Value != null && row.Cells["MaNCC"].Value.ToString().Equals(maNCC, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMancc.Focus();
                    return;
                }

                if (row.Cells["DienThoai"].Value != null && row.Cells["DienThoai"].Value.ToString() == dienThoai)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mskDienthoai.Focus();
                    return;
                }
            }

            // Thêm vào DataGridView nếu hợp lệ
            dgvNhaCungCap.Rows.Add(maNCC, tenNCC, diaChi, dienThoai);

            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa các trường nhập
            txtMancc.Clear();
            txtTenncc.Clear();
            txtDiachi.Clear();
            mskDienthoai.Clear();
            txtMancc.Focus();
        }

        // Hàm kiểm tra định dạng số điện thoại
        private bool KiemTraSoDienThoai(string soDienThoai)
        {
            // Cho phép dạng: (028)xxxxxxx hoặc 0xxxxxxxxx
            string pattern = @"^(\(0\d{2,3}\)\d{6,7}|0\d{9})$";
            return Regex.IsMatch(soDienThoai, pattern);
        }




        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvNhaCungCap.Rows.RemoveAt(dgvNhaCungCap.CurrentRow.Index);
                    MessageBox.Show("Đã xóa nhà cung cấp.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa.");
            }


        }
     
         
            

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.CurrentRow != null)
            {
                DataGridViewRow row = dgvNhaCungCap.CurrentRow;

                row.Cells["MaNCC"].Value = txtMancc.Text.Trim();
                row.Cells["TenNCC"].Value = txtTenncc.Text.Trim();
                row.Cells["DiaChi"].Value = txtDiachi.Text.Trim();
                row.Cells["DienThoai"].Value = mskDienthoai.Text.Trim();

                MessageBox.Show("Đã cập nhật thông tin nhà cung cấp.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMancc.Text.Trim();
            string ten = txtTenncc.Text.Trim();
            string diachi = txtDiachi.Text.Trim();
            string sdt = mskDienthoai.Text.Trim();

           

           
            DataTable dt = (DataTable)dgvNhaCungCap.DataSource;
            dt.Rows.Add(ma, ten, diachi, sdt);

            MessageBox.Show("Lưu thành công!");

            // Reset lại TextBox
            txtMancc.Text = "";
            txtTenncc.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";

            // Vô hiệu hoá TextBox và nút
            txtMancc.Enabled = false;
            txtTenncc.Enabled = false;
            txtDiachi.Enabled = false;
            mskDienthoai.Enabled = false;

            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu
            txtMancc.Text = "";
            txtTenncc.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";

            // Vô hiệu hóa các TextBox sau khi bỏ qua
            txtMancc.Enabled = false;
            txtTenncc.Enabled = false;
            txtDiachi.Enabled = false;
            mskDienthoai.Enabled = false;

            // Tắt các nút liên quan đến thao tác thêm mới
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;

            MessageBox.Show("Đã hủy thao tác thêm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    
