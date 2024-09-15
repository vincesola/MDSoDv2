using System.Windows.Forms;
using MaterialSkin.Controls;

namespace MDSoDv2
{
    partial class UpdateClassForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtClassName = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbDayOfWeek = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbTime = new MaterialSkin.Controls.MaterialComboBox();
            this.chkTeachers = new System.Windows.Forms.CheckedListBox();
            this.cmbSession = new MaterialSkin.Controls.MaterialComboBox();
            this.btnAddSession = new MaterialSkin.Controls.MaterialButton();
            this.cmbClassLocation = new MaterialSkin.Controls.MaterialComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(84, 533);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(219, 533);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.AnimateReadOnly = false;
            this.txtClassName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClassName.Depth = 0;
            this.txtClassName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtClassName.Hint = "Class Name";
            this.txtClassName.LeadingIcon = null;
            this.txtClassName.Location = new System.Drawing.Point(13, 142);
            this.txtClassName.MaxLength = 50;
            this.txtClassName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClassName.Multiline = false;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(358, 50);
            this.txtClassName.TabIndex = 2;
            this.txtClassName.Text = "";
            this.txtClassName.TrailingIcon = null;
            // 
            // cmbDayOfWeek
            // 
            this.cmbDayOfWeek.AutoResize = false;
            this.cmbDayOfWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDayOfWeek.Depth = 0;
            this.cmbDayOfWeek.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDayOfWeek.DropDownHeight = 174;
            this.cmbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayOfWeek.DropDownWidth = 121;
            this.cmbDayOfWeek.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDayOfWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbDayOfWeek.Hint = "Day of Week";
            this.cmbDayOfWeek.IntegralHeight = false;
            this.cmbDayOfWeek.ItemHeight = 43;
            this.cmbDayOfWeek.Location = new System.Drawing.Point(13, 273);
            this.cmbDayOfWeek.MaxDropDownItems = 4;
            this.cmbDayOfWeek.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(358, 49);
            this.cmbDayOfWeek.StartIndex = 0;
            this.cmbDayOfWeek.TabIndex = 4;
            // 
            // cmbTime
            // 
            this.cmbTime.AutoResize = false;
            this.cmbTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTime.Depth = 0;
            this.cmbTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTime.DropDownHeight = 174;
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.DropDownWidth = 121;
            this.cmbTime.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbTime.Hint = "Time";
            this.cmbTime.IntegralHeight = false;
            this.cmbTime.ItemHeight = 43;
            this.cmbTime.Location = new System.Drawing.Point(13, 340);
            this.cmbTime.MaxDropDownItems = 4;
            this.cmbTime.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(358, 49);
            this.cmbTime.StartIndex = 0;
            this.cmbTime.TabIndex = 5;
            // 
            // chkTeachers
            // 
            this.chkTeachers.FormattingEnabled = true;
            this.chkTeachers.Location = new System.Drawing.Point(13, 404);
            this.chkTeachers.Name = "chkTeachers";
            this.chkTeachers.Size = new System.Drawing.Size(358, 94);
            this.chkTeachers.TabIndex = 6;
            this.chkTeachers.CheckOnClick = true;
            // 
            // cmbSession
            // 
            this.cmbSession.AutoResize = false;
            this.cmbSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbSession.Depth = 0;
            this.cmbSession.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSession.DropDownHeight = 174;
            this.cmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSession.DropDownWidth = 121;
            this.cmbSession.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbSession.Hint = "Session";
            this.cmbSession.IntegralHeight = false;
            this.cmbSession.ItemHeight = 43;
            this.cmbSession.Location = new System.Drawing.Point(13, 76);
            this.cmbSession.MaxDropDownItems = 4;
            this.cmbSession.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(135, 49);
            this.cmbSession.StartIndex = 0;
            this.cmbSession.TabIndex = 7;
            // 
            // btnAddSession
            // 
            this.btnAddSession.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSession.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddSession.Depth = 0;
            this.btnAddSession.HighEmphasis = true;
            this.btnAddSession.Icon = null;
            this.btnAddSession.Location = new System.Drawing.Point(169, 76);
            this.btnAddSession.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddSession.Name = "btnAddSession";
            this.btnAddSession.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddSession.Size = new System.Drawing.Size(64, 36);
            this.btnAddSession.TabIndex = 8;
            this.btnAddSession.Text = "+";
            this.btnAddSession.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddSession.UseAccentColor = false;
            this.btnAddSession.Click += new System.EventHandler(this.btnAddSession_Click);
            // 
            // cmbClassLocation
            // 
            this.cmbClassLocation.AutoResize = false;
            this.cmbClassLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbClassLocation.Depth = 0;
            this.cmbClassLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbClassLocation.DropDownHeight = 174;
            this.cmbClassLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassLocation.DropDownWidth = 121;
            this.cmbClassLocation.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbClassLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbClassLocation.Hint = "Class Location";
            this.cmbClassLocation.IntegralHeight = false;
            this.cmbClassLocation.ItemHeight = 43;
            this.cmbClassLocation.Location = new System.Drawing.Point(13, 207);
            this.cmbClassLocation.MaxDropDownItems = 4;
            this.cmbClassLocation.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbClassLocation.Name = "cmbClassLocation";
            this.cmbClassLocation.Size = new System.Drawing.Size(358, 49);
            this.cmbClassLocation.StartIndex = 0;
            this.cmbClassLocation.TabIndex = 3;
            // 
            // AddNewClassForm
            // 
            this.ClientSize = new System.Drawing.Size(397, 583);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.cmbClassLocation);
            this.Controls.Add(this.cmbDayOfWeek);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.chkTeachers);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.btnAddSession);
            this.Name = "UpdateClassForm";
            this.Text = "Update Class";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialButton btnSave;
        private MaterialButton btnCancel;
        private MaterialTextBox txtClassName;
        private MaterialComboBox cmbDayOfWeek;
        private MaterialComboBox cmbTime;
        private CheckedListBox chkTeachers;
        private MaterialComboBox cmbSession;
        private MaterialButton btnAddSession;
        private MaterialComboBox cmbClassLocation;
    }
}
