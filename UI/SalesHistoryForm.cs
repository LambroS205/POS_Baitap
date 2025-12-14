using POS.BLL;
using POS.MODEL;

namespace POS.UI
{
    public partial class SalesHistoryForm : Form
    {
        private readonly SalesService _salesService;

        public SalesHistoryForm()
        {
            InitializeComponent();
            _salesService = new SalesService();
        }

        private void SalesHistoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<Invoice> invoices = _salesService.GetSalesHistory();
                dgvInvoices.DataSource = invoices;
                SetupGrid();
                UpdateSummary(invoices);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu lịch sử: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGrid()
        {
            dgvInvoices.AutoGenerateColumns = false;

            // Xóa cột cũ nếu có để tránh trùng lặp khi reload
            dgvInvoices.Columns.Clear();

            // Cột Mã Hóa Đơn
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceId",
                HeaderText = "Mã HĐ",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Cột Ngày Giờ
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "InvoiceDate",
                HeaderText = "Thời Gian Giao Dịch",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            // Cột Khách Hàng
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Khách Hàng",
                Width = 200
            });

            // Cột Người Bán (Nhân Viên)
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "StaffName",
                HeaderText = "Người Lập",
                Width = 150
            });

            // Cột Tổng Tiền
            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Tổng Tiền (VND)",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.DarkGreen
                }
            });

            // Tự động giãn cột cuối
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UpdateSummary(List<Invoice> invoices)
        {
            if (invoices != null)
            {
                decimal totalRevenue = invoices.Sum(i => i.TotalAmount);
                int count = invoices.Count;
                lblSummary.Text = $"Tổng số đơn: {count}  |  Tổng doanh thu: {totalRevenue.ToString("N0")} VND";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}