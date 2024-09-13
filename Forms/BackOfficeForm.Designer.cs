using MaterialSkin.Controls;
using System.Windows.Forms;

namespace MDSoDv2
{
    partial class BackOfficeForm
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
            this.btnSession = new MaterialSkin.Controls.MaterialButton();
            this.btnClass = new MaterialSkin.Controls.MaterialButton();
            this.btnImport = new MaterialSkin.Controls.MaterialButton();
            this.btnExport = new MaterialSkin.Controls.MaterialButton();
            this.btnPayment = new MaterialSkin.Controls.MaterialButton();
            this.btnParent = new MaterialSkin.Controls.MaterialButton();
            this.btnTeacher = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSession
            //
            this.btnSession.Dock = DockStyle.Fill;
            this.btnSession.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSession.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSession.Depth = 0;
            this.btnSession.HighEmphasis = true;
            this.btnSession.Icon = null;
            this.btnSession.Location = new System.Drawing.Point(4, 6);
            this.btnSession.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSession.Name = "btnSession";
            this.btnSession.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSession.Size = new System.Drawing.Size(90, 36);
            this.btnSession.TabIndex = 1;
            this.btnSession.Text = "Session";
            this.btnSession.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSession.UseAccentColor = false;
            this.btnSession.UseVisualStyleBackColor = true;
            this.btnSession.Click += new System.EventHandler(this.btnSession_Click);
            // 
            // btnClass
            // 
            this.btnClass.Dock = DockStyle.Fill;
            this.btnClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClass.Depth = 0;
            this.btnClass.HighEmphasis = true;
            this.btnClass.Icon = null;
            this.btnClass.Location = new System.Drawing.Point(4, 73);
            this.btnClass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClass.Name = "btnClass";
            this.btnClass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClass.Size = new System.Drawing.Size(90, 36);
            this.btnClass.TabIndex = 2;
            this.btnClass.Text = "Class";
            this.btnClass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClass.UseAccentColor = false;
            this.btnClass.UseVisualStyleBackColor = true;
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = DockStyle.Fill;
            this.btnImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnImport.Depth = 0;
            this.btnImport.HighEmphasis = true;
            this.btnImport.Icon = null;
            this.btnImport.Location = new System.Drawing.Point(4, 408);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnImport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnImport.Name = "btnImport";
            this.btnImport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnImport.Size = new System.Drawing.Size(90, 36);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnImport.UseAccentColor = false;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = DockStyle.Fill;
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExport.Depth = 0;
            this.btnExport.HighEmphasis = true;
            this.btnExport.Icon = null;
            this.btnExport.Location = new System.Drawing.Point(4, 341);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExport.Name = "btnExport";
            this.btnExport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExport.Size = new System.Drawing.Size(90, 36);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExport.UseAccentColor = false;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Dock = DockStyle.Fill;
            this.btnPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPayment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPayment.Depth = 0;
            this.btnPayment.HighEmphasis = true;
            this.btnPayment.Icon = null;
            this.btnPayment.Location = new System.Drawing.Point(4, 274);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPayment.Size = new System.Drawing.Size(90, 36);
            this.btnPayment.TabIndex = 5;
            this.btnPayment.Text = "Payment";
            this.btnPayment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPayment.UseAccentColor = false;
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnParent
            // 
            this.btnParent.Dock = DockStyle.Fill;
            this.btnParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnParent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnParent.Depth = 0;
            this.btnParent.HighEmphasis = true;
            this.btnParent.Icon = null;
            this.btnParent.Location = new System.Drawing.Point(4, 207);
            this.btnParent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnParent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnParent.Name = "btnParent";
            this.btnParent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnParent.Size = new System.Drawing.Size(90, 36);
            this.btnParent.TabIndex = 4;
            this.btnParent.Text = "Parent";
            this.btnParent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnParent.UseAccentColor = false;
            this.btnParent.UseVisualStyleBackColor = true;
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // btnTeacher
            // 
            this.btnTeacher.Dock = DockStyle.Fill;
            this.btnTeacher.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTeacher.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTeacher.Depth = 0;
            this.btnTeacher.HighEmphasis = true;
            this.btnTeacher.Icon = null;
            this.btnTeacher.Location = new System.Drawing.Point(4, 140);
            this.btnTeacher.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTeacher.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTeacher.Size = new System.Drawing.Size(90, 36);
            this.btnTeacher.TabIndex = 3;
            this.btnTeacher.Text = "Teacher";
            this.btnTeacher.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTeacher.UseAccentColor = false;
            this.btnTeacher.UseVisualStyleBackColor = true;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.btnTeacher, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnParent, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.btnPayment, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.btnExport, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.btnImport, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.btnClass, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnSession, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(603, 473);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // BackOfficeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 540);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = global::MDSoDv2.Properties.Resources.MDSoDv2_logo1;
            this.Name = "BackOfficeForm";
            this.Text = "BackOffice";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private MaterialButton btnSession;
        private MaterialButton btnClass;
        private MaterialButton btnImport;
        private MaterialButton btnExport;
        private MaterialButton btnPayment;
        private MaterialButton btnParent;
        private MaterialButton btnTeacher;
        private TableLayoutPanel tableLayoutPanel;
    }
}
