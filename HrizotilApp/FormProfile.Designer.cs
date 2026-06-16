namespace HrizotilApp.Forms
{
    partial class FormProfile
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLogin;
        private TextBox txtFullName;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Button btnCancel;
        private Label lblLogin;
        private Label lblFullName;
        private Label lblNewPassword;
        private Label lblConfirmPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLogin = new TextBox();
            this.txtFullName = new TextBox();
            this.txtNewPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblLogin = new Label();
            this.lblFullName = new Label();
            this.lblNewPassword = new Label();
            this.lblConfirmPassword = new Label();
            this.SuspendLayout();

            // lblLogin
            this.lblLogin.Text = "Логин:";
            this.lblLogin.Location = new Point(20, 30);
            this.lblLogin.Size = new Size(120, 25);
            this.lblLogin.Font = new Font("Times New Roman", 12F);
            this.lblLogin.TextAlign = ContentAlignment.MiddleRight;

            // txtLogin
            this.txtLogin.Location = new Point(150, 30);
            this.txtLogin.Size = new Size(200, 26);
            this.txtLogin.Font = new Font("Times New Roman", 12F);
            this.txtLogin.ReadOnly = true;
            this.txtLogin.BackColor = Color.WhiteSmoke;

            // lblFullName
            this.lblFullName.Text = "ФИО:";
            this.lblFullName.Location = new Point(20, 70);
            this.lblFullName.Size = new Size(120, 25);
            this.lblFullName.Font = new Font("Times New Roman", 12F);
            this.lblFullName.TextAlign = ContentAlignment.MiddleRight;

            // txtFullName
            this.txtFullName.Location = new Point(150, 70);
            this.txtFullName.Size = new Size(200, 26);
            this.txtFullName.Font = new Font("Times New Roman", 12F);

            // lblNewPassword
            this.lblNewPassword.Text = "Новый пароль:";
            this.lblNewPassword.Location = new Point(20, 110);
            this.lblNewPassword.Size = new Size(120, 25);
            this.lblNewPassword.Font = new Font("Times New Roman", 12F);
            this.lblNewPassword.TextAlign = ContentAlignment.MiddleRight;

            // txtNewPassword
            this.txtNewPassword.Location = new Point(150, 110);
            this.txtNewPassword.Size = new Size(200, 26);
            this.txtNewPassword.Font = new Font("Times New Roman", 12F);
            this.txtNewPassword.UseSystemPasswordChar = true;

            // lblConfirmPassword
            this.lblConfirmPassword.Text = "Подтверждение:";
            this.lblConfirmPassword.Location = new Point(20, 150);
            this.lblConfirmPassword.Size = new Size(120, 25);
            this.lblConfirmPassword.Font = new Font("Times New Roman", 12F);
            this.lblConfirmPassword.TextAlign = ContentAlignment.MiddleRight;

            // txtConfirmPassword
            this.txtConfirmPassword.Location = new Point(150, 150);
            this.txtConfirmPassword.Size = new Size(200, 26);
            this.txtConfirmPassword.Font = new Font("Times New Roman", 12F);
            this.txtConfirmPassword.UseSystemPasswordChar = true;

            // btnSave
            this.btnSave.Text = "Сохранить";
            this.btnSave.BackColor = Color.LightGreen;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.btnSave.Size = new Size(110, 38);
            this.btnSave.Location = new Point(65, 210);
            this.btnSave.Click += BtnSave_Click;

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.btnCancel.Size = new Size(110, 38);
            this.btnCancel.Location = new Point(195, 210);
            this.btnCancel.Click += BtnCancel_Click;

            // FormProfile
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 290);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new Font("Times New Roman", 12F);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Редактирование профиля";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}