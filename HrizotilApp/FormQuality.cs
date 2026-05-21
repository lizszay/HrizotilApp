using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;
using Font = System.Drawing.Font;

namespace HrizotilApp.Forms
{
    public partial class FormQuality : Form
    {
        private User currentUser;
        private bool readOnly;

        public FormQuality(User user, bool readOnlyMode)
        {
            InitializeComponent();
            currentUser = user;
            readOnly = readOnlyMode;

            ConfigureUI();
            LoadProductsFilter();
            LoadData();

            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
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
                var query = db.Qualities
                    .Include(q => q.Product)
                    .Where(q => q.DateQuality >= DateOnly.FromDateTime(dateFrom))
                    .Where(q => q.DateQuality <= DateOnly.FromDateTime(dateTo));

                if (selectedProduct != null && selectedProduct != "Все марки")
                    query = query.Where(q => q.IdProduct == selectedProduct);

                var data = query
                    .Select(q => new
                    {
                        quality_date = q.DateQuality,
                        product_code = q.IdProduct,
                        sieve = q.Sieve135mm,
                        dust = q.Dust,
                        pk = q.Pk075mm,
                        norm_dust = q.Product.NormDustMax
                    })
                    .OrderByDescending(x => x.quality_date)
                    .ThenBy(x => x.product_code)
                    .ToList();

                dgvData.DataSource = data;
                SetupColumns();
                ApplyRowStyles();
            }
        }

        private void SetupColumns()
        {
            if (dgvData.Columns.Contains("quality_date"))
                dgvData.Columns["quality_date"].HeaderText = "Дата";
            if (dgvData.Columns.Contains("product_code"))
                dgvData.Columns["product_code"].HeaderText = "Марка";
            if (dgvData.Columns.Contains("sieve"))
                dgvData.Columns["sieve"].HeaderText = "Сито 1,35 мм, %";
            if (dgvData.Columns.Contains("dust"))
                dgvData.Columns["dust"].HeaderText = "Пыль, %";
            if (dgvData.Columns.Contains("pk"))
                dgvData.Columns["pk"].HeaderText = "ПК, %";
            if (dgvData.Columns.Contains("norm_dust"))
                dgvData.Columns["norm_dust"].Visible = false;
        }

        private void ApplyRowStyles()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["dust"].Value != null && row.Cells["norm_dust"].Value != null)
                {
                    int dust = Convert.ToInt32(row.Cells["dust"].Value);
                    int norm = Convert.ToInt32(row.Cells["norm_dust"].Value);

                    if (dust > norm)
                    {
                        row.Cells["dust"].Style.BackColor = Color.LightCoral;
                        row.Cells["dust"].Style.Font = new Font(dgvData.Font, FontStyle.Bold);
                    }
                }

                // Пустые значения ПК
                if (row.Cells["pk"].Value == null || string.IsNullOrEmpty(row.Cells["pk"].Value.ToString()))
                {
                    row.Cells["pk"].Style.BackColor = Color.LightGray;
                    row.Cells["pk"].Style.Font = new Font(dgvData.Font, FontStyle.Italic);
                }
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
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
            MessageBox.Show("Добавление качества (в разработке)");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редактирование качества (в разработке)");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Удаление качества (в разработке)");
        }
    }
}