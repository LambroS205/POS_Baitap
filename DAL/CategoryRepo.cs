using Microsoft.Data.SqlClient;
using POS.MODEL;
using POS.UTIL;

namespace POS.DAL
{
    public class CategoryRepo
    {
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string sql = "SELECT CategoryId, CategoryName FROM Categories ORDER BY CategoryName";

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
                                categories.Add(new Category
                                {
                                    CategoryId = reader.GetInt32(0),
                                    CategoryName = reader.GetString(1)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi tải danh mục: \n" + ex.Message);
                    }
                }
            }
            return categories;
        }

        public void AddCategory(Category category)
        {
            string sql = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thêm danh mục: \n" + ex.Message);
                    }
                }
            }
        }

        public void UpdateCategory(Category category)
        {
            string sql = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi cập nhật danh mục: \n" + ex.Message);
                    }
                }
            }
        }

        public void DeleteCategory(int categoryId)
        {
            string sql = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547) // Lỗi khóa ngoại (FK)
                        {
                            throw new Exception("Không thể xóa danh mục này vì đang có sản phẩm thuộc danh mục.");
                        }
                        throw new Exception("Lỗi SQL khi xóa danh mục: \n" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi xóa danh mục: \n" + ex.Message);
                    }
                }
            }
        }
    }
}