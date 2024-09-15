namespace MDSoDv2
{
    partial class ClassForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialComboBox cmbSession;
        private MaterialSkin.Controls.MaterialButton btnAddClass;
        private MaterialSkin.Controls.MaterialButton btnDeleteClass;
        private MaterialSkin.Controls.MaterialButton btnUpdateClass;
        private System.Windows.Forms.DataGridView dgvClasses;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbSession = new MaterialSkin.Controls.MaterialComboBox();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.btnAddClass = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteClass = new MaterialSkin.Controls.MaterialButton();
            this.btnUpdateClass = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSession
            // 
            this.cmbSession.AutoResize = false;
            this.cmbSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cmbSession.Depth = 0;
            this.cmbSession.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSession.DropDownHeight = 174;
            this.cmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSession.DropDownWidth = 121;
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.IntegralHeight = false;
            this.cmbSession.ItemHeight = 43;
            this.cmbSession.Location = new System.Drawing.Point(12, 78);
            this.cmbSession.MaxDropDownItems = 4;
            this.cmbSession.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(209, 49);
            this.cmbSession.StartIndex = 0;
            this.cmbSession.TabIndex = 0;
            // 
            // dgvClasses
            // 
            this.dgvClasses.AllowUserToAddRows = false;
            this.dgvClasses.AllowUserToDeleteRows = false;
            this.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClasses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClasses.ColumnHeadersHeight = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(17)))), ((int)(((byte)(98)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClasses.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClasses.EnableHeadersVisualStyles = false;
            this.dgvClasses.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvClasses.GridColor = System.Drawing.Color.Gray;
            this.dgvClasses.Location = new System.Drawing.Point(12, 136);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.ReadOnly = true;
            this.dgvClasses.RowHeadersVisible = false;
            this.dgvClasses.Size = new System.Drawing.Size(1226, 320);
            this.dgvClasses.TabIndex = 1;
            // 
            // btnAddClass
            // 
            this.btnAddClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnAddClass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddClass.Depth = 0;
            this.btnAddClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddClass.HighEmphasis = true;
            this.btnAddClass.Icon = null;
            this.btnAddClass.Location = new System.Drawing.Point(12, 466);
            this.btnAddClass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddClass.Size = new System.Drawing.Size(99, 36);
            this.btnAddClass.TabIndex = 2;
            this.btnAddClass.Text = "Add Class";
            this.btnAddClass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddClass.UseAccentColor = false;
            this.btnAddClass.UseVisualStyleBackColor = false;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnDeleteClass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteClass.Depth = 0;
            this.btnDeleteClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteClass.HighEmphasis = true;
            this.btnDeleteClass.Icon = null;
            this.btnDeleteClass.Location = new System.Drawing.Point(253, 466);
            this.btnDeleteClass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDeleteClass.Size = new System.Drawing.Size(122, 36);
            this.btnDeleteClass.TabIndex = 3;
            this.btnDeleteClass.Text = "Delete Class";
            this.btnDeleteClass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteClass.UseAccentColor = false;
            this.btnDeleteClass.UseVisualStyleBackColor = false;
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // btnUpdateClass
            // 
            this.btnUpdateClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnUpdateClass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUpdateClass.Depth = 0;
            this.btnUpdateClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdateClass.HighEmphasis = true;
            this.btnUpdateClass.Icon = null;
            this.btnUpdateClass.Location = new System.Drawing.Point(119, 466);
            this.btnUpdateClass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdateClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdateClass.Name = "btnUpdateClass";
            this.btnUpdateClass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUpdateClass.Size = new System.Drawing.Size(126, 36);
            this.btnUpdateClass.TabIndex = 4;
            this.btnUpdateClass.Text = "Update Class";
            this.btnUpdateClass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUpdateClass.UseAccentColor = false;
            this.btnUpdateClass.UseVisualStyleBackColor = false;
            this.btnUpdateClass.Click += new System.EventHandler(this.btnUpdateClass_Click);
            // 
            // ClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 523);
            this.Controls.Add(this.btnDeleteClass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.btnUpdateClass);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.cmbSession);
            this.Name = "ClassForm";
            this.Text = "Classes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
