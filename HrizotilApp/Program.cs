
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
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        return; // Закрытие приложения
                    }

                    if (loginForm.IsGuest)
                    {
                        Application.Run(new FormInfo(loginForm.CurrentUser, true));
                    }
                    else
                    {
                    }
                }
            }
        }
    }
}