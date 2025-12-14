namespace POS.MODEL
{
    /// <summary>
    /// Model để lưu trữ thông tin Role (dùng cho ComboBox)
    /// </summary>
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}