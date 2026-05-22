using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormProductions : Form
    {
        private User currentUser;
        private bool readOnly;

        public FormProductions(User user, bool readOnlyMode)
        {
            InitializeComponent();
            currentUser = user;
            readOnly = readOnlyMode;

            ConfigureUI();
            LoadProductsFilter();
            LoadData();

            DataGridViewStyle.ApplyStyle(dgvData);
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            int userRole = currentUser?.IdRole ?? 1;

            // Редактировать: Мастер смены (2) и Админ (5)
            bool canEdit = (userRole == 2 || userRole == 6);

            btnAdd.Visible = canEdit;
            btnEdit.Visible = canEdit;
            btnDelete.Visible = canEdit;

            dtpFrom.Value = new DateTime(2026, 4, 1);
            dtpTo.Value = new DateTime(2026, 5, 21);
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

                var data = query
                    .GroupBy(p => new { p.Id, p.DateProduction, p.IdProduct })
                    .Select(g => new
                    {
                        g.Key.Id,
                        g.Key.DateProduction,
                        g.Key.IdProduct,
                        PlanShift1 = g.Where(x => x.Shift == 1).Select(x => x.PlanQuantity).FirstOrDefault(),
                        FactShift1 = g.Where(x => x.Shift == 1).Select(x => x.FactQuantity).FirstOrDefault(),
                        PlanShift2 = g.Where(x => x.Shift == 2).Select(x => x.PlanQuantity).FirstOrDefault(),
                        FactShift2 = g.Where(x => x.Shift == 2).Select(x => x.FactQuantity).FirstOrDefault(),
                        PlanShift3 = g.Where(x => x.Shift == 3).Select(x => x.PlanQuantity).FirstOrDefault(),
                        FactShift3 = g.Where(x => x.Shift == 3).Select(x => x.FactQuantity).FirstOrDefault(),
                        DailyPlan = g.Sum(x => x.PlanQuantity),
                        DailyFact = g.Sum(x => x.FactQuantity),
                        Deviation = g.Sum(x => x.FactQuantity) - g.Sum(x => x.PlanQuantity)
                    })
                    .OrderByDescending(x => x.DateProduction)
                    .ThenBy(x => x.IdProduct)
                    .ToList();

                dgvData.DataSource = data;
                SetupColumns();
                ApplyRowStyles();

                // Автоширина колонок
                dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
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
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["Deviation"].Value != null)
                {
                    decimal diff = Convert.ToDecimal(row.Cells["Deviation"].Value);
                    if (diff < 0)
                    {
                        row.Cells["Deviation"].Style.BackColor = Color.LightCoral;
                        row.Cells["Deviation"].Style.Font = new Font(dgvData.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells["Deviation"].Style.BackColor = Color.Empty;
                        row.Cells["Deviation"].Style.Font = new Font(dgvData.Font, FontStyle.Regular);
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
            LoadData();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // Закрываем все формы и показываем форму входа
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

            int id = Convert.ToInt32(dgvData.SelectedRows[0].Cells["Id"].Value);

            using (var db = new HrizotilAccountingDbContext())
            {
                var production = db.Productions.Find(id);
                if (production != null)
                {
                    using (var form = new FormProductionEdit(production))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
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

            int id = Convert.ToInt32(dgvData.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    var production = db.Productions.Find(id);
                    if (production != null)
                    {
                        db.Productions.Remove(production);
                        db.SaveChanges();
                        LoadData();
                        MessageBox.Show("Запись успешно удалена!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}