using HrizotilApp.Models;
using HrizotilApp.Forms;

namespace HrizotilApp
{
    public partial class FormMenu : Form
    {
        private User currentUser;
        private int userRole;

        public FormMenu(User user, bool isGuest)
        {
            InitializeComponent();
            currentUser = user;
            userRole = currentUser?.IdRole ?? 1;

            ConfigureMenu();
        }

        private void ConfigureMenu()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Пользователь";

            // Кнопка пользователей только для админа
            btnUsers.Visible = (userRole == 5);
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            var form = new FormInfo(currentUser, false);
            form.ShowDialog();
        }

        private void BtnProductions_Click(object sender, EventArgs e)
        {
            bool canEdit = (userRole == 2 || userRole == 5);
            var form = new FormProductions(currentUser, !canEdit);
            form.ShowDialog();
        }

        private void BtnQuality_Click(object sender, EventArgs e)
        {
            bool canEdit = (userRole == 1 || userRole == 5);
            var form = new FormQuality(currentUser, !canEdit);
            form.ShowDialog();
        }

        private void BtnShipments_Click(object sender, EventArgs e)
        {
            bool canEdit = (userRole == 3 || userRole == 5);
            var form = new FormShipments(currentUser, !canEdit);
            form.ShowDialog();
        }

        private void BtnStocks_Click(object sender, EventArgs e)
        {
            var form = new FormStocks(currentUser);
            form.ShowDialog();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            var form = new FormProfile(currentUser);
            form.ShowDialog();
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            if (userRole == 5)
            {
                var form = new FormUsers(currentUser);
                form.ShowDialog();
            }
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