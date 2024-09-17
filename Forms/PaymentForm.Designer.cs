namespace MDSoDv2
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvStudents;
        private MaterialSkin.Controls.MaterialButton btnPaymentHistory;
        private MaterialSkin.Controls.MaterialButton btnGeneratePayments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnPaymentHistory = new MaterialSkin.Controls.MaterialButton();
            this.btnGeneratePayments = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.AnimateReadOnly = false;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.LeadingIcon = null;
            this.txtSearch.Location = new System.Drawing.Point(12, 86);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 50);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "";
            this.txtSearch.TrailingIcon = null;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold);
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStudents.ColumnHeadersHeight = 50;

            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvStudents.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvStudents.DefaultCellStyle.Font = new System.Drawing.Font("Roboto", 10F);
            this.dgvStudents.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(197, 17, 98);
            this.dgvStudents.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            this.dgvStudents.GridColor = System.Drawing.Color.Gray;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;

            this.dgvStudents.Location = new System.Drawing.Point(12, 142);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.Size = new System.Drawing.Size(664, 429);
            this.dgvStudents.TabIndex = 1;
            // 
            // btnPaymentHistory
            // 
            this.btnPaymentHistory.AutoSize = false;
            this.btnPaymentHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPaymentHistory.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPaymentHistory.Depth = 0;
            this.btnPaymentHistory.HighEmphasis = true;
            this.btnPaymentHistory.Icon = null;
            this.btnPaymentHistory.Location = new System.Drawing.Point(683, 142);
            this.btnPaymentHistory.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPaymentHistory.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPaymentHistory.Name = "btnPaymentHistory";
            this.btnPaymentHistory.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPaymentHistory.Size = new System.Drawing.Size(199, 73);
            this.btnPaymentHistory.TabIndex = 2;
            this.btnPaymentHistory.Text = "Payment History";
            this.btnPaymentHistory.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPaymentHistory.UseAccentColor = false;
            this.btnPaymentHistory.UseVisualStyleBackColor = true;
            this.btnPaymentHistory.Click += new System.EventHandler(this.btnPaymentHistory_Click);
            // 
            // btnGeneratePayments
            // 
            this.btnGeneratePayments.AutoSize = false;
            this.btnGeneratePayments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGeneratePayments.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGeneratePayments.Depth = 0;
            this.btnGeneratePayments.HighEmphasis = true;
            this.btnGeneratePayments.Icon = null;
            this.btnGeneratePayments.Location = new System.Drawing.Point(683, 227);
            this.btnGeneratePayments.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGeneratePayments.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGeneratePayments.Name = "btnGeneratePayments";
            this.btnGeneratePayments.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGeneratePayments.Size = new System.Drawing.Size(199, 73);
            this.btnGeneratePayments.TabIndex = 3;
            this.btnGeneratePayments.Text = "Generate Payments";
            this.btnGeneratePayments.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGeneratePayments.UseAccentColor = false;
            this.btnGeneratePayments.UseVisualStyleBackColor = true;
            this.btnGeneratePayments.Click += new System.EventHandler(this.btnGeneratePayments_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 583);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnPaymentHistory);
            this.Controls.Add(this.btnGeneratePayments);
            this.Name = "PaymentForm";
            this.Text = "Payment Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
