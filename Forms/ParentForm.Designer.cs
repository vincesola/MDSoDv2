namespace MDSoDv2
{
    partial class ParentForm
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
            this.SuspendLayout();
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = global::MDSoDv2.Properties.Resources.MDSoDv2_logo1; // Set the form icon
            this.Name = "ParentForm";
            this.Text = "ParentForm";
            this.ResumeLayout(false);
        }
    }
}
