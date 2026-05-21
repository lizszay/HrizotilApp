using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HrizotilApp.Forms
{
    partial class FormUserEdit
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblLogin;
        private TextBox txtLogin;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblRole;
        private ComboBox cmbRole;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // lblLogin
            lblLogin.Text = "Логин:";
            lblLogin.Location = new Point(30, 30);
            lblLogin.Size = new Size(100, 25);

            // txtLogin
            txtLogin.Location = new Point(140, 30);
            txtLogin.Size = new Size(200, 27);

            // lblPassword
            lblPassword.Text = "Пароль:";
            lblPassword.Location = new Point(30, 70);
            lblPassword.Size = new Size(100, 25);

            // txtPassword
            txtPassword.Location = new Point(140, 70);
            txtPassword.Size = new Size(200, 27);
            txtPassword.UseSystemPasswordChar = true;

            // lblFullName
            lblFullName.Text = "ФИО:";
            lblFullName.Location = new Point(30, 110);
            lblFullName.Size = new Size(100, 25);

            // txtFullName
            txtFullName.Location = new Point(140, 110);
            txtFullName.Size = new Size(200, 27);

            // lblRole
            lblRole.Text = "Роль:";
            lblRole.Location = new Point(30, 150);
            lblRole.Size = new Size(100, 25);

            // cmbRole
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Location = new Point(140, 150);
            cmbRole.Size = new Size(200, 27);

            // btnSave
            btnSave.Text = "Сохранить";
            btnSave.Size = new Size(100, 35);
            btnSave.Location = new Point(80, 220);
            btnSave.BackColor = Color.LightGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            // btnCancel
            btnCancel.Text = "Отмена";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(200, 220);
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancel_Click;

            // FormUserEdit
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 300);
            Controls.Add(lblLogin);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblRole);
            Controls.Add(cmbRole);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new System.Drawing.Font("Times New Roman", 12F);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Пользователь";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}