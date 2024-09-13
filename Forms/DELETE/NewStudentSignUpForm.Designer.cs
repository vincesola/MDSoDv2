namespace MDSoDv2
{
    partial class NewStudentSignUpForm
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
            this.txtParentFirstName = new System.Windows.Forms.TextBox();
            this.txtParentLastName = new System.Windows.Forms.TextBox();
            this.txtStreetAddress = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.txtZipCode = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnRemoveStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtParentFirstName
            // 
            this.txtParentFirstName.Location = new System.Drawing.Point(12, 12);
            this.txtParentFirstName.Name = "txtParentFirstName";
            this.txtParentFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtParentFirstName.TabIndex = 0;
            this.txtParentFirstName.Tag = "Parent First Name";
            this.txtParentFirstName.Enter += new System.EventHandler(this.txt_Enter);
            this.txtParentFirstName.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtParentLastName
            // 
            this.txtParentLastName.Location = new System.Drawing.Point(12, 38);
            this.txtParentLastName.Name = "txtParentLastName";
            this.txtParentLastName.Size = new System.Drawing.Size(200, 20);
            this.txtParentLastName.TabIndex = 1;
            this.txtParentLastName.Tag = "Parent Last Name";
            this.txtParentLastName.Enter += new System.EventHandler(this.txt_Enter);
            this.txtParentLastName.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtStreetAddress
            // 
            this.txtStreetAddress.Location = new System.Drawing.Point(12, 64);
            this.txtStreetAddress.Name = "txtStreetAddress";
            this.txtStreetAddress.Size = new System.Drawing.Size(200, 20);
            this.txtStreetAddress.TabIndex = 2;
            this.txtStreetAddress.Tag = "Street Address";
            this.txtStreetAddress.Enter += new System.EventHandler(this.txt_Enter);
            this.txtStreetAddress.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(12, 90);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(200, 20);
            this.txtCity.TabIndex = 3;
            this.txtCity.Tag = "City";
            this.txtCity.Enter += new System.EventHandler(this.txt_Enter);
            this.txtCity.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
                "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID",
                "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS",
                "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK",
                "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV",
                "WI", "WY"});
            this.cmbState.Location = new System.Drawing.Point(12, 116);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(200, 21);
            this.cmbState.TabIndex = 4;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(12, 142);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(200, 20);
            this.txtZipCode.TabIndex = 5;
            this.txtZipCode.Tag = "Zip Code";
            this.txtZipCode.Enter += new System.EventHandler(this.txt_Enter);
            this.txtZipCode.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(12, 168);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(200, 20);
            this.txtPhoneNumber.TabIndex = 6;
            this.txtPhoneNumber.Tag = "Phone Number";
            this.txtPhoneNumber.Enter += new System.EventHandler(this.txt_Enter);
            this.txtPhoneNumber.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 194);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Tag = "Email";
            this.txtEmail.Enter += new System.EventHandler(this.txt_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(12, 260);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.Size = new System.Drawing.Size(760, 150);
            this.dgvStudents.TabIndex = 9;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(12, 420);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(100, 23);
            this.btnAddStudent.TabIndex = 10;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnRemoveStudent
            // 
            this.btnRemoveStudent.Location = new System.Drawing.Point(130, 420);
            this.btnRemoveStudent.Name = "btnRemoveStudent";
            this.btnRemoveStudent.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveStudent.TabIndex = 11;
            this.btnRemoveStudent.Text = "Remove Student";
            this.btnRemoveStudent.UseVisualStyleBackColor = true;
            this.btnRemoveStudent.Click += new System.EventHandler(this.btnRemoveStudent_Click);
            // 
            // NewStudentSignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnRemoveStudent);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtStreetAddress);
            this.Controls.Add(this.txtParentLastName);
            this.Controls.Add(this.txtParentFirstName);
            this.Name = "NewStudentSignUpForm";
            this.Text = "New Student Sign Up";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtParentFirstName;
        private System.Windows.Forms.TextBox txtParentLastName;
        private System.Windows.Forms.TextBox txtStreetAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.TextBox txtZipCode;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnRemoveStudent;
    }
}
