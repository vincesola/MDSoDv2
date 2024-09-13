using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data;
using System.Collections;

namespace MDSoDv2
{
    public partial class AddClassForm : BaseForm
    {
        public List<Class> SelectedClasses { get; private set; } = new List<Class>();
        private DatabaseHelper dbHelper;
        private bool ascending = true; // Sorting direction flag

        // Variables to store original form size and control bounds for resizing
        private Size originalFormSize;
        private Rectangle originalListViewClassesBounds;
        private Rectangle originalBtnAddSelectedClassesBounds;

        public AddClassForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            InitializeClassListView();

            // Set form's starting position near the parent form
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Hook up form load and resize events
            this.Load += AddClassForm_Load;
            this.Resize += AddClassForm_Resize;
            this.listViewClasses.ColumnClick += ListViewClasses_ColumnClick; // Add column click event
        }

        private void AddClassForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalListViewClassesBounds = listViewClasses.Bounds;
            originalBtnAddSelectedClassesBounds = btnAddSelectedClasses.Bounds;
        }

        private void AddClassForm_Resize(object sender, EventArgs e)
        {
            // Resize each control based on the current form size
            ResizeControl(listViewClasses, originalListViewClassesBounds);
            ResizeControl(btnAddSelectedClasses, originalBtnAddSelectedClassesBounds);
        }

        private void ResizeControl(Control control, Rectangle originalBounds)
        {
            // Calculate the resize ratio for width and height
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            // Calculate the new control bounds
            int newX = (int)(originalBounds.X * xRatio);
            int newY = (int)(originalBounds.Y * yRatio);
            int newWidth = (int)(originalBounds.Width * xRatio);
            int newHeight = (int)(originalBounds.Height * yRatio);

            // Apply new bounds to the control
            control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
        }

        private void InitializeClassListView()
        {
            // Clear any existing columns and items
            listViewClasses.Clear();

            // Set View to Details for columns to be visible
            listViewClasses.View = View.Details;
            listViewClasses.FullRowSelect = true;
            listViewClasses.MultiSelect = true;  // Allow multi-select

            // Add columns
            listViewClasses.Columns.Add("Day of Week", 100, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Time", 100, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Class Name", 100, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Class Location", 100, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Session Name", 100, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Teachers", 100, HorizontalAlignment.Left);

            // Fetch classes data
            var dataTable = dbHelper.GetClassesDataTable();

            // Populate list view with data
            foreach (DataRow row in dataTable.Rows)
            {
                var classObj = new Class
                {
                    ClassID = Convert.ToInt32(row["ClassID"]),
                    ClassName = row["ClassName"].ToString(),
                    ClassLocation = row["ClassLocation"].ToString(),
                    SessionName = row["SessionName"].ToString(),
                    DayOfWeek = row["DayOfWeek"].ToString(),
                    Time = row["Time"].ToString(),
                    Teachers = row["Teachers"].ToString()
                };

                var listViewItem = new ListViewItem(classObj.DayOfWeek);
                listViewItem.SubItems.Add(classObj.Time);
                listViewItem.SubItems.Add(classObj.ClassName);
                listViewItem.SubItems.Add(classObj.ClassLocation);
                listViewItem.SubItems.Add(classObj.SessionName);
                listViewItem.SubItems.Add(classObj.Teachers);

                // Store the Class object in the Tag property of each ListViewItem
                listViewItem.Tag = classObj;

                listViewClasses.Items.Add(listViewItem);
            }

            // Auto-resize columns to fit content
            foreach (ColumnHeader column in listViewClasses.Columns)
            {
                column.Width = -2;  // Auto-size based on content
            }

            // Adjust the form and list view size after populating the content
            AdjustFormSize();
        }

        private void AdjustFormSize()
        {
            // Manually set column widths based on expected content size
            listViewClasses.Columns[0].Width = 250; // ClassName
            listViewClasses.Columns[1].Width = 150; // ClassLocation
            listViewClasses.Columns[2].Width = 180; // SessionName
            listViewClasses.Columns[3].Width = 150; // DayOfWeek
            listViewClasses.Columns[4].Width = 130;  // Time
            listViewClasses.Columns[5].Width = 150; // Teachers

            // Set ListView to a fixed width and height
            listViewClasses.Width = listViewClasses.Columns.Cast<ColumnHeader>().Sum(c => c.Width) + SystemInformation.VerticalScrollBarWidth;

            // Set ListView height manually (example: limit to 400 for vertical scrolling)
            listViewClasses.Height = Math.Min(listViewClasses.Items.Count * listViewClasses.Items[0].Bounds.Height, 400);

            // Adjust form size based on the ListView size
            this.Width = listViewClasses.Width + 40;  // Add padding for the form width
            this.Height = listViewClasses.Height + 150;  // Add padding for the form height (includes room for the button)

            // Position the button below the ListView aligned to the bottom left
            btnAddSelectedClasses.Location = new Point(10, listViewClasses.Bottom + 10);  // Position button with some padding
            btnAddSelectedClasses.BringToFront();  // Ensure the button is visible on top
        }

        private void ListViewClasses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Toggle sorting direction
            ascending = !ascending;

            // Sort the ListView items based on the clicked column index
            listViewClasses.ListViewItemSorter = new ListViewItemComparer(e.Column, ascending);
            listViewClasses.Sort();
        }

        private void btnAddSelectedClasses_Click(object sender, EventArgs e)
        {
            // Retrieve selected items and store them in SelectedClasses list
            foreach (ListViewItem item in listViewClasses.SelectedItems)
            {
                var selectedClass = (Class)item.Tag;
                if (!SelectedClasses.Any(c => c.ClassID == selectedClass.ClassID))
                {
                    SelectedClasses.Add(selectedClass);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    // Comparer class to sort ListView columns
    public class ListViewItemComparer : IComparer
    {
        private readonly int col;
        private readonly bool ascending;

        public ListViewItemComparer(int column, bool ascending)
        {
            col = column;
            this.ascending = ascending;
        }

        public int Compare(object x, object y)
        {
            int returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                            ((ListViewItem)y).SubItems[col].Text);
            return ascending ? returnVal : -returnVal;
        }
    }
}
