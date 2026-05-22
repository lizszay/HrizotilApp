using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

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
                txtPassword.Enabled = true;
            }
            else
            {
                isNew = false;
                editingUser = user;
                this.Text = "Редактирование пользователя";
                LoadUserData();
                txtPassword.Text = "";
                txtPassword.Enabled = true;
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
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Введите логин!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) && isNew)
            {
                MessageBox.Show("Введите пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text.Length > 0 && txtPassword.Text.Length < 3)
            {
                MessageBox.Show("Пароль должен быть не менее 3 символов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsLoginExists(string login, int? excludeId = null)
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var query = db.Users.Where(u => u.Login == login);
                if (excludeId.HasValue)
                    query = query.Where(u => u.Id != excludeId.Value);
                return query.Any();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            string login = txtLogin.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            int roleId = (int)cmbRole.SelectedValue;

            // Проверка на дубликат логина
            if (isNew)
            {
                if (IsLoginExists(login))
                {
                    MessageBox.Show($"Пользователь с логином '{login}' уже существует!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (IsLoginExists(login, editingUser.Id))
                {
                    MessageBox.Show($"Пользователь с логином '{login}' уже существует!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    if (isNew)
                    {
                        var newUser = new User
                        {
                            Login = login,
                            Password = txtPassword.Text,
                            FullName = fullName,
                            IdRole = roleId
                        };
                        db.Users.Add(newUser);
                    }
                    else
                    {
                        var user = db.Users.Find(editingUser.Id);
                        if (user != null)
                        {
                            user.Login = login;
                            user.FullName = fullName;
                            user.IdRole = roleId;
                            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                            {
                                user.Password = txtPassword.Text;
                            }
                            db.Entry(user).State = EntityState.Modified;
                        }
                    }
                    db.SaveChanges();
                }

                MessageBox.Show("Пользователь сохранен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}