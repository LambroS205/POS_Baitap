using POS.DAL;
using POS.MODEL;
using POS.UTIL; // Thêm namespace UTIL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
    public class UserService
    {
        private UserRepo _userRepo;
        public UserService()
        {
            _userRepo = new UserRepo();
        }

        public User AuthenticatedUser(string username, string password)
        {
            User user = _userRepo.GetUserByUserName(username);

            if (user == null)
            {
                return null; // Không tồn tại người dùng            
            }

            // **CẬP NHẬT QUAN TRỌNG VỀ BẢO MẬT**
            // Không bao giờ so sánh mật khẩu trực tiếp.
            // Sử dụng PasswordHasher để xác minh.
            if (PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                return user; // Mật khẩu khớp
            }
            else
            {
                return null; // Mật khẩu sai
            }
        }

        // --- CÁC HÀM MỚI CHO QUẢN LÝ USER ---

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public List<Role> GetRoles()
        {
            return _userRepo.GetRoles();
        }

        public void AddUser(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new Exception("Tên đăng nhập không được để trống.");
            if (string.IsNullOrWhiteSpace(user.FullName))
                throw new Exception("Tên đầy đủ không được để trống.");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Mật khẩu không được để trống.");
            if (user.RoleId <= 0)
                throw new Exception("Vui lòng chọn vai trò.");

            // Băm mật khẩu
            string passwordHash = PasswordHasher.HashPassword(password);
            _userRepo.AddUser(user, passwordHash);
        }

        public void UpdateUser(User user, string? newPassword)
        {
            if (string.IsNullOrWhiteSpace(user.FullName))
                throw new Exception("Tên đầy đủ không được để trống.");
            if (user.RoleId <= 0)
                throw new Exception("Vui lòng chọn vai trò.");
            if (user.UserId <= 0)
                throw new Exception("ID người dùng không hợp lệ.");

            string? passwordHash = null;
            // Chỉ băm mật khẩu mới nếu nó được cung cấp (không trống)
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                passwordHash = PasswordHasher.HashPassword(newPassword);
            }

            _userRepo.UpdateUser(user, passwordHash);
        }

        public void DeleteUser(int userId, int currentUserId)
        {
            if (userId <= 0)
                throw new Exception("ID người dùng không hợp lệ.");
            // Ngăn người dùng tự xóa mình
            if (userId == currentUserId)
                throw new Exception("Không thể tự xóa tài khoản của chính mình.");
            // Ngăn xóa Admin (ví dụ: ID 1)
            if (userId == 1)
                throw new Exception("Không thể xóa tài khoản Quản trị cao nhất.");

            _userRepo.DeleteUser(userId);
        }
    }
}