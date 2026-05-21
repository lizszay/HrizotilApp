using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp
{
    public partial class FormInfo : Form
    {
        private User currentUser;
        private bool isGuest;

        public FormInfo(User user, bool guest)
        {
            InitializeComponent();
            currentUser = user;
            isGuest = guest;

            LoadProducts();
            ConfigureUI();
        }

        private void LoadProducts()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var products = db.Products
                    .Include(p => p.Group)
                    .OrderBy(p => p.Group.Id)
                    .ThenBy(p => p.Id)
                    .ToList();

                dataGridView1.DataSource = products.Select(p => new
                {
                    Группа = p.Group.GroupName,
                    Код = p.Id,
                    Сито = p.NormSieve135mmMin?.ToString() ?? "-",
                    Пыль = p.NormDustMax?.ToString() ?? "-",
                    ПК = p.NormPk075mmMax?.ToString() ?? "-",
                    Плотность = p.BulkDensityTarget?.ToString() ?? "-"
                }).ToList();
            }
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                btnCurrentUser.Text = currentUser.FullName;
            else if (isGuest)
                btnCurrentUser.Text = "Гость";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCurrentUser_Click(object sender, EventArgs e)
        {
            // Пока ничего, просто показывает кто вошёл
            MessageBox.Show($"Текущий пользователь: {btnCurrentUser.Text}", "Информация");
        }
    }
}