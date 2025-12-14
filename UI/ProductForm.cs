using POS.BLL;
using POS.MODEL;
using System.Data;

namespace POS.UI
{
    public partial class ProductForm : Form
    {
        private readonly ProductService _productService;
        private List<Product> _productList;
        private Product? _selectedProduct;

        // Mức tồn kho thấp
        private const int LOW_STOCK_THRESHOLD = 10;

        public ProductForm()
        {
            InitializeComponent();
            _productService = new ProductService();
            _productList = new List<Product>();
            _selectedProduct = null;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProductGrid();
            ClearForm();
        }

        private void LoadCategories()
        {
            try
            {
                // Tải danh sách gốc cho form SỬA
                List<Category> editCategories = _productService.GetCategories();
                cboCategory.DataSource = editCategories;
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";

                // Tạo một danh sách MỚI cho bộ LỌC, bao gồm "-- Tất cả --"
                List<Category> filterCategories = new List<Category>();
                filterCategories.Add(new Category { CategoryId = 0, CategoryName = "-- Tất cả danh mục --" });
                filterCategories.AddRange(editCategories); // Thêm danh sách gốc vào

                cboFilterCategory.DataSource = filterCategories;
                cboFilterCategory.DisplayMember = "CategoryName";
                cboFilterCategory.ValueMember = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductGrid()
        {
            try
            {
                _productList = _productService.GetProducts();
                ApplyFilter(); // Hiển thị dữ liệu đã lọc (ban đầu là tất cả)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter()
        {
            string filterText = txtFilterName.Text.Trim().ToLower();

            // SỬA LỖI: Lấy giá trị từ ComboBox một cách an toàn
            int filterCategory = 0;
            if (cboFilterCategory.SelectedValue != null)
            {
                // Thử chuyển đổi sang int, vì SelectedValue có thể là object
                // thay vì int (đặc biệt là khi form đang load)
                bool success = int.TryParse(cboFilterCategory.SelectedValue.ToString(), out filterCategory);
                if (!success)
                {
                    filterCategory = 0; // Nếu thất bại, coi như không lọc
                }
            }

            List<Product> filteredList = _productList;

            // Lọc theo tên
            if (!string.IsNullOrEmpty(filterText))
            {
                filteredList = filteredList.Where(p => p.ProductName.ToLower().Contains(filterText)).ToList();
            }

            // Lọc theo danh mục
            if (filterCategory > 0)
            {
                filteredList = filteredList.Where(p => p.CategoryId == filterCategory).ToList();
            }

            dgvProducts.DataSource = null;
            dgvProducts.AutoGenerateColumns = false; // Tắt tự động tạo cột
            SetupGridViewColumns(); // Đảm bảo các cột được thiết lập
            dgvProducts.DataSource = filteredList;
        }

        private void SetupGridViewColumns()
        {
            if (dgvProducts.Columns.Count == 0)
            {
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ProductId",
                    DataPropertyName = "ProductId",
                    HeaderText = "ID",
                    Width = 60
                });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    DataPropertyName = "ProductName",
                    HeaderText = "Tên Sản Phẩm",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CategoryName",
                    DataPropertyName = "CategoryName",
                    HeaderText = "Danh Mục",
                    Width = 150
                });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SellingPrice",
                    DataPropertyName = "SellingPrice",
                    HeaderText = "Giá Bán",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    DataPropertyName = "Quantity",
                    HeaderText = "Tồn Kho",
                    Width = 80
                });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CostPrice",
                    DataPropertyName = "CostPrice",
                    HeaderText = "Giá Nhập",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
                });
                dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Unit",
                    DataPropertyName = "Unit",
                    HeaderText = "ĐVT",
                    Width = 80
                });
            }
        }

        private void ClearForm()
        {
            _selectedProduct = null;
            txtProductName.Clear();
            txtUnit.Clear();
            numCostPrice.Value = 0;
            numSellingPrice.Value = 0;
            numQuantity.Value = 0;
            if (cboCategory.Items.Count > 0)
            {
                // TỐI ƯU:
                // Bây giờ cboCategory (sửa) không còn mục "Tất cả"
                // nên chúng ta có thể an toàn chọn index 0
                cboCategory.SelectedIndex = 0;
            }

            // --- CẬP NHẬT CHO VIỆC NHẬP HÀNG ---
            numQuantity.Enabled = true; // Bật lại khi thêm mới
            labelAddStock.Visible = false;
            numAddStock.Visible = false;
            numAddStock.Value = 0;
            // --- KẾT THÚC CẬP NHẬT ---

            btnSave.Text = "Lưu (Thêm)";
            btnDelete.Enabled = false;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                // Lấy sản phẩm từ danh sách đã lọc
                var filteredList = (List<Product>)dgvProducts.DataSource;
                _selectedProduct = filteredList[e.RowIndex];

                if (_selectedProduct != null)
                {
                    // Điền thông tin lên form
                    txtProductName.Text = _selectedProduct.ProductName;
                    txtUnit.Text = _selectedProduct.Unit;
                    numCostPrice.Value = _selectedProduct.CostPrice;
                    numSellingPrice.Value = _selectedProduct.SellingPrice;
                    numQuantity.Value = _selectedProduct.Quantity;
                    cboCategory.SelectedValue = _selectedProduct.CategoryId;

                    // --- CẬP NHẬT CHO VIỆC NHẬP HÀNG ---
                    numQuantity.Enabled = false; // Khóa ô tồn kho khi sửa
                    labelAddStock.Visible = true; // Hiện ô nhập hàng
                    numAddStock.Visible = true;
                    numAddStock.Value = 0;
                    // --- KẾT THÚC CẬP NHẬT ---

                    btnSave.Text = "Lưu (Sửa)";
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ form
            try
            {
                string productName = txtProductName.Text.Trim();
                int categoryId = (int)cboCategory.SelectedValue;
                string unit = txtUnit.Text.Trim();
                decimal costPrice = numCostPrice.Value;
                decimal sellingPrice = numSellingPrice.Value;
                int quantity = (int)numQuantity.Value;

                if (categoryId == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cho sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCategory.Focus();
                    return;
                }

                if (_selectedProduct == null) // Thêm mới
                {
                    Product newProduct = new Product
                    {
                        ProductName = productName,
                        CategoryId = categoryId,
                        Unit = unit,
                        CostPrice = costPrice,
                        SellingPrice = sellingPrice,
                        Quantity = quantity // Lấy từ ô quantity đang BẬT
                    };
                    _productService.AddProduct(newProduct);
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Cập nhật
                {
                    // --- CẬP NHẬT LOGIC NHẬP HÀNG ---
                    int addStock = (int)numAddStock.Value;
                    int currentStock = _selectedProduct.Quantity; // Lấy tồn kho cũ

                    _selectedProduct.ProductName = productName;
                    _selectedProduct.CategoryId = categoryId;
                    _selectedProduct.Unit = unit;
                    _selectedProduct.CostPrice = costPrice; // Cập nhật giá nhập mới (nếu có)
                    _selectedProduct.SellingPrice = sellingPrice;
                    _selectedProduct.Quantity = currentStock + addStock; // Cộng dồn
                    // --- KẾT THÚC CẬP NHẬT ---

                    _productService.UpdateProduct(_selectedProduct);
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadProductGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{_selectedProduct.ProductName}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _productService.DeleteProduct(_selectedProduct.ProductId);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductGrid();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Lọc khi thay đổi text hoặc combobox
        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cboFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // --- MỚI: SỰ KIỆN CẢNH BÁO TỒN KHO ---
        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra hàng
            if (e.RowIndex >= 0 && e.RowIndex < dgvProducts.Rows.Count)
            {
                // Lấy sản phẩm từ DataSource của hàng đó
                var product = (Product)dgvProducts.Rows[e.RowIndex].DataBoundItem;

                if (product != null)
                {
                    // Nếu tồn kho <= 10 (hoặc 0)
                    if (product.Quantity <= LOW_STOCK_THRESHOLD)
                    {
                        // Tô màu hồng nhạt cho cả hàng
                        e.CellStyle.BackColor = Color.LightPink;
                        e.CellStyle.SelectionBackColor = Color.Crimson;
                    }
                    else
                    {
                        // Đảm bảo màu về mặc định
                        e.CellStyle.BackColor = SystemColors.Window;
                        e.CellStyle.SelectionBackColor = SystemColors.Highlight;
                    }
                }
            }
        }
    }
}