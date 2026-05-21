using HrizotilApp.Models;

namespace HrizotilApp.Forms
{
    public partial class FormUserEdit : Form
    {
        private User editingUser;
        private bool isNew;

        public FormUserEdit(User user = null)
        {
            InitializeComponent();

            LoadRoles();

            if (user == null)
            {
                isNew = true;
                editingUser = new User();
                this.Text = "Добавление пользователя";
            }
            else
            {
                isNew = false;
                editingUser = user;
                this.Text = "Редактирование пользователя";
                LoadUserData();
            }
        }

        private void LoadRoles()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var roles = db.Roles.OrderBy(r => r.Id).ToList();
                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "Id";
            }
        }

        private void LoadUserData()
        {
            txtLogin.Text = editingUser.Login;
            txtFullName.Text = editingUser.FullName;
            cmbRole.SelectedValue = editingUser.IdRole;
            txtPassword.Text = editingUser.Password;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) && isNew)
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new HrizotilAccountingDbContext())
            {
                if (isNew)
                {
                    editingUser.Login = txtLogin.Text.Trim();
                    editingUser.Password = txtPassword.Text;
                    editingUser.FullName = txtFullName.Text.Trim();
                    editingUser.IdRole = (int)cmbRole.SelectedValue;
                    db.Users.Add(editingUser);
                }
                else
                {
                    var user = db.Users.Find(editingUser.Id);
                    if (user != null)
                    {
                        user.Login = txtLogin.Text.Trim();
                        user.FullName = txtFullName.Text.Trim();
                        user.IdRole = (int)cmbRole.SelectedValue;
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                            user.Password = txtPassword.Text;
                        db.Users.Update(user);
                    }
                }
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}