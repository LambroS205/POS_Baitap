using POS.UI;
using POS.UTIL;
using System.Windows.Forms;

namespace POS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            ApplicationConfiguration.Initialize();

            // ===================================================================
            // ĐÃ DỌN DẸP:
            // Hoàn tác lại, chạy LoginForm (Form đăng nhập)
            // ===================================================================
            Application.Run(new LoginForm());

            // (Bạn có thể xóa dòng 'Application.Run(new HashToolForm());' cũ)
        }
    }
}