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
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            btnAdd.Visible = !readOnly;
            btnEdit.Visible = !readOnly;
            btnDelete.Visible = !readOnly;

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
                    .GroupBy(p => new { p.DateProduction, p.IdProduct })
                    .Select(g => new
                    {
                        prod_date = g.Key.DateProduction,
                        prod_code = g.Key.IdProduct,
                        shift1_plan = g.Where(x => x.Shift == 1).Select(x => x.PlanQuantity).FirstOrDefault(),
                        shift1_fact = g.Where(x => x.Shift == 1).Select(x => x.FactQuantity).FirstOrDefault(),
                        shift2_plan = g.Where(x => x.Shift == 2).Select(x => x.PlanQuantity).FirstOrDefault(),
                        shift2_fact = g.Where(x => x.Shift == 2).Select(x => x.FactQuantity).FirstOrDefault(),
                        shift3_plan = g.Where(x => x.Shift == 3).Select(x => x.PlanQuantity).FirstOrDefault(),
                        shift3_fact = g.Where(x => x.Shift == 3).Select(x => x.FactQuantity).FirstOrDefault(),
                        daily_plan = g.Sum(x => x.PlanQuantity),
                        daily_fact = g.Sum(x => x.FactQuantity),
                        daily_diff = g.Sum(x => x.FactQuantity) - g.Sum(x => x.PlanQuantity)
                    })
                    .OrderByDescending(x => x.prod_date)
                    .ThenBy(x => x.prod_code)
                    .ToList();

                dgvData.DataSource = data;
                SetupColumns();
                ApplyRowStyles();  // ← сразу после установки данных
            }
        }

        private void SetupColumns()
        {
            if (dgvData.Columns.Contains("prod_date"))
                dgvData.Columns["prod_date"].HeaderText = "Дата";
            if (dgvData.Columns.Contains("prod_code"))
                dgvData.Columns["prod_code"].HeaderText = "Номенклатура";
            if (dgvData.Columns.Contains("shift1_plan"))
                dgvData.Columns["shift1_plan"].HeaderText = "См1 План";
            if (dgvData.Columns.Contains("shift1_fact"))
                dgvData.Columns["shift1_fact"].HeaderText = "См1 Факт";
            if (dgvData.Columns.Contains("shift2_plan"))
                dgvData.Columns["shift2_plan"].HeaderText = "См2 План";
            if (dgvData.Columns.Contains("shift2_fact"))
                dgvData.Columns["shift2_fact"].HeaderText = "См2 Факт";
            if (dgvData.Columns.Contains("shift3_plan"))
                dgvData.Columns["shift3_plan"].HeaderText = "См3 План";
            if (dgvData.Columns.Contains("shift3_fact"))
                dgvData.Columns["shift3_fact"].HeaderText = "См3 Факт";
            if (dgvData.Columns.Contains("daily_plan"))
                dgvData.Columns["daily_plan"].HeaderText = "Сутки План";
            if (dgvData.Columns.Contains("daily_fact"))
                dgvData.Columns["daily_fact"].HeaderText = "Сутки Факт";
            if (dgvData.Columns.Contains("daily_diff"))
                dgvData.Columns["daily_diff"].HeaderText = "Отклонение";
        }

        private void ApplyRowStyles()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["daily_diff"].Value != null)
                {
                    decimal diff = Convert.ToDecimal(row.Cells["daily_diff"].Value);
                    if (diff < 0)
                    {
                        // Только ячейка отклонения — красный фон
                        row.Cells["daily_diff"].Style.BackColor = Color.LightCoral;
                        row.Cells["daily_diff"].Style.Font = new Font(dgvData.Font, FontStyle.Bold);
                    }
                    else if (diff > 0)
                    {
                        // Только ячейка отклонения — зелёный текст
                        row.Cells["daily_diff"].Style.ForeColor = Color.Green;
                        row.Cells["daily_diff"].Style.Font = new Font(dgvData.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadData();  // при фильтрации тоже перезагружаем с подсветкой
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
            MessageBox.Show("Добавление выработки (в разработке)");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редактирование выработки (в разработке)");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удаление выработки (в разработке)");
        }
    }
}