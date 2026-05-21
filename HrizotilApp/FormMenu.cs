using HrizotilApp.Models;
using HrizotilApp.Forms;

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
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            btnProducts.Visible = isAdmin;
            btnUsers.Visible = isAdmin;
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            var form = new FormInfo(currentUser, false);
            form.ShowDialog();
        }

        private void BtnProductions_Click(object sender, EventArgs e)
        {
            bool readOnly = (currentUser.IdRole != 2 && currentUser.IdRole != 5);
            var form = new FormProductions(currentUser, readOnly);
            form.ShowDialog();
        }

        private void BtnQuality_Click(object sender, EventArgs e)
        {
            bool readOnly = (currentUser.IdRole != 1 && currentUser.IdRole != 5);
            var form = new FormQuality(currentUser, readOnly);
            form.ShowDialog();
        }

        private void BtnShipments_Click(object sender, EventArgs e)
        {
            bool readOnly = (currentUser.IdRole != 3 && currentUser.IdRole != 5);
            var form = new FormShipments(currentUser, readOnly);
            form.ShowDialog();
        }

        private void BtnStocks_Click(object sender, EventArgs e)
        {
            var form = new FormStocks();
            form.ShowDialog();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Управление марками будет добавлено позже", "В разработке");
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            if (!isAdmin) return;
            var form = new FormUsers(currentUser);
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