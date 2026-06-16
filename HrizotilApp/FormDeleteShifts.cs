using HrizotilApp.Models;

namespace HrizotilApp.Forms
{
    public partial class FormDeleteShifts : Form
    {
        private DateTime date;
        private string productId;
        private List<Production> productions;

        public FormDeleteShifts(DateTime date, string productId, List<Production> productions)
        {
            InitializeComponent();
            this.date = date;
            this.productId = productId;
            this.productions = productions;

            LoadShifts();
        }

        private void LoadShifts()
        {
            lblInfo.Text = $"Дата: {date:dd.MM.yyyy} | Марка: {productId}";

            int y = 50;
            foreach (var p in productions)
            {
                var checkBox = new CheckBox();
                checkBox.Text = $"Смена {p.Shift}  |  План: {p.PlanQuantity} т  |  Факт: {p.FactQuantity} т";
                checkBox.Tag = p.Id;
                checkBox.Location = new Point(20, y);
                checkBox.Size = new Size(400, 30);
                checkBox.Font = new Font("Times New Roman", 12F);
                this.Controls.Add(checkBox);
                y += 35;
            }

            // Кнопки
            btnDeleteAll.Text = "🗑️ Удалить все";
            btnDeleteAll.Location = new Point(20, y + 20);
            btnDeleteAll.Size = new Size(120, 35);
            btnDeleteAll.Click += BtnDeleteAll_Click;

            btnDeleteSelected.Text = "🗑️ Удалить выбранные";
            btnDeleteSelected.Location = new Point(150, y + 20);
            btnDeleteSelected.Size = new Size(140, 35);
            btnDeleteSelected.Click += BtnDeleteSelected_Click;

            btnCancel.Text = "❌ Отмена";
            btnCancel.Location = new Point(300, y + 20);
            btnCancel.Size = new Size(100, 35);
            btnCancel.Click += BtnCancel_Click;

            this.Height = y + 120;
        }

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Удалить ВСЕ смены за {date:dd.MM.yyyy} для марки {productId}?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    var toDelete = db.Productions
                        .Where(p => p.DateProduction == DateOnly.FromDateTime(date) &&
                                    p.IdProduct == productId)
                        .ToList();
                    db.Productions.RemoveRange(toDelete);
                    db.SaveChanges();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnDeleteSelected_Click(object sender, EventArgs e)
        {
            var selectedIds = new List<int>();
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    selectedIds.Add((int)checkBox.Tag);
                }
            }

            if (!selectedIds.Any())
            {
                MessageBox.Show("Выберите хотя бы одну смену для удаления!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Удалить выбранные смены ({selectedIds.Count} шт.)?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var db = new HrizotilAccountingDbContext())
                {
                    var toDelete = db.Productions.Where(p => selectedIds.Contains(p.Id)).ToList();
                    db.Productions.RemoveRange(toDelete);
                    db.SaveChanges();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}