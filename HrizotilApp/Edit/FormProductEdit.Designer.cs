namespace HrizotilApp
{
    partial class FormProductEdit
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblCode;
        private TextBox txtCode;
        private Label lblGroup;
        private ComboBox cmbGroup;
        private Label lblSieve;
        private TextBox txtSieve;
        private Label lblDust;
        private TextBox txtDust;
        private Label lblPk;
        private TextBox txtPk;
        private Label lblDensity;
        private TextBox txtDensity;
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
            lblCode = new Label();
            txtCode = new TextBox();
            lblGroup = new Label();
            cmbGroup = new ComboBox();
            lblSieve = new Label();
            txtSieve = new TextBox();
            lblDust = new Label();
            txtDust = new TextBox();
            lblPk = new Label();
            txtPk = new TextBox();
            lblDensity = new Label();
            txtDensity = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // lblCode
            lblCode.Text = "Код марки:";
            lblCode.Location = new Point(30, 30);
            lblCode.Size = new Size(100, 25);

            // txtCode
            txtCode.Location = new Point(140, 30);
            txtCode.Size = new Size(200, 27);

            // lblGroup
            lblGroup.Text = "Группа:";
            lblGroup.Location = new Point(30, 70);
            lblGroup.Size = new Size(100, 25);

            // cmbGroup
            cmbGroup.Location = new Point(140, 70);
            cmbGroup.Size = new Size(200, 27);
            cmbGroup.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblSieve
            lblSieve.Text = "Норма сито (min):";
            lblSieve.Location = new Point(30, 110);
            lblSieve.Size = new Size(140, 25);

            // txtSieve
            txtSieve.Location = new Point(180, 110);
            txtSieve.Size = new Size(100, 27);

            // lblDust
            lblDust.Text = "Норма пыль (max):";
            lblDust.Location = new Point(30, 150);
            lblDust.Size = new Size(140, 25);

            // txtDust
            txtDust.Location = new Point(180, 150);
            txtDust.Size = new Size(100, 27);

            // lblPk
            lblPk.Text = "Норма ПК (max):";
            lblPk.Location = new Point(30, 190);
            lblPk.Size = new Size(140, 25);

            // txtPk
            txtPk.Location = new Point(180, 190);
            txtPk.Size = new Size(100, 27);

            // lblDensity
            lblDensity.Text = "Насыпная плотность:";
            lblDensity.Location = new Point(30, 230);
            lblDensity.Size = new Size(140, 25);

            // txtDensity
            txtDensity.Location = new Point(180, 230);
            txtDensity.Size = new Size(100, 27);

            // btnSave
            btnSave.Text = "Сохранить";
            btnSave.Size = new Size(100, 35);
            btnSave.Location = new Point(80, 290);
            btnSave.BackColor = Color.LightGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;

            // btnCancel
            btnCancel.Text = "Отмена";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(200, 290);
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += BtnCancel_Click;

            // FormProductEdit
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 360);
            Controls.Add(lblCode);
            Controls.Add(txtCode);
            Controls.Add(lblGroup);
            Controls.Add(cmbGroup);
            Controls.Add(lblSieve);
            Controls.Add(txtSieve);
            Controls.Add(lblDust);
            Controls.Add(txtDust);
            Controls.Add(lblPk);
            Controls.Add(txtPk);
            Controls.Add(lblDensity);
            Controls.Add(txtDensity);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 10F);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление / Редактирование марки";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}