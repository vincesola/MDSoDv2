namespace MDSoDv2
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Location = new System.Drawing.Point(150, 20);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(200, 20);
            this.dtpPaymentDate.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(150, 60);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 20);
            this.txtAmount.TabIndex = 1;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Check",
            "Credit Card",
            "Bank Transfer"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(150, 100);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(200, 21);
            this.cmbPaymentMethod.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(80, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Location = new System.Drawing.Point(50, 20);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(74, 13);
            this.lblPaymentDate.TabIndex = 5;
            this.lblPaymentDate.Text = "Payment Date";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(50, 60);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Amount";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(50, 100);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(87, 13);
            this.lblPaymentMethod.TabIndex = 7;
            this.lblPaymentMethod.Text = "Payment Method";
            // 
            // PaymentForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblPaymentDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpPaymentDate);
            this.Icon = global::MDSoDv2.Properties.Resources.MDSoDv2_logo1; // Set the form icon
            this.Name = "PaymentForm";
            this.Text = "PaymentForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPaymentMethod;
    }
}
