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
            DataGridViewStyle.ApplyStyle(dgvProducts);
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else if (isGuest)
                lblUserName.Text = "Гость";
            else
                lblUserName.Text = "Не авторизован";

            int userRole = currentUser?.IdRole ?? 1;

            // Только админ может редактировать описание
            btnEditDesc.Visible = (userRole == 5); // Админ - роль 5

            // Кнопка "Назад" видна для всех (кроме гостя, у которого нет меню)
            btnBack.Visible = !isGuest;

            // Кнопки редактирования марок скрыты для всех
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void SetupDataGridViewStyle()
        {
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducts.GridColor = Color.FromArgb(230, 230, 230);
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.RowTemplate.Height = 35;

            // Стиль заголовков
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.ColumnHeadersHeight = 40;

            // Стиль ячеек
            dgvProducts.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgvProducts.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvProducts.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProducts.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);

            // Чередующиеся строки
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);
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
                        Сито = p.NormSieve135mmMin != null ? $"{p.NormSieve135mmMin}%" : "—",
                        Пыль = p.NormDustMax != null ? $"{p.NormDustMax}%" : "—",
                        ПК = p.NormPk075mmMax != null ? $"{p.NormPk075mmMax}%" : "—",
                        Плотность = p.BulkDensityTarget != null ? $"{p.BulkDensityTarget} г/дм³" : "—"
                    })
                    .ToList();

                dgvProducts.DataSource = products;

                // Настройка заголовков и выравнивания
                if (dgvProducts.Columns.Contains("Группа"))
                {
                    dgvProducts.Columns["Группа"].HeaderText = "Группа";
                    dgvProducts.Columns["Группа"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                if (dgvProducts.Columns.Contains("Номенклатура"))
                {
                    dgvProducts.Columns["Номенклатура"].HeaderText = "Марка";
                    dgvProducts.Columns["Номенклатура"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvProducts.Columns["Номенклатура"].DefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
                }

                if (dgvProducts.Columns.Contains("Сито"))
                {
                    dgvProducts.Columns["Сито"].HeaderText = "Сито (↑ лучше)";
                    dgvProducts.Columns["Сито"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvProducts.Columns.Contains("Пыль"))
                {
                    dgvProducts.Columns["Пыль"].HeaderText = "Пыль (↓ лучше)";
                    dgvProducts.Columns["Пыль"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvProducts.Columns.Contains("ПК"))
                {
                    dgvProducts.Columns["ПК"].HeaderText = "ПК (↓ лучше)";
                    dgvProducts.Columns["ПК"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvProducts.Columns.Contains("Плотность"))
                {
                    dgvProducts.Columns["Плотность"].HeaderText = "Плотность";
                    dgvProducts.Columns["Плотность"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Применяем стили к строкам
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    string сито = row.Cells["Сито"].Value?.ToString() ?? "";
                    string пыль = row.Cells["Пыль"].Value?.ToString() ?? "";
                    string пк = row.Cells["ПК"].Value?.ToString() ?? "";

                    // Если все нормы отсутствуют - серый фон
                    if (сито == "—" && пыль == "—" && пк == "—")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                    }

                    // Подсветка лучших показателей
                    if (пыль != "—")
                    {
                        decimal dustValue = decimal.Parse(пыль.Replace("%", ""));
                        if (dustValue < 1.5m)
                        {
                            row.Cells["Пыль"].Style.BackColor = Color.FromArgb(200, 230, 200);
                            row.Cells["Пыль"].Style.ForeColor = Color.DarkGreen;
                        }
                    }

                    if (пк != "—")
                    {
                        decimal pkValue = decimal.Parse(пк.Replace("%", ""));
                        if (pkValue < 2.5m)
                        {
                            row.Cells["ПК"].Style.BackColor = Color.FromArgb(200, 230, 200);
                            row.Cells["ПК"].Style.ForeColor = Color.DarkGreen;
                        }
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
            txtDescription.BackColor = Color.FromArgb(248, 248, 248);
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
            txtDescription.BackColor = Color.FromArgb(248, 248, 248);
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