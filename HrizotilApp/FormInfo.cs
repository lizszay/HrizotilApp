using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp
{
    public partial class FormInfo : Form
    {
        private User currentUser;
        private bool isGuest;
        private bool isAdmin;

        public FormInfo(User user, bool guest)
        {
            InitializeComponent();
            currentUser = user;
            isGuest = guest;
            isAdmin = (currentUser != null && currentUser.IdRole == 5);

            ConfigureUI();
            LoadProducts();
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else if (isGuest)
                lblUserName.Text = "Гость";
            else
                lblUserName.Text = "Не авторизован";

            btnAdd.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnDelete.Visible = isAdmin;
            btnEditDesc.Visible = isAdmin;
        }

        private void LoadProducts()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var products = db.Products
                    .Include(p => p.Group)
                    .OrderBy(p => p.Group.Id)
                    .ThenBy(p => p.Id)
                    .Select(p => new
                    {
                        Группа = p.Group.GroupName,
                        Номенклатура = p.Id,
                        Сито = p.NormSieve135mmMin != null ? $"{p.NormSieve135mmMin}%" : "-",
                        Пыль = p.NormDustMax != null ? $"{p.NormDustMax}%" : "-",
                        ПК = p.NormPk075mmMax != null ? $"{p.NormPk075mmMax}%" : "-",
                        Плотность = p.BulkDensityTarget != null ? $"{p.BulkDensityTarget} г/дм³" : "-"
                    })
                    .ToList();

                dgvProducts.DataSource = products;

                if (dgvProducts.Columns.Contains("Сито"))
                    dgvProducts.Columns["Сито"].HeaderText = "Сито (↑ лучше)";

                if (dgvProducts.Columns.Contains("Пыль"))
                    dgvProducts.Columns["Пыль"].HeaderText = "Пыль (↓ лучше)";

                if (dgvProducts.Columns.Contains("ПК"))
                    dgvProducts.Columns["ПК"].HeaderText = "ПК (↓ лучше)";

                if (dgvProducts.Columns.Contains("Группа"))
                    dgvProducts.Columns["Группа"].DisplayIndex = 0;

                if (dgvProducts.Columns.Contains("Номенклатура"))
                    dgvProducts.Columns["Номенклатура"].DisplayIndex = 1;

                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    string сито = row.Cells["Сито"].Value?.ToString() ?? "";
                    string пыль = row.Cells["Пыль"].Value?.ToString() ?? "";
                    string пк = row.Cells["ПК"].Value?.ToString() ?? "";

                    if (сито == "-" && пыль == "-" && пк == "-")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void BtnEditDesc_Click(object sender, EventArgs e)
        {
            txtDescription.ReadOnly = false;
            txtDescription.BackColor = Color.White;
            txtDescription.Focus();
            btnEditDesc.Visible = false;
            btnSaveDesc.Visible = true;
            btnCancelDesc.Visible = true;
        }

        private void BtnSaveDesc_Click(object sender, EventArgs e)
        {
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = Color.WhiteSmoke;
            btnEditDesc.Visible = true;
            btnSaveDesc.Visible = false;
            btnCancelDesc.Visible = false;
            MessageBox.Show("Описание сохранено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCancelDesc_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "Автоматизированная система учёта Цеха обогащения ПАО \"Ураласбест\"\n\n" +
                                  "Система предназначена для:\n" +
                                  "• учёта выработки хризотила по сменам\n" +
                                  "• контроля качества продукции\n" +
                                  "• учёта отгрузок и перемещений между складами\n" +
                                  "• расчёта остатков на любую дату";
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = Color.WhiteSmoke;
            btnEditDesc.Visible = true;
            btnSaveDesc.Visible = false;
            btnCancelDesc.Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormProductEdit(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            string productId = dgvProducts.CurrentRow.Cells["Номенклатура"].Value.ToString();

            using (var db = new HrizotilAccountingDbContext())
            {
                var product = db.Products.Find(productId);
                if (product != null)
                {
                    var form = new FormProductEdit(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            string productId = dgvProducts.CurrentRow.Cells["Номенклатура"].Value.ToString();

            if (MessageBox.Show($"Удалить марку {productId}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    var product = db.Products.Find(productId);
                    if (product != null)
                    {
                        db.Products.Remove(product);
                        db.SaveChanges();
                        LoadProducts();
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;
            base.OnFormClosing(e);
        }
    }
}