namespace MDSoDv2
{
    partial class AddSessionForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtSessionName;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;

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
            this.txtSessionName = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtSessionName
            // 
            this.txtSessionName.AnimateReadOnly = false;
            this.txtSessionName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSessionName.Depth = 0;
            this.txtSessionName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSessionName.Hint = "Session Name";
            this.txtSessionName.LeadingIcon = null;
            this.txtSessionName.Location = new System.Drawing.Point(7, 71);
            this.txtSessionName.MaxLength = 50;
            this.txtSessionName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSessionName.Multiline = false;
            this.txtSessionName.Name = "txtSessionName";
            this.txtSessionName.Size = new System.Drawing.Size(385, 50);
            this.txtSessionName.TabIndex = 0;
            this.txtSessionName.Text = "";
            this.txtSessionName.TrailingIcon = null;
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(328, 130);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(243, 130);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 182);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSessionName);
            this.Name = "AddSessionForm";
            this.Text = "Add Session";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
