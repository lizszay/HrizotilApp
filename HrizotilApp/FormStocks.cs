using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormStocks : Form
    {
        private User currentUser;

        public FormStocks(User user)
        {
            InitializeComponent();
            currentUser = user;

            ConfigureUI();
            dtpDate.Value = DateTime.Today;
            LoadData();
            DataGridViewStyle.ApplyStyle(dgvData);
        }

        private void ConfigureUI()
        {
            if (currentUser != null)
                lblUserName.Text = currentUser.FullName;
            else
                lblUserName.Text = "Гость";
        }

        private void LoadData()
        {
            DateTime selectedDate = dtpDate.Value.Date;

            using (var db = new HrizotilAccountingDbContext())
            {
                // 1. Начальные остатки на 01.04.2026 (суммируем по марке)
                var initialStocks = db.Remains
                    .Where(r => r.DateStock == new DateOnly(2026, 4, 1))
                    .GroupBy(r => r.IdProduct)
                    .Select(g => new { Product = g.Key, Total = g.Sum(x => x.Quantity) })
                    .ToDictionary(x => x.Product, x => x.Total);

                // 2. Выработка до выбранной даты
                var production = db.Productions
                    .Where(p => p.DateProduction <= DateOnly.FromDateTime(selectedDate))
                    .GroupBy(p => p.IdProduct)
                    .Select(g => new { Product = g.Key, Total = g.Sum(x => x.FactQuantity) })
                    .ToDictionary(x => x.Product, x => x.Total);

                // 3. Отгрузки до выбранной даты (со склада 1)
                var shipments = db.Shipments
                    .Where(s => s.DateShipment <= DateOnly.FromDateTime(selectedDate) && s.IdFromWarehouse == 1)
                    .GroupBy(s => s.IdProduct)
                    .Select(g => new { Product = g.Key, Total = g.Sum(x => x.Quantity) })
                    .ToDictionary(x => x.Product, x => x.Total);

                // 4. Все марки
                var products = db.Products.OrderBy(p => p.Id).ToList();

                var result = new List<StockRow>();

                foreach (var product in products)
                {
                    decimal initial = initialStocks.ContainsKey(product.Id) ? initialStocks[product.Id] : 0;
                    decimal produced = production.ContainsKey(product.Id) ? production[product.Id] : 0;
                    decimal shipped = shipments.ContainsKey(product.Id) ? shipments[product.Id] : 0;
                    decimal remain = initial + produced - shipped;

                    // Показываем только если остаток не равен нулю
                    if (remain != 0)
                    {
                        result.Add(new StockRow
                        {
                            Product = product.Id,
                            Initial = initial,
                            Produced = produced,
                            Shipped = shipped,
                            Remain = remain
                        });
                    }
                }

                dgvData.DataSource = result.OrderBy(r => r.Product).ToList();
                SetupColumns();
            }
        }

        private void SetupColumns()
        {
            if (dgvData.Columns.Contains("Product"))
                dgvData.Columns["Product"].HeaderText = "Марка";
            if (dgvData.Columns.Contains("Initial"))
                dgvData.Columns["Initial"].HeaderText = "Нач.остаток";
            if (dgvData.Columns.Contains("Produced"))
                dgvData.Columns["Produced"].HeaderText = "Выработка";
            if (dgvData.Columns.Contains("Shipped"))
                dgvData.Columns["Shipped"].HeaderText = "Отгрузки";
            if (dgvData.Columns.Contains("Remain"))
                dgvData.Columns["Remain"].HeaderText = "Остаток";
        }

        private void BtnShow_Click(object sender, EventArgs e)
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

        private class StockRow
        {
            public string Product { get; set; }
            public decimal Initial { get; set; }
            public decimal Produced { get; set; }
            public decimal Shipped { get; set; }
            public decimal Remain { get; set; }
        }
    }
}