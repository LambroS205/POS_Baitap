using POS.BLL;
using POS.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class LoginForm : Form
    {
        UserService _userService;
        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();

            // Chấp nhận nút Enter
            this.AcceptButton = cmdLogin;
            // Chấp nhận nút Escape
            this.CancelButton = cmdCancel;
            // Dùng PasswordChar
            txtPassword.PasswordChar = '•';
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát hoàn toàn ứng dụng
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên truy cập không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            try
            {
                User authenticatedUser = _userService.AuthenticatedUser(username, password);
                if (authenticatedUser != null)
                {
                    MessageBox.Show("Chào mừng " + authenticatedUser.FullName + "! Đăng nhập thành công.", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // **THAY ĐỔI**
                    // Mở MainForm và truyền thông tin người dùng vào
                    MainForm mainForm = new MainForm(authenticatedUser);
                    mainForm.Show(); // Hiển thị form chính
                    this.Hide(); // Ẩn form đăng nhập
                }
                else
                {
                    MessageBox.Show("Tên truy cập hoặc mật khẩu không đúng.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chi tiết hơn (ví dụ: không kết nối được CSDL)
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}