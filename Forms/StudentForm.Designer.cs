using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace MDSoDv2
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtSearch;
        private MaterialSkin.Controls.MaterialCheckbox chkSearchAllStudents;
        private System.Windows.Forms.DataGridView dgvStudents;
        private MaterialSkin.Controls.MaterialButton btnAddStudent;
        private MaterialSkin.Controls.MaterialButton btnUpdateStudent;
        private MaterialSkin.Controls.MaterialButton btnDeleteStudent;

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
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.chkSearchAllStudents = new MaterialSkin.Controls.MaterialCheckbox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnAddStudent = new MaterialSkin.Controls.MaterialButton();
            this.btnUpdateStudent = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteStudent = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.AnimateReadOnly = false;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.LeadingIcon = null;
            this.txtSearch.Location = new System.Drawing.Point(12, 86);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 50);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "";
            this.txtSearch.TrailingIcon = null;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // chkSearchAllStudents
            // 
            this.chkSearchAllStudents.AutoSize = true;
            this.chkSearchAllStudents.Depth = 0;
            this.chkSearchAllStudents.Location = new System.Drawing.Point(400, 50);
            this.chkSearchAllStudents.Margin = new System.Windows.Forms.Padding(0);
            this.chkSearchAllStudents.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSearchAllStudents.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSearchAllStudents.Name = "chkSearchAllStudents";
            this.chkSearchAllStudents.ReadOnly = false;
            this.chkSearchAllStudents.Ripple = true;
            this.chkSearchAllStudents.Size = new System.Drawing.Size(173, 37);
            this.chkSearchAllStudents.TabIndex = 1;
            this.chkSearchAllStudents.Text = "Search All Students";
            this.chkSearchAllStudents.UseVisualStyleBackColor = true;
            this.chkSearchAllStudents.CheckedChanged += new System.EventHandler(this.chkSearchAllStudents_CheckedChanged);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Columns auto-size
            this.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76); // Header background
            this.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text color
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 12F, FontStyle.Bold); // Custom font for headers
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStudents.ColumnHeadersHeight = 50; // Set header height

            this.dgvStudents.EnableHeadersVisualStyles = false; // Allow custom header styles
            this.dgvStudents.DefaultCellStyle.BackColor = Color.White; // Default cell background
            this.dgvStudents.DefaultCellStyle.ForeColor = Color.Black; // Default cell text color
            this.dgvStudents.DefaultCellStyle.Font = new Font("Roboto", 10F); // Custom font for cells
            this.dgvStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 17, 98); // Fuchsia-like selection color
            this.dgvStudents.DefaultCellStyle.SelectionForeColor = Color.White; // Selection text color

            this.dgvStudents.GridColor = Color.Gray; // Gridline color
            this.dgvStudents.BorderStyle = BorderStyle.None; // Remove border for cleaner look
            this.dgvStudents.RowHeadersVisible = false; // Optionally hide row headers for a cleaner look

            this.dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Alternating row background color
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Make columns fill the grid width
            this.dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Auto-size rows

            this.dgvStudents.Location = new System.Drawing.Point(12, 142);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true; // Set the grid to read-only
            this.dgvStudents.Size = new System.Drawing.Size(664, 429);
            this.dgvStudents.TabIndex = 2;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.AutoSize = false;
            this.btnAddStudent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddStudent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddStudent.Depth = 0;
            this.btnAddStudent.HighEmphasis = true;
            this.btnAddStudent.Icon = null;
            this.btnAddStudent.Location = new System.Drawing.Point(683, 86);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddStudent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddStudent.Size = new System.Drawing.Size(199, 73);
            this.btnAddStudent.TabIndex = 3;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddStudent.UseAccentColor = false;
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.AutoSize = false;
            this.btnUpdateStudent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateStudent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUpdateStudent.Depth = 0;
            this.btnUpdateStudent.HighEmphasis = true;
            this.btnUpdateStudent.Icon = null;
            this.btnUpdateStudent.Location = new System.Drawing.Point(683, 171);
            this.btnUpdateStudent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdateStudent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUpdateStudent.Size = new System.Drawing.Size(199, 73);
            this.btnUpdateStudent.TabIndex = 4;
            this.btnUpdateStudent.Text = "Update Student";
            this.btnUpdateStudent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUpdateStudent.UseAccentColor = false;
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.AutoSize = false;
            this.btnDeleteStudent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteStudent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteStudent.Depth = 0;
            this.btnDeleteStudent.HighEmphasis = true;
            this.btnDeleteStudent.Icon = null;
            this.btnDeleteStudent.Location = new System.Drawing.Point(683, 256);
            this.btnDeleteStudent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteStudent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDeleteStudent.Size = new System.Drawing.Size(199, 73);
            this.btnDeleteStudent.TabIndex = 5;
            this.btnDeleteStudent.Text = "Delete Student";
            this.btnDeleteStudent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteStudent.UseAccentColor = false;
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 583);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnUpdateStudent);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.chkSearchAllStudents);
            this.Controls.Add(this.txtSearch);
            this.Icon = global::MDSoDv2.Properties.Resources.MDSoDv2_logo1;
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}