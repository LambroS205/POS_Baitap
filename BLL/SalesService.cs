using POS.DAL;
using POS.MODEL;

namespace POS.BLL
{
    public class SalesService
    {
        private readonly SalesRepo _salesRepo;
        private readonly ProductRepo _productRepo;

        public SalesService()
        {
            _salesRepo = new SalesRepo();
            _productRepo = new ProductRepo();
        }

        public int CreateSale(Invoice invoice, List<CartItem> cart)
        {
            if (cart == null || cart.Count == 0)
            {
                throw new Exception("Giỏ hàng rỗng. Không thể tạo hóa đơn.");
            }

            decimal totalAmount = cart.Sum(item => item.LineTotal);
            invoice.TotalAmount = totalAmount;
            invoice.FinalAmount = totalAmount;
            invoice.InvoiceDate = DateTime.Now;

            foreach (var item in cart)
            {
                Product productInDb = _productRepo.GetProductById(item.ProductId);
                if (productInDb == null)
                {
                    throw new Exception($"Sản phẩm '{item.ProductName}' không còn tồn tại.");
                }
                if (productInDb.Quantity < item.Quantity)
                {
                    throw new Exception($"Không đủ hàng tồn kho cho '{item.ProductName}'. " +
                                      $"Trong kho chỉ còn: {productInDb.Quantity}");
                }
            }

            try
            {
                return _salesRepo.SaveInvoice(invoice, cart);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiêm trọng khi lưu hóa đơn: \n" + ex.Message);
            }
        }

        // MỚI: Lấy danh sách lịch sử
        public List<Invoice> GetSalesHistory()
        {
            return _salesRepo.GetInvoices();
        }
    }
}