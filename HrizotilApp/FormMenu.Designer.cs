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

            // ========== panelTop (точно как в FormInfo) ==========
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

            // btnBack
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

            // lblUserName
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUserName.Location = new Point(641, 6);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(175, 38);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "имя";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;

            // btnLogout
            btnLogout.BackColor = Color.YellowGreen;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 12F);
            btnLogout.Location = new Point(816, 6);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(129, 38);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;

            // ========== flowButtons ==========
            flowButtons.Dock = DockStyle.Fill;
            flowButtons.FlowDirection = FlowDirection.TopDown;
            flowButtons.WrapContents = false;
            flowButtons.Padding = new Padding(20);
            flowButtons.AutoScroll = true;

            // btnInfo
            btnInfo.Text = "📋 Информация о системе";
            btnInfo.Size = new Size(300, 50);
            btnInfo.Font = new Font("Times New Roman", 14F);
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.BackColor = Color.LightGray;
            btnInfo.Click += BtnInfo_Click;

            // btnProductions
            btnProductions.Text = "🏭 Выработка";
            btnProductions.Size = new Size(300, 50);
            btnProductions.Font = new Font("Times New Roman", 14F);
            btnProductions.FlatStyle = FlatStyle.Flat;
            btnProductions.BackColor = Color.LightGray;

            // btnQuality
            btnQuality.Text = "🔬 Качество";
            btnQuality.Size = new Size(300, 50);
            btnQuality.Font = new Font("Times New Roman", 14F);
            btnQuality.FlatStyle = FlatStyle.Flat;
            btnQuality.BackColor = Color.LightGray;

            // btnShipments
            btnShipments.Text = "🚛 Отгрузки";
            btnShipments.Size = new Size(300, 50);
            btnShipments.Font = new Font("Times New Roman", 14F);
            btnShipments.FlatStyle = FlatStyle.Flat;
            btnShipments.BackColor = Color.LightGray;

            // btnStocks
            btnStocks.Text = "📦 Остатки";
            btnStocks.Size = new Size(300, 50);
            btnStocks.Font = new Font("Times New Roman", 14F);
            btnStocks.FlatStyle = FlatStyle.Flat;
            btnStocks.BackColor = Color.LightGray;

            // btnProducts (справочник марок)
            btnProducts.Text = "🏷️ Марки продукции";
            btnProducts.Size = new Size(300, 50);
            btnProducts.Font = new Font("Times New Roman", 14F);
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.BackColor = Color.LightGray;
            btnProducts.Visible = false;

            // btnUsers (управление пользователями)
            btnUsers.Text = "👥 Пользователи";
            btnUsers.Size = new Size(300, 50);
            btnUsers.Font = new Font("Times New Roman", 14F);
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.BackColor = Color.LightGray;
            btnUsers.Visible = false;

            flowButtons.Controls.Add(btnInfo);
            flowButtons.Controls.Add(btnProductions);
            flowButtons.Controls.Add(btnQuality);
            flowButtons.Controls.Add(btnShipments);
            flowButtons.Controls.Add(btnStocks);
            flowButtons.Controls.Add(btnProducts);
            flowButtons.Controls.Add(btnUsers);

            // FormMenu
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(flowButtons);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";
            Name = "FormMenu";

            panelTop.ResumeLayout(false);
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}