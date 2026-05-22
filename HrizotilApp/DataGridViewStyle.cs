using System.Drawing;
using System.Windows.Forms;

namespace HrizotilApp
{
    public static class DataGridViewStyle
    {
        public static void ApplyStyle(DataGridView dgv)
        {
            // Базовые настройки
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(200, 200, 200);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;

            // Стиль заголовков
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 35;

            // Стиль ячеек
            dgv.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
            dgv.RowTemplate.Height = 30;

            // Чередующиеся строки
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Растягивание
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Dock = DockStyle.Fill;
        }
    }
}