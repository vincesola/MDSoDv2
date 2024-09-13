using MaterialSkin.Controls;
using System.Windows.Forms;

namespace MDSoDv2
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialButton btnStudents;
        private MaterialButton btnBackOffice;
        private PictureBox pictureBoxLogo;

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
            this.btnStudents = new MaterialSkin.Controls.MaterialButton();
            this.btnBackOffice = new MaterialSkin.Controls.MaterialButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStudents
            // 
            this.btnStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStudents.AutoSize = false;
            this.btnStudents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStudents.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStudents.Depth = 0;
            this.btnStudents.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnStudents.HighEmphasis = true;
            this.btnStudents.Icon = null;
            this.btnStudents.Location = new System.Drawing.Point(193, 460);
            this.btnStudents.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStudents.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStudents.Size = new System.Drawing.Size(324, 179);
            this.btnStudents.TabIndex = 0;
            this.btnStudents.Text = "Students";
            this.btnStudents.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStudents.UseAccentColor = false;
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnBackOffice
            // 
            this.btnBackOffice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackOffice.AutoSize = false;
            this.btnBackOffice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackOffice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackOffice.Depth = 0;
            this.btnBackOffice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnBackOffice.HighEmphasis = true;
            this.btnBackOffice.Icon = null;
            this.btnBackOffice.Location = new System.Drawing.Point(650, 460);
            this.btnBackOffice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBackOffice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackOffice.Name = "btnBackOffice";
            this.btnBackOffice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackOffice.Size = new System.Drawing.Size(324, 179);
            this.btnBackOffice.TabIndex = 1;
            this.btnBackOffice.Text = "Back Office";
            this.btnBackOffice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBackOffice.UseAccentColor = false;
            this.btnBackOffice.UseVisualStyleBackColor = true;
            this.btnBackOffice.Click += new System.EventHandler(this.btnBackOffice_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxLogo.Image = global::MDSoDv2.Properties.Resources.MDSoDv2_logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(437, 103);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(294, 294);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 3;
            this.pictureBoxLogo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1183, 716);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.btnBackOffice);
            this.Controls.Add(this.btnStudents);
            this.Icon = global::MDSoDv2.Properties.Resources.MDSoDv2_logo1;
            this.Name = "MainForm";
            this.Text = "Miss Dianna\'s System of Data";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
