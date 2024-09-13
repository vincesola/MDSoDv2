namespace MDSoDv2
{
    partial class SelectClassForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;

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
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClasses
            // 
            this.dgvClasses.AllowUserToAddRows = false;
            this.dgvClasses.AllowUserToDeleteRows = false;
            this.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Location = new System.Drawing.Point(12, 12);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.ReadOnly = true;
            this.dgvClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.Size = new System.Drawing.Size(987, 200);
            this.dgvClasses.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 220);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SelectClassForm
            // 
            this.ClientSize = new System.Drawing.Size(1011, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvClasses);
            this.Name = "SelectClassForm";
            this.Text = "Select Class";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
