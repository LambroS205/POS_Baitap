using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace POS.UTIL
{
    public class DBConnection
    {
        // Hàm lấy chuỗi kết nối động
        public static string GetConnectionString()
        {
            // Lưu ý: Với Microsoft.Data.SqlClient, đôi khi cần thêm "TrustServerCertificate=True" nếu gặp lỗi SSL
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\POS.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            return connectionString;
        }

        // Hàm trả về đối tượng SqlConnection để các lớp khác sử dụng
        public static SqlConnection GetConnection()
        {
            // Xóa try-catch để tránh trả về null.
            // Việc khởi tạo SqlConnection ít khi lỗi, lỗi thường xảy ra khi Open().
            // Trả về trực tiếp giúp tránh lỗi NullReferenceException ở các lớp gọi (như UserRepo).
            string connString = GetConnectionString();
            return new SqlConnection(connString);
        }

        // Hàm kiểm tra kết nối
        public static bool CheckConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open(); // Thử mở kết nối. Nếu lỗi sẽ nhảy xuống catch.
                    return true;
                }
            }
            catch (Exception)
            {
                return false; // Nếu có lỗi thì trả về false
            }
        }
    }
}