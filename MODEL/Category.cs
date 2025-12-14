namespace POS.MODEL
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        // Dùng để hiển thị trong ComboBox
        public override string ToString()
        {
            return CategoryName;
        }
    }
}