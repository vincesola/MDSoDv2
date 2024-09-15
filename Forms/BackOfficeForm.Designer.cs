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
            this.btnReporting = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSession
            // 
            this.btnSession.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSession.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSession.Depth = 0;
            this.btnSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSession.HighEmphasis = true;
            this.btnSession.Icon = null;
            this.btnSession.Location = new System.Drawing.Point(4, 6);
            this.btnSession.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSession.Name = "btnSession";
            this.btnSession.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSession.Size = new System.Drawing.Size(595, 62);
            this.btnSession.TabIndex = 6;
            this.btnSession.Text = "Session";
            this.btnSession.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSession.UseAccentColor = false;
            this.btnSession.UseVisualStyleBackColor = false;
            this.btnSession.Click += new System.EventHandler(this.btnSession_Click);
            // 
            // btnClass
            // 
            this.btnClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnClass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClass.Depth = 0;
            this.btnClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClass.HighEmphasis = true;
            this.btnClass.Icon = null;
            this.btnClass.Location = new System.Drawing.Point(4, 80);
            this.btnClass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClass.Name = "btnClass";
            this.btnClass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClass.Size = new System.Drawing.Size(595, 62);
            this.btnClass.TabIndex = 5;
            this.btnClass.Text = "Class";
            this.btnClass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClass.UseAccentColor = false;
            this.btnClass.UseVisualStyleBackColor = false;
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // btnImport
            // 
            this.btnImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnImport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnImport.Depth = 0;
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnImport.HighEmphasis = true;
            this.btnImport.Icon = null;
            this.btnImport.Location = new System.Drawing.Point(4, 524);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnImport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnImport.Name = "btnImport";
            this.btnImport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnImport.Size = new System.Drawing.Size(595, 68);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnImport.UseAccentColor = false;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnExport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExport.Depth = 0;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExport.HighEmphasis = true;
            this.btnExport.Icon = null;
            this.btnExport.Location = new System.Drawing.Point(4, 450);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExport.Name = "btnExport";
            this.btnExport.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExport.Size = new System.Drawing.Size(595, 62);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExport.UseAccentColor = false;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnPayment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPayment.Depth = 0;
            this.btnPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPayment.HighEmphasis = true;
            this.btnPayment.Icon = null;
            this.btnPayment.Location = new System.Drawing.Point(4, 302);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPayment.Size = new System.Drawing.Size(595, 62);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "Payment";
            this.btnPayment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPayment.UseAccentColor = false;
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnParent
            // 
            this.btnParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnParent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnParent.Depth = 0;
            this.btnParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnParent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnParent.HighEmphasis = true;
            this.btnParent.Icon = null;
            this.btnParent.Location = new System.Drawing.Point(4, 228);
            this.btnParent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnParent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnParent.Name = "btnParent";
            this.btnParent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnParent.Size = new System.Drawing.Size(595, 62);
            this.btnParent.TabIndex = 1;
            this.btnParent.Text = "Parent";
            this.btnParent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnParent.UseAccentColor = false;
            this.btnParent.UseVisualStyleBackColor = false;
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // btnTeacher
            // 
            this.btnTeacher.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnTeacher.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTeacher.Depth = 0;
            this.btnTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTeacher.HighEmphasis = true;
            this.btnTeacher.Icon = null;
            this.btnTeacher.Location = new System.Drawing.Point(4, 154);
            this.btnTeacher.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTeacher.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTeacher.Size = new System.Drawing.Size(595, 62);
            this.btnTeacher.TabIndex = 0;
            this.btnTeacher.Text = "Teacher";
            this.btnTeacher.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTeacher.UseAccentColor = false;
            this.btnTeacher.UseVisualStyleBackColor = false;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // btnReporting
            // 
            this.btnReporting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReporting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnReporting.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReporting.Depth = 0;
            this.btnReporting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReporting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReporting.HighEmphasis = true;
            this.btnReporting.Icon = null;
            this.btnReporting.Location = new System.Drawing.Point(4, 376);
            this.btnReporting.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReporting.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReporting.Name = "btnReporting";
            this.btnReporting.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReporting.Size = new System.Drawing.Size(595, 62);
            this.btnReporting.TabIndex = 8;
            this.btnReporting.Text = "Reporting";
            this.btnReporting.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReporting.UseAccentColor = false;
            this.btnReporting.UseVisualStyleBackColor = false;
            this.btnReporting.Click += new System.EventHandler(this.btnReporting_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.btnTeacher, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.btnParent, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.btnPayment, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.btnExport, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.btnImport, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.btnClass, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnSession, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnReporting, 0, 5);
            this.tableLayoutPanel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tableLayoutPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel.Location = new System.Drawing.Point(2, 70);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(603, 598);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // BackOfficeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 687);
            this.Controls.Add(this.tableLayoutPanel);
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
        private MaterialButton btnReporting;
        private TableLayoutPanel tableLayoutPanel;
    }
}
