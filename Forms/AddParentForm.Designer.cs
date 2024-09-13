namespace MDSoDv2
{
    partial class AddParentForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtFirstName;
        private MaterialSkin.Controls.MaterialTextBox txtLastName;
        private MaterialSkin.Controls.MaterialTextBox txtPhoneNumber;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtRelationship;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialCheckbox chkSameAsStudentPhone;
        private MaterialSkin.Controls.MaterialCheckbox chkSameAsStudentEmail;

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
            this.txtPhoneNumber = new MaterialSkin.Controls.MaterialTextBox();
            this.txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtRelationship = new MaterialSkin.Controls.MaterialTextBox();
            this.chkSameAsStudentPhone = new MaterialSkin.Controls.MaterialCheckbox();
            this.chkSameAsStudentEmail = new MaterialSkin.Controls.MaterialCheckbox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.AnimateReadOnly = false;
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.Depth = 0;
            this.txtFirstName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtFirstName.Hint = "First Name";
            this.txtFirstName.LeadingIcon = null;
            this.txtFirstName.Location = new System.Drawing.Point(19, 79);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtFirstName.Multiline = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(260, 50);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.Tag = "First Name";
            this.txtFirstName.Text = "";
            this.txtFirstName.TrailingIcon = null;
            this.txtFirstName.Enter += new System.EventHandler(this.txt_Enter);
            this.txtFirstName.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtLastName
            // 
            this.txtLastName.AnimateReadOnly = false;
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.Depth = 0;
            this.txtLastName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtLastName.Hint = "Last Name";
            this.txtLastName.LeadingIcon = null;
            this.txtLastName.Location = new System.Drawing.Point(19, 135);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtLastName.Multiline = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(260, 50);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.Tag = "Last Name";
            this.txtLastName.Text = "";
            this.txtLastName.TrailingIcon = null;
            this.txtLastName.Enter += new System.EventHandler(this.txt_Enter);
            this.txtLastName.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.AnimateReadOnly = false;
            this.txtPhoneNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhoneNumber.Depth = 0;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhoneNumber.Hint = "Phone Number";
            this.txtPhoneNumber.LeadingIcon = null;
            this.txtPhoneNumber.Location = new System.Drawing.Point(19, 191);
            this.txtPhoneNumber.MaxLength = 10;
            this.txtPhoneNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPhoneNumber.Multiline = false;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(260, 50);
            this.txtPhoneNumber.TabIndex = 2;
            this.txtPhoneNumber.Tag = "Phone Number";
            this.txtPhoneNumber.Text = "";
            this.txtPhoneNumber.TrailingIcon = null;
            this.txtPhoneNumber.Enter += new System.EventHandler(this.txt_Enter);
            this.txtPhoneNumber.Leave += new System.EventHandler(this.txtPhoneNumber_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.AnimateReadOnly = false;
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmail.Hint = "Email";
            this.txtEmail.LeadingIcon = null;
            this.txtEmail.Location = new System.Drawing.Point(19, 247);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 50);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Tag = "Email";
            this.txtEmail.Text = "";
            this.txtEmail.TrailingIcon = null;
            this.txtEmail.Enter += new System.EventHandler(this.txt_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtRelationship
            // 
            this.txtRelationship.AnimateReadOnly = false;
            this.txtRelationship.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtRelationship.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRelationship.Depth = 0;
            this.txtRelationship.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRelationship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtRelationship.Hint = "Relationship";
            this.txtRelationship.LeadingIcon = null;
            this.txtRelationship.Location = new System.Drawing.Point(19, 303);
            this.txtRelationship.MaxLength = 50;
            this.txtRelationship.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRelationship.Multiline = false;
            this.txtRelationship.Name = "txtRelationship";
            this.txtRelationship.Size = new System.Drawing.Size(260, 50);
            this.txtRelationship.TabIndex = 4;
            this.txtRelationship.Tag = "Relationship";
            this.txtRelationship.Text = "";
            this.txtRelationship.TrailingIcon = null;
            this.txtRelationship.Enter += new System.EventHandler(this.txt_Enter);
            this.txtRelationship.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // chkSameAsStudentPhone
            // 
            this.chkSameAsStudentPhone.AutoSize = true;
            this.chkSameAsStudentPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.chkSameAsStudentPhone.Depth = 0;
            this.chkSameAsStudentPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkSameAsStudentPhone.Location = new System.Drawing.Point(290, 200);
            this.chkSameAsStudentPhone.Margin = new System.Windows.Forms.Padding(0);
            this.chkSameAsStudentPhone.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSameAsStudentPhone.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSameAsStudentPhone.Name = "chkSameAsStudentPhone";
            this.chkSameAsStudentPhone.ReadOnly = false;
            this.chkSameAsStudentPhone.Ripple = true;
            this.chkSameAsStudentPhone.Size = new System.Drawing.Size(156, 37);
            this.chkSameAsStudentPhone.TabIndex = 6;
            this.chkSameAsStudentPhone.Text = "Same as Student";
            this.chkSameAsStudentPhone.UseVisualStyleBackColor = false;
            this.chkSameAsStudentPhone.CheckedChanged += new System.EventHandler(this.chkSameAsStudentPhone_CheckedChanged);
            // 
            // chkSameAsStudentEmail
            // 
            this.chkSameAsStudentEmail.AutoSize = true;
            this.chkSameAsStudentEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.chkSameAsStudentEmail.Depth = 0;
            this.chkSameAsStudentEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkSameAsStudentEmail.Location = new System.Drawing.Point(290, 255);
            this.chkSameAsStudentEmail.Margin = new System.Windows.Forms.Padding(0);
            this.chkSameAsStudentEmail.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSameAsStudentEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSameAsStudentEmail.Name = "chkSameAsStudentEmail";
            this.chkSameAsStudentEmail.ReadOnly = false;
            this.chkSameAsStudentEmail.Ripple = true;
            this.chkSameAsStudentEmail.Size = new System.Drawing.Size(156, 37);
            this.chkSameAsStudentEmail.TabIndex = 7;
            this.chkSameAsStudentEmail.Text = "Same as Student";
            this.chkSameAsStudentEmail.UseVisualStyleBackColor = false;
            this.chkSameAsStudentEmail.CheckedChanged += new System.EventHandler(this.chkSameAsStudentEmail_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(19, 359);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 415);
            this.Controls.Add(this.chkSameAsStudentEmail);
            this.Controls.Add(this.chkSameAsStudentPhone);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRelationship);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Name = "AddParentForm";
            this.Text = "Add Parent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
