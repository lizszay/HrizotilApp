namespace HrizotilApp
{
    partial class FormInfo
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Button btnBack;
        private Button btnLogout;
        private Label lblUserName;

        private Panel panelDescription;
        private TextBox txtDescription;
        private Button btnEditDesc;
        private Button btnSaveDesc;
        private Button btnCancelDesc;

        private Panel panelButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private DataGridView dgvProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            panelTop = new Panel();
            btnBack = new Button();
            lblUserName = new Label();
            btnLogout = new Button();
            panelDescription = new Panel();
            txtDescription = new TextBox();
            btnEditDesc = new Button();
            btnSaveDesc = new Button();
            btnCancelDesc = new Button();
            panelButtons = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvProducts = new DataGridView();
            panelTop.SuspendLayout();
            panelDescription.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(13, 6, 13, 6);
            panelTop.Size = new Size(984, 50);
            panelTop.TabIndex = 3;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Khaki;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Times New Roman", 12F);
            btnBack.Location = new Point(13, 6);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(129, 39);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUserName.Location = new Point(667, 6);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(175, 38);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "имя";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 12F);
            btnLogout.Location = new Point(842, 6);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(129, 38);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // panelDescription
            // 
            panelDescription.BackColor = Color.WhiteSmoke;
            panelDescription.Controls.Add(txtDescription);
            panelDescription.Controls.Add(btnEditDesc);
            panelDescription.Controls.Add(btnSaveDesc);
            panelDescription.Controls.Add(btnCancelDesc);
            panelDescription.Dock = DockStyle.Top;
            panelDescription.Location = new Point(0, 50);
            panelDescription.Margin = new Padding(4, 3, 4, 3);
            panelDescription.Name = "panelDescription";
            panelDescription.Padding = new Padding(13, 6, 13, 6);
            panelDescription.Size = new Size(984, 145);
            panelDescription.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.WhiteSmoke;
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDescription.Location = new Point(13, 6);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(958, 133);
            txtDescription.TabIndex = 0;
            txtDescription.Text = resources.GetString("txtDescription.Text");
            // 
            // btnEditDesc
            // 
            btnEditDesc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEditDesc.BackColor = Color.LightBlue;
            btnEditDesc.FlatStyle = FlatStyle.Flat;
            btnEditDesc.Location = new Point(1833, 101);
            btnEditDesc.Margin = new Padding(4, 3, 4, 3);
            btnEditDesc.Name = "btnEditDesc";
            btnEditDesc.Size = new Size(154, 34);
            btnEditDesc.TabIndex = 1;
            btnEditDesc.Text = "✎ Редактировать";
            btnEditDesc.UseVisualStyleBackColor = false;
            btnEditDesc.Visible = false;
            btnEditDesc.Click += BtnEditDesc_Click;
            // 
            // btnSaveDesc
            // 
            btnSaveDesc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveDesc.BackColor = Color.LightGreen;
            btnSaveDesc.FlatStyle = FlatStyle.Flat;
            btnSaveDesc.Location = new Point(1833, 101);
            btnSaveDesc.Margin = new Padding(4, 3, 4, 3);
            btnSaveDesc.Name = "btnSaveDesc";
            btnSaveDesc.Size = new Size(129, 34);
            btnSaveDesc.TabIndex = 2;
            btnSaveDesc.Text = "✓ Сохранить";
            btnSaveDesc.UseVisualStyleBackColor = false;
            btnSaveDesc.Visible = false;
            btnSaveDesc.Click += BtnSaveDesc_Click;
            // 
            // btnCancelDesc
            // 
            btnCancelDesc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelDesc.BackColor = Color.LightCoral;
            btnCancelDesc.FlatStyle = FlatStyle.Flat;
            btnCancelDesc.Location = new Point(1691, 101);
            btnCancelDesc.Margin = new Padding(4, 3, 4, 3);
            btnCancelDesc.Name = "btnCancelDesc";
            btnCancelDesc.Size = new Size(129, 34);
            btnCancelDesc.TabIndex = 3;
            btnCancelDesc.Text = "✖ Отменить";
            btnCancelDesc.UseVisualStyleBackColor = false;
            btnCancelDesc.Visible = false;
            btnCancelDesc.Click += BtnCancelDesc_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 195);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(984, 56);
            panelButtons.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(222, 9);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(154, 39);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(389, 9);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 39);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏️ Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(582, 9);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 39);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToResizeColumns = false;
            dgvProducts.AllowUserToResizeRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(0, 251);
            dgvProducts.Margin = new Padding(4, 3, 4, 3);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(984, 510);
            dgvProducts.TabIndex = 0;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 761);
            Controls.Add(dgvProducts);
            Controls.Add(panelButtons);
            Controls.Add(panelDescription);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Информация о системе";
            panelTop.ResumeLayout(false);
            panelDescription.ResumeLayout(false);
            panelDescription.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }
    }
}