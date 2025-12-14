using POS.BLL;
using POS.MODEL;

namespace POS.UI
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryService _categoryService;
        private List<Category> _categoryList;
        private Category? _selectedCategory;

        public CategoryForm()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            _categoryList = new List<Category>();
            _selectedCategory = null;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadCategoryGrid();
            ClearForm();
        }

        private void LoadCategoryGrid()
        {
            try
            {
                _categoryList = _categoryService.GetCategories();
                dgvCategories.DataSource = null;
                dgvCategories.DataSource = _categoryList;
                SetupGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGridViewColumns()
        {
            dgvCategories.AutoGenerateColumns = false;
            if (dgvCategories.Columns.Count == 0)
            {
                dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CategoryId",
                    DataPropertyName = "CategoryId",
                    HeaderText = "ID",
                    Width = 80
                });
                dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CategoryName",
                    DataPropertyName = "CategoryName",
                    HeaderText = "Tên Danh Mục",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
            }
        }

        private void ClearForm()
        {
            _selectedCategory = null;
            txtCategoryName.Clear();
            btnSave.Text = "Lưu (Thêm)";
            btnDelete.Enabled = false;
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCategories.Rows.Count)
            {
                _selectedCategory = _categoryList[e.RowIndex];

                if (_selectedCategory != null)
                {
                    txtCategoryName.Text = _selectedCategory.CategoryName;
                    btnSave.Text = "Lưu (Sửa)";
                    btnDelete.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = txtCategoryName.Text.Trim();

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show("Tên danh mục không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                if (_selectedCategory == null) // Thêm mới
                {
                    Category newCategory = new Category { CategoryName = categoryName };
                    _categoryService.AddCategory(newCategory);
                    MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Cập nhật
                {
                    _selectedCategory.CategoryName = categoryName;
                    _categoryService.UpdateCategory(_selectedCategory);
                    MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadCategoryGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục '{_selectedCategory.CategoryName}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _categoryService.DeleteCategory(_selectedCategory.CategoryId);
                    MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategoryGrid();
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