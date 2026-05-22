using HrizotilApp.Models;

namespace HrizotilApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (var loginForm = new FormLogin())
                {
                    var result = loginForm.ShowDialog();

                    if (result != DialogResult.OK)
                    {
                        return;
                    }

                    if (loginForm.IsGuest)
                    {
                        // Гость - сразу в информацию
                        using (var infoForm = new FormInfo(loginForm.CurrentUser, true))
                        {
                            infoForm.ShowDialog();
                        }
                        continue;
                    }
                    else
                    {
                        // Авторизованный - в меню
                        using (var menuForm = new FormMenu(loginForm.CurrentUser, false))
                        {
                            var menuResult = menuForm.ShowDialog();
                            if (menuResult == DialogResult.Abort)
                            {
                                continue;
                            }
                        }
                    }
                }
            }
        }
    }
}