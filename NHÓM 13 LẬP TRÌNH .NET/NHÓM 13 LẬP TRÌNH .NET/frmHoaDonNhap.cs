using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDNhap
{
    public partial class frmHoaDonNhap: Form
    {
        public frmHoaDonNhap()
        {
            InitializeComponent();
            ConnectToDatabase();
        }
        private void ConnectToDatabase()
        {
            string connectionString = @"Server=LAPTOP-UKHEH49R;Database=qlyquanao;User Id=sa;Password=maihien271104;";  // Đảm bảo bạn đã khai báo chính xác thông tin kết nối

            try
            {
                // Tạo đối tượng kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối đến cơ sở dữ liệu

                    // Thực thi truy vấn SQL
                    string query = "SELECT * FROM tblHoaDonNhap"; // Thay đổi "tblHoaDonNhap" với tên bảng trong cơ sở dữ liệu của bạn
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Đọc dữ liệu từ cơ sở dữ liệu
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable); // Lấy kết quả truy vấn và lưu vào DataTable

                    // Gán dữ liệu vào DataGridView
                    dataGridViewHDNhap.DataSource = dataTable; // Cập nhật dữ liệu vào DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message); // Hiển thị thông báo lỗi nếu có vấn đề kết nối
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Server=LAPTOP-UKHEH49R;Database=qlyquanao;User Id=sa;Password=maihien271104;";

                // Kiểm tra xem người dùng đã nhập đầy đủ dữ liệu chưa
                if (string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtTongtien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                // Câu lệnh SQL để thêm dữ liệu
                string query = "INSERT INTO tblHoaDonNhap (TenNV, TenNCC, TongTien) VALUES (@TenNV, @TenNCC, @TongTien)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                    cmd.Parameters.AddWithValue("@TongTien", decimal.Parse(txtTongtien.Text));

                    connection.Open();
                    cmd.ExecuteNonQuery(); // Thực thi câu lệnh INSERT

                    MessageBox.Show("Dữ liệu đã được thêm thành công.");
                }

                // Làm mới lại DataGridView để hiển thị dữ liệu mới
                ConnectToDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập đầy đủ dữ liệu chưa
                if (string.IsNullOrEmpty(txtSoHDNhap.Text) || string.IsNullOrEmpty(txtTenNV.Text) ||
                    string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtTongtien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                // Câu lệnh SQL để lưu dữ liệu vào cơ sở dữ liệu
                string query = "INSERT INTO tblHoaDonNhap (SoHDNhap, TenNV, TenNCC, TongTien, NgayNhap) " +
                               "VALUES (@SoHDNhap, @TenNV, @TenNCC, @TongTien, @NgayNhap)";

                // Chuỗi kết nối đến cơ sở dữ liệu
                string connectionString = @"Server=LAPTOP-UKHEH49R;Database=qlyquanao;User Id=sa;Password=maihien271104;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@SoHDNhap", txtSoHDNhap.Text);  // Thêm số hóa đơn nhập
                    cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);        // Thêm tên nhân viên
                    cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);      // Thêm tên nhà cung cấp
                    cmd.Parameters.AddWithValue("@TongTien", decimal.Parse(txtTongtien.Text));  // Thêm tổng tiền
                    cmd.Parameters.AddWithValue("@NgayNhap", DateTime.Parse(txtNgaynhap.Text));  // Thêm ngày nhập

                    // Mở kết nối đến cơ sở dữ liệu
                    connection.Open();

                    // Thực thi câu lệnh SQL
                    cmd.ExecuteNonQuery();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Hóa đơn đã được lưu thành công.");

                    // Làm mới lại DataGridView để hiển thị dữ liệu mới
                    ConnectToDatabase();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có vấn đề trong quá trình lưu dữ liệu
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa các dữ liệu trong các TextBox để người dùng có thể nhập lại
                txtSoHDNhap.Clear();   // Xóa số hóa đơn nhập
                txtTenNV.Clear();      // Xóa tên nhân viên
                txtTenNCC.Clear();     // Xóa tên nhà cung cấp
                txtTongtien.Clear();   // Xóa tổng tiền
                txtNgaynhap.Clear();   // Xóa ngày nhập

                // Có thể reset các ComboBox hoặc DateTimePicker nếu có
                cboMaNV.SelectedIndex = -1; // Reset ComboBox Mã nhân viên
                cboMaNCC.SelectedIndex = -1; // Reset ComboBox Mã nhà cung cấp
                cboMaquanao.SelectedIndex = -1; // Reset ComboBox Mã quần áo

                // Hiển thị thông báo xác nhận đã hủy dữ liệu
                MessageBox.Show("Dữ liệu đã được hủy và form đã trở về trạng thái ban đầu.");
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, thông báo lỗi
                MessageBox.Show("Lỗi khi hủy dữ liệu: " + ex.Message);
            }
        }
        private void btnInHD_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào đã đầy đủ chưa
                if (string.IsNullOrEmpty(txtSoHDNhap.Text) || string.IsNullOrEmpty(txtTenNV.Text) ||
                    string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtTongtien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi in.");
                    return;
                }

                // Khởi tạo đối tượng PrintDocument
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);  // Xử lý sự kiện khi in
                printDoc.Print();  // Gọi phương thức in

                MessageBox.Show("Hóa đơn đã được gửi để in.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message);
            }
        }

        // Phương thức xử lý in hóa đơn
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Lấy thông tin cần in từ các TextBox
            string soHD = txtSoHDNhap.Text;
            string tenNV = txtTenNV.Text;
            string tenNCC = txtTenNCC.Text;
            string tongTien = txtTongtien.Text;
            string ngayNhap = txtNgaynhap.Text; // Nếu có trường Ngày nhập, bạn lấy từ TextBox

            // Cấu trúc dữ liệu để in hóa đơn
            string invoiceDetails = $"Hóa Đơn Nhập\n\n" +
                                    $"Số Hóa Đơn: {soHD}\n" +
                                    $"Nhân Viên: {tenNV}\n" +
                                    $"Nhà Cung Cấp: {tenNCC}\n" +
                                    $"Tổng Tiền: {tongTien}\n" +
                                    $"Ngày Nhập: {ngayNhap}\n\n" +
                                    $"Cảm ơn bạn đã sử dụng dịch vụ!";

            // Thiết lập font và vị trí in trên trang
            Font font = new Font("Arial", 12);
            e.Graphics.DrawString(invoiceDetails, font, Brushes.Black, 100, 100);  // Vị trí và màu sắc
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo yêu cầu người dùng xác nhận
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn đóng không?", "Xác nhận đóng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra lựa chọn của người dùng
            if (dialogResult == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, đóng form
                this.Close();
            }
            else
            {
                // Nếu người dùng chọn No, không làm gì và giữ lại cửa sổ
                // Form sẽ không bị đóng
                MessageBox.Show("Hành động đã bị hủy. Cửa sổ vẫn mở.");
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập số hóa đơn hoặc từ khóa tìm kiếm chưa
                if (string.IsNullOrEmpty(txtSoHDNhap.Text) && string.IsNullOrEmpty(cboSoHDNhap.Text))
                {
                    MessageBox.Show("Vui lòng nhập số hóa đơn hoặc từ khóa tìm kiếm.");
                    return;
                }

                // Xây dựng câu lệnh SQL tìm kiếm dựa trên số hóa đơn hoặc từ khóa tìm kiếm
                string query = "SELECT * FROM tblHoaDonNhap WHERE ";

                // Nếu người dùng nhập số hóa đơn, tìm kiếm theo số hóa đơn
                if (!string.IsNullOrEmpty(txtSoHDNhap.Text))
                {
                    query += "SoHDNhap = @SoHDNhap";
                }

                // Nếu người dùng nhập từ khóa tìm kiếm, tìm kiếm theo từ khóa
                if (!string.IsNullOrEmpty(cboSoHDNhap.Text))
                {
                    if (!string.IsNullOrEmpty(txtSoHDNhap.Text)) // Nếu đã có điều kiện tìm theo số hóa đơn
                    {
                        query += " OR ";  // Sử dụng OR để kết hợp 2 điều kiện
                    }
                    query += "TenNV LIKE @Timkiem OR TenNCC LIKE @Timkiem"; // Tìm theo tên nhân viên hoặc tên nhà cung cấp
                }

                // Chuỗi kết nối đến cơ sở dữ liệu
                string connectionString = @"Server=LAPTOP-UKHEH49R;Database=qlyquanao;User Id=sa;Password=maihien271104;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);

                    // Thêm tham số vào câu lệnh SQL
                    if (!string.IsNullOrEmpty(txtSoHDNhap.Text))
                    {
                        cmd.Parameters.AddWithValue("@SoHDNhap", txtSoHDNhap.Text);  // Tìm kiếm theo số hóa đơn
                    }
                    if (!string.IsNullOrEmpty(cboSoHDNhap.Text))
                    {
                        cmd.Parameters.AddWithValue("@Timkiem", "%" + cboSoHDNhap.Text + "%");  // Tìm kiếm theo từ khóa (LIKE)
                    }

                    // Mở kết nối và thực thi câu lệnh tìm kiếm
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Nếu có kết quả tìm thấy, hiển thị vào DataGridView
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridViewHDNhap.DataSource = dataTable;  // Hiển thị kết quả vào DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có vấn đề xảy ra
                MessageBox.Show("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
        }




    }
}
