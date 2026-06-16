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

            bool showLogin = true;

            while (showLogin)
            {
                using (var loginForm = new FormLogin())
                {
                    var result = loginForm.ShowDialog();

                    if (result != DialogResult.OK)
                    {
                        return; // Закрытие приложения
                    }

                    if (loginForm.IsGuest)
                    {
                        // Гость - показываем информацию
                        using (var infoForm = new FormInfo(loginForm.CurrentUser, true))
                        {
                            var infoResult = infoForm.ShowDialog();
                            if (infoResult == DialogResult.Abort)
                            {
                                continue; // Выход - показываем форму входа
                            }
                        }
                        // Если infoResult не Abort, то выходим из цикла
                        showLogin = false;
                    }
                    else
                    {
                        // Авторизованный - показываем меню
                        using (var menuForm = new FormMenu(loginForm.CurrentUser, false))
                        {
                            var menuResult = menuForm.ShowDialog();
                            if (menuResult == DialogResult.Abort)
                            {
                                continue; // Выход - показываем форму входа
                            }
                        }
                        showLogin = false;
                    }
                }
            }
        }
    }
}