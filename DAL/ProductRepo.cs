using Microsoft.Data.SqlClient;
using POS.MODEL;
using POS.UTIL;
using System.Data;

namespace POS.DAL
{
    public class ProductRepo
    {
        // --- ĐÃ XÓA GetCategories() ---
        // (Vì đã có trong CategoryRepo.cs, không nên lặp lại)

        // Lấy tất cả sản phẩm (kèm tên danh mục)
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            string sql = @"
                SELECT p.ProductId, p.ProductName, p.CategoryId, c.CategoryName, 
                       p.Quantity, p.CostPrice, p.SellingPrice, p.Unit
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                ORDER BY p.ProductName";

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
                                products.Add(new Product
                                {
                                    ProductId = reader.GetInt32(0),
                                    ProductName = reader.GetString(1),
                                    CategoryId = reader.GetInt32(2),
                                    CategoryName = reader.GetString(3),
                                    Quantity = reader.GetInt32(4),
                                    CostPrice = reader.GetDecimal(5),
                                    SellingPrice = reader.GetDecimal(6),
                                    Unit = reader.IsDBNull(7) ? string.Empty : reader.GetString(7)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi tải danh sách sản phẩm: \n" + ex.Message);
                    }
                }
            }
            return products;
        }

        // Lấy sản phẩm theo ID (để kiểm tra tồn kho khi bán)
        public Product GetProductById(int productId)
        {
            Product? product = null;
            string sql = @"
                SELECT p.ProductId, p.ProductName, p.CategoryId, c.CategoryName, 
                       p.Quantity, p.CostPrice, p.SellingPrice, p.Unit
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                WHERE p.ProductId = @ProductId";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product = new Product
                                {
                                    ProductId = reader.GetInt32(0),
                                    ProductName = reader.GetString(1),
                                    CategoryId = reader.GetInt32(2),
                                    CategoryName = reader.GetString(3),
                                    Quantity = reader.GetInt32(4),
                                    CostPrice = reader.GetDecimal(5),
                                    SellingPrice = reader.GetDecimal(6),
                                    Unit = reader.IsDBNull(7) ? string.Empty : reader.GetString(7)
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi tải sản phẩm: \n" + ex.Message);
                    }
                }
            }
            return product;
        }

        // Lấy sản phẩm để bán hàng (để tìm kiếm trên màn hình POS)
        public List<Product> GetProductsForSale(string searchTerm)
        {
            List<Product> products = new List<Product>();
            string sql = @"
                SELECT ProductId, ProductName, SellingPrice, Quantity, Unit
                FROM Products
                WHERE (ProductName LIKE @SearchTerm OR CAST(ProductId AS NVARCHAR(100)) = @ExactTerm)
                  AND Quantity > 0
                ORDER BY ProductName";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    command.Parameters.AddWithValue("@ExactTerm", searchTerm);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductId = reader.GetInt32(0),
                                    ProductName = reader.GetString(1),
                                    SellingPrice = reader.GetDecimal(2),
                                    Quantity = reader.GetInt32(3),
                                    Unit = reader.IsDBNull(4) ? string.Empty : reader.GetString(4)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi tìm sản phẩm: \n" + ex.Message);
                    }
                }
            }
            return products;
        }

        // MỚI: Thêm phương thức AddProduct (đã bị thiếu)
        public void AddProduct(Product product)
        {
            string sql = @"
                INSERT INTO Products (ProductName, CategoryId, Quantity, CostPrice, SellingPrice, Unit)
                VALUES (@ProductName, @CategoryId, @Quantity, @CostPrice, @SellingPrice, @Unit)";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.Parameters.AddWithValue("@CostPrice", product.CostPrice);
                    command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                    // Xử lý Unit nếu null
                    command.Parameters.AddWithValue("@Unit", (object)product.Unit ?? DBNull.Value);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thêm sản phẩm: \n" + ex.Message);
                    }
                }
            }
        }

        // SỬA: Đổi tên từ AddProduct thành UpdateProduct (logic bên trong đã đúng)
        public void UpdateProduct(Product product)
        {
            string sql = @"
                UPDATE Products
                SET ProductName = @ProductName,
                    CategoryId = @CategoryId,
                    Quantity = @Quantity,
                    CostPrice = @CostPrice,
                    SellingPrice = @SellingPrice,
                    Unit = @Unit
                WHERE ProductId = @ProductId";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.Parameters.AddWithValue("@CostPrice", product.CostPrice);
                    command.Parameters.AddWithValue("@SellingPrice", product.SellingPrice);
                    command.Parameters.AddWithValue("@Unit", (object)product.Unit ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi cập nhật sản phẩm: \n" + ex.Message);
                    }
                }
            }
        }

        // SỬA: Sửa lại hoàn toàn phương thức DeleteProduct (bị lỗi nặng)
        public void DeleteProduct(int productId)
        {
            string sql = "DELETE FROM Products WHERE ProductId = @ProductId";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547) // Lỗi khóa ngoại
                        {
                            throw new Exception("Không thể xóa sản phẩm này vì đã có trong hóa đơn.");
                        }
                        throw new Exception("Lỗi SQL khi xóa sản phẩm: \n" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi xóa sản phẩm: \n" + ex.Message);
                    }
                }
            }
        }
    }
}