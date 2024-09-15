namespace MDSoDv2
{
    partial class UnknownsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUnknowns;
        private MaterialSkin.Controls.MaterialButton btnSaveToFile;
        private MaterialSkin.Controls.MaterialButton btnPrint;

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
            this.dgvUnknowns = new System.Windows.Forms.DataGridView();
            this.btnSaveToFile = new MaterialSkin.Controls.MaterialButton();
            this.btnPrint = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknowns)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUnknowns
            // 
            this.dgvUnknowns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnknowns.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvUnknowns.Location = new System.Drawing.Point(4, 68);
            this.dgvUnknowns.Name = "dgvUnknowns";
            this.dgvUnknowns.Size = new System.Drawing.Size(760, 400);
            this.dgvUnknowns.TabIndex = 0;
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveToFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSaveToFile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSaveToFile.Depth = 0;
            this.btnSaveToFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSaveToFile.HighEmphasis = true;
            this.btnSaveToFile.Icon = null;
            this.btnSaveToFile.Location = new System.Drawing.Point(273, 477);
            this.btnSaveToFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveToFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSaveToFile.Size = new System.Drawing.Size(113, 36);
            this.btnSaveToFile.TabIndex = 1;
            this.btnSaveToFile.Text = "Save to File";
            this.btnSaveToFile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSaveToFile.UseAccentColor = false;
            this.btnSaveToFile.UseVisualStyleBackColor = false;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnPrint.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPrint.Depth = 0;
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrint.HighEmphasis = true;
            this.btnPrint.Icon = null;
            this.btnPrint.Location = new System.Drawing.Point(401, 477);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPrint.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPrint.Size = new System.Drawing.Size(64, 36);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPrint.UseAccentColor = false;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // UnknownsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 532);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.dgvUnknowns);
            this.Name = "UnknownsForm";
            this.Text = "Unknowns";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnknowns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
