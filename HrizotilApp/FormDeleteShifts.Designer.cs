namespace HrizotilApp.Forms
{
    partial class FormDeleteShifts
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblInfo;
        private Button btnDeleteAll;
        private Button btnDeleteSelected;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblInfo = new Label();
            btnDeleteAll = new Button();
            btnDeleteSelected = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // lblInfo
            lblInfo.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblInfo.Location = new Point(20, 20);
            lblInfo.Size = new Size(400, 30);
            lblInfo.Text = "Выберите смены для удаления:";

            // btnDeleteAll
            this.btnDeleteAll.Text = "🗑️ Всё";
            this.btnDeleteAll.Size = new Size(80, 35);

            // btnDeleteSelected
            this.btnDeleteSelected.Text = "🗑️ Выбр.";
            this.btnDeleteSelected.Size = new Size(80, 35);

            // btnCancel
            this.btnCancel.Text = "✖";
            this.btnCancel.Size = new Size(50, 35);

            // FormDeleteShifts
            this.AutoScaleDimensions = new SizeF(9F, 19F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(450, 200);
            this.Controls.Add(lblInfo);
            this.Controls.Add(btnDeleteAll);
            this.Controls.Add(btnDeleteSelected);
            this.Controls.Add(btnCancel);
            this.Font = new Font("Times New Roman", 12F);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Удаление смен";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            ResumeLayout(false);
        }
    }
}