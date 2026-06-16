namespace HrizotilApp.Forms
{
    partial class FormShipmentEdit
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpDate;
        private ComboBox cmbProduct;
        private ComboBox cmbFromWarehouse;
        private ComboBox cmbToWarehouse;
        private NumericUpDown numQuantity;
        private Button btnSave;
        private Button btnCancel;
        private Label lblDate;
        private Label lblProduct;
        private Label lblFromWarehouse;
        private Label lblToWarehouse;
        private Label lblQuantity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dtpDate = new DateTimePicker();
            cmbProduct = new ComboBox();
            cmbFromWarehouse = new ComboBox();
            cmbToWarehouse = new ComboBox();
            numQuantity = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblDate = new Label();
            lblProduct = new Label();
            lblFromWarehouse = new Label();
            lblToWarehouse = new Label();
            lblQuantity = new Label();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Times New Roman", 12F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(140, 30);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(120, 26);
            dtpDate.TabIndex = 1;
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Font = new Font("Times New Roman", 12F);
            cmbProduct.Location = new Point(140, 70);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(150, 27);
            cmbProduct.TabIndex = 3;
            // 
            // cmbFromWarehouse
            // 
            cmbFromWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFromWarehouse.Font = new Font("Times New Roman", 12F);
            cmbFromWarehouse.Location = new Point(170, 110);
            cmbFromWarehouse.Name = "cmbFromWarehouse";
            cmbFromWarehouse.Size = new Size(150, 27);
            cmbFromWarehouse.TabIndex = 5;
            // 
            // cmbToWarehouse
            // 
            cmbToWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbToWarehouse.Font = new Font("Times New Roman", 12F);
            cmbToWarehouse.Location = new Point(170, 150);
            cmbToWarehouse.Name = "cmbToWarehouse";
            cmbToWarehouse.Size = new Size(150, 27);
            cmbToWarehouse.TabIndex = 7;
            // 
            // numQuantity
            // 
            numQuantity.DecimalPlaces = 2;
            numQuantity.Font = new Font("Times New Roman", 12F);
            numQuantity.Location = new Point(140, 190);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(100, 26);
            numQuantity.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LightGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnSave.Location = new Point(70, 250);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnCancel.Location = new Point(190, 250);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Times New Roman", 12F);
            lblDate.Location = new Point(30, 30);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(80, 25);
            lblDate.TabIndex = 0;
            lblDate.Text = "Дата:";
            // 
            // lblProduct
            // 
            lblProduct.Font = new Font("Times New Roman", 12F);
            lblProduct.Location = new Point(30, 70);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(80, 25);
            lblProduct.TabIndex = 2;
            lblProduct.Text = "Марка:";
            // 
            // lblFromWarehouse
            // 
            lblFromWarehouse.Font = new Font("Times New Roman", 12F);
            lblFromWarehouse.Location = new Point(30, 110);
            lblFromWarehouse.Name = "lblFromWarehouse";
            lblFromWarehouse.Size = new Size(130, 25);
            lblFromWarehouse.TabIndex = 4;
            lblFromWarehouse.Text = "Склад отправитель:";
            // 
            // lblToWarehouse
            // 
            lblToWarehouse.Font = new Font("Times New Roman", 12F);
            lblToWarehouse.Location = new Point(30, 150);
            lblToWarehouse.Name = "lblToWarehouse";
            lblToWarehouse.Size = new Size(130, 25);
            lblToWarehouse.TabIndex = 6;
            lblToWarehouse.Text = "Склад получатель:";
            // 
            // lblQuantity
            // 
            lblQuantity.Font = new Font("Times New Roman", 12F);
            lblQuantity.Location = new Point(30, 190);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 25);
            lblQuantity.TabIndex = 8;
            lblQuantity.Text = "Количество, т:";
            // 
            // FormShipmentEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 320);
            Controls.Add(lblDate);
            Controls.Add(dtpDate);
            Controls.Add(lblProduct);
            Controls.Add(cmbProduct);
            Controls.Add(lblFromWarehouse);
            Controls.Add(cmbFromWarehouse);
            Controls.Add(lblToWarehouse);
            Controls.Add(cmbToWarehouse);
            Controls.Add(lblQuantity);
            Controls.Add(numQuantity);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Font = new Font("Times New Roman", 12F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormShipmentEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление/Редактирование отгрузки";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
        }
    }
}