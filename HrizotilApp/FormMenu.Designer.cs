namespace HrizotilApp
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Button btnBack;
        private Button btnLogout;
        private Label lblUserName;
        private TableLayoutPanel tableLayoutPanel;
        private Button btnInfo;
        private Button btnProductions;
        private Button btnQuality;
        private Button btnShipments;
        private Button btnStocks;
        private Button btnProfile;
        private Button btnUsers;

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
            tableLayoutPanel = new TableLayoutPanel();
            btnProductions = new Button();
            btnInfo = new Button();
            btnQuality = new Button();
            btnShipments = new Button();
            btnStocks = new Button();
            btnProfile = new Button();
            btnUsers = new Button();
            panelTop.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10, 5, 10, 5);
            panelTop.Size = new Size(800, 50);
            panelTop.TabIndex = 0;

            // btnBack
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

            // lblUserName
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Times New Roman", 12F);
            lblUserName.Location = new Point(500, 5);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(175, 40);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "имя";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;

            // btnLogout
            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 12F);
            btnLogout.Location = new Point(675, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(115, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;

            // tableLayoutPanel
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(btnInfo, 0, 0);        // Информация - первая
            tableLayoutPanel.Controls.Add(btnProductions, 0, 1); // Выработка - вторая
            tableLayoutPanel.Controls.Add(btnQuality, 0, 2);    // Качество - третья
            tableLayoutPanel.Controls.Add(btnShipments, 0, 3);   // Отгрузки - четвертая
            tableLayoutPanel.Controls.Add(btnStocks, 0, 4);      // Остатки - пятая
            tableLayoutPanel.Controls.Add(btnProfile, 0, 5);     // Профиль - шестая
            tableLayoutPanel.Controls.Add(btnUsers, 0, 6);       // Пользователи - седьмая
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 50);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(50, 20, 50, 20);
            tableLayoutPanel.RowCount = 7;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.Size = new Size(800, 550);
            tableLayoutPanel.TabIndex = 1;

            // btnProductions
            btnProductions.Anchor = AnchorStyles.None;
            btnProductions.BackColor = Color.FromArgb(52, 73, 94);
            btnProductions.FlatStyle = FlatStyle.Flat;
            btnProductions.FlatAppearance.BorderSize = 0;
            btnProductions.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btnProductions.ForeColor = Color.White;
            btnProductions.Size = new Size(350, 55);
            btnProductions.Text = "🏭 Выработка";
            btnProductions.UseVisualStyleBackColor = false;
            btnProductions.Cursor = Cursors.Hand;
            btnProductions.Click += BtnProductions_Click;

            // btnInfo
            btnInfo.Anchor = AnchorStyles.None;
            btnInfo.BackColor = Color.FromArgb(52, 73, 94);
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.FlatAppearance.BorderSize = 0;
            btnInfo.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btnInfo.ForeColor = Color.White;
            btnInfo.Size = new Size(350, 55);
            btnInfo.Text = "📋 Информация";
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Cursor = Cursors.Hand;
            btnInfo.Click += BtnInfo_Click;

            // btnQuality
            btnQuality.Anchor = AnchorStyles.None;
            btnQuality.BackColor = Color.FromArgb(52, 73, 94);
            btnQuality.FlatStyle = FlatStyle.Flat;
            btnQuality.FlatAppearance.BorderSize = 0;
            btnQuality.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btnQuality.ForeColor = Color.White;
            btnQuality.Size = new Size(350, 55);
            btnQuality.Text = "🔬 Качество";
            btnQuality.UseVisualStyleBackColor = false;
            btnQuality.Cursor = Cursors.Hand;
            btnQuality.Click += BtnQuality_Click;

            // btnShipments
            btnShipments.Anchor = AnchorStyles.None;
            btnShipments.BackColor = Color.FromArgb(52, 73, 94);
            btnShipments.FlatStyle = FlatStyle.Flat;
            btnShipments.FlatAppearance.BorderSize = 0;
            btnShipments.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btnShipments.ForeColor = Color.White;
            btnShipments.Size = new Size(350, 55);
            btnShipments.Text = "🚛 Отгрузки";
            btnShipments.UseVisualStyleBackColor = false;
            btnShipments.Cursor = Cursors.Hand;
            btnShipments.Click += BtnShipments_Click;

            // btnStocks
            btnStocks.Anchor = AnchorStyles.None;
            btnStocks.BackColor = Color.FromArgb(52, 73, 94);
            btnStocks.FlatStyle = FlatStyle.Flat;
            btnStocks.FlatAppearance.BorderSize = 0;
            btnStocks.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btnStocks.ForeColor = Color.White;
            btnStocks.Size = new Size(350, 55);
            btnStocks.Text = "📦 Остатки";
            btnStocks.UseVisualStyleBackColor = false;
            btnStocks.Cursor = Cursors.Hand;
            btnStocks.Click += BtnStocks_Click;

            // btnProfile
            btnProfile.Anchor = AnchorStyles.None;
            btnProfile.BackColor = Color.FromArgb(46, 204, 113);
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Size = new Size(350, 55);
            btnProfile.Text = "👤 Профиль";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.Click += BtnProfile_Click;

            // btnUsers
            btnUsers.Anchor = AnchorStyles.None;
            btnUsers.BackColor = Color.FromArgb(52, 73, 94);  // ИСПРАВЛЕНО: было "aplenty"
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btnUsers.ForeColor = Color.White;
            btnUsers.Size = new Size(350, 55);
            btnUsers.Text = "👥 Пользователи";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.Visible = false;
            btnUsers.Click += BtnUsers_Click;

            // FormMenu
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(tableLayoutPanel);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            MinimumSize = new Size(600, 400);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";

            panelTop.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}