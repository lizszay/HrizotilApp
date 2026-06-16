using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;
using Font = System.Drawing.Font;

namespace HrizotilApp.Forms
{
    public partial class FormQuality : Form
    {
        private User currentUser;
        private bool readOnly;

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 0;
        private int totalRecords = 0;

        public FormQuality(User user, bool readOnlyMode)
        {
            InitializeComponent();
            currentUser = user;
            readOnly = readOnlyMode;

            ConfigureUI();
            LoadProductsFilter();
            LoadData();

            DataGridViewStyle.ApplyStyle(dgvData);

            this.MinimumSize = new Size(950, 550);

            dgvData.DataBindingComplete += (s, e) =>
            {
                DataGridViewStyle.SetColumnMinimumWidth(dgvData);
                ApplyRowStyles();  // ← Добавлено: сразу применяем стили после загрузки
            };
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            int userRole = currentUser?.IdRole ?? 1;
            bool canEdit = (userRole == 1 || userRole == 5);

            btnAdd.Visible = canEdit;
            btnEdit.Visible = canEdit;
            btnDelete.Visible = canEdit;

            dtpFrom.Value = new DateTime(2026, 4, 1);
            dtpTo.Value = DateTime.Today;

            if (!canEdit)
            {
                panelButtons.Visible = false;
                dgvData.Top = panelFilter.Bottom;
                dgvData.Height = this.ClientSize.Height - panelFilter.Bottom;
            }

            cmbPageSize.SelectedIndex = 2;
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
                    var query = db.Qualities
                        .Include(q => q.Product)
                        .Where(q => q.DateQuality >= DateOnly.FromDateTime(dateFrom))
                        .Where(q => q.DateQuality <= DateOnly.FromDateTime(dateTo));

                    if (selectedProduct != null && selectedProduct != "Все марки")
                        query = query.Where(q => q.IdProduct == selectedProduct);

                    totalRecords = query.Count();
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;

                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    var data = query
                        .Select(q => new
                        {
                            q.Id,
                            quality_date = q.DateQuality,
                            product_code = q.IdProduct,
                            sieve = q.Sieve135mm,
                            dust = q.Dust,
                            pk = q.Pk075mm,
                            norm_dust = q.Product.NormDustMax
                        })
                        .OrderByDescending(x => x.quality_date)
                        .ThenBy(x => x.product_code)
                        .Skip((currentPage - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    dgvData.DataSource = data;
                    SetupColumns();
                    ApplyRowStyles();  // ← Добавлено: сразу применяем стили после загрузки
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

            if (dgvData.Columns.Contains("quality_date"))
            {
                dgvData.Columns["quality_date"].HeaderText = "Дата";
                dgvData.Columns["quality_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }
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
            if (dgvData == null || dgvData.Rows.Count == 0) return;
            if (!dgvData.Columns.Contains("dust")) return;
            if (!dgvData.Columns.Contains("norm_dust")) return;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow) continue;

                // Подсветка пыли (красным), если превышает норму
                if (row.Cells["dust"].Value != null && row.Cells["norm_dust"].Value != null)
                {
                    if (int.TryParse(row.Cells["dust"].Value.ToString(), out int dust) &&
                        int.TryParse(row.Cells["norm_dust"].Value.ToString(), out int norm))
                    {
                        if (dust > norm)
                        {
                            row.Cells["dust"].Style.BackColor = Color.LightCoral;
                            row.Cells["dust"].Style.Font = new Font(dgvData.Font, FontStyle.Bold);
                        }
                        else
                        {
                            // Сбрасываем стиль если норма не превышена
                            row.Cells["dust"].Style.BackColor = Color.Empty;
                            row.Cells["dust"].Style.Font = new Font(dgvData.Font, FontStyle.Regular);
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
            using (var form = new FormQualityEdit(null))
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
                var quality = db.Qualities.Find(id);
                if (quality != null)
                {
                    using (var form = new FormQualityEdit(quality))
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
                    var quality = db.Qualities.Find(id);
                    if (quality != null)
                    {
                        db.Qualities.Remove(quality);
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