using Microsoft.Data.SqlClient;
using POS.MODEL;
using POS.UTIL;

namespace POS.DAL
{
    public class SalesRepo
    {
        public int SaveInvoice(Invoice invoice, List<CartItem> cart)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string sqlInvoice = @"
                        INSERT INTO Invoices (InvoiceDate, UserId, CustomerName, TotalAmount, FinalAmount)
                        VALUES (@InvoiceDate, @UserId, @CustomerName, @TotalAmount, @FinalAmount);
                        SELECT SCOPE_IDENTITY();";

                    int invoiceId;
                    using (SqlCommand cmdInvoice = new SqlCommand(sqlInvoice, connection, transaction))
                    {
                        cmdInvoice.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate);
                        cmdInvoice.Parameters.AddWithValue("@UserId", invoice.UserId);
                        cmdInvoice.Parameters.AddWithValue("@CustomerName", (object)invoice.CustomerName ?? DBNull.Value);
                        cmdInvoice.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                        cmdInvoice.Parameters.AddWithValue("@FinalAmount", invoice.FinalAmount);

                        invoiceId = Convert.ToInt32(cmdInvoice.ExecuteScalar());
                    }

                    if (invoiceId <= 0) throw new Exception("Không thể tạo hóa đơn.");

                    string sqlDetail = @"
                        INSERT INTO InvoiceDetail (InvoiceId, ProductId, Quantity, UnitPrice, LineTotal)
                        VALUES (@InvoiceId, @ProductId, @Quantity, @UnitPrice, @LineTotal);";

                    using (SqlCommand cmdDetail = new SqlCommand(sqlDetail, connection, transaction))
                    {
                        foreach (var item in cart)
                        {
                            cmdDetail.Parameters.Clear();
                            cmdDetail.Parameters.AddWithValue("@InvoiceId", invoiceId);
                            cmdDetail.Parameters.AddWithValue("@ProductId", item.ProductId);
                            cmdDetail.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmdDetail.Parameters.AddWithValue("@UnitPrice", item.SellingPrice);
                            cmdDetail.Parameters.AddWithValue("@LineTotal", item.LineTotal);
                            cmdDetail.ExecuteNonQuery();
                        }
                    }

                    string sqlUpdateStock = @"
                        UPDATE Products SET Quantity = Quantity - @SoldQuantity
                        WHERE ProductId = @ProductId";

                    using (SqlCommand cmdUpdateStock = new SqlCommand(sqlUpdateStock, connection, transaction))
                    {
                        foreach (var item in cart)
                        {
                            cmdUpdateStock.Parameters.Clear();
                            cmdUpdateStock.Parameters.AddWithValue("@SoldQuantity", item.Quantity);
                            cmdUpdateStock.Parameters.AddWithValue("@ProductId", item.ProductId);
                            cmdUpdateStock.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return invoiceId;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // MỚI: Lấy danh sách hóa đơn (Lịch sử)
        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();
            // Kết hợp bảng Users để lấy tên nhân viên
            string sql = @"
                SELECT i.InvoiceId, i.InvoiceDate, i.UserId, u.FullName, i.CustomerName, i.TotalAmount, i.FinalAmount
                FROM Invoices i
                INNER JOIN Users u ON i.UserId = u.UserId
                ORDER BY i.InvoiceDate DESC";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                invoices.Add(new Invoice
                                {
                                    InvoiceId = reader.GetInt32(0),
                                    InvoiceDate = reader.GetDateTime(1),
                                    UserId = reader.GetInt32(2),
                                    StaffName = reader.GetString(3), // Lấy tên nhân viên
                                    CustomerName = reader.IsDBNull(4) ? "Khách lẻ" : reader.GetString(4),
                                    TotalAmount = reader.GetDecimal(5),
                                    FinalAmount = reader.GetDecimal(6)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi tải lịch sử hóa đơn: \n" + ex.Message);
                    }
                }
            }
            return invoices;
        }
    }
}