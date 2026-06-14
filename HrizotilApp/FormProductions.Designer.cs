namespace HrizotilApp.Forms
{
    partial class FormProductions
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

        private Panel panelPagination;
        private Button btnFirst;
        private Button btnPrev;
        private Button btnNext;
        private Button btnLast;
        private Label lblPageInfo;
        private ComboBox cmbPageSize;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            dgvData = new DataGridView();
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
            btnBack.FlatAppearance.BorderSize = 0;
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
            lblTitle.Text = "Выработка";
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
            dtpFrom.Location = new Point(10, 9);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 26);
            dtpFrom.TabIndex = 0;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(140, 13);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 19);
            lblTo.TabIndex = 1;
            lblTo.Text = "—";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(175, 9);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 26);
            dtpTo.TabIndex = 2;
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Items.AddRange(new object[] { "Все марки" });
            cmbProduct.Location = new Point(315, 9);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(150, 27);
            cmbProduct.TabIndex = 3;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.LightBlue;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Location = new Point(485, 7);
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
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 95);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10, 5, 10, 5);
            panelButtons.Size = new Size(1000, 55);
            panelButtons.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(243, 6);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(154, 39);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(603, 6);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 39);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(410, 6);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 39);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "✏️ Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvData.BackgroundColor = Color.White;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(0, 150);
            dgvData.MultiSelect = false;
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(1000, 500);
            dgvData.TabIndex = 0;
            // 
            // FormProductions
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(dgvData);
            Controls.Add(panelButtons);
            Controls.Add(panelFilter);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            Name = "FormProductions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выработка";
            panelTop.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();

            // panelPagination
            this.panelPagination = new Panel();
            this.panelPagination.Dock = DockStyle.Bottom;
            this.panelPagination.Height = 45;
            this.panelPagination.BackColor = Color.White;
            this.panelPagination.Padding = new Padding(10, 5, 10, 5);

            // btnFirst
            this.btnFirst = new Button();
            this.btnFirst.Text = "⏮ Первая";
            this.btnFirst.Size = new Size(85, 32);
            this.btnFirst.FlatStyle = FlatStyle.Flat;
            this.btnFirst.BackColor = Color.LightGray;
            this.btnFirst.Click += BtnFirst_Click;

            // btnPrev
            this.btnPrev = new Button();
            this.btnPrev.Text = "◀ Назад";
            this.btnPrev.Size = new Size(85, 32);
            this.btnPrev.FlatStyle = FlatStyle.Flat;
            this.btnPrev.BackColor = Color.LightGray;
            this.btnPrev.Click += BtnPrev_Click;

            // btnNext
            this.btnNext = new Button();
            this.btnNext.Text = "Вперед ▶";
            this.btnNext.Size = new Size(85, 32);
            this.btnNext.FlatStyle = FlatStyle.Flat;
            this.btnNext.BackColor = Color.LightGray;
            this.btnNext.Click += BtnNext_Click;

            // btnLast
            this.btnLast = new Button();
            this.btnLast.Text = "Последняя ⏩";
            this.btnLast.Size = new Size(95, 32);
            this.btnLast.FlatStyle = FlatStyle.Flat;
            this.btnLast.BackColor = Color.LightGray;
            this.btnLast.Click += BtnLast_Click;

            // lblPageInfo
            this.lblPageInfo = new Label();
            this.lblPageInfo.Text = "Страница 1 из 1";
            this.lblPageInfo.Size = new Size(150, 32);
            this.lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;
            this.lblPageInfo.Font = new Font("Times New Roman", 11F);

            // cmbPageSize
            this.cmbPageSize = new ComboBox();
            this.cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPageSize.Items.AddRange(new object[] { "15", "20", "30", "40", "50" });
            this.cmbPageSize.SelectedIndex = 1;
            this.cmbPageSize.Size = new Size(65, 27);
            this.cmbPageSize.Font = new Font("Times New Roman", 11F);
            this.cmbPageSize.SelectedIndexChanged += CmbPageSize_SelectedIndexChanged;

            // Размещаем элементы на панели
            this.panelPagination.Controls.Add(this.btnFirst);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnLast);
            this.panelPagination.Controls.Add(this.cmbPageSize);

            // Позиционирование
            this.btnFirst.Location = new Point(10, 6);
            this.btnPrev.Location = new Point(100, 6);
            this.lblPageInfo.Location = new Point(190, 6);
            this.btnNext.Location = new Point(345, 6);
            this.btnLast.Location = new Point(435, 6);
            this.cmbPageSize.Location = new Point(540, 7);

            // Добавляем панель на форму
            this.Controls.Add(this.panelPagination);

            // Переносим dgvData наверх (чтобы не перекрывала пагинацию)
            this.dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvData.Location = new Point(0, 150);
            this.dgvData.Size = new Size(1000, 455); // Уменьшаем высоту, чтобы уместилась пагинация

            ResumeLayout(false);

        }
    }
}