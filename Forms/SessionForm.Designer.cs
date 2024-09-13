using System.Windows.Forms;
using System.Drawing;

namespace MDSoDv2
{
    partial class SessionForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialButton btnAddSession;
        private MaterialSkin.Controls.MaterialButton btnDeleteSession;
        private System.Windows.Forms.DataGridView dgvSessions;

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
            this.dgvSessions = new System.Windows.Forms.DataGridView();
            this.btnAddSession = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteSession = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSessions
            //

            this.dgvSessions.AllowUserToAddRows = false;
            this.dgvSessions.AllowUserToDeleteRows = false;
            this.dgvSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Columns auto-size
            this.dgvSessions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76); // Header background
            this.dgvSessions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text color
            this.dgvSessions.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 12F, FontStyle.Bold); // Custom font for headers
            this.dgvSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSessions.ColumnHeadersHeight = 50; // Set header height

            this.dgvSessions.EnableHeadersVisualStyles = false; // Allow custom header styles
            this.dgvSessions.DefaultCellStyle.BackColor = Color.White; // Default cell background
            this.dgvSessions.DefaultCellStyle.ForeColor = Color.Black; // Default cell text color
            this.dgvSessions.DefaultCellStyle.Font = new Font("Roboto", 10F); // Custom font for cells
            this.dgvSessions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 17, 98); // Fuchsia-like selection color
            this.dgvSessions.DefaultCellStyle.SelectionForeColor = Color.White; // Selection text color

            this.dgvSessions.GridColor = Color.Gray; // Gridline color
            this.dgvSessions.BorderStyle = BorderStyle.None; // Remove border for cleaner look
            this.dgvSessions.RowHeadersVisible = false; // Optionally hide row headers for a cleaner look

            this.dgvSessions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Alternating row background color
            this.dgvSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Make columns fill the grid width
            this.dgvSessions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Auto-size rows

            this.dgvSessions.Location = new System.Drawing.Point(12, 70);
            this.dgvSessions.Name = "dgvSessions";
            this.dgvSessions.ReadOnly = true; // Set the grid to read-only
            this.dgvSessions.Size = new System.Drawing.Size(760, 300);
            this.dgvSessions.TabIndex = 0;

            //this.dgvSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //this.dgvSessions.Location = new System.Drawing.Point(12, 70);
            //this.dgvSessions.Name = "dgvSessions";
            //this.dgvSessions.ReadOnly = true;
            //this.dgvSessions.Size = new System.Drawing.Size(760, 300);
            //this.dgvSessions.TabIndex = 0;
            // 
            // btnAddSession
            // 
            this.btnAddSession.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSession.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddSession.Depth = 0;
            this.btnAddSession.HighEmphasis = true;
            this.btnAddSession.Icon = null;
            this.btnAddSession.Location = new System.Drawing.Point(12, 390);
            this.btnAddSession.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddSession.Size = new System.Drawing.Size(150, 50);
            this.btnAddSession.TabIndex = 1;
            this.btnAddSession.Text = "Add Session";
            this.btnAddSession.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddSession.UseAccentColor = false;
            this.btnAddSession.UseVisualStyleBackColor = true;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // btnDeleteSession
            // 
            this.btnDeleteSession.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteSession.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteSession.Depth = 0;
            this.btnDeleteSession.HighEmphasis = true;
            this.btnDeleteSession.Icon = null;
            this.btnDeleteSession.Location = new System.Drawing.Point(170, 390);
            this.btnDeleteSession.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteSession.Name = "btnDeleteSession";
            this.btnDeleteSession.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDeleteSession.Size = new System.Drawing.Size(150, 50);
            this.btnDeleteSession.TabIndex = 2;
            this.btnDeleteSession.Text = "Delete Session";
            this.btnDeleteSession.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteSession.UseAccentColor = false;
            this.btnDeleteSession.UseVisualStyleBackColor = true;
            this.btnDeleteSession.Click += new System.EventHandler(this.btnDeleteSession_Click);
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnDeleteSession);
            this.Controls.Add(this.btnAddSession);
            this.Controls.Add(this.dgvSessions);
            this.Name = "SessionForm";
            this.Text = "Session Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
