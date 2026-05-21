using HrizotilApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrizotilApp.Forms
{
    public partial class FormStocks : Form
    {
        public FormStocks()
        {
            InitializeComponent();
            LoadData();

            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void LoadData()
        {
            DateTime selectedDate = dtpDate.Value.Date;
            DateOnly stockDate = DateOnly.FromDateTime(selectedDate);

            using (var db = new HrizotilAccountingDbContext())
            {
                // Получаем начальные остатки (на 01.04.2026)
                var initialStocks = db.Remains
                    .Where(r => r.DateStock == new DateOnly(2026, 4, 1))
                    .ToDictionary(r => (r.IdWarehouse, r.IdProduct), r => r.Quantity);

                // Получаем выработку до выбранной даты
                var production = db.Productions
                    .Where(p => p.DateProduction <= stockDate)
                    .GroupBy(p => new { p.IdProduct })
                    .Select(g => new
                    {
                        ProductCode = g.Key.IdProduct,
                        TotalProduced = g.Sum(x => x.FactQuantity)
                    })
                    .ToDictionary(x => x.ProductCode, x => x.TotalProduced);

                // Получаем отгрузки до выбранной даты (со склада 1)
                var shipments = db.Shipments
                    .Where(s => s.DateShipment <= stockDate && s.IdFromWarehouse == 1)
                    .GroupBy(s => new { s.IdProduct })
                    .Select(g => new
                    {
                        ProductCode = g.Key.IdProduct,
                        TotalShipped = g.Sum(x => x.Quantity)
                    })
                    .ToDictionary(x => x.ProductCode, x => x.TotalShipped);

                // Получаем все склады и продукты
                var warehouses = db.Warehouses.ToList();
                var products = db.Products.ToList();

                var result = new List<StockRow>();

                foreach (var warehouse in warehouses)
                {
                    foreach (var product in products)
                    {
                        decimal initial = 0;
                        if (initialStocks.ContainsKey((warehouse.Id, product.Id)))
                            initial = initialStocks[(warehouse.Id, product.Id)];

                        decimal produced = 0;
                        if (production.ContainsKey(product.Id))
                            produced = production[product.Id];

                        decimal shipped = 0;
                        if (warehouse.Id == 1 && shipments.ContainsKey(product.Id))
                            shipped = shipments[product.Id];

                        decimal current = initial + produced - shipped;

                        if (current != 0 || initial != 0 || produced != 0 || shipped != 0)
                        {
                            result.Add(new StockRow
                            {
                                WarehouseName = warehouse.WarehouseName,
                                ProductCode = product.Id,
                                InitialStock = initial,
                                Produced = produced,
                                Shipped = shipped,
                                CurrentStock = current
                            });
                        }
                    }
                }

                dgvData.DataSource = result.OrderBy(r => r.WarehouseName).ThenBy(r => r.ProductCode).ToList();
                SetupColumns();
            }
        }

        private void SetupColumns()
        {
            if (dgvData.Columns.Contains("WarehouseName"))
                dgvData.Columns["WarehouseName"].HeaderText = "Склад";
            if (dgvData.Columns.Contains("ProductCode"))
                dgvData.Columns["ProductCode"].HeaderText = "Марка";
            if (dgvData.Columns.Contains("InitialStock"))
                dgvData.Columns["InitialStock"].HeaderText = "Нач. остаток, т";
            if (dgvData.Columns.Contains("Produced"))
                dgvData.Columns["Produced"].HeaderText = "Выработка, т";
            if (dgvData.Columns.Contains("Shipped"))
                dgvData.Columns["Shipped"].HeaderText = "Отгрузка, т";
            if (dgvData.Columns.Contains("CurrentStock"))
                dgvData.Columns["CurrentStock"].HeaderText = "Остаток, т";
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
            public string WarehouseName { get; set; }
            public string ProductCode { get; set; }
            public decimal InitialStock { get; set; }
            public decimal Produced { get; set; }
            public decimal Shipped { get; set; }
            public decimal CurrentStock { get; set; }
        }
    }
}