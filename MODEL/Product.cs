namespace POS.MODEL
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty; // Để hiển thị
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; } // Giá nhập
        public decimal SellingPrice { get; set; } // Giá bán
        public string Unit { get; set; } = string.Empty; // Đơn vị tính
    }
}