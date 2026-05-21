using HrizotilApp.Models;

namespace HrizotilApp
{
    public partial class FormMenu : Form
    {
        private User currentUser;
        private bool isAdmin;

        public FormMenu(User user, bool isGuest)
        {
            InitializeComponent();
            currentUser = user;
            isAdmin = (currentUser != null && currentUser.IdRole == 5);

            ConfigureMenu();
        }

        private void ConfigureMenu()
        {
            // Отображение имени пользователя
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            // Кнопки для админа
            btnProducts.Visible = isAdmin;
            btnUsers.Visible = isAdmin;
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            var form = new FormInfo(currentUser, false);
            form.ShowDialog();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}