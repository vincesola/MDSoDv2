namespace MDSoDv2
{
    partial class TeacherForm
    {
        private System.ComponentModel.IContainer components = null;
        private MaterialSkin.Controls.MaterialTextBox txtTeacherName;
        private MaterialSkin.Controls.MaterialListBox lstTeachers;
        private MaterialSkin.Controls.MaterialButton btnAdd;
        private MaterialSkin.Controls.MaterialButton btnRemove;

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
            this.txtTeacherName = new MaterialSkin.Controls.MaterialTextBox();
            this.lstTeachers = new MaterialSkin.Controls.MaterialListBox();
            this.btnAdd = new MaterialSkin.Controls.MaterialButton();
            this.btnRemove = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.AnimateReadOnly = false;
            this.txtTeacherName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTeacherName.Depth = 0;
            this.txtTeacherName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTeacherName.Hint = "Teacher Name";
            this.txtTeacherName.LeadingIcon = null;
            this.txtTeacherName.Location = new System.Drawing.Point(6, 72);
            this.txtTeacherName.MaxLength = 50;
            this.txtTeacherName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTeacherName.Multiline = false;
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.Size = new System.Drawing.Size(408, 50);
            this.txtTeacherName.TabIndex = 0;
            this.txtTeacherName.Text = "";
            this.txtTeacherName.TrailingIcon = null;
            // 
            // lstTeachers
            // 
            this.lstTeachers.BackColor = System.Drawing.Color.White;
            this.lstTeachers.BorderColor = System.Drawing.Color.LightGray;
            this.lstTeachers.Depth = 0;
            this.lstTeachers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lstTeachers.Location = new System.Drawing.Point(6, 128);
            this.lstTeachers.MouseState = MaterialSkin.MouseState.HOVER;
            this.lstTeachers.Name = "lstTeachers";
            this.lstTeachers.SelectedIndex = -1;
            this.lstTeachers.SelectedItem = null;
            this.lstTeachers.Size = new System.Drawing.Size(408, 363);
            this.lstTeachers.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAdd.Depth = 0;
            this.btnAdd.HighEmphasis = true;
            this.btnAdd.Icon = null;
            this.btnAdd.Location = new System.Drawing.Point(6, 500);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAdd.Size = new System.Drawing.Size(64, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAdd.UseAccentColor = false;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRemove.Depth = 0;
            this.btnRemove.HighEmphasis = true;
            this.btnRemove.Icon = null;
            this.btnRemove.Location = new System.Drawing.Point(334, 500);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRemove.Size = new System.Drawing.Size(80, 36);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemove.UseAccentColor = false;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 545);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstTeachers);
            this.Controls.Add(this.txtTeacherName);
            this.Icon = global::MDSoDv2.Properties.Resources.MDSoDv2_logo1;
            this.Name = "TeacherForm";
            this.Text = "Add/Update Teacher";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.Resize += new System.EventHandler(this.TeacherForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
