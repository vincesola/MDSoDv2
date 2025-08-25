namespace MDSoDv2
{
    partial class AddClassForm
    {
        private MaterialSkin.Controls.MaterialListView listViewClasses;
        private MaterialSkin.Controls.MaterialButton btnAddSelectedClasses;
        private MaterialSkin.Controls.MaterialComboBox cmbSessionFilter;
        private MaterialSkin.Controls.MaterialLabel lblSession;

        private void InitializeComponent()
        {
            this.listViewClasses = new MaterialSkin.Controls.MaterialListView();
            this.btnAddSelectedClasses = new MaterialSkin.Controls.MaterialButton();

            // NEW
            this.lblSession = new MaterialSkin.Controls.MaterialLabel();
            this.cmbSessionFilter = new MaterialSkin.Controls.MaterialComboBox();

            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Depth = 0;
            this.lblSession.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSession.Location = new System.Drawing.Point(12, 80);
            this.lblSession.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(66, 19);
            this.lblSession.TabIndex = 0;
            this.lblSession.Text = "Session:";

            // 
            // cmbSessionFilter
            // 
            this.cmbSessionFilter.AutoResize = false;
            this.cmbSessionFilter.BackColor = System.Drawing.Color.White;
            this.cmbSessionFilter.Depth = 0;
            this.cmbSessionFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSessionFilter.DropDownHeight = 174;
            this.cmbSessionFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSessionFilter.DropDownWidth = 121;
            this.cmbSessionFilter.IntegralHeight = false;
            this.cmbSessionFilter.ItemHeight = 43;
            this.cmbSessionFilter.Location = new System.Drawing.Point(90, 70);
            this.cmbSessionFilter.MaxDropDownItems = 4;
            this.cmbSessionFilter.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbSessionFilter.Name = "cmbSessionFilter";
            this.cmbSessionFilter.Size = new System.Drawing.Size(300, 49);
            this.cmbSessionFilter.TabIndex = 1;
            // hook up change event (handler lives in AddClassForm.cs)
            this.cmbSessionFilter.SelectedIndexChanged += new System.EventHandler(this.cmbSessionFilter_SelectedIndexChanged);

            // 
            // listViewClasses
            // 
            this.listViewClasses.AutoSizeTable = false;
            this.listViewClasses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewClasses.Depth = 0;
            this.listViewClasses.FullRowSelect = true;
            this.listViewClasses.HideSelection = false;

            // moved down to make room for the filter row
            this.listViewClasses.Location = new System.Drawing.Point(12, 130);

            this.listViewClasses.MultiSelect = true;
            this.listViewClasses.Name = "listViewClasses";
            this.listViewClasses.Size = new System.Drawing.Size(760, 250);
            this.listViewClasses.TabIndex = 2;
            this.listViewClasses.UseCompatibleStateImageBehavior = false;
            this.listViewClasses.View = System.Windows.Forms.View.Details;
            this.listViewClasses.Columns.Add("ClassName", 150);
            this.listViewClasses.Columns.Add("ClassLocation", 100);
            this.listViewClasses.Columns.Add("SessionName", 100);
            this.listViewClasses.Columns.Add("DayOfWeek", 100);
            this.listViewClasses.Columns.Add("Time", 100);
            this.listViewClasses.Columns.Add("Teachers", 150);

            // 
            // btnAddSelectedClasses
            // 
            this.btnAddSelectedClasses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddSelectedClasses.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddSelectedClasses.Depth = 0;
            this.btnAddSelectedClasses.HighEmphasis = true;
            this.btnAddSelectedClasses.Icon = null;
            this.btnAddSelectedClasses.Location = new System.Drawing.Point(600, 400);
            this.btnAddSelectedClasses.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddSelectedClasses.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddSelectedClasses.Name = "btnAddSelectedClasses";
            this.btnAddSelectedClasses.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddSelectedClasses.Size = new System.Drawing.Size(150, 36);
            this.btnAddSelectedClasses.TabIndex = 3;
            this.btnAddSelectedClasses.Text = "Add Classes";
            this.btnAddSelectedClasses.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddSelectedClasses.UseAccentColor = false;
            this.btnAddSelectedClasses.UseVisualStyleBackColor = true;
            this.btnAddSelectedClasses.Click += new System.EventHandler(this.btnAddSelectedClasses_Click);

            // 
            // AddClassForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSession);
            this.Controls.Add(this.cmbSessionFilter);
            this.Controls.Add(this.btnAddSelectedClasses);
            this.Controls.Add(this.listViewClasses);
            this.Name = "AddClassForm";
            this.Text = "Select Classes";
        }
    }
}
