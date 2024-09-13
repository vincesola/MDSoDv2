using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Drawing;

namespace MDSoDv2
{
    partial class UpdateStudentForm
    {
        private System.ComponentModel.IContainer components = null;

        // Declare form controls
        private MaterialSkin.Controls.MaterialTextBox txtFirstName;
        private MaterialSkin.Controls.MaterialTextBox txtLastName;
        private MaterialSkin.Controls.MaterialTextBox txtDateOfBirth;
        private MaterialSkin.Controls.MaterialTextBox txtStreetAddress;
        private MaterialSkin.Controls.MaterialTextBox txtCity;
        private MaterialSkin.Controls.MaterialTextBox txtZipCode;
        private MaterialSkin.Controls.MaterialTextBox txtPhoneNumber;
        private MaterialSkin.Controls.MaterialTextBox txtFamilyEmail;
        private MaterialSkin.Controls.MaterialCheckbox chkActive;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnAddParent;
        private MaterialSkin.Controls.MaterialButton btnRemoveParent;
        private MaterialSkin.Controls.MaterialButton btnAddClass;
        private MaterialSkin.Controls.MaterialButton btnRemoveClass;
        private MaterialSkin.Controls.MaterialComboBox cmbState;
        private System.Windows.Forms.DataGridView dgvParents;
        private System.Windows.Forms.DataGridView dgvClasses;

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
            this.txtFirstName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtLastName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDateOfBirth = new MaterialSkin.Controls.MaterialTextBox();
            this.txtStreetAddress = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCity = new MaterialSkin.Controls.MaterialTextBox();
            this.txtZipCode = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPhoneNumber = new MaterialSkin.Controls.MaterialTextBox();
            this.txtFamilyEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.chkActive = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnAddParent = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveParent = new MaterialSkin.Controls.MaterialButton();
            this.btnAddClass = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveClass = new MaterialSkin.Controls.MaterialButton();
            this.cmbState = new MaterialSkin.Controls.MaterialComboBox();
            this.dgvParents = new System.Windows.Forms.DataGridView();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.AnimateReadOnly = false;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Depth = 0;
            this.txtFirstName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFirstName.Hint = "First Name";
            this.txtFirstName.LeadingIcon = null;
            this.txtFirstName.Location = new System.Drawing.Point(20, 78);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFirstName.Multiline = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 50);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.TrailingIcon = null;
            this.txtFirstName.Enter += new System.EventHandler(this.txt_Enter);
            this.txtFirstName.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtLastName
            // 
            this.txtLastName.AnimateReadOnly = false;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Depth = 0;
            this.txtLastName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLastName.Hint = "Last Name";
            this.txtLastName.LeadingIcon = null;
            this.txtLastName.Location = new System.Drawing.Point(20, 138);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtLastName.Multiline = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 50);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.TrailingIcon = null;
            this.txtLastName.Enter += new System.EventHandler(this.txt_Enter);
            this.txtLastName.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtDateOfBirth
            // 
            this.txtDateOfBirth.AnimateReadOnly = false;
            this.txtDateOfBirth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDateOfBirth.Depth = 0;
            this.txtDateOfBirth.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDateOfBirth.Hint = "Date Of Birth";
            this.txtDateOfBirth.LeadingIcon = null;
            this.txtDateOfBirth.Location = new System.Drawing.Point(20, 198);
            this.txtDateOfBirth.MaxLength = 50;
            this.txtDateOfBirth.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDateOfBirth.Multiline = false;
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.Size = new System.Drawing.Size(200, 50);
            this.txtDateOfBirth.TabIndex = 2;
            this.txtDateOfBirth.TrailingIcon = null;
            this.txtDateOfBirth.Enter += new System.EventHandler(this.txt_Enter);
            this.txtDateOfBirth.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.AnimateReadOnly = false;
            this.txtStreetAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStreetAddress.Depth = 0;
            this.txtStreetAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtStreetAddress.Hint = "Street Address";
            this.txtStreetAddress.LeadingIcon = null;
            this.txtStreetAddress.Location = new System.Drawing.Point(20, 258);
            this.txtStreetAddress.MaxLength = 50;
            this.txtStreetAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStreetAddress.Multiline = false;
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(200, 50);
            this.txtStreetAddress.TabIndex = 3;
            this.txtStreetAddress.TrailingIcon = null;
            this.txtStreetAddress.Enter += new System.EventHandler(this.txt_Enter);
            this.txtStreetAddress.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtCity
            // 
            this.txtCity.AnimateReadOnly = false;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCity.Depth = 0;
            this.txtCity.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCity.Hint = "City";
            this.txtCity.LeadingIcon = null;
            this.txtCity.Location = new System.Drawing.Point(20, 318);
            this.txtCity.MaxLength = 50;
            this.txtCity.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCity.Multiline = false;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(200, 50);
            this.txtCity.TabIndex = 4;
            this.txtCity.TrailingIcon = null;
            this.txtCity.Enter += new System.EventHandler(this.txt_Enter);
            this.txtCity.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtZipCode
            // 
            this.txtZipCode.AnimateReadOnly = false;
            this.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtZipCode.Depth = 0;
            this.txtZipCode.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtZipCode.Hint = "Zip Code";
            this.txtZipCode.LeadingIcon = null;
            this.txtZipCode.Location = new System.Drawing.Point(20, 429);
            this.txtZipCode.MaxLength = 50;
            this.txtZipCode.MouseState = MaterialSkin.MouseState.OUT;
            this.txtZipCode.Multiline = false;
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(200, 50);
            this.txtZipCode.TabIndex = 5;
            this.txtZipCode.TrailingIcon = null;
            this.txtZipCode.Enter += new System.EventHandler(this.txt_Enter);
            this.txtZipCode.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.AnimateReadOnly = false;
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhoneNumber.Depth = 0;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPhoneNumber.Hint = "Phone Number";
            this.txtPhoneNumber.LeadingIcon = null;
            this.txtPhoneNumber.Location = new System.Drawing.Point(20, 489);
            this.txtPhoneNumber.MaxLength = 50;
            this.txtPhoneNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPhoneNumber.Multiline = false;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(200, 50);
            this.txtPhoneNumber.TabIndex = 6;
            this.txtPhoneNumber.TrailingIcon = null;
            this.txtPhoneNumber.Enter += new System.EventHandler(this.txt_Enter);
            this.txtPhoneNumber.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtFamilyEmail
            // 
            this.txtFamilyEmail.AnimateReadOnly = false;
            this.txtFamilyEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFamilyEmail.Depth = 0;
            this.txtFamilyEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFamilyEmail.Hint = "Family Email";
            this.txtFamilyEmail.LeadingIcon = null;
            this.txtFamilyEmail.Location = new System.Drawing.Point(20, 549);
            this.txtFamilyEmail.MaxLength = 50;
            this.txtFamilyEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFamilyEmail.Multiline = false;
            this.txtFamilyEmail.Name = "txtFamilyEmail";
            this.txtFamilyEmail.Size = new System.Drawing.Size(200, 50);
            this.txtFamilyEmail.TabIndex = 7;
            this.txtFamilyEmail.TrailingIcon = null;
            this.txtFamilyEmail.Enter += new System.EventHandler(this.txt_Enter);
            this.txtFamilyEmail.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Depth = 0;
            this.chkActive.Location = new System.Drawing.Point(23, 607);
            this.chkActive.Margin = new System.Windows.Forms.Padding(0);
            this.chkActive.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkActive.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkActive.Name = "chkActive";
            this.chkActive.ReadOnly = false;
            this.chkActive.Ripple = true;
            this.chkActive.Size = new System.Drawing.Size(78, 37);
            this.chkActive.TabIndex = 8;
            this.chkActive.Text = "Active";
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(20, 650);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddParent
            // 
            this.btnAddParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddParent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddParent.Depth = 0;
            this.btnAddParent.HighEmphasis = true;
            this.btnAddParent.Icon = null;
            this.btnAddParent.Location = new System.Drawing.Point(252, 318);
            this.btnAddParent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddParent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddParent.Name = "btnAddParent";
            this.btnAddParent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddParent.Size = new System.Drawing.Size(110, 36);
            this.btnAddParent.TabIndex = 10;
            this.btnAddParent.Text = "Add Parent";
            this.btnAddParent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddParent.UseAccentColor = false;
            this.btnAddParent.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // btnRemoveParent
            // 
            this.btnRemoveParent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveParent.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRemoveParent.Depth = 0;
            this.btnRemoveParent.HighEmphasis = true;
            this.btnRemoveParent.Icon = null;
            this.btnRemoveParent.Location = new System.Drawing.Point(370, 318);
            this.btnRemoveParent.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveParent.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveParent.Name = "btnRemoveParent";
            this.btnRemoveParent.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRemoveParent.Size = new System.Drawing.Size(140, 36);
            this.btnRemoveParent.TabIndex = 11;
            this.btnRemoveParent.Text = "Remove Parent";
            this.btnRemoveParent.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoveParent.UseAccentColor = false;
            this.btnRemoveParent.Click += new System.EventHandler(this.btnRemoveParent_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddClass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddClass.Depth = 0;
            this.btnAddClass.HighEmphasis = true;
            this.btnAddClass.Icon = null;
            this.btnAddClass.Location = new System.Drawing.Point(252, 606);
            this.btnAddClass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddClass.Size = new System.Drawing.Size(99, 36);
            this.btnAddClass.TabIndex = 12;
            this.btnAddClass.Text = "Add Class";
            this.btnAddClass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddClass.UseAccentColor = false;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveClass.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRemoveClass.Depth = 0;
            this.btnRemoveClass.HighEmphasis = true;
            this.btnRemoveClass.Icon = null;
            this.btnRemoveClass.Location = new System.Drawing.Point(359, 606);
            this.btnRemoveClass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveClass.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRemoveClass.Size = new System.Drawing.Size(129, 36);
            this.btnRemoveClass.TabIndex = 13;
            this.btnRemoveClass.Text = "Remove Class";
            this.btnRemoveClass.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemoveClass.UseAccentColor = false;
            this.btnRemoveClass.Click += new System.EventHandler(this.btnRemoveClass_Click);
            // 
            // dgvParents
            //
            this.dgvParents.ReadOnly = true;
            this.dgvParents.AllowUserToAddRows = false;
            this.dgvParents.AllowUserToDeleteRows = false;
            this.dgvParents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParents.MultiSelect = false; // Disable multi-row selection if not needed
            this.dgvParents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Columns auto-size
            this.dgvParents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76); // Header background
            this.dgvParents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text color
            this.dgvParents.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 12F, FontStyle.Bold); // Custom font for headers
            this.dgvParents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvParents.ColumnHeadersHeight = 50; // Set header height

            this.dgvParents.EnableHeadersVisualStyles = false; // Allow custom header styles
            this.dgvParents.DefaultCellStyle.BackColor = Color.White; // Default cell background
            this.dgvParents.DefaultCellStyle.ForeColor = Color.Black; // Default cell text color
            this.dgvParents.DefaultCellStyle.Font = new Font("Roboto", 10F); // Custom font for cells
            this.dgvParents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 17, 98); // Fuchsia-like selection color
            this.dgvParents.DefaultCellStyle.SelectionForeColor = Color.White; // Selection text color

            this.dgvParents.GridColor = Color.Gray; // Gridline color
            this.dgvParents.BorderStyle = BorderStyle.None; // Remove border for cleaner look
            this.dgvParents.RowHeadersVisible = false; // Optionally hide row headers for a cleaner look

            this.dgvParents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Alternating row background color
            this.dgvParents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Make columns fill the grid width
            this.dgvParents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Auto-size rows
            this.dgvParents.Location = new System.Drawing.Point(252, 78);
            this.dgvParents.Name = "dgvParents";
            this.dgvParents.Size = new System.Drawing.Size(694, 230);
            this.dgvParents.TabIndex = 14;
            // 
            // dgvClasses
            // 
            this.dgvClasses.ReadOnly = true;
            this.dgvClasses.AllowUserToAddRows = false;
            this.dgvClasses.AllowUserToDeleteRows = false;
            this.dgvClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.MultiSelect = false; // Disable multi-row selection if not needed
            this.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Columns auto-size
            this.dgvClasses.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76); // Header background
            this.dgvClasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text color
            this.dgvClasses.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 12F, FontStyle.Bold); // Custom font for headers
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClasses.ColumnHeadersHeight = 50; // Set header height

            this.dgvClasses.EnableHeadersVisualStyles = false; // Allow custom header styles
            this.dgvClasses.DefaultCellStyle.BackColor = Color.White; // Default cell background
            this.dgvClasses.DefaultCellStyle.ForeColor = Color.Black; // Default cell text color
            this.dgvClasses.DefaultCellStyle.Font = new Font("Roboto", 10F); // Custom font for cells
            this.dgvClasses.DefaultCellStyle.SelectionBackColor = Color.FromArgb(197, 17, 98); // Fuchsia-like selection color
            this.dgvClasses.DefaultCellStyle.SelectionForeColor = Color.White; // Selection text color

            this.dgvClasses.GridColor = Color.Gray; // Gridline color
            this.dgvClasses.BorderStyle = BorderStyle.None; // Remove border for cleaner look
            this.dgvClasses.RowHeadersVisible = false; // Optionally hide row headers for a cleaner look

            this.dgvClasses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Alternating row background color
            this.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Make columns fill the grid width
            this.dgvClasses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Auto-size rows
            this.dgvClasses.Location = new System.Drawing.Point(252, 374);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.Size = new System.Drawing.Size(694, 225);
            this.dgvClasses.TabIndex = 15;
            // 
            // cmbState
            // 
            this.cmbState.AutoResize = false;
            this.cmbState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbState.Depth = 0;
            this.cmbState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbState.DropDownHeight = 174;
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.DropDownWidth = 121;
            this.cmbState.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbState.IntegralHeight = false;
            this.cmbState.ItemHeight = 43;
            this.cmbState.Items.AddRange(new object[] {
            "KS",
            "MO"});
            this.cmbState.Location = new System.Drawing.Point(20, 374);
            this.cmbState.MaxDropDownItems = 4;
            this.cmbState.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(200, 49);
            this.cmbState.StartIndex = 0;
            this.cmbState.TabIndex = 17;
            this.cmbState.SelectedIndexChanged += new System.EventHandler(this.CmbState_SelectedIndexChanged);
            // 
            // UpdateStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 697);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtDateOfBirth);
            this.Controls.Add(this.txtStreetAddress);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtFamilyEmail);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddParent);
            this.Controls.Add(this.btnRemoveParent);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.btnRemoveClass);
            this.Controls.Add(this.dgvParents);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.cmbState);
            this.Name = "UpdateStudentForm";
            this.Text = "Update Student";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
