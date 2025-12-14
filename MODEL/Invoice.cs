namespace POS.MODEL
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal FinalAmount { get; set; }

        // Thêm trường này để hiển thị trong lịch sử
        public string StaffName { get; set; } = string.Empty;
    }
}