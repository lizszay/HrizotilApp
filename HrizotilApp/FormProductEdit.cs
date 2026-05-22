using HrizotilApp.Models;

namespace HrizotilApp
{
    public partial class FormProductEdit : Form
    {
        private Product editingProduct;
        private bool isNew;

        public FormProductEdit(Product product = null)
        {
            InitializeComponent();

            if (product == null)
            {
                isNew = true;
                editingProduct = new Product();
                this.Text = "Добавление марки";
            }
            else
            {
                isNew = false;
                editingProduct = product;
                this.Text = "Редактирование марки";
                LoadProductData();
            }

            LoadGroups();
        }

        private void LoadGroups()
        {
            using (var db = new HrizotilAccountingDbContext())
            {
                var groups = db.Groups.OrderBy(g => g.Id).ToList();
                cmbGroup.DataSource = groups;
                cmbGroup.DisplayMember = "GroupName";
                cmbGroup.ValueMember = "Id";
            }
        }

        private void LoadProductData()
        {
            txtCode.Text = editingProduct.Id;
            cmbGroup.SelectedValue = editingProduct.IdGroup;
            txtSieve.Text = editingProduct.NormSieve135mmMin?.ToString();
            txtDust.Text = editingProduct.NormDustMax?.ToString();
            txtPk.Text = editingProduct.NormPk075mmMax?.ToString();
            txtDensity.Text = editingProduct.BulkDensityTarget?.ToString();

            // При редактировании код марки нельзя менять
            txtCode.ReadOnly = true;
            txtCode.BackColor = Color.LightGray;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательного поля
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Введите код марки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на отрицательные значения для полей
            if (!string.IsNullOrWhiteSpace(txtSieve.Text))
            {
                if (int.TryParse(txtSieve.Text, out int sieve) && sieve < 0)
                {
                    MessageBox.Show("Сито не может быть отрицательным!",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtDust.Text))
            {
                if (int.TryParse(txtDust.Text, out int dust) && dust < 0)
                {
                    MessageBox.Show("Пыль не может быть отрицательной!",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtPk.Text))
            {
                if (int.TryParse(txtPk.Text, out int pk) && pk < 0)
                {
                    MessageBox.Show("ПК не может быть отрицательным!",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtDensity.Text))
            {
                if (int.TryParse(txtDensity.Text, out int density) && density < 0)
                {
                    MessageBox.Show("Плотность не может быть отрицательной!",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (var db = new HrizotilAccountingDbContext())
            {
                if (isNew)
                {
                    editingProduct.Id = txtCode.Text.Trim();
                    editingProduct.IdGroup = (int)cmbGroup.SelectedValue;
                    editingProduct.NormSieve135mmMin = ParseNullableInt(txtSieve.Text);
                    editingProduct.NormDustMax = ParseNullableInt(txtDust.Text);
                    editingProduct.NormPk075mmMax = ParseNullableInt(txtPk.Text);
                    editingProduct.BulkDensityTarget = ParseNullableInt(txtDensity.Text);

                    db.Products.Add(editingProduct);
                }
                else
                {
                    var product = db.Products.Find(editingProduct.Id);
                    if (product != null)
                    {
                        product.IdGroup = (int)cmbGroup.SelectedValue;
                        product.NormSieve135mmMin = ParseNullableInt(txtSieve.Text);
                        product.NormDustMax = ParseNullableInt(txtDust.Text);
                        product.NormPk075mmMax = ParseNullableInt(txtPk.Text);
                        product.BulkDensityTarget = ParseNullableInt(txtDensity.Text);
                        db.Products.Update(product);
                    }
                }

                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private int? ParseNullableInt(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            if (int.TryParse(text, out int result))
                return result;

            return null;
        }
    }
}