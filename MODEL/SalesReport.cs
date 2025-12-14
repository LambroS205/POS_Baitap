namespace POS.MODEL
{
    /// <summary>
    /// Model này dùng để chứa dữ liệu báo cáo, không tương ứng 1-1 với CSDL
    /// </summary>
    public class SalesReport
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal FinalAmount { get; set; }
    }
}