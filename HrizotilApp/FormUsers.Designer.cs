namespace HrizotilApp.Forms
{
    partial class FormUsers
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Button btnBack;
        private Button btnLogout;
        private Label lblUserName;
        private Label lblTitle;

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

            panelButtons = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            dgvData = new DataGridView();

            panelTop.SuspendLayout();
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
            btnBack.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnBack.Location = new Point(10, 5);
            btnBack.Size = new Size(100, 38);
            btnBack.Text = "← Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;

            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new System.Drawing.Font("Times New Roman", 12F);
            lblUserName.Location = new Point(700, 5);
            lblUserName.Size = new Size(180, 38);
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            lblUserName.Text = "Имя";

            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnLogout.Location = new Point(880, 5);
            btnLogout.Size = new Size(100, 38);
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new System.Drawing.Font("Times New Roman", 16F, FontStyle.Bold);
            lblTitle.Text = "Управление пользователями";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

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
            btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnAdd.Location = new Point(270, 8);
            btnAdd.Size = new Size(120, 38);
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;

            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnEdit.Location = new Point(410, 8);
            btnEdit.Size = new Size(120, 38);
            btnEdit.Text = "✏️ Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;

            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Times New Roman", 12F);
            btnDelete.Location = new Point(550, 8);
            btnDelete.Size = new Size(120, 38);
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.UseVisualStyleBackColor = false;
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

            // FormUsers
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(dgvData);
            Controls.Add(panelButtons);
            Controls.Add(panelTop);
            Font = new System.Drawing.Font("Times New Roman", 12F);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Пользователи";
            Name = "FormUsers";

            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }
    }
}