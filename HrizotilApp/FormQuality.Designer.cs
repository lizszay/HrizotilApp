using System.Windows.Forms;
using System.Xml.Linq;
using Font = System.Drawing.Font;
using static System.Net.Mime.MediaTypeNames;

namespace HrizotilApp.Forms
{
    partial class FormQuality
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
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            cmbProduct = new ComboBox();
            btnFilter = new Button();
            panelButtons = new Panel();
            dgvData = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            panelTop.SuspendLayout();
            panelFilter.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10, 5, 10, 5);
            panelTop.Size = new Size(1000, 50);
            panelTop.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Khaki;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Times New Roman", 12F);
            btnBack.Location = new Point(10, 5);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 38);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Times New Roman", 12F);
            lblUserName.Location = new Point(710, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(180, 40);
            lblUserName.TabIndex = 1;
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 12F);
            btnLogout.Location = new Point(890, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(980, 40);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Качество";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(dtpFrom);
            panelFilter.Controls.Add(lblTo);
            panelFilter.Controls.Add(dtpTo);
            panelFilter.Controls.Add(cmbProduct);
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 50);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(10, 5, 10, 5);
            panelFilter.Size = new Size(1000, 45);
            panelFilter.TabIndex = 2;
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(10, 8);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 26);
            dtpFrom.TabIndex = 0;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(140, 12);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 19);
            lblTo.TabIndex = 1;
            lblTo.Text = "—";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(168, 8);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 26);
            dtpTo.TabIndex = 2;
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Location = new Point(308, 8);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(150, 27);
            cmbProduct.TabIndex = 3;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.LightBlue;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Location = new Point(478, 6);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(80, 30);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "Фильтр";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += BtnFilter_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 95);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10, 5, 10, 5);
            panelButtons.Size = new Size(1000, 55);
            panelButtons.TabIndex = 1;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.BackgroundColor = Color.White;
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(0, 150);
            dgvData.MultiSelect = false;
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1000, 500);
            dgvData.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(243, 8);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(154, 39);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(603, 8);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 39);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(410, 8);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 39);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "✏️ Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // FormQuality
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(dgvData);
            Controls.Add(panelButtons);
            Controls.Add(panelFilter);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            Name = "FormQuality";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Качество";
            panelTop.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}