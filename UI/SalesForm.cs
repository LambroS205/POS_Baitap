using POS.BLL;
using POS.MODEL;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;

namespace POS.UI
{
    public partial class SalesForm : Form
    {
        private readonly User _currentUser;
        private readonly ProductService _productService;
        private readonly SalesService _salesService;
        private BindingList<CartItem> _cart;

        // Biến tạm để lưu dữ liệu in
        private Invoice _printInvoice;
        private List<CartItem> _printCart;

        public SalesForm(User user)
        {
            InitializeComponent();

            _currentUser = user;
            _productService = new ProductService();
            _salesService = new SalesService();
            _cart = new BindingList<CartItem>();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            lblStaffName.Text = _currentUser.FullName;
            SetupCartGrid();
            SetupSearchGrid();

            // THAY ĐỔI: Tự động tải danh sách sản phẩm khi mở form
            LoadAllProducts();

            ClearSale();
        }

        private void LoadAllProducts()
        {
            try
            {
                // Gọi với chuỗi rỗng để lấy tất cả (đã sửa trong Service)
                List<Product> results = _productService.GetProductsForSale("");
                dgvSearchResults.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        private void SetupCartGrid()
        {
            dgvCart.DataSource = _cart;
            dgvCart.AutoGenerateColumns = false;

            if (dgvCart.Columns.Count == 0)
            {
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "ID", Width = 60 });
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SellingPrice", HeaderText = "Đơn Giá", Width = 100, DefaultCellStyle = { Format = "N0" } });
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 60 });
                dgvCart.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LineTotal", HeaderText = "Thành Tiền", Width = 120, DefaultCellStyle = { Format = "N0" }, ReadOnly = true });
            }
        }

        private void SetupSearchGrid()
        {
            dgvSearchResults.AutoGenerateColumns = false;
            if (dgvSearchResults.Columns.Count == 0)
            {
                dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "ID", Width = 60 });
                dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên Sản Phẩm", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SellingPrice", HeaderText = "Giá Bán", Width = 100, DefaultCellStyle = { Format = "N0" } });
                dgvSearchResults.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Tồn Kho", Width = 70 });
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                // Service giờ đã xử lý được chuỗi rỗng
                List<Product> results = _productService.GetProductsForSale(searchTerm);
                dgvSearchResults.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void dgvSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var product = (Product)dgvSearchResults.Rows[e.RowIndex].DataBoundItem;
                if (product != null)
                {
                    AddProductToCart(product);
                }
            }
        }

        private void AddProductToCart(Product product)
        {
            CartItem existingItem = _cart.FirstOrDefault(item => item.ProductId == product.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    SellingPrice = product.SellingPrice,
                    Quantity = 1
                });
            }

            _cart.ResetBindings();
            UpdateTotal();
        }

        private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["Quantity"]?.Index)
            {
                try
                {
                    CartItem item = _cart[e.RowIndex];
                    if (item.Quantity <= 0)
                    {
                        _cart.Remove(item);
                    }
                }
                catch (Exception)
                {
                }
            }
            _cart.ResetBindings();
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = _cart.Sum(item => item.LineTotal);
            lblTotal.Text = total.ToString("N0") + " VND";
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa toàn bộ giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearSale();
                LoadAllProducts(); // Refresh lại danh sách nếu cần
            }
        }

        private void ClearSale()
        {
            _cart.Clear();
            txtCustomerName.Clear();
            txtSearch.Clear();
            // Không xóa dataSource searchResult nữa để giữ danh sách sản phẩm
            // dgvSearchResults.DataSource = null; 
            UpdateTotal();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang rỗng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Tổng cộng: {lblTotal.Text}\n\nXác nhận thanh toán hóa đơn này?", "Xác nhận Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }

            Invoice newInvoice = new Invoice
            {
                UserId = _currentUser.UserId,
                CustomerName = txtCustomerName.Text.Trim()
            };

            try
            {
                int newInvoiceId = _salesService.CreateSale(newInvoice, _cart.ToList());

                newInvoice.InvoiceId = newInvoiceId;
                var cartToPrint = _cart.ToList();
                var invoiceToPrint = newInvoice;

                DialogResult printConfirm = MessageBox.Show(
                    $"Thanh toán thành công!\nSố hóa đơn: {newInvoiceId}\n\nBạn có muốn in hóa đơn không?",
                    "Thành công",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (printConfirm == DialogResult.Yes)
                {
                    PrintInvoice(invoiceToPrint, cartToPrint);
                }

                ClearSale();
                // Tải lại danh sách sản phẩm để cập nhật tồn kho mới
                LoadAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: \n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Index >= 0)
                {
                    CartItem item = _cart[dgvCart.CurrentRow.Index];
                    if (MessageBox.Show($"Bạn có muốn xóa '{item.ProductName}' khỏi giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _cart.Remove(item);
                        _cart.ResetBindings();
                        UpdateTotal();
                    }
                }
            }
        }

        private void PrintInvoice(Invoice invoice, List<CartItem> cart)
        {
            _printInvoice = invoice;
            _printCart = cart;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Width = 800;
            printPreviewDialog1.Height = 600;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontRegular = new Font("Arial", 11, FontStyle.Regular);
            Font fontSmall = new Font("Arial", 9, FontStyle.Italic);
            Brush brush = Brushes.Black;

            float x = 50;
            float y = 50;
            float width = e.PageBounds.Width - 100;

            string storeName = "CỬA HÀNG POS VIETNAM";
            string address = "Địa chỉ: 123 Đường ABC, Quận XYZ, TP.HCM";
            string phone = "Điện thoại: (028) 1234 5678";

            SizeF sizeStore = g.MeasureString(storeName, fontTitle);
            g.DrawString(storeName, fontTitle, brush, (e.PageBounds.Width - sizeStore.Width) / 2, y);
            y += 30;

            SizeF sizeAddr = g.MeasureString(address, fontRegular);
            g.DrawString(address, fontRegular, brush, (e.PageBounds.Width - sizeAddr.Width) / 2, y);
            y += 20;

            SizeF sizePhone = g.MeasureString(phone, fontRegular);
            g.DrawString(phone, fontRegular, brush, (e.PageBounds.Width - sizePhone.Width) / 2, y);
            y += 40;

            string invoiceTitle = "HÓA ĐƠN BÁN HÀNG";
            SizeF sizeTitle = g.MeasureString(invoiceTitle, fontTitle);
            g.DrawString(invoiceTitle, fontTitle, brush, (e.PageBounds.Width - sizeTitle.Width) / 2, y);
            y += 40;

            g.DrawString($"Số Hóa Đơn: #{_printInvoice.InvoiceId}", fontRegular, brush, x, y);
            y += 20;
            g.DrawString($"Ngày: {_printInvoice.InvoiceDate.ToString("dd/MM/yyyy HH:mm")}", fontRegular, brush, x, y);
            y += 20;
            g.DrawString($"Nhân viên: {_currentUser.FullName}", fontRegular, brush, x, y);
            y += 20;
            g.DrawString($"Khách hàng: {(_printInvoice.CustomerName == "" ? "Khách lẻ" : _printInvoice.CustomerName)}", fontRegular, brush, x, y);
            y += 30;

            float col1 = x;
            float col2 = x + 300;
            float col3 = x + 380;
            float col4 = x + 500;

            g.DrawString("Sản Phẩm", fontHeader, brush, col1, y);
            g.DrawString("SL", fontHeader, brush, col2, y);
            g.DrawString("Đơn Giá", fontHeader, brush, col3, y);
            g.DrawString("T.Tiền", fontHeader, brush, col4, y);
            y += 10;
            g.DrawLine(Pens.Black, x, y + 15, x + width, y + 15);
            y += 20;

            foreach (var item in _printCart)
            {
                string name = item.ProductName;
                if (name.Length > 35) name = name.Substring(0, 32) + "...";

                g.DrawString(name, fontRegular, brush, col1, y);
                g.DrawString(item.Quantity.ToString(), fontRegular, brush, col2, y);
                g.DrawString(item.SellingPrice.ToString("N0"), fontRegular, brush, col3, y);
                g.DrawString(item.LineTotal.ToString("N0"), fontRegular, brush, col4, y);
                y += 25;
            }

            g.DrawLine(Pens.Black, x, y, x + width, y);
            y += 10;

            string totalText = $"TỔNG CỘNG: {_printInvoice.TotalAmount.ToString("N0")} VND";
            Font fontTotal = new Font("Arial", 14, FontStyle.Bold);
            SizeF sizeTotal = g.MeasureString(totalText, fontTotal);
            g.DrawString(totalText, fontTotal, Brushes.Red, x + width - sizeTotal.Width, y);
            y += 50;

            string footer = "Cảm ơn quý khách và hẹn gặp lại!";
            SizeF sizeFooter = g.MeasureString(footer, fontSmall);
            g.DrawString(footer, fontSmall, brush, (e.PageBounds.Width - sizeFooter.Width) / 2, y);
        }
    }
}