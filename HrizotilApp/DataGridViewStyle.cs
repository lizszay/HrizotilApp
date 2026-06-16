using System.Drawing;
using System.Windows.Forms;

namespace HrizotilApp
{
    public static class DataGridViewStyle
    {
        public static void ApplyStyle(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 220, 220);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dgv.RowTemplate.Height = 35;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Снимаем выделение после загрузки данных
            dgv.DataBindingComplete += (s, e) =>
            {
                dgv.ClearSelection();
            };
        }

        public static void SetColumnMinimumWidth(DataGridView dgv)
        {
            if (dgv == null || dgv.Columns == null || dgv.Columns.Count == 0) return;

            dgv.SuspendLayout();

            try
            {
                var columns = dgv.Columns.Cast<DataGridViewColumn>().ToList();

                foreach (DataGridViewColumn column in columns)
                {
                    if (column == null) continue;

                    try
                    {
                        int maxWidth = 50;

                        using (Graphics g = dgv.CreateGraphics())
                        {
                            Font headerFont = column.HeaderCell.Style.Font ?? dgv.ColumnHeadersDefaultCellStyle.Font ?? new Font("Times New Roman", 11F);
                            if (!string.IsNullOrEmpty(column.HeaderText))
                            {
                                int headerWidth = (int)g.MeasureString(column.HeaderText, headerFont).Width + 30;
                                if (headerWidth > maxWidth) maxWidth = headerWidth;
                            }

                            if (dgv.Rows != null && dgv.Rows.Count > 0)
                            {
                                int rowsToCheck = Math.Min(20, dgv.Rows.Count);
                                for (int i = 0; i < rowsToCheck; i++)
                                {
                                    var row = dgv.Rows[i];
                                    if (row != null && !row.IsNewRow && row.Cells[column.Index].Value != null)
                                    {
                                        string cellValue = row.Cells[column.Index].Value.ToString();
                                        if (!string.IsNullOrEmpty(cellValue))
                                        {
                                            Font cellFont = column.DefaultCellStyle.Font ?? dgv.DefaultCellStyle.Font ?? new Font("Times New Roman", 11F);
                                            int cellWidth = (int)g.MeasureString(cellValue, cellFont).Width + 30;
                                            if (cellWidth > maxWidth) maxWidth = cellWidth;
                                        }
                                    }
                                }
                            }
                        }

                        column.MinimumWidth = Math.Min(maxWidth + 10, 300);
                    }
                    catch
                    {
                        column.MinimumWidth = 80;
                    }
                }
            }
            finally
            {
                dgv.ResumeLayout();
            }
        }

        public static void RefreshRowHeights(DataGridView dgv)
        {
            if (dgv == null || dgv.Rows == null) return;

            dgv.SuspendLayout();
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row != null && !row.IsNewRow)
                    {
                        row.Height = -1;
                    }
                }
            }
            finally
            {
                dgv.ResumeLayout();
            }
        }
    }
}