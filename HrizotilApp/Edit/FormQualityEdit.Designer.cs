namespace HrizotilApp.Forms
{
    partial class FormQualityEdit
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpDate;
        private ComboBox cmbProduct;
        private NumericUpDown numSieve;
        private NumericUpDown numDust;
        private NumericUpDown numPk;
        private Button btnSave;
        private Button btnCancel;
        private Label lblDate;
        private Label lblProduct;
        private Label lblSieve;
        private Label lblDust;
        private Label lblPk;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpDate = new DateTimePicker();
            this.cmbProduct = new ComboBox();
            this.numSieve = new NumericUpDown();
            this.numDust = new NumericUpDown();
            this.numPk = new NumericUpDown();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblDate = new Label();
            this.lblProduct = new Label();
            this.lblSieve = new Label();
            this.lblDust = new Label();
            this.lblPk = new Label();

            ((System.ComponentModel.ISupportInitialize)this.numSieve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numDust).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numPk).BeginInit();
            this.SuspendLayout();

            // lblDate
            this.lblDate.Text = "Дата:";
            this.lblDate.Location = new Point(30, 30);
            this.lblDate.Size = new Size(80, 25);
            this.lblDate.Font = new Font("Times New Roman", 12F);

            // dtpDate
            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Location = new Point(120, 30);
            this.dtpDate.Size = new Size(120, 26);
            this.dtpDate.Font = new Font("Times New Roman", 12F);

            // lblProduct
            this.lblProduct.Text = "Марка:";
            this.lblProduct.Location = new Point(30, 70);
            this.lblProduct.Size = new Size(80, 25);
            this.lblProduct.Font = new Font("Times New Roman", 12F);

            // cmbProduct
            this.cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProduct.Location = new Point(120, 70);
            this.cmbProduct.Size = new Size(150, 27);
            this.cmbProduct.Font = new Font("Times New Roman", 12F);

            // lblSieve
            this.lblSieve.Text = "Сито 1,35 мм:";
            this.lblSieve.Location = new Point(30, 110);
            this.lblSieve.Size = new Size(110, 25);
            this.lblSieve.Font = new Font("Times New Roman", 12F);

            // numSieve
            this.numSieve.Location = new Point(150, 110);
            this.numSieve.Size = new Size(80, 26);
            this.numSieve.Font = new Font("Times New Roman", 12F);
            this.numSieve.Minimum = 0;
            this.numSieve.Maximum = 100;

            // lblDust
            this.lblDust.Text = "Пыль:";
            this.lblDust.Location = new Point(30, 150);
            this.lblDust.Size = new Size(80, 25);
            this.lblDust.Font = new Font("Times New Roman", 12F);

            // numDust
            this.numDust.Location = new Point(120, 150);
            this.numDust.Size = new Size(80, 26);
            this.numDust.Font = new Font("Times New Roman", 12F);
            this.numDust.Minimum = 0;
            this.numDust.Maximum = 100;

            // lblPk
            this.lblPk.Text = "ПК:";
            this.lblPk.Location = new Point(30, 190);
            this.lblPk.Size = new Size(80, 25);
            this.lblPk.Font = new Font("Times New Roman", 12F);

            // numPk
            this.numPk.Location = new Point(120, 190);
            this.numPk.Size = new Size(80, 26);
            this.numPk.Font = new Font("Times New Roman", 12F);
            this.numPk.Minimum = 0;
            this.numPk.Maximum = 100;

            // btnSave
            this.btnSave.Text = "Сохранить";
            this.btnSave.BackColor = Color.LightGreen;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Location = new Point(60, 250);
            this.btnSave.Size = new Size(100, 35);
            this.btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.btnSave.Click += BtnSave_Click;

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Location = new Point(180, 250);
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.btnCancel.Click += BtnCancel_Click;

            // FormQualityEdit
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(330, 320);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblSieve);
            this.Controls.Add(this.numSieve);
            this.Controls.Add(this.lblDust);
            this.Controls.Add(this.numDust);
            this.Controls.Add(this.lblPk);
            this.Controls.Add(this.numPk);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new Font("Times New Roman", 12F);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавление/Редактирование качества";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            ((System.ComponentModel.ISupportInitialize)this.numSieve).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numDust).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numPk).EndInit();
            this.ResumeLayout(false);
        }
    }
}