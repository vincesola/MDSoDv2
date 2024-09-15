using MaterialSkin.Controls;

namespace MDSoDv2
{
    partial class ClassSheetForm
    {
        // Designer variables
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckedListBox chkListClasses;
        private MaterialButton btnSelectAll;
        private MaterialButton btnPrintRosters;
        private MaterialComboBox cmbSessions;

        // Dispose method to clean up any resources being used
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
            this.chkListClasses = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAll = new MaterialSkin.Controls.MaterialButton();
            this.btnPrintRosters = new MaterialSkin.Controls.MaterialButton();
            this.cmbSessions = new MaterialSkin.Controls.MaterialComboBox();
            this.SuspendLayout();
            // 
            // chkListClasses
            // 
            this.chkListClasses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.chkListClasses.CheckOnClick = true;
            this.chkListClasses.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chkListClasses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkListClasses.FormattingEnabled = true;
            this.chkListClasses.Location = new System.Drawing.Point(12, 130);
            this.chkListClasses.Name = "chkListClasses";
            this.chkListClasses.Size = new System.Drawing.Size(725, 593);
            this.chkListClasses.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSelectAll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSelectAll.Depth = 0;
            this.btnSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSelectAll.HighEmphasis = true;
            this.btnSelectAll.Icon = null;
            this.btnSelectAll.Location = new System.Drawing.Point(755, 130);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSelectAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSelectAll.Size = new System.Drawing.Size(103, 36);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSelectAll.UseAccentColor = false;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnPrintRosters
            // 
            this.btnPrintRosters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrintRosters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnPrintRosters.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPrintRosters.Depth = 0;
            this.btnPrintRosters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintRosters.HighEmphasis = true;
            this.btnPrintRosters.Icon = null;
            this.btnPrintRosters.Location = new System.Drawing.Point(755, 178);
            this.btnPrintRosters.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPrintRosters.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPrintRosters.Name = "btnPrintRosters";
            this.btnPrintRosters.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPrintRosters.Size = new System.Drawing.Size(131, 36);
            this.btnPrintRosters.TabIndex = 2;
            this.btnPrintRosters.Text = "Print Rosters";
            this.btnPrintRosters.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPrintRosters.UseAccentColor = false;
            this.btnPrintRosters.UseVisualStyleBackColor = false;
            this.btnPrintRosters.Click += new System.EventHandler(this.btnPrintRosters_Click);
            // 
            // cmbSessions
            // 
            this.cmbSessions.AutoResize = false;
            this.cmbSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cmbSessions.Depth = 0;
            this.cmbSessions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSessions.DropDownHeight = 174;
            this.cmbSessions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSessions.DropDownWidth = 121;
            this.cmbSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbSessions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbSessions.Hint = "Select Session";
            this.cmbSessions.IntegralHeight = false;
            this.cmbSessions.ItemHeight = 43;
            this.cmbSessions.Location = new System.Drawing.Point(12, 75);
            this.cmbSessions.MaxDropDownItems = 4;
            this.cmbSessions.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbSessions.Name = "cmbSessions";
            this.cmbSessions.Size = new System.Drawing.Size(200, 49);
            this.cmbSessions.StartIndex = 0;
            this.cmbSessions.TabIndex = 0;
            this.cmbSessions.SelectedIndexChanged += new System.EventHandler(this.cmbSessions_SelectedIndexChanged);
            // 
            // ClassSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 760);
            this.Controls.Add(this.chkListClasses);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnPrintRosters);
            this.Controls.Add(this.cmbSessions);
            this.Name = "ClassSheetForm";
            this.Text = "Class Sheets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
