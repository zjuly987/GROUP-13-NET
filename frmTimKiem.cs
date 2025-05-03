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
    public partial class frmTimKiem : Form
    {
        DataTable tblSanPham;
        public frmTimKiem()
        {
            InitializeComponent();
        }
        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            ResetValues();
            dataGridViewFind.DataSource = null;

        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            cboMaquanao.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboMaquanao.Text == "")
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblSanPham WHERE 1=1";
            if (cboMaquanao.Text != "")
                sql = sql + " AND Maquanao Like N'%" + cboMaquanao.Text + "%'";
            tblSanPham = Functions.LoadDataToTable(sql);
            if (tblSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblSanPham.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridViewFind.DataSource = tblSanPham;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            dataGridViewFind.Columns[0].HeaderText = "Mã quần áo";
            dataGridViewFind.Columns[1].HeaderText = "Tên quần áo";
            dataGridViewFind.Columns[2].HeaderText = "Mã chất liệu";
            dataGridViewFind.Columns[3].HeaderText = "Mã loại";
            dataGridViewFind.Columns[4].HeaderText = "Mã cỡ";
            dataGridViewFind.Columns[5].HeaderText = "Mã màu";
            dataGridViewFind.Columns[6].HeaderText = "Mã đối tượng";
            dataGridViewFind.Columns[7].HeaderText = "Mã mùa";
            dataGridViewFind.Columns[9].HeaderText = "Mã nhà sản xuất";
            dataGridViewFind.Columns[10].HeaderText = "Số lượng";
            dataGridViewFind.Columns[11].HeaderText = "Đơn giá nhập";
            dataGridViewFind.Columns[12].HeaderText = "Đơn giá bán";
            dataGridViewFind.AllowUserToAddRows = false;
            dataGridViewFind.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}
