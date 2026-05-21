using HrizotilApp.Models;

namespace HrizotilApp
{
    public partial class FormProductEdit : Form
    {
        private Product _editingProduct;
        private bool _isNew;

        public FormProductEdit(Product product = null)
        {
            InitializeComponent();

            if (product == null)
            {
                _isNew = true;
                _editingProduct = new Product();
                this.Text = "Добавление марки";
            }
            else
            {
                _isNew = false;
                _editingProduct = product;
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
            txtCode.Text = _editingProduct.Id;
            cmbGroup.SelectedValue = _editingProduct.IdGroup;
            txtSieve.Text = _editingProduct.NormSieve135mmMin?.ToString();
            txtDust.Text = _editingProduct.NormDustMax?.ToString();
            txtPk.Text = _editingProduct.NormPk075mmMax?.ToString();
            txtDensity.Text = _editingProduct.BulkDensityTarget?.ToString();

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

            using (var db = new HrizotilAccountingDbContext())
            {
                if (_isNew)
                {
                    _editingProduct.Id = txtCode.Text.Trim();
                    _editingProduct.IdGroup = (int)cmbGroup.SelectedValue;
                    _editingProduct.NormSieve135mmMin = ParseNullableInt(txtSieve.Text);
                    _editingProduct.NormDustMax = ParseNullableInt(txtDust.Text);
                    _editingProduct.NormPk075mmMax = ParseNullableInt(txtPk.Text);
                    _editingProduct.BulkDensityTarget = ParseNullableInt(txtDensity.Text);

                    db.Products.Add(_editingProduct);
                }
                else
                {
                    var product = db.Products.Find(_editingProduct.Id);
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