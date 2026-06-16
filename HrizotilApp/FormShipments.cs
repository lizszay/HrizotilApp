using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;
using Font = System.Drawing.Font;

namespace HrizotilApp.Forms
{
    public partial class FormShipments : Form
    {
        private User currentUser;
        private bool readOnly;

        public FormShipments(User user, bool readOnlyMode)
        {
            InitializeComponent();
            currentUser = user;
            readOnly = readOnlyMode;

            ConfigureUI();
            LoadProductsFilter();
            LoadData();

            DataGridViewStyle.ApplyStyle(dgvData);

            this.MinimumSize = new Size(1000, 550);

            dgvData.DataBindingComplete += (s, e) =>
            {
                DataGridViewStyle.SetColumnMinimumWidth(dgvData);
            };
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";

            int userRole = currentUser?.IdRole ?? 1;
            bool canEdit = (userRole == 3 || userRole == 5);

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
            DateTime dateFrom = dtpFrom.Value.Date;
            DateTime dateTo = dtpTo.Value.Date;
            string selectedProduct = cmbProduct.SelectedItem?.ToString();

            using (var db = new HrizotilAccountingDbContext())
            {
                var query = db.Shipments
                    .Include(s => s.Product)
                    .Include(s => s.FromWarehouse)
                    .Include(s => s.ToWarehouse)
                    .Where(s => s.DateShipment >= DateOnly.FromDateTime(dateFrom))
                    .Where(s => s.DateShipment <= DateOnly.FromDateTime(dateTo));

                if (selectedProduct != null && selectedProduct != "Все марки")
                    query = query.Where(s => s.IdProduct == selectedProduct);

                var data = query
                    .Select(s => new
                    {
                        s.Id,  
                        shipment_date = s.DateShipment,
                        from_warehouse = s.FromWarehouse.WarehouseName,
                        to_warehouse = s.ToWarehouse.WarehouseName,
                        product_code = s.IdProduct,
                        quantity = s.Quantity
                    })
                    .OrderByDescending(x => x.shipment_date)
                    .ThenBy(x => x.product_code)
                    .ToList();

                dgvData.DataSource = data;
                SetupColumns();
            }
        }

        private void SetupColumns()
        {
            if (dgvData.Columns.Contains("Id"))
                dgvData.Columns["Id"].Visible = false;
            if (dgvData.Columns.Contains("shipment_date"))
                dgvData.Columns["shipment_date"].HeaderText = "Дата";
            if (dgvData.Columns.Contains("from_warehouse"))
                dgvData.Columns["from_warehouse"].HeaderText = "Склад отправитель";
            if (dgvData.Columns.Contains("to_warehouse"))
                dgvData.Columns["to_warehouse"].HeaderText = "Склад получатель";
            if (dgvData.Columns.Contains("product_code"))
                dgvData.Columns["product_code"].HeaderText = "Марка";
            if (dgvData.Columns.Contains("quantity"))
                dgvData.Columns["quantity"].HeaderText = "Количество, т";
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
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormShipmentEdit(null))
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
                var shipment = db.Shipments.Find(id);
                if (shipment != null)
                {
                    using (var form = new FormShipmentEdit(shipment))
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
                    var shipment = db.Shipments.Find(id);
                    if (shipment != null)
                    {
                        db.Shipments.Remove(shipment);
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