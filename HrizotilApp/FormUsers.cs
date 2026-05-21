using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormUsers : Form
    {
        private User currentUser;

        public FormUsers(User user)
        {
            InitializeComponent();
            currentUser = user;

            if (!DesignMode)
            {
                LoadData();
                dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void LoadData()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var users = db.Users
                    .Include(u => u.Role)
                    .Select(u => new
                    {
                        u.Id,
                        u.Login,
                        u.FullName,
                        RoleName = u.Role.RoleName
                    })
                    .OrderBy(u => u.Id)
                    .ToList();

                dgvData.DataSource = users;

                if (dgvData.Columns.Contains("Id"))
                    dgvData.Columns["Id"].HeaderText = "ID";
                if (dgvData.Columns.Contains("Login"))
                    dgvData.Columns["Login"].HeaderText = "Логин";
                if (dgvData.Columns.Contains("FullName"))
                    dgvData.Columns["FullName"].HeaderText = "ФИО";
                if (dgvData.Columns.Contains("RoleName"))
                    dgvData.Columns["RoleName"].HeaderText = "Роль";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormUserEdit(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null) return;

            int userId = Convert.ToInt32(dgvData.CurrentRow.Cells["Id"].Value);

            using (var db = new HrizotilAccountingDbContext())
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    var form = new FormUserEdit(user);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null) return;

            int userId = Convert.ToInt32(dgvData.CurrentRow.Cells["Id"].Value);
            string userName = dgvData.CurrentRow.Cells["FullName"].Value.ToString();

            if (userId == currentUser.Id)
            {
                MessageBox.Show("Нельзя удалить самого себя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить пользователя {userName}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    var user = db.Users.Find(userId);
                    if (user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        LoadData();
                    }
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}