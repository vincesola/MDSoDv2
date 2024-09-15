namespace MDSoDv2
{
    partial class ReportingForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialButton btnAllUnknowns;

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
            this.SuspendLayout();
            // 
            // btnAllUnknowns
            // 
            this.btnAllUnknowns.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAllUnknowns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAllUnknowns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnAllUnknowns.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAllUnknowns.Depth = 0;
            this.btnAllUnknowns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllUnknowns.HighEmphasis = true;
            this.btnAllUnknowns.Icon = null;
            this.btnAllUnknowns.Location = new System.Drawing.Point(5, 71);
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
            // ReportingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnAllUnknowns);
            this.Name = "ReportingForm";
            this.Text = "Reporting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
