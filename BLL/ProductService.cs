using POS.DAL;
using POS.MODEL;

namespace POS.BLL
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo;
        private readonly CategoryRepo _categoryRepo; // Khai báo thêm CategoryRepo

        public ProductService()
        {
            _productRepo = new ProductRepo();
            _categoryRepo = new CategoryRepo(); // Khởi tạo CategoryRepo
        }

        public List<Category> GetCategories()
        {
            // SỬA LỖI: Sử dụng CategoryRepo để lấy danh mục thay vì ProductRepo
            return _categoryRepo.GetCategories();
        }

        public List<Product> GetProducts()
        {
            return _productRepo.GetProducts();
        }

        public Product GetProductById(int productId)
        {
            return _productRepo.GetProductById(productId);
        }

        public List<Product> GetProductsForSale(string searchTerm)
        {
            // Cho phép tìm kiếm rỗng để lấy tất cả sản phẩm
            if (searchTerm == null)
            {
                searchTerm = "";
            }
            return _productRepo.GetProductsForSale(searchTerm);
        }

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                throw new Exception("Tên sản phẩm không được để trống.");
            }
            if (product.SellingPrice < product.CostPrice)
            {
                throw new Exception("Giá bán không được nhỏ hơn giá nhập.");
            }
            _productRepo.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                throw new Exception("Tên sản phẩm không được để trống.");
            }
            if (product.SellingPrice < product.CostPrice)
            {
                throw new Exception("Giá bán không được nhỏ hơn giá nhập.");
            }
            if (product.ProductId <= 0)
            {
                throw new Exception("ID sản phẩm không hợp lệ.");
            }
            _productRepo.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            if (productId <= 0)
            {
                throw new Exception("ID sản phẩm không hợp lệ.");
            }
            _productRepo.DeleteProduct(productId);
        }
    }
}