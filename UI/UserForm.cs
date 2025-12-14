using POS.BLL;
using POS.MODEL;

namespace POS.UI
{
    public partial class UserForm : Form
    {
        private readonly UserService _userService;
        private readonly User _currentUser; // Người dùng đang đăng nhập (để check quyền)
        private List<User> _userList;
        private User? _selectedUser;

        // Cần truyền User hiện tại vào để biết ai đang thao tác
        public UserForm(User currentUser)
        {
            InitializeComponent();
            _userService = new UserService();
            _currentUser = currentUser;
            _userList = new List<User>();
            _selectedUser = null;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadUserGrid();
            ClearForm();
        }

        private void LoadRoles()
        {
            try
            {
                List<Role> roles = _userService.GetRoles();
                cboRole.DataSource = roles;
                cboRole.DisplayMember = "RoleName";
                cboRole.ValueMember = "RoleId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserGrid()
        {
            try
            {
                _userList = _userService.GetAllUsers();
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _userList;
                SetupGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGridViewColumns()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear(); // Xóa cột cũ nếu có

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UserId",
                DataPropertyName = "UserId",
                HeaderText = "ID",
                Width = 60
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                DataPropertyName = "Username",
                HeaderText = "Tên đăng nhập",
                Width = 150
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                DataPropertyName = "FullName",
                HeaderText = "Họ và Tên",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoleName",
                DataPropertyName = "RoleName",
                HeaderText = "Vai trò",
                Width = 120
            });

            // Ẩn cột PasswordHash (không bao giờ hiển thị)
            // Nếu bạn thêm nó vào Select, hãy ẩn nó đi
        }

        private void ClearForm()
        {
            _selectedUser = null;
            txtUsername.Clear();
            txtFullName.Clear();
            txtPassword.Clear();
            if (cboRole.Items.Count > 0)
            {
                cboRole.SelectedIndex = 0;
            }
            txtUsername.Enabled = true; // Cho phép nhập khi thêm mới
            btnSave.Text = "Lưu (Thêm)";
            btnDelete.Enabled = false;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _userList.Count)
            {
                _selectedUser = _userList[e.RowIndex];

                if (_selectedUser != null)
                {
                    txtUsername.Text = _selectedUser.Username;
                    txtFullName.Text = _selectedUser.FullName;
                    cboRole.SelectedValue = _selectedUser.RoleId;

                    txtUsername.Enabled = false; // Không cho sửa tên đăng nhập
                    txtPassword.Clear(); // Xóa mật khẩu cũ
                    btnSave.Text = "Lưu (Sửa)";
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string password = txtPassword.Text.Trim();
                int roleId = (int)cboRole.SelectedValue;

                if (_selectedUser == null) // Thêm mới
                {
                    User newUser = new User
                    {
                        Username = username,
                        FullName = fullName,
                        RoleId = roleId
                    };
                    _userService.AddUser(newUser, password); // BLL sẽ kiểm tra và băm MK
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Cập nhật
                {
                    _selectedUser.FullName = fullName;
                    _selectedUser.RoleId = roleId;

                    // BLL sẽ kiểm tra xem password có rỗng hay không
                    _userService.UpdateUser(_selectedUser, password);
                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadUserGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng '{_selectedUser.Username}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Truyền ID của người đang đăng nhập để kiểm tra
                    _userService.DeleteUser(_selectedUser.UserId, _currentUser.UserId);
                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserGrid();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}