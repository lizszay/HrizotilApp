using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormProductionEdit : Form
    {
        private Production editingProduction;
        private bool isEditMode;
        private DateTime editDate;
        private string editProductId;

        // Конструктор для добавления
        public FormProductionEdit(Production production = null)
        {
            InitializeComponent();

            if (production != null)
            {
                isEditMode = true;
                editingProduction = production;
                this.Text = "✏️ Редактирование выработки";
                LoadProducts();
                LoadProductionData();
            }
            else
            {
                isEditMode = false;
                this.Text = "➕ Добавление выработки";
                LoadProducts();
                dtpDate.Value = DateTime.Today;
                if (cmbShift.Items.Count > 0)
                    cmbShift.SelectedIndex = 0;
            }
        }

        // Конструктор для редактирования по дате и марке
        public FormProductionEdit(DateTime date, string productId)
        {
            InitializeComponent();
            isEditMode = true;
            editDate = date;
            editProductId = productId;
            this.Text = "✏️ Редактирование выработки";

            LoadProducts();
            LoadProductionDataByDate(date, productId);
        }

        private void LoadProducts()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var products = db.Products.OrderBy(p => p.Id).ToList();
                products.Insert(0, new Product { Id = "", IdGroup = 0 });

                cmbProduct.DisplayMember = "Id";
                cmbProduct.ValueMember = "Id";
                cmbProduct.DataSource = products;

                if (!isEditMode)
                    cmbProduct.SelectedIndex = 0;
            }
        }

        private void LoadProductionData()
        {
            if (editingProduction != null)
            {
                dtpDate.Value = editingProduction.DateProduction.ToDateTime(TimeOnly.MinValue);
                cmbProduct.SelectedValue = editingProduction.IdProduct;
                cmbShift.SelectedItem = editingProduction.Shift;
                numPlan.Value = editingProduction.PlanQuantity;
                numFact.Value = editingProduction.FactQuantity;

                // РАЗБЛОКИРОВЫВАЕМ ВСЕ ПОЛЯ ДЛЯ РЕДАКТИРОВАНИЯ
                dtpDate.Enabled = true;
                cmbProduct.Enabled = true;
                cmbShift.Enabled = true;
                numPlan.Enabled = true;
                numFact.Enabled = true;
            }
        }

        private void LoadProductionDataByDate(DateTime date, string productId)
        {
            dtpDate.Value = date;
            cmbProduct.SelectedValue = productId;
            dtpDate.Enabled = false;
            cmbProduct.Enabled = false;
            cmbShift.Enabled = true;

            using (var db = new HrizotilAccountingDbContext())
            {
                var existingShifts = db.Productions
                    .Where(p => p.DateProduction == DateOnly.FromDateTime(date) &&
                                p.IdProduct == productId)
                    .Select(p => p.Shift)
                    .ToList();

                // Показываем только те смены, которые ещё не заняты
                cmbShift.Items.Clear();
                foreach (int i in new int[] { 1, 2, 3 })
                {
                    if (!existingShifts.Contains(i))
                        cmbShift.Items.Add(i);
                }

                if (cmbShift.Items.Count > 0)
                {
                    cmbShift.SelectedIndex = 0;
                    numPlan.Value = 0;
                    numFact.Value = 0;
                }
                else
                {
                    MessageBox.Show("Все смены за этот день уже заполнены!\n" +
                        "Выберите другую дату или марку.",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private bool ValidateData()
        {
            if (numPlan.Value < 0)
            {
                MessageBox.Show("План не может быть отрицательным!",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numFact.Value < 0)
            {
                MessageBox.Show("Факт не может быть отрицательным!",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbShift.SelectedItem == null)
            {
                MessageBox.Show("Выберите смену!",
                    "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsDuplicate(DateTime date, string productId, int shift, int? excludeId = null)
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var query = db.Productions
                    .Where(p => p.DateProduction == DateOnly.FromDateTime(date))
                    .Where(p => p.IdProduct == productId)
                    .Where(p => p.Shift == shift);

                if (excludeId.HasValue)
                    query = query.Where(p => p.Id != excludeId.Value);

                return query.Any();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            DateTime selectedDate = dtpDate.Value.Date;
            string productId = cmbProduct.SelectedValue?.ToString();
            int shift = Convert.ToInt32(cmbShift.SelectedItem);

            if (string.IsNullOrEmpty(productId))
            {
                MessageBox.Show("Выберите марку продукции!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    if (isEditMode && editingProduction != null)
                    {
                        // РЕДАКТИРОВАНИЕ
                        var production = db.Productions.Find(editingProduction.Id);
                        if (production != null)
                        {
                            // Проверка на дубликат (исключая текущую запись)
                            if (IsDuplicate(selectedDate, productId, shift, editingProduction.Id))
                            {
                                MessageBox.Show("Запись за эту дату, марку и смену уже существует!\n" +
                                    "Измените дату, марку или смену.",
                                    "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            production.DateProduction = DateOnly.FromDateTime(selectedDate);
                            production.IdProduct = productId;
                            production.Shift = shift;
                            production.PlanQuantity = (int)numPlan.Value;
                            production.FactQuantity = numFact.Value;

                            db.SaveChanges();
                            MessageBox.Show("Запись обновлена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        // ДОБАВЛЕНИЕ
                        if (IsDuplicate(selectedDate, productId, shift))
                        {
                            MessageBox.Show("Запись за эту дату, марку и смену уже существует!\n" +
                                "Используйте редактирование для изменения существующей записи.",
                                "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var newProduction = new Production
                        {
                            DateProduction = DateOnly.FromDateTime(selectedDate),
                            IdProduct = productId,
                            Shift = shift,
                            PlanQuantity = (int)numPlan.Value,
                            FactQuantity = numFact.Value
                        };

                        db.Productions.Add(newProduction);
                        db.SaveChanges();
                        MessageBox.Show("Запись добавлена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}\n{ex.InnerException?.Message}",
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