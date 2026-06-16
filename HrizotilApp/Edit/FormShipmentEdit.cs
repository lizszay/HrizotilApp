using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormShipmentEdit : Form
    {
        private Shipment editingShipment;
        private bool isEditMode;

        public FormShipmentEdit(Shipment shipment = null)
        {
            InitializeComponent();
            editingShipment = shipment;
            isEditMode = (shipment != null);

            LoadProducts();
            LoadWarehouses();

            if (isEditMode)
            {
                this.Text = "✏️ Редактирование отгрузки";
                LoadShipmentData();
            }
            else
            {
                this.Text = "➕ Добавление отгрузки";
                dtpDate.Value = DateTime.Today;
                // Устанавливаем значения по умолчанию
                if (cmbFromWarehouse.Items.Count > 0) cmbFromWarehouse.SelectedIndex = 0;
                if (cmbToWarehouse.Items.Count > 1) cmbToWarehouse.SelectedIndex = 1;
            }
        }

        private void LoadProducts()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var products = db.Products.OrderBy(p => p.Id).ToList();
                cmbProduct.DisplayMember = "Id";
                cmbProduct.ValueMember = "Id";
                cmbProduct.DataSource = products;
                if (cmbProduct.Items.Count > 0) cmbProduct.SelectedIndex = 0;
            }
        }

        private void LoadWarehouses()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var warehouses = db.Warehouses.OrderBy(w => w.Id).ToList();

                // Отображаем ID + Название, чтобы различать склады
                cmbFromWarehouse.DisplayMember = "WarehouseName";
                cmbFromWarehouse.ValueMember = "Id";
                cmbFromWarehouse.DataSource = warehouses.ToList();

                cmbToWarehouse.DisplayMember = "WarehouseName";
                cmbToWarehouse.ValueMember = "Id";
                cmbToWarehouse.DataSource = warehouses.ToList();
            }
        }

        private void LoadShipmentData()
        {
            if (editingShipment != null)
            {
                dtpDate.Value = editingShipment.DateShipment.ToDateTime(TimeOnly.MinValue);
                cmbProduct.SelectedValue = editingShipment.IdProduct;
                cmbFromWarehouse.SelectedValue = editingShipment.IdFromWarehouse;
                cmbToWarehouse.SelectedValue = editingShipment.IdToWarehouse;
                numQuantity.Value = editingShipment.Quantity;
            }
        }

        private bool ValidateData()
        {
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbFromWarehouse.SelectedValue == null || cmbToWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склады!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbFromWarehouse.SelectedValue.ToString() == cmbToWarehouse.SelectedValue.ToString())
            {
                MessageBox.Show("Склад отправитель и получатель не могут совпадать!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите марку!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            DateTime selectedDate = dtpDate.Value.Date;
            string productId = cmbProduct.SelectedValue.ToString();
            int fromWarehouse = (int)cmbFromWarehouse.SelectedValue;
            int toWarehouse = (int)cmbToWarehouse.SelectedValue;

            try
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    if (isEditMode && editingShipment != null)
                    {
                        var shipment = db.Shipments.Find(editingShipment.Id);
                        if (shipment != null)
                        {
                            shipment.DateShipment = DateOnly.FromDateTime(selectedDate);
                            shipment.IdProduct = productId;
                            shipment.IdFromWarehouse = fromWarehouse;
                            shipment.IdToWarehouse = toWarehouse;
                            shipment.Quantity = numQuantity.Value;
                            db.Entry(shipment).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        // Проверяем существование складов
                        var fromWarehouseExists = db.Warehouses.Any(w => w.Id == fromWarehouse);
                        var toWarehouseExists = db.Warehouses.Any(w => w.Id == toWarehouse);
                        var productExists = db.Products.Any(p => p.Id == productId);

                        if (!fromWarehouseExists || !toWarehouseExists || !productExists)
                        {
                            MessageBox.Show("Один из выбранных складов или марка не существует в базе!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var shipment = new Shipment
                        {
                            DateShipment = DateOnly.FromDateTime(selectedDate),
                            IdProduct = productId,
                            IdFromWarehouse = fromWarehouse,
                            IdToWarehouse = toWarehouse,
                            Quantity = numQuantity.Value
                        };
                        db.Shipments.Add(shipment);
                    }

                    db.SaveChanges();
                    MessageBox.Show("Отгрузка сохранена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex.InnerException?.Message ?? ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}