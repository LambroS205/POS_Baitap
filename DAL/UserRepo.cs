using Microsoft.Data.SqlClient;
using POS.MODEL;
using POS.UTIL;

namespace POS.DAL
{
    public class UserRepo
    {
        public User? GetUserByUserName(string username)
        {
            User? user = null;
            // Câu lệnh SQL này phải khớp với các cột trong CSDL của bạn
            string sql = @"
                SELECT u.UserID, u.Username, u.PasswordHash, u.FullName, u.RoleId, r.RoleName 
                FROM Users u 
                INNER JOIN Roles r ON u.RoleId = r.RoleId 
                WHERE u.Username = @Username";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserId = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    PasswordHash = reader.GetString(2),
                                    FullName = reader.GetString(3),
                                    RoleId = reader.GetInt32(4),
                                    RoleName = reader.GetString(5),
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Lỗi này rất quan trọng, nó sẽ cho bạn biết CSDL có kết nối được không
                        throw new Exception("Lỗi truy vấn người dùng (UserRepo): \n" + ex.Message);
                    }
                }
            }
            // Nếu user == null, tức là không tìm thấy username
            return user;
        }

        // --- CÁC HÀM MỚI CHO QUẢN LÝ USER ---

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string sql = @"
                SELECT u.UserID, u.Username, u.PasswordHash, u.FullName, u.RoleId, r.RoleName 
                FROM Users u 
                INNER JOIN Roles r ON u.RoleId = r.RoleId 
                ORDER BY u.FullName";

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
                                users.Add(new User
                                {
                                    UserId = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    PasswordHash = reader.GetString(2),
                                    FullName = reader.GetString(3),
                                    RoleId = reader.GetInt32(4),
                                    RoleName = reader.GetString(5),
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi tải danh sách người dùng: \n" + ex.Message);
                    }
                }
            }
            return users;
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            string sql = "SELECT RoleId, RoleName FROM Roles ORDER BY RoleName";
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
                                roles.Add(new Role
                                {
                                    RoleId = reader.GetInt32(0),
                                    RoleName = reader.GetString(1)
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi tải danh sách vai trò: \n" + ex.Message);
                    }
                }
            }
            return roles;
        }

        public void AddUser(User user, string passwordHash)
        {
            string sql = @"
                INSERT INTO Users (Username, PasswordHash, FullName, RoleId) 
                VALUES (@Username, @PasswordHash, @FullName, @RoleId)";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627 || ex.Number == 2601) // Lỗi trùng username
                        {
                            throw new Exception($"Tên đăng nhập '{user.Username}' đã tồn tại.");
                        }
                        throw new Exception("Lỗi SQL khi thêm người dùng: \n" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thêm người dùng: \n" + ex.Message);
                    }
                }
            }
        }

        public void UpdateUser(User user, string? newPasswordHash)
        {
            // Nếu newPasswordHash là null, chỉ cập nhật thông tin
            // Nếu có, cập nhật cả mật khẩu
            string sql = newPasswordHash != null
                ? @"UPDATE Users SET FullName = @FullName, RoleId = @RoleId, PasswordHash = @PasswordHash
                    WHERE UserId = @UserId"
                : @"UPDATE Users SET FullName = @FullName, RoleId = @RoleId 
                    WHERE UserId = @UserId";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@RoleId", user.RoleId);
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    if (newPasswordHash != null)
                    {
                        command.Parameters.AddWithValue("@PasswordHash", newPasswordHash);
                    }

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi cập nhật người dùng: \n" + ex.Message);
                    }
                }
            }
        }

        public void DeleteUser(int userId)
        {
            string sql = "DELETE FROM Users WHERE UserId = @UserId";
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547) // Lỗi khóa ngoại (FK)
                        {
                            throw new Exception("Không thể xóa người dùng này vì đã tạo hóa đơn.");
                        }
                        throw new Exception("Lỗi SQL khi xóa người dùng: \n" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi xóa người dùng: \n" + ex.Message);
                    }
                }
            }
        }
    }
}