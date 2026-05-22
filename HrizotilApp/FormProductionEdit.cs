using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormProductionEdit : Form
    {
        private Production editingProduction;
        private bool isEditMode;

        public FormProductionEdit(Production production = null)
        {
            InitializeComponent();
            editingProduction = production;
            isEditMode = (production != null);

            LoadProducts();

            if (isEditMode)
            {
                this.Text = "✏️ Редактирование выработки";
                LoadProductionData();
            }
            else
            {
                this.Text = "➕ Добавление выработки";
                dtpDate.Value = DateTime.Today;
                if (cmbShift.Items.Count > 0)
                    cmbShift.SelectedIndex = 0;
            }
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
            string productId = cmbProduct.SelectedValue.ToString();
            int shift = Convert.ToInt32(cmbShift.SelectedItem);

            // Проверка на дубликат
            if (!isEditMode && IsDuplicate(selectedDate, productId, shift))
            {
                MessageBox.Show("Запись за эту дату, марку и смену уже существует!\n" +
                    "Используйте редактирование для изменения существующей записи.",
                    "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEditMode && IsDuplicate(selectedDate, productId, shift, editingProduction.Id))
            {
                MessageBox.Show("Запись за эту дату, марку и смену уже существует!\n" +
                    "Измените дату, марку или смену.",
                    "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    if (isEditMode)
                    {
                        var production = db.Productions.Find(editingProduction.Id);
                        if (production != null)
                        {
                            production.DateProduction = DateOnly.FromDateTime(selectedDate);
                            production.IdProduct = productId;
                            production.Shift = shift;
                            production.PlanQuantity = (int)numPlan.Value;
                            production.FactQuantity = numFact.Value;
                            db.Entry(production).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        var production = new Production
                        {
                            DateProduction = DateOnly.FromDateTime(selectedDate),
                            IdProduct = productId,
                            Shift = shift,
                            PlanQuantity = (int)numPlan.Value,
                            FactQuantity = numFact.Value
                        };
                        db.Productions.Add(production);
                    }

                    db.SaveChanges();

                    // Важно: устанавливаем DialogResult и закрываем форму
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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