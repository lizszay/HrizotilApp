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
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private DataGridView dgvData;

        private Panel panelPagination;
        private TableLayoutPanel tablePagination;
        private FlowLayoutPanel flowPagination;
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
            panelPagination = new Panel();
            tablePagination = new TableLayoutPanel();
            flowPagination = new FlowLayoutPanel();
            btnFirst = new Button();
            btnPrev = new Button();
            lblPageInfo = new Label();
            btnNext = new Button();
            btnLast = new Button();
            cmbPageSize = new ComboBox();
            panelTop.SuspendLayout();
            panelFilter.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            panelPagination.SuspendLayout();
            tablePagination.SuspendLayout();
            flowPagination.SuspendLayout();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10, 5, 10, 5);
            panelTop.Size = new Size(950, 50);
            panelTop.TabIndex = 3;

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

            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Times New Roman", 12F);
            lblUserName.Location = new Point(650, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(175, 40);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "имя";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;

            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 12F);
            btnLogout.Location = new Point(825, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(115, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(930, 40);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Качество";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // panelFilter
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
            panelFilter.Size = new Size(950, 45);
            panelFilter.TabIndex = 2;

            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(10, 9);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 26);
            dtpFrom.TabIndex = 0;

            lblTo.AutoSize = true;
            lblTo.Location = new Point(140, 13);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(25, 19);
            lblTo.TabIndex = 1;
            lblTo.Text = "—";

            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(175, 9);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 26);
            dtpTo.TabIndex = 2;

            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Items.AddRange(new object[] { "Все марки" });
            cmbProduct.Location = new Point(315, 9);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(150, 27);
            cmbProduct.TabIndex = 3;

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

            // panelButtons
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 95);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10, 5, 10, 5);
            panelButtons.Size = new Size(950, 55);
            panelButtons.TabIndex = 1;

            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(243, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(154, 39);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "➕ Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;

            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(603, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(154, 39);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "🗑️ Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;

            btnEdit.Anchor = AnchorStyles.None;
            btnEdit.BackColor = Color.LightBlue;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(410, 6);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(180, 39);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "✏️ Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;

            // dgvData
            dgvData.AllowUserToAddRows = false;
            dgvData.BackgroundColor = Color.White;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.Location = new Point(0, 150);
            dgvData.MultiSelect = false;
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersVisible = false;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(950, 455);
            dgvData.TabIndex = 0;

            // panelPagination
            panelPagination.BackColor = Color.White;
            panelPagination.Controls.Add(tablePagination);
            panelPagination.Dock = DockStyle.Bottom;
            panelPagination.Location = new Point(0, 605);
            panelPagination.Name = "panelPagination";
            panelPagination.Size = new Size(950, 45);
            panelPagination.TabIndex = 4;

            // tablePagination
            tablePagination.ColumnCount = 1;
            tablePagination.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablePagination.Controls.Add(flowPagination, 0, 0);
            tablePagination.Dock = DockStyle.Fill;
            tablePagination.Location = new Point(0, 0);
            tablePagination.Name = "tablePagination";
            tablePagination.RowCount = 1;
            tablePagination.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tablePagination.Size = new Size(950, 45);
            tablePagination.TabIndex = 0;

            // flowPagination
            flowPagination.Anchor = AnchorStyles.None;
            flowPagination.AutoSize = true;
            flowPagination.Controls.Add(btnFirst);
            flowPagination.Controls.Add(btnPrev);
            flowPagination.Controls.Add(lblPageInfo);
            flowPagination.Controls.Add(btnNext);
            flowPagination.Controls.Add(btnLast);
            flowPagination.Controls.Add(cmbPageSize);
            flowPagination.Location = new Point(229, 3);
            flowPagination.Name = "flowPagination";
            flowPagination.Size = new Size(491, 38);
            flowPagination.TabIndex = 0;

            // btnFirst
            btnFirst.BackColor = Color.LightGray;
            btnFirst.FlatStyle = FlatStyle.Flat;
            btnFirst.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnFirst.Location = new Point(3, 3);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(40, 32);
            btnFirst.TabIndex = 0;
            btnFirst.Text = "⏮";
            btnFirst.UseVisualStyleBackColor = false;
            btnFirst.Click += BtnFirst_Click;

            // btnPrev
            btnPrev.BackColor = Color.LightGray;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnPrev.Location = new Point(49, 3);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(85, 32);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "◀ Назад";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += BtnPrev_Click;

            // lblPageInfo
            lblPageInfo.Font = new Font("Times New Roman", 11F);
            lblPageInfo.Location = new Point(140, 0);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(150, 32);
            lblPageInfo.TabIndex = 2;
            lblPageInfo.Text = "Страница 1 из 1";
            lblPageInfo.TextAlign = ContentAlignment.MiddleCenter;

            // btnNext
            btnNext.BackColor = Color.LightGray;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnNext.Location = new Point(296, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(85, 32);
            btnNext.TabIndex = 3;
            btnNext.Text = "Вперед ▶";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += BtnNext_Click;

            // btnLast
            btnLast.BackColor = Color.LightGray;
            btnLast.FlatStyle = FlatStyle.Flat;
            btnLast.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnLast.Location = new Point(387, 3);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(40, 32);
            btnLast.TabIndex = 4;
            btnLast.Text = "⏭";
            btnLast.UseVisualStyleBackColor = false;
            btnLast.Click += BtnLast_Click;

            // cmbPageSize
            cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPageSize.Font = new Font("Times New Roman", 11F);
            cmbPageSize.Items.AddRange(new object[] { "15", "20", "30", "50" });
            cmbPageSize.Location = new Point(433, 3);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(55, 25);
            cmbPageSize.TabIndex = 5;
            cmbPageSize.SelectedIndexChanged += CmbPageSize_SelectedIndexChanged;

            // FormQuality
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 650);
            Controls.Add(panelPagination);
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
            panelPagination.ResumeLayout(false);
            tablePagination.ResumeLayout(false);
            tablePagination.PerformLayout();
            flowPagination.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}