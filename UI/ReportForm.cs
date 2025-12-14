using POS.BLL;
using POS.MODEL;

namespace POS.UI
{
    public partial class ReportForm : Form
    {
        private readonly ReportService _reportService;
        private readonly User _currentUser;

        public ReportForm(User currentUser)
        {
            InitializeComponent();
            _reportService = new ReportService();
            _currentUser = currentUser; // Nhận User từ MainForm
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            SetupForm();
            RunReport(); // Tự động chạy báo cáo lần đầu
        }

        private void SetupForm()
        {
            // Cài đặt ngày mặc định (30 ngày qua)
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-30);

            // Cấu hình form dựa trên vai trò
            if (_currentUser.RoleName == "Staff")
            {
                this.Text = $"Báo cáo cá nhân: {_currentUser.FullName}";
                // (Trong tương lai, có thể ẩn bộ lọc nhân viên nếu có)
                panelFilter.Enabled = true; // Staff vẫn được đổi ngày
            }
            else
            {
                this.Text = "Báo cáo Doanh thu Tổng thể";
                panelFilter.Enabled = true;
            }

            SetupGridViewColumns();
        }

        private void SetupGridViewColumns()
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.Columns.Clear();

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceId",
                DataPropertyName = "InvoiceId",
                HeaderText = "Số HĐ",
                Width = 80
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "InvoiceDate",
                DataPropertyName = "InvoiceDate",
                HeaderText = "Ngày Lập",
                Width = 150,
                DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" }
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StaffName",
                DataPropertyName = "StaffName",
                HeaderText = "Nhân viên",
                Width = 180
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CustomerName",
                DataPropertyName = "CustomerName",
                HeaderText = "Khách hàng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FinalAmount",
                DataPropertyName = "FinalAmount",
                HeaderText = "Doanh thu",
                Width = 150,
                DefaultCellStyle = { Format = "N0" }
            });
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void RunReport()
        {
            try
            {
                List<SalesReport> reportData = _reportService.GetSalesReport(
                    dtpStartDate.Value,
                    dtpEndDate.Value,
                    _currentUser
                );

                dgvReport.DataSource = reportData;

                // Tính toán tổng
                decimal totalRevenue = reportData.Sum(r => r.FinalAmount);
                int totalInvoices = reportData.Count;

                lblTotalRevenue.Text = totalRevenue.ToString("N0") + " VND";
                lblTotalInvoices.Text = totalInvoices.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}