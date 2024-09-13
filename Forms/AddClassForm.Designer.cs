namespace MDSoDv2
{
    partial class AddClassForm
    {
        private MaterialSkin.Controls.MaterialListView listViewClasses;
        private MaterialSkin.Controls.MaterialButton btnAddSelectedClasses;

        private void InitializeComponent()
        {
            this.listViewClasses = new MaterialSkin.Controls.MaterialListView();
            this.btnAddSelectedClasses = new MaterialSkin.Controls.MaterialButton();

            // 
            // listViewClasses
            // 
            this.listViewClasses.AutoSizeTable = false;
            this.listViewClasses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewClasses.Depth = 0;
            this.listViewClasses.FullRowSelect = true;
            this.listViewClasses.HideSelection = false;
            this.listViewClasses.Location = new System.Drawing.Point(12, 80);
            this.listViewClasses.MultiSelect = true; // Enable multi-select
            this.listViewClasses.Name = "listViewClasses";
            this.listViewClasses.Size = new System.Drawing.Size(760, 300);
            this.listViewClasses.TabIndex = 0;
            this.listViewClasses.UseCompatibleStateImageBehavior = false;
            this.listViewClasses.View = System.Windows.Forms.View.Details; // Details view to display columns
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
            this.btnAddSelectedClasses.TabIndex = 1;
            this.btnAddSelectedClasses.Text = "Add Classes";
            this.btnAddSelectedClasses.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddSelectedClasses.UseAccentColor = false;
            this.btnAddSelectedClasses.UseVisualStyleBackColor = true;
            this.btnAddSelectedClasses.Click += new System.EventHandler(this.btnAddSelectedClasses_Click);

            // 
            // AddClassForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddSelectedClasses);
            this.Controls.Add(this.listViewClasses);
            this.Name = "AddClassForm";
            this.Text = "Select Classes";
        }
    }
}
