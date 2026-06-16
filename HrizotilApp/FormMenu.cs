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

            btnUsers.Visible = (userRole == 5);
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            using (var form = new FormInfo(currentUser, false))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        private void BtnProductions_Click(object sender, EventArgs e)
        {
            bool canEdit = (userRole == 2 || userRole == 5);
            using (var form = new FormProductions(currentUser, !canEdit))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        private void BtnQuality_Click(object sender, EventArgs e)
        {
            bool canEdit = (userRole == 1 || userRole == 5);
            using (var form = new FormQuality(currentUser, !canEdit))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        private void BtnShipments_Click(object sender, EventArgs e)
        {
            bool canEdit = (userRole == 3 || userRole == 5);
            using (var form = new FormShipments(currentUser, !canEdit))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        private void BtnStocks_Click(object sender, EventArgs e)
        {
            using (var form = new FormStocks(currentUser))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            using (var form = new FormProfile(currentUser))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            if (userRole == 5)
            {
                using (var form = new FormUsers(currentUser))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.Abort)
                    {
                        this.DialogResult = DialogResult.Abort;
                        this.Close();
                    }
                }
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