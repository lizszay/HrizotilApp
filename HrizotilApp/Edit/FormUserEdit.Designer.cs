namespace HrizotilApp.Forms
{
    partial class FormUserEdit
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private ComboBox cmbRole;
        private Button btnSave;
        private Button btnCancel;
        private Label lblLogin;
        private Label lblPassword;
        private Label lblFullName;
        private Label lblRole;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            cmbRole = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblLogin = new Label();
            lblPassword = new Label();
            lblFullName = new Label();
            lblRole = new Label();
            SuspendLayout();
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Times New Roman", 12F);
            txtLogin.Location = new Point(120, 30);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(180, 26);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Times New Roman", 12F);
            txtPassword.Location = new Point(120, 70);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(180, 26);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Times New Roman", 12F);
            txtFullName.Location = new Point(120, 110);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 26);
            txtFullName.TabIndex = 5;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Times New Roman", 12F);
            cmbRole.Location = new Point(120, 150);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(180, 27);
            cmbRole.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSave.Location = new Point(80, 210);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnCancel.Location = new Point(200, 210);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblLogin
            // 
            lblLogin.Font = new Font("Times New Roman", 12F);
            lblLogin.Location = new Point(30, 30);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(80, 25);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин:";
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Times New Roman", 12F);
            lblPassword.Location = new Point(30, 70);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 25);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль:";
            // 
            // lblFullName
            // 
            lblFullName.Font = new Font("Times New Roman", 12F);
            lblFullName.Location = new Point(30, 110);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(80, 25);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "ФИО:";
            // 
            // lblRole
            // 
            lblRole.Font = new Font("Times New Roman", 12F);
            lblRole.Location = new Point(30, 150);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(80, 25);
            lblRole.TabIndex = 6;
            lblRole.Text = "Роль:";
            // 
            // FormUserEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 280);
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
            Font = new Font("Times New Roman", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormUserEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление/Редактирование пользователя";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}