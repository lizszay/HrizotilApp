using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormProductions : Form
    {
        private User currentUser;
        private bool readOnly;

        // Параметры пагинации
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 0;
        private int totalRecords = 0;

        public FormProductions(User user, bool readOnlyMode)
        {
            InitializeComponent();
            currentUser = user;
            readOnly = readOnlyMode;

            ConfigureUI();
            LoadProductsFilter();
            LoadData();

            DataGridViewStyle.ApplyStyle(dgvData);

            this.MinimumSize = new Size(1500, 550);

            dgvData.DataBindingComplete += (s, e) =>
            {
                DataGridViewStyle.SetColumnMinimumWidth(dgvData);
                DataGridViewStyle.RefreshRowHeights(dgvData);
                ApplyRowStyles();
            };
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            int userRole = currentUser?.IdRole ?? 1;
            bool canEdit = (userRole == 2 || userRole == 5);

            btnAdd.Visible = canEdit;
            btnEdit.Visible = canEdit;
            btnDelete.Visible = canEdit;

            dtpFrom.Value = new DateTime(2026, 4, 1);
            dtpTo.Value = DateTime.Today;

            // Если кнопок нет - поднимаем таблицу вверх
            if (!canEdit)
            {
                panelButtons.Visible = false;
                dgvData.Top = panelFilter.Bottom;
                dgvData.Height = this.ClientSize.Height - panelFilter.Bottom;
            }
        }

        private void LoadProductsFilter()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var products = db.Products.OrderBy(p => p.Id).Select(p => p.Id).ToList();
                cmbProduct.Items.Clear();
                cmbProduct.Items.Add("Все марки");
                foreach (var product in products)
                    cmbProduct.Items.Add(product);
                cmbProduct.SelectedIndex = 0;
            }
        }

        private void LoadData()
        {
            Cursor = Cursors.WaitCursor;
            dgvData.Enabled = false;

            try
            {
                DateTime dateFrom = dtpFrom.Value.Date;
                DateTime dateTo = dtpTo.Value.Date;
                string selectedProduct = cmbProduct.SelectedItem?.ToString();

                using (var db = new HrizotilAccountingDbContext())
                {
                    var query = db.Productions
                        .Where(p => p.DateProduction >= DateOnly.FromDateTime(dateFrom))
                        .Where(p => p.DateProduction <= DateOnly.FromDateTime(dateTo));

                    if (selectedProduct != null && selectedProduct != "Все марки")
                        query = query.Where(p => p.IdProduct == selectedProduct);

                    // Получаем общее количество записей (групп)
                    totalRecords = query
                        .GroupBy(p => new { p.DateProduction, p.IdProduct })  // ← БЕЗ Id
                        .Count();

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;

                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    // Группировка по дате и марке - ОДНА СТРОКА НА ДЕНЬ
                    var data = query
                         .GroupBy(p => new { p.DateProduction, p.IdProduct })
                         .Select(g => new
                         {
                             Id = g.Min(p => p.Id),
                             DateProduction = g.Key.DateProduction,
                             IdProduct = g.Key.IdProduct,
                             PlanShift1 = g.Where(x => x.Shift == 1).Sum(x => x.PlanQuantity),
                             FactShift1 = g.Where(x => x.Shift == 1).Sum(x => x.FactQuantity),
                             PlanShift2 = g.Where(x => x.Shift == 2).Sum(x => x.PlanQuantity),
                             FactShift2 = g.Where(x => x.Shift == 2).Sum(x => x.FactQuantity),
                             PlanShift3 = g.Where(x => x.Shift == 3).Sum(x => x.PlanQuantity),
                             FactShift3 = g.Where(x => x.Shift == 3).Sum(x => x.FactQuantity),
                             DailyPlan = g.Sum(x => x.PlanQuantity),
                             DailyFact = g.Sum(x => x.FactQuantity),
                             Deviation = g.Sum(x => x.FactQuantity) - g.Sum(x => x.PlanQuantity)
                         })
                         .OrderByDescending(x => x.DateProduction)
                         .ThenBy(x => x.IdProduct)
                         .Skip((currentPage - 1) * pageSize)
                         .Take(pageSize)
                         .ToList();

                    var displayData = data.Select(d => new
                    {
                        d.Id,
                        d.DateProduction,
                        d.IdProduct,
                        PlanShift1 = d.PlanShift1 == 0 ? "—" : d.PlanShift1.ToString(),
                        FactShift1 = d.FactShift1 == 0 ? "—" : d.FactShift1.ToString(),
                        PlanShift2 = d.PlanShift2 == 0 ? "—" : d.PlanShift2.ToString(),
                        FactShift2 = d.FactShift2 == 0 ? "—" : d.FactShift2.ToString(),
                        PlanShift3 = d.PlanShift3 == 0 ? "—" : d.PlanShift3.ToString(),
                        FactShift3 = d.FactShift3 == 0 ? "—" : d.FactShift3.ToString(),
                        DailyPlan = d.DailyPlan,
                        DailyFact = d.DailyFact,
                        Deviation = d.Deviation
                    }).ToList();

                    dgvData.DataSource = displayData;
                    SetupColumns();
                    UpdatePaginationControls();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
                dgvData.Enabled = true;
            }
        }

        private void UpdatePaginationControls()
        {
            btnFirst.Enabled = currentPage > 1;
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
            btnLast.Enabled = currentPage < totalPages;

            lblPageInfo.Text = $"Страница {currentPage} из {(totalPages == 0 ? 1 : totalPages)}";
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadData();
        }

        private void CmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(cmbPageSize.SelectedItem);
            currentPage = 1;
            LoadData();
        }

        private void SetupColumns()
        {
            if (dgvData.Columns.Contains("Id"))
                dgvData.Columns["Id"].Visible = false;

            if (dgvData.Columns.Contains("DateProduction"))
            {
                dgvData.Columns["DateProduction"].HeaderText = "Дата";
                dgvData.Columns["DateProduction"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
            if (dgvData.Columns.Contains("IdProduct"))
                dgvData.Columns["IdProduct"].HeaderText = "Марка";
            if (dgvData.Columns.Contains("PlanShift1"))
                dgvData.Columns["PlanShift1"].HeaderText = "См1 План";
            if (dgvData.Columns.Contains("FactShift1"))
                dgvData.Columns["FactShift1"].HeaderText = "См1 Факт";
            if (dgvData.Columns.Contains("PlanShift2"))
                dgvData.Columns["PlanShift2"].HeaderText = "См2 План";
            if (dgvData.Columns.Contains("FactShift2"))
                dgvData.Columns["FactShift2"].HeaderText = "См2 Факт";
            if (dgvData.Columns.Contains("PlanShift3"))
                dgvData.Columns["PlanShift3"].HeaderText = "См3 План";
            if (dgvData.Columns.Contains("FactShift3"))
                dgvData.Columns["FactShift3"].HeaderText = "См3 Факт";
            if (dgvData.Columns.Contains("DailyPlan"))
                dgvData.Columns["DailyPlan"].HeaderText = "Сутки План";
            if (dgvData.Columns.Contains("DailyFact"))
                dgvData.Columns["DailyFact"].HeaderText = "Сутки Факт";
            if (dgvData.Columns.Contains("Deviation"))
                dgvData.Columns["Deviation"].HeaderText = "Отклонение";
        }

        private void ApplyRowStyles()
        {
            if (dgvData == null || dgvData.Rows.Count == 0) return;
            if (!dgvData.Columns.Contains("Deviation")) return;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;

                var deviationCell = row.Cells["Deviation"];
                if (deviationCell != null && deviationCell.Value != null)
                {
                    if (decimal.TryParse(deviationCell.Value.ToString(), out decimal diff))
                    {
                        if (diff < 0)
                        {
                            deviationCell.Style.BackColor = Color.LightCoral;
                            deviationCell.Style.Font = new Font(dgvData.Font, FontStyle.Bold);
                        }
                        else
                        {
                            deviationCell.Style.BackColor = Color.Empty;
                            deviationCell.Style.Font = new Font(dgvData.Font, FontStyle.Regular);
                        }
                    }
                }
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("Начальная дата не может быть больше конечной!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTo.Value = dtpFrom.Value;
                return;
            }
            currentPage = 1;
            LoadData();
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormProductionEdit(null))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для редактирования!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvData.SelectedRows[0];

            // Получаем Id записи
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            using (var db = new HrizotilAccountingDbContext())
            {
                var production = db.Productions.Find(id);
                if (production != null)
                {
                    // ОТКРЫВАЕМ РЕДАКТИРОВАНИЕ СРАЗУ
                    using (var form = new FormProductionEdit(production))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Запись не найдена!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvData.SelectedRows[0];

            // Получаем дату и марку
            DateOnly dateOnly = (DateOnly)row.Cells["DateProduction"].Value;
            DateTime date = dateOnly.ToDateTime(TimeOnly.MinValue);
            string productId = row.Cells["IdProduct"].Value.ToString();

            using (var db = new HrizotilAccountingDbContext())
            {
                var productions = db.Productions
                    .Where(p => p.DateProduction == DateOnly.FromDateTime(date) &&
                                p.IdProduct == productId)
                    .OrderBy(p => p.Shift)
                    .ToList();

                if (!productions.Any())
                {
                    MessageBox.Show("Нет записей для удаления!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Открываем форму выбора смен для удаления
                using (var deleteForm = new FormDeleteShifts(date, productId, productions))
                {
                    if (deleteForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        MessageBox.Show("Выбранные смены удалены!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}