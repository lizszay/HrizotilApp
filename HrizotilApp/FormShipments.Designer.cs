using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace HrizotilApp.Forms
{
    partial class FormShipments
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Button btnBack;
        private Button btnLogout;
        private Label lblUserName;
        private Label lblTitle;

        private Panel panelFilter;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Label lblTo;
        private ComboBox cmbProduct;
        private Button btnFilter;

        private Panel panelButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

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
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            lblTo = new Label();
            cmbProduct = new ComboBox();
            btnFilter = new Button();

            panelButtons = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            dgvData = new DataGridView();

            panelTop.SuspendLayout();
            panelFilter.SuspendLayout();
            panelButtons.SuspendLayout();
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
            btnBack.Font = new Font("Times New Roman", 12F);
            btnBack.Location = new Point(10, 5);
            btnBack.Size = new Size(100, 38);
            btnBack.Text = "← Назад";
            btnBack.Click += BtnBack_Click;

            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Times New Roman", 12F);
            lblUserName.Location = new Point(700, 5);
            lblUserName.Size = new Size(180, 38);
            lblUserName.TextAlign = ContentAlignment.MiddleRight;

            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 12F);
            btnLogout.Location = new Point(880, 5);
            btnLogout.Size = new Size(100, 38);
            btnLogout.Text = "Выход";
            btnLogout.Click += BtnLogout_Click;

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lblTitle.Text = "Отгрузки";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // panelFilter
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(dtpFrom);
            panelFilter.Controls.Add(lblTo);
            panelFilter.Controls.Add(dtpTo);
            panelFilter.Controls.Add(cmbProduct);
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Height = 45;
            panelFilter.Padding = new Padding(10, 5, 10, 5);

            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(10, 8);
            dtpFrom.Size = new Size(120, 27);

            lblTo.AutoSize = true;
            lblTo.Location = new Point(140, 12);
            lblTo.Text = "—";

            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(160, 8);
            dtpTo.Size = new Size(120, 27);

            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Location = new Point(300, 8);
            cmbProduct.Size = new Size(150, 27);

            btnFilter.BackColor = Color.LightBlue;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Location = new Point(470, 6);
            btnFilter.Size = new Size(80, 30);
            btnFilter.Text = "Фильтр";
            btnFilter.Click += BtnFilter_Click;

            // panelButtons
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Height = 55;
            panelButtons.Padding = new Padding(10, 5, 10, 5);

            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Times New Roman", 12F);
            btnAdd.Location = new Point(220, 8);
            btnAdd.Size = new Size(120, 38);
            btnAdd.Text = "➕ Добавить";
            btnAdd.Click += BtnAdd_Click;

            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Times New Roman", 12F);
            btnEdit.Location = new Point(360, 8);
            btnEdit.Size = new Size(130, 38);
            btnEdit.Text = "✏️ Редактировать";
            btnEdit.Click += BtnEdit_Click;

            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Times New Roman", 12F);
            btnDelete.Location = new Point(510, 8);
            btnDelete.Size = new Size(120, 38);
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.Click += BtnDelete_Click;

            // dgvData
            dgvData.Dock = DockStyle.Fill;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.RowHeadersVisible = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.BackgroundColor = Color.White;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.MultiSelect = false;

            // FormShipments
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(dgvData);
            Controls.Add(panelButtons);
            Controls.Add(panelFilter);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отгрузки";
            Name = "FormShipments";

            panelTop.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }
    }
}