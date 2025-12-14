namespace POS.UTIL
{
    /// <summary>
    /// Lớp tiện ích để băm và xác minh mật khẩu bằng BCrypt.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Tạo một chuỗi băm mật khẩu từ một mật khẩu rõ.
        /// </summary>
        /// <param name="password">Mật khẩu (chuỗi rõ).</param>
        /// <returns>Chuỗi băm mật khẩu.</returns>
        public static string HashPassword(string password)
        {
            // Tham số "work factor" (11) quyết định độ phức tạp của việc băm.
            // Giá trị càng cao, băm càng chậm và càng an toàn. 11 là một giá trị tốt.
            return BCrypt.Net.BCrypt.HashPassword(password, 11);
        }

        /// <summary>
        /// Xác minh một mật khẩu (chuỗi rõ) với một chuỗi băm đã có.
        /// </summary>
        /// <param name="password">Mật khẩu (chuỗi rõ) cần kiểm tra.</param>
        /// <param name="hashedPassword">Chuỗi băm mật khẩu lấy từ CSDL.</param>
        /// <returns>True nếu mật khẩu khớp, ngược lại False.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu chuỗi băm không hợp lệ
                return false;
            }
        }
    }
}