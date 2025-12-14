using POS.DAL;
using POS.MODEL;

namespace POS.BLL
{
    public class CategoryService
    {
        private readonly CategoryRepo _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
        }

        public List<Category> GetCategories()
        {
            return _categoryRepo.GetCategories();
        }

        public void AddCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new Exception("Tên danh mục không được để trống.");
            }
            _categoryRepo.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new Exception("Tên danh mục không được để trống.");
            }
            if (category.CategoryId <= 0)
            {
                throw new Exception("ID danh mục không hợp lệ.");
            }
            _categoryRepo.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new Exception("ID danh mục không hợp lệ.");
            }
            _categoryRepo.DeleteCategory(categoryId);
        }
    }
}