using Microsoft.Data.SqlClient;
using POS.MODEL;
using POS.UTIL;

namespace POS.DAL
{
    public class ReportRepo
    {
        /// <summary>
        /// Lấy báo cáo tổng thể (Admin/Manager)
        /// </summary>
        public List<SalesReport> GetOverallReport(DateTime startDate, DateTime endDate)
        {
            List<SalesReport> report = new List<SalesReport>();
            string sql = @"
                SELECT i.InvoiceId, i.InvoiceDate, u.FullName, i.CustomerName, i.FinalAmount
                FROM Invoices i
                JOIN Users u ON i.UserId = u.UserId
                WHERE i.InvoiceDate BETWEEN @StartDate AND @EndDate
                ORDER BY i.InvoiceDate DESC";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                report.Add(new SalesReport
                                {
                                    InvoiceId = reader.GetInt32(0),
                                    InvoiceDate = reader.GetDateTime(1),
                                    StaffName = reader.GetString(2),
                                    CustomerName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                    FinalAmount = reader.GetDecimal(4)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi truy vấn báo cáo tổng thể: \n" + ex.Message);
                    }
                }
            }
            return report;
        }

        /// <summary>
        /// Lấy báo cáo cá nhân (Staff)
        /// </summary>
        public List<SalesReport> GetStaffReport(DateTime startDate, DateTime endDate, int userId)
        {
            List<SalesReport> report = new List<SalesReport>();
            string sql = @"
                SELECT i.InvoiceId, i.InvoiceDate, u.FullName, i.CustomerName, i.FinalAmount
                FROM Invoices i
                JOIN Users u ON i.UserId = u.UserId
                WHERE i.InvoiceDate BETWEEN @StartDate AND @EndDate
                  AND i.UserId = @UserId
                ORDER BY i.InvoiceDate DESC";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    command.Parameters.AddWithValue("@UserId", userId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                report.Add(new SalesReport
                                {
                                    InvoiceId = reader.GetInt32(0),
                                    InvoiceDate = reader.GetDateTime(1),
                                    StaffName = reader.GetString(2),
                                    CustomerName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                    FinalAmount = reader.GetDecimal(4)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi truy vấn báo cáo cá nhân: \n" + ex.Message);
                    }
                }
            }
            return report;
        }
    }
}