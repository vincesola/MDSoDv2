namespace MDSoDv2
{
    partial class ReportingForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialButton btnAllUnknowns;
        private MaterialSkin.Controls.MaterialButton btnClassSheets;

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
            this.btnAllUnknowns = new MaterialSkin.Controls.MaterialButton();
            this.btnClassSheets = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // btnAllUnknowns
            // 
            this.btnAllUnknowns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAllUnknowns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnAllUnknowns.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAllUnknowns.Depth = 0;
            this.btnAllUnknowns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllUnknowns.HighEmphasis = true;
            this.btnAllUnknowns.Icon = null;
            this.btnAllUnknowns.Location = new System.Drawing.Point(18, 80);
            this.btnAllUnknowns.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAllUnknowns.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAllUnknowns.Name = "btnAllUnknowns";
            this.btnAllUnknowns.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAllUnknowns.Size = new System.Drawing.Size(133, 36);
            this.btnAllUnknowns.TabIndex = 0;
            this.btnAllUnknowns.Text = "All Unknowns";
            this.btnAllUnknowns.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAllUnknowns.UseAccentColor = false;
            this.btnAllUnknowns.UseVisualStyleBackColor = false;
            this.btnAllUnknowns.Click += new System.EventHandler(this.btnAllUnknowns_Click);
            // 
            // btnClassSheets
            // 
            this.btnClassSheets.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClassSheets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnClassSheets.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClassSheets.Depth = 0;
            this.btnClassSheets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClassSheets.HighEmphasis = true;
            this.btnClassSheets.Icon = null;
            this.btnClassSheets.Location = new System.Drawing.Point(168, 80);
            this.btnClassSheets.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClassSheets.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClassSheets.Name = "btnClassSheets";
            this.btnClassSheets.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClassSheets.Size = new System.Drawing.Size(124, 36);
            this.btnClassSheets.TabIndex = 2;
            this.btnClassSheets.Text = "Class Sheets";
            this.btnClassSheets.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClassSheets.UseAccentColor = false;
            this.btnClassSheets.UseVisualStyleBackColor = false;
            this.btnClassSheets.Click += new System.EventHandler(this.btnClassSheets_Click);
            // 
            // ReportingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 323);
            this.Controls.Add(this.btnAllUnknowns);
            this.Controls.Add(this.btnClassSheets);
            this.Name = "ReportingForm";
            this.Text = "Reporting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
