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
using Quanlysanpham;

namespace NHÓM_13_LẬP_TRÌNH.NET
{
    public partial class frmDMKhachHang : Form
    {
        public frmDMKhachHang()
        {
            InitializeComponent();
        }
        private void frmDMKhachhang_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewKH.CellClick += new DataGridViewCellEventHandler(dataGridViewKH_CellClick);
                DAO.Connect();
                ///  MessageBox.Show("Ket noi thanh cong");
                ///  load dât to gridview
                LoadDataToGridview();
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message);
            }
        }
        private void LoadDataToGridview()
        {
            string sql = "select * from tblKhachhang";
            DataTable dt = new DataTable();
            dt = DAO.LoadDataToTable(sql);
            dataGridViewKH.DataSource = dt;
        }
        private void dataGridViewKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKH.Rows.Count > 0)
            {
                txtMakhachhang.Text = dataGridViewKH.CurrentRow.Cells[0].Value.ToString();
                txtTenkhachhang.Text = dataGridViewKH.CurrentRow.Cells[1].Value.ToString();
                txtDiachi.Text = dataGridViewKH.CurrentRow.Cells[2].Value.ToString();
                mskDienthoai.Text = dataGridViewKH.CurrentRow.Cells[3].Value.ToString();
                txtMakhachhang.Enabled = false;
            }
        }
        private void clear()
        {
            txtMakhachhang.Text = "";
            txtTenkhachhang.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            btnBoqua.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMakhachhang.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            if (txtMakhachhang.Text == "")
            {
                MessageBox.Show("Chọn dữ liệu cần xóa");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM tblKhachhang WHERE MaKH = N'" + txtMakhachhang.Text.Trim() + "'";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnBoqua.Enabled = true;
            if (txtMakhachhang.Text == "")
            {
                MessageBox.Show("Chọn dữ liệu cần sửa");
                return;
            }
            string sql = "UPDATE tblKhachhang SET " +
                 "TenKH = N'" + txtTenkhachhang.Text.Trim() + "', " +
                 "Diachi = N'" + txtDiachi.Text.Trim() + "', " +
                 "Dienthoai = '" + mskDienthoai.Text.Trim() + "' " +
                 "WHERE MaKH = N'" + txtMakhachhang.Text.Trim() + "'";

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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMakhachhang.Text == "")
            {
                MessageBox.Show("chua nhap ma");
            }
            // luu
            string sql = "INSERT INTO tblKhachhang  (MaKH, TenKH, Diachi, Dienthoai) " +
            "VALUES (N'" + txtMakhachhang.Text.Trim() + "', N'" + txtTenkhachhang.Text.Trim() + "', N'" +
            txtDiachi.Text.Trim() + "', N'" + mskDienthoai.Text.Trim() + "')";
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

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            clear();
            txtMakhachhang.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {        
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
        }
    }
}
