using System.ComponentModel;

namespace POS.MODEL
{
    /// <summary>
    /// Model này chỉ dùng cục bộ trong Form Bán hàng, không lưu vào CSDL
    /// </summary>
    public class CartItem
    {
        [DisplayName("ID")]
        public int ProductId { get; set; }

        [DisplayName("Tên Sản Phẩm")]
        public string ProductName { get; set; } = string.Empty;

        [DisplayName("Đơn Giá")]
        public decimal SellingPrice { get; set; }

        [DisplayName("Số Lượng")]
        public int Quantity { get; set; }

        [DisplayName("Thành Tiền")]
        public decimal LineTotal
        {
            get { return SellingPrice * Quantity; }
        }
    }
}