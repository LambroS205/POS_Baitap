using POS.MODEL;
using System.Windows.Forms;

namespace POS.UI
{
    public partial class MainForm : Form
    {
        private User _currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            statusLabelUser.Text = $"Chào, {_currentUser.FullName} ({_currentUser.RoleName})";
            AuthorizeMenu();
        }

        private void AuthorizeMenu()
        {
            mnuManagement.Visible = false;
            mnuReports.Visible = false;

            switch (_currentUser.RoleName)
            {
                case "Admin":
                    mnuManagement.Visible = true;
                    mnuReports.Visible = true;
                    mnuProductManagement.Visible = true;
                    mnuCategoryManagement.Visible = true;
                    mnuUserManagement.Visible = true;
                    mnuReportByStaff.Visible = true;
                    mnuReportOverall.Visible = true;
                    break;

                case "Manager":
                    mnuManagement.Visible = true;
                    mnuReports.Visible = true;
                    mnuProductManagement.Visible = true;
                    mnuCategoryManagement.Visible = true;
                    mnuUserManagement.Visible = false;
                    mnuReportByStaff.Visible = true;
                    mnuReportOverall.Visible = true;
                    break;

                case "Staff":
                    mnuManagement.Visible = false;
                    mnuReports.Visible = true;
                    mnuReportByStaff.Visible = true;
                    mnuReportOverall.Visible = false;
                    break;
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }

        private void mnuProductManagement_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ProductForm))
                {
                    form.Activate();
                    return;
                }
            }

            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void mnuPOS_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(SalesForm))
                {
                    form.Activate();
                    return;
                }
            }
            SalesForm salesForm = new SalesForm(_currentUser);
            salesForm.Show();
        }

        private void mnuCategoryManagement_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CategoryForm))
                {
                    form.Activate();
                    return;
                }
            }
            CategoryForm categoryForm = new CategoryForm();
            categoryForm.Show();
        }

        // MỚI: Xử lý sự kiện click menu Lịch sử bán hàng
        private void mnuSalesHistory_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(SalesHistoryForm))
                {
                    form.Activate();
                    return;
                }
            }
            SalesHistoryForm historyForm = new SalesHistoryForm();
            historyForm.Show();
        }
    }
}