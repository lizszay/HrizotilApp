using HrizotilApp.Models;

namespace HrizotilApp.Forms
{
    public partial class FormProfile : Form
    {
        private User currentUser;

        public FormProfile(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            txtLogin.Text = currentUser.Login;
            txtLogin.ReadOnly = true;
            txtFullName.Text = currentUser.FullName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new HrizotilAccountingDbContext())
            {
                var user = db.Users.Find(currentUser.Id);
                if (user != null)
                {
                    user.FullName = txtFullName.Text.Trim();

                    if (!string.IsNullOrWhiteSpace(txtNewPassword.Text))
                    {
                        if (txtNewPassword.Text != txtConfirmPassword.Text)
                        {
                            MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        user.Password = txtNewPassword.Text;
                    }

                    db.SaveChanges();
                    MessageBox.Show("Профиль обновлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}