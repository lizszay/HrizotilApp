namespace HrizotilApp
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pbLogo = new PictureBox();
            panel1 = new Panel();
            btnGuest = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtLogin = new TextBox();
            lbPassword = new Label();
            lbLogin = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(141, 29);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(100, 90);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnGuest);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtLogin);
            panel1.Controls.Add(lbPassword);
            panel1.Controls.Add(lbLogin);
            panel1.Location = new Point(14, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 222);
            panel1.TabIndex = 1;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.Khaki;
            btnGuest.FlatAppearance.BorderSize = 0;
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.Font = new Font("Times New Roman", 12F);
            btnGuest.ForeColor = Color.Black;
            btnGuest.Location = new Point(103, 176);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(150, 23);
            btnGuest.TabIndex = 5;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += BtnGuest_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.YellowGreen;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 12F);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(103, 145);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 23);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(53, 111);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 26);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(53, 50);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 26);
            txtLogin.TabIndex = 2;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(149, 84);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(58, 19);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Пароль";
            // 
            // lbLogin
            // 
            lbLogin.AutoSize = true;
            lbLogin.Location = new Point(152, 23);
            lbLogin.Name = "lbLogin";
            lbLogin.Size = new Size(52, 19);
            lbLogin.TabIndex = 0;
            lbLogin.Text = "Логин";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 361);
            Controls.Add(panel1);
            Controls.Add(pbLogo);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            Padding = new Padding(10, 11, 10, 11);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Panel panel1;
        private Button btnGuest;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtLogin;
        private Label lbPassword;
        private Label lbLogin;
    }
}