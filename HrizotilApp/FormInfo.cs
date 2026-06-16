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

            this.MinimumSize = new Size(900, 550);

            dgvProducts.DataBindingComplete += (s, e) =>
            {
                DataGridViewStyle.SetColumnMinimumWidth(dgvProducts);
            };
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

            btnEditDesc.Visible = (userRole == 5);

            bool canEditProducts = (userRole == 5);
            btnAdd.Visible = canEditProducts;
            btnEdit.Visible = canEditProducts;
            btnDelete.Visible = canEditProducts;

            btnBack.Visible = !isGuest;

            if (isGuest)
            {
                btnLogout.Location = new Point(10, 5);
            }

            // Если кнопок марок нет - поднимаем таблицу вверх
            if (!canEditProducts)
            {
                panelButtons.Visible = false;
                dgvProducts.Top = panelDescription.Bottom;
                dgvProducts.Height = this.ClientSize.Height - panelDescription.Bottom;
            }

            txtDescription.Text = GetDescriptionText();
        }

        private string GetDescriptionText()
        {
            return
                "Автоматизированная система учёта хризотила Цеха обогащения ПАО «Ураласбест».\r\n" +
        "Обеспечивает учёт выработки по сменам, контроль качества, отгрузки и расчёт остатков.\r\n" +
            "                                                                    \r\n" +
                "  Технологии: C#, WinForms, PostgreSQL, EF Core                     \r\n" +
                "                                                                    \r\n" +
                "  © ПАО «Ураласбест», 2026 г.                                       ";
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
                SetupProductColumns();
                ApplyProductRowStyles();
            }
        }

        private void SetupProductColumns()
        {
            if (dgvProducts.Columns.Contains("Группа"))
            {
                dgvProducts.Columns["Группа"].HeaderText = "Группа";
                dgvProducts.Columns["Группа"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvProducts.Columns.Contains("Номенклатура"))
            {
                dgvProducts.Columns["Номенклатура"].HeaderText = "Марка";
                dgvProducts.Columns["Номенклатура"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
        }

        private void ApplyProductRowStyles()
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                string сито = row.Cells["Сито"].Value?.ToString() ?? "";
                string пыль = row.Cells["Пыль"].Value?.ToString() ?? "";
                string пк = row.Cells["ПК"].Value?.ToString() ?? "";

                if (сито == "—" && пыль == "—" && пк == "—")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }

                if (пыль != "—" && decimal.TryParse(пыль.Replace("%", ""), out decimal dustValue))
                {
                    if (dustValue < 1.5m)
                    {
                        row.Cells["Пыль"].Style.BackColor = Color.FromArgb(200, 230, 200);
                        row.Cells["Пыль"].Style.ForeColor = Color.DarkGreen;
                    }
                }

                if (пк != "—" && decimal.TryParse(пк.Replace("%", ""), out decimal pkValue))
                {
                    if (pkValue < 2.5m)
                    {
                        row.Cells["ПК"].Style.BackColor = Color.FromArgb(200, 230, 200);
                        row.Cells["ПК"].Style.ForeColor = Color.DarkGreen;
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
            txtDescription.Text = GetDescriptionText();
            txtDescription.ReadOnly = true;
            txtDescription.BackColor = Color.FromArgb(248, 248, 248);
            btnEditDesc.Visible = true;
            btnSaveDesc.Visible = false;
            btnCancelDesc.Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавление марок в разработке", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редактирование марок в разработке", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            string productId = dgvProducts.CurrentRow.Cells["Номенклатура"].Value.ToString();
            string group = dgvProducts.CurrentRow.Cells["Группа"].Value.ToString();

            DialogResult result = MessageBox.Show($"Удалить марку {productId} (группа {group})?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    var product = db.Products.Find(productId);
                    if (product != null)
                    {
                        db.Products.Remove(product);
                        db.SaveChanges();
                        LoadProducts();
                        MessageBox.Show("Марка удалена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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