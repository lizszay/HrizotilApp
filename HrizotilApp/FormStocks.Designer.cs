using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HrizotilApp.Forms
{
    partial class FormStocks
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Button btnBack;
        private Button btnLogout;
        private Label lblUserName;
        private Label lblTitle;

        private Panel panelFilter;
        private DateTimePicker dtpDate;
        private Button btnShow;

        private DataGridView dgvData;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            btnBack = new Button();
            lblUserName = new Label();
            btnLogout = new Button();
            lblTitle = new Label();

            panelFilter = new Panel();
            dtpDate = new DateTimePicker();
            btnShow = new Button();

            dgvData = new DataGridView();

            panelTop.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 50;
            panelTop.Padding = new Padding(10, 5, 10, 5);

            btnBack.BackColor = Color.Khaki;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnBack.Location = new Point(10, 5);
            btnBack.Size = new Size(100, 38);
            btnBack.Text = "← Назад";
            btnBack.Click += BtnBack_Click;

            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new System.Drawing.Font("Times New Roman", 12F);
            lblUserName.Location = new Point(700, 5);
            lblUserName.Size = new Size(180, 38);
            lblUserName.TextAlign = ContentAlignment.MiddleRight;

            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnLogout.Location = new Point(880, 5);
            btnLogout.Size = new Size(100, 38);
            btnLogout.Text = "Выход";
            btnLogout.Click += BtnLogout_Click;

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Times New Roman", 16F, FontStyle.Bold);
            lblTitle.Text = "Остатки на складах";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // panelFilter
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(dtpDate);
            panelFilter.Controls.Add(btnShow);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Height = 50;
            panelFilter.Padding = new Padding(10, 5, 10, 5);

            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(10, 8);
            dtpDate.Size = new Size(120, 27);
            dtpDate.Value = new DateTime(2026, 5, 21);

            btnShow.BackColor = Color.LightBlue;
            btnShow.FlatStyle = FlatStyle.Flat;
            btnShow.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnShow.Location = new Point(140, 6);
            btnShow.Size = new Size(100, 30);
            btnShow.Text = "Показать";
            btnShow.Click += BtnShow_Click;

            // dgvData
            dgvData.Dock = DockStyle.Fill;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.RowHeadersVisible = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.BackgroundColor = Color.White;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = false;

            // FormStocks
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(dgvData);
            Controls.Add(panelFilter);
            Controls.Add(panelTop);
            Font = new System.Drawing.Font("Times New Roman", 12F);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Остатки";
            Name = "FormStocks";

            panelTop.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }
    }
}