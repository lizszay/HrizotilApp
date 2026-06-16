using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormQualityEdit : Form
    {
        private Quality editingQuality;
        private bool isEditMode;

        public FormQualityEdit(Quality quality = null)
        {
            InitializeComponent();
            editingQuality = quality;
            isEditMode = (quality != null);

            LoadProducts();

            if (isEditMode)
            {
                this.Text = "✏️ Редактирование качества";
                LoadQualityData();
            }
            else
            {
                this.Text = "➕ Добавление качества";
                dtpDate.Value = DateTime.Today;
                cmbProduct.SelectedIndex = 0;
                numSieve.Value = 0;
                numDust.Value = 0;
                numPk.Value = 0;
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
            }
        }

        private void LoadQualityData()
        {
            if (editingQuality != null)
            {
                dtpDate.Value = editingQuality.DateQuality.ToDateTime(TimeOnly.MinValue);
                cmbProduct.SelectedValue = editingQuality.IdProduct;
                numSieve.Value = editingQuality.Sieve135mm ?? 0;
                numDust.Value = editingQuality.Dust ?? 0;
                numPk.Value = editingQuality.Pk075mm ?? 0;
            }
        }

        private bool ValidateData()
        {
            if (numSieve.Value < 0)
            {
                MessageBox.Show("Сито не может быть отрицательным!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numDust.Value < 0)
            {
                MessageBox.Show("Пыль не может быть отрицательной!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numPk.Value < 0)
            {
                MessageBox.Show("ПК не может быть отрицательным!",
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

        private bool IsDuplicate(DateTime date, string productId, int? excludeId = null)
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var query = db.Qualities
                    .Where(q => q.DateQuality == DateOnly.FromDateTime(date) && q.IdProduct == productId);

                if (excludeId.HasValue)
                    query = query.Where(q => q.Id != excludeId.Value);

                return query.Any();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            DateTime selectedDate = dtpDate.Value.Date;
            string productId = cmbProduct.SelectedValue.ToString();

            // Проверка на дубликат
            if (!isEditMode)
            {
                if (IsDuplicate(selectedDate, productId))
                {
                    MessageBox.Show("Запись качества за эту дату и марку уже существует!",
                        "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (IsDuplicate(selectedDate, productId, editingQuality?.Id))
                {
                    MessageBox.Show("Запись качества за эту дату и марку уже существует!",
                        "Дубликат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    if (isEditMode && editingQuality != null)
                    {
                        var quality = db.Qualities.Find(editingQuality.Id);
                        if (quality != null)
                        {
                            quality.DateQuality = DateOnly.FromDateTime(selectedDate);
                            quality.IdProduct = productId;
                            quality.Sieve135mm = (int)numSieve.Value;
                            quality.Dust = (int)numDust.Value;
                            quality.Pk075mm = (int)numPk.Value;
                            db.Entry(quality).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        var quality = new Quality
                        {
                            DateQuality = DateOnly.FromDateTime(selectedDate),
                            IdProduct = productId,
                            Sieve135mm = (int)numSieve.Value,
                            Dust = (int)numDust.Value,
                            Pk075mm = (int)numPk.Value
                        };
                        db.Qualities.Add(quality);
                    }

                    db.SaveChanges();
                    MessageBox.Show("Запись сохранена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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