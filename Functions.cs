using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace QuanLyCuaHang.Class
{
    class Functions
    {
        public static SqlConnection Con;
        public static string connstring;

        //Hàm  kết nối csdl
        public static void Connect()
        {
            connstring = @"Data Source=pc\SQLEXPRESS01;Initial Catalog=QuanLyCuaHang;Integrated Security=True;";

            Con = new SqlConnection(); //Cap phat doi tuong
            Con.ConnectionString = connstring; //Ket noi
            Con.Open(); //Mo ket noi
            MessageBox.Show("Kết nối  thành  công");
        }

        //trả về datatable chứa dữ liệu từ câu lệnh sql
        public static DataTable GetDataTable(String sql)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(); //SqlDataAdapter lấy dữ liệu từ database đổ vào datatable
            mydata.SelectCommand = new SqlCommand();
            mydata.SelectCommand.Connection = Class.Functions.Con;
            mydata.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            mydata.Fill(table);
            return table;
        }

        //Hàm check giá trị trùng lặp
        public static bool checkkey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.Con; //gắn kết nối
            cmd.CommandText = sql; //gắn câu lệnh sql
            try
            {
                cmd.ExecuteNonQuery(); //thực hiện câu lệnh sql
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;

            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }

        public static string getFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Functions.Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }


        public static void Disconnect()
        {
            if (Con != null && Con.State == ConnectionState.Open)
            {
                Con.Close(); // Đóng kết nối
                Con.Dispose(); // Giải phóng tài nguyên
                Con = null;
                MessageBox.Show("Đã ngắt kết nối CSDL");
            }

        }
    }
}
