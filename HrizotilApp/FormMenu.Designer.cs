namespace HrizotilApp
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelTop;
        private Button btnBack;
        private Button btnLogout;
        private Label lblUserName;

        private FlowLayoutPanel flowButtons;
        private Button btnInfo;
        private Button btnProductions;
        private Button btnQuality;
        private Button btnShipments;
        private Button btnStocks;
        private Button btnProducts;
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
            flowButtons = new FlowLayoutPanel();
            btnInfo = new Button();
            btnProductions = new Button();
            btnQuality = new Button();
            btnShipments = new Button();
            btnStocks = new Button();
            btnProducts = new Button();
            btnUsers = new Button();
            panelTop.SuspendLayout();
            flowButtons.SuspendLayout();
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
            panelTop.Size = new Size(1000, 50);
            panelTop.TabIndex = 0;
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
            btnBack.Size = new Size(100, 38);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // lblUserName
            // 
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUserName.Location = new Point(683, 6);
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
            btnLogout.Location = new Point(858, 6);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(129, 38);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // flowButtons
            // 
            flowButtons.AutoScroll = true;
            flowButtons.Controls.Add(btnInfo);
            flowButtons.Controls.Add(btnProductions);
            flowButtons.Controls.Add(btnQuality);
            flowButtons.Controls.Add(btnShipments);
            flowButtons.Controls.Add(btnStocks);
            flowButtons.Controls.Add(btnProducts);
            flowButtons.Controls.Add(btnUsers);
            flowButtons.Dock = DockStyle.Fill;
            flowButtons.FlowDirection = FlowDirection.TopDown;
            flowButtons.Location = new Point(0, 50);
            flowButtons.Name = "flowButtons";
            flowButtons.Padding = new Padding(20);
            flowButtons.Size = new Size(1000, 550);
            flowButtons.TabIndex = 0;
            flowButtons.WrapContents = false;
            // 
            // btnInfo
            // 
            btnInfo.BackColor = Color.LightGray;
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.Font = new Font("Times New Roman", 14F);
            btnInfo.Location = new Point(23, 23);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(300, 50);
            btnInfo.TabIndex = 0;
            btnInfo.Text = "📋 Информация о системе";
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += BtnInfo_Click;
            // 
            // btnProductions
            // 
            btnProductions.BackColor = Color.LightGray;
            btnProductions.FlatStyle = FlatStyle.Flat;
            btnProductions.Font = new Font("Times New Roman", 14F);
            btnProductions.Location = new Point(23, 79);
            btnProductions.Name = "btnProductions";
            btnProductions.Size = new Size(300, 50);
            btnProductions.TabIndex = 1;
            btnProductions.Text = "🏭 Выработка";
            btnProductions.UseVisualStyleBackColor = false;
            btnProductions.Click += BtnProductions_Click;
            // 
            // btnQuality
            // 
            btnQuality.BackColor = Color.LightGray;
            btnQuality.FlatStyle = FlatStyle.Flat;
            btnQuality.Font = new Font("Times New Roman", 14F);
            btnQuality.Location = new Point(23, 135);
            btnQuality.Name = "btnQuality";
            btnQuality.Size = new Size(300, 50);
            btnQuality.TabIndex = 2;
            btnQuality.Text = "🔬 Качество";
            btnQuality.UseVisualStyleBackColor = false;
            btnQuality.Click += BtnQuality_Click;
            // 
            // btnShipments
            // 
            btnShipments.BackColor = Color.LightGray;
            btnShipments.FlatStyle = FlatStyle.Flat;
            btnShipments.Font = new Font("Times New Roman", 14F);
            btnShipments.Location = new Point(23, 191);
            btnShipments.Name = "btnShipments";
            btnShipments.Size = new Size(300, 50);
            btnShipments.TabIndex = 3;
            btnShipments.Text = "🚛 Отгрузки";
            btnShipments.UseVisualStyleBackColor = false;
            btnShipments.Click += BtnShipments_Click;
            // 
            // btnStocks
            // 
            btnStocks.BackColor = Color.LightGray;
            btnStocks.FlatStyle = FlatStyle.Flat;
            btnStocks.Font = new Font("Times New Roman", 14F);
            btnStocks.Location = new Point(23, 247);
            btnStocks.Name = "btnStocks";
            btnStocks.Size = new Size(300, 50);
            btnStocks.TabIndex = 4;
            btnStocks.Text = "📦 Остатки";
            btnStocks.UseVisualStyleBackColor = false;
            btnStocks.Click += BtnStocks_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.LightGray;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Times New Roman", 14F);
            btnProducts.Location = new Point(23, 303);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(300, 50);
            btnProducts.TabIndex = 5;
            btnProducts.Text = "🏷️ Марки продукции";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Visible = false;
            btnProducts.Click += BtnProducts_Click;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.LightGray;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Times New Roman", 14F);
            btnUsers.Location = new Point(23, 359);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(300, 50);
            btnUsers.TabIndex = 6;
            btnUsers.Text = "👥 Пользователи";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Visible = false;
            btnUsers.Click += BtnUsers_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(flowButtons);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";
            panelTop.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}