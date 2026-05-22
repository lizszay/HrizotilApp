namespace HrizotilApp.Forms
{
    partial class FormProductionEdit
    {
        private System.ComponentModel.IContainer components = null;

        private DateTimePicker dtpDate;
        private ComboBox cmbProduct;
        private ComboBox cmbShift;
        private NumericUpDown numPlan;
        private NumericUpDown numFact;
        private Button btnSave;
        private Button btnCancel;
        private Label lblDate;
        private Label lblProduct;
        private Label lblShift;
        private Label lblPlan;
        private Label lblFact;

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
            this.cmbShift = new ComboBox();
            this.numPlan = new NumericUpDown();
            this.numFact = new NumericUpDown();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblDate = new Label();
            this.lblProduct = new Label();
            this.lblShift = new Label();
            this.lblPlan = new Label();
            this.lblFact = new Label();

            ((System.ComponentModel.ISupportInitialize)this.numPlan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.numFact).BeginInit();
            this.SuspendLayout();

            // lblDate
            this.lblDate.Font = new Font("Times New Roman", 12F);
            this.lblDate.Location = new Point(30, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(100, 25);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата:";
            this.lblDate.TextAlign = ContentAlignment.MiddleLeft;

            // dtpDate
            this.dtpDate.Font = new Font("Times New Roman", 12F);
            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Location = new Point(140, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new Size(130, 26);
            this.dtpDate.TabIndex = 1;

            // lblProduct
            this.lblProduct.Font = new Font("Times New Roman", 12F);
            this.lblProduct.Location = new Point(30, 75);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new Size(100, 25);
            this.lblProduct.TabIndex = 2;
            this.lblProduct.Text = "Продукция:";
            this.lblProduct.TextAlign = ContentAlignment.MiddleLeft;

            // cmbProduct
            this.cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new Font("Times New Roman", 12F);
            this.cmbProduct.Location = new Point(140, 75);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new Size(180, 27);
            this.cmbProduct.TabIndex = 3;

            // lblShift
            this.lblShift.Font = new Font("Times New Roman", 12F);
            this.lblShift.Location = new Point(30, 120);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new Size(100, 25);
            this.lblShift.TabIndex = 4;
            this.lblShift.Text = "Смена:";
            this.lblShift.TextAlign = ContentAlignment.MiddleLeft;

            // cmbShift
            this.cmbShift.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbShift.Font = new Font("Times New Roman", 12F);
            this.cmbShift.Items.AddRange(new object[] { "1", "2", "3" });
            this.cmbShift.Location = new Point(140, 120);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new Size(80, 27);
            this.cmbShift.TabIndex = 5;

            // lblPlan
            this.lblPlan.Font = new Font("Times New Roman", 12F);
            this.lblPlan.Location = new Point(30, 165);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new Size(100, 25);
            this.lblPlan.TabIndex = 6;
            this.lblPlan.Text = "План (т):";
            this.lblPlan.TextAlign = ContentAlignment.MiddleLeft;

            // numPlan
            this.numPlan.DecimalPlaces = 2;
            this.numPlan.Font = new Font("Times New Roman", 12F);
            this.numPlan.Location = new Point(140, 165);
            this.numPlan.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numPlan.Name = "numPlan";
            this.numPlan.Size = new Size(130, 26);
            this.numPlan.TabIndex = 7;

            // lblFact
            this.lblFact.Font = new Font("Times New Roman", 12F);
            this.lblFact.Location = new Point(30, 210);
            this.lblFact.Name = "lblFact";
            this.lblFact.Size = new Size(100, 25);
            this.lblFact.TabIndex = 8;
            this.lblFact.Text = "Факт (т):";
            this.lblFact.TextAlign = ContentAlignment.MiddleLeft;

            // numFact
            this.numFact.DecimalPlaces = 2;
            this.numFact.Font = new Font("Times New Roman", 12F);
            this.numFact.Location = new Point(140, 210);
            this.numFact.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numFact.Name = "numFact";
            this.numFact.Size = new Size(130, 26);
            this.numFact.TabIndex = 9;

            // btnSave
            this.btnSave.BackColor = Color.LightGreen;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.btnSave.Location = new Point(70, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(110, 38);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += BtnSave_Click;

            // btnCancel
            this.btnCancel.BackColor = Color.LightGray;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.btnCancel.Location = new Point(200, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(110, 38);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += BtnCancel_Click;

            // FormProductionEdit
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(360, 340);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.numPlan);
            this.Controls.Add(this.lblFact);
            this.Controls.Add(this.numFact);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Font = new Font("Times New Roman", 12F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProductionEdit";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавление / Редактирование выработки";

            ((System.ComponentModel.ISupportInitialize)this.numPlan).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.numFact).EndInit();
            this.ResumeLayout(false);
        }
    }
}