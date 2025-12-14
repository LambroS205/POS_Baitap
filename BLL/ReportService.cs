using POS.DAL;
using POS.MODEL;

namespace POS.BLL
{
    public class ReportService
    {
        private readonly ReportRepo _reportRepo;

        public ReportService()
        {
            _reportRepo = new ReportRepo();
        }

        /// <summary>
        /// Lấy báo cáo dựa trên quyền của người dùng
        /// </summary>
        public List<SalesReport> GetSalesReport(DateTime startDate, DateTime endDate, User currentUser)
        {
            // Chuẩn hóa ngày
            DateTime start = startDate.Date; // 00:00:00
            DateTime end = endDate.Date.AddDays(1).AddTicks(-1); // 23:59:59.999

            if (currentUser.RoleName == "Staff")
            {
                // Staff chỉ xem được của mình
                return _reportRepo.GetStaffReport(start, end, currentUser.UserId);
            }
            else
            {
                // Admin/Manager xem được tất cả
                return _reportRepo.GetOverallReport(start, end);
            }
        }
    }
}