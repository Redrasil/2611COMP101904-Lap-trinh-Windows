using System;
using System.Windows.Forms;
using ShopManagerMini.Forms;

namespace ShopManagerMini
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi chạy chính của ứng dụng ShopManagerMini.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Vòng lặp điều phối phiên đăng nhập / đăng xuất
            while (true)
            {
                using (var loginForm = new FrmLogin())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK || loginForm.LoggedInUser == null)
                    {
                        // Người dùng hủy đăng nhập hoặc đóng form -> Thoát ứng dụng
                        break;
                    }

                    // Chuyển sang màn hình MDI chính với thông tin tài khoản đã xác thực
                    using (var mainForm = new FrmMain(loginForm.LoggedInUser))
                    {
                        Application.Run(mainForm);

                        // Nếu không phải thao tác đăng xuất thì thoát toàn bộ chương trình
                        if (!mainForm.IsLoggedOut)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
