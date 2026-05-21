namespace HrizotilApp
{
    partial class FormInfo
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            btnLogin = new Button();
            btnCurrentUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 75);
            label1.Name = "label1";
            label1.Size = new Size(494, 19);
            label1.TabIndex = 0;
            label1.Text = "Автоматизированная система учёта Цеха обогащения ПАО \"Ураласбест";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 113);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1005, 445);
            dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCurrentUser);
            panel1.Controls.Add(btnLogin);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1029, 58);
            panel1.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.OliveDrab;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 12F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(12, 12);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(97, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Выйти";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // btnCurrentUser
            // 
            btnCurrentUser.BackColor = Color.OliveDrab;
            btnCurrentUser.FlatAppearance.BorderSize = 0;
            btnCurrentUser.FlatStyle = FlatStyle.Flat;
            btnCurrentUser.Font = new Font("Times New Roman", 12F);
            btnCurrentUser.ForeColor = Color.White;
            btnCurrentUser.Location = new Point(904, 12);
            btnCurrentUser.Name = "btnCurrentUser";
            btnCurrentUser.Size = new Size(97, 23);
            btnCurrentUser.TabIndex = 6;
            btnCurrentUser.Text = "Гость";
            btnCurrentUser.UseVisualStyleBackColor = false;
            // 
            // FormInfo
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 570);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FormInfo";
            Text = "FormInfo";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button btnCurrentUser;
        private Button btnLogin;
    }
}