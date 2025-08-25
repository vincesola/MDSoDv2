using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class AddClassForm : BaseForm
    {
        public List<Class> SelectedClasses { get; private set; } = new List<Class>();
        private DatabaseHelper dbHelper;
        private bool ascending = true; // Sorting direction flag

        // For session filter binding
        private bool _sessionsLoaded = false;

        // Variables to store original form size and control bounds for resizing
        private Size originalFormSize;
        private Rectangle originalListViewClassesBounds;
        private Rectangle originalBtnAddSelectedClassesBounds;

        public AddClassForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            InitializeClassListView();

            // session combo change handler (control added in Designer)
            this.cmbSessionFilter.SelectedIndexChanged += cmbSessionFilter_SelectedIndexChanged;

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
            // Bind sessions and default the selection (session containing today, else next upcoming)
            BindSessionsAndDefault();

            // Once the list is filtered for the first time, capture "original" bounds for your resize logic
            originalFormSize = this.Size;
            originalListViewClassesBounds = listViewClasses.Bounds;
            originalBtnAddSelectedClassesBounds = btnAddSelectedClasses.Bounds;
        }

        private void AddClassForm_Resize(object sender, EventArgs e)
        {
            ResizeControl(listViewClasses, originalListViewClassesBounds);
            ResizeControl(btnAddSelectedClasses, originalBtnAddSelectedClassesBounds);
        }

        private void ResizeControl(Control control, Rectangle originalBounds)
        {
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            int newX = (int)(originalBounds.X * xRatio);
            int newY = (int)(originalBounds.Y * yRatio);
            int newWidth = (int)(originalBounds.Width * xRatio);
            int newHeight = (int)(originalBounds.Height * yRatio);

            control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
        }

        private void InitializeClassListView()
        {
            // Columns/appearance
            listViewClasses.Clear();
            listViewClasses.View = View.Details;
            listViewClasses.FullRowSelect = true;
            listViewClasses.MultiSelect = true;

            listViewClasses.Columns.Add("Day of Week", 120, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Time", 100, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Class Name", 220, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Class Location", 140, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Session Name", 160, HorizontalAlignment.Left);
            listViewClasses.Columns.Add("Teachers", 160, HorizontalAlignment.Left);

            // Initial population (will be immediately replaced by session-filtered data on Load)
            var dataTable = dbHelper.GetClassesDataTable();
            PopulateClassListView(dataTable);

            AdjustFormSize();
        }

        private void PopulateClassListView(DataTable dataTable)
        {
            listViewClasses.BeginUpdate();
            try
            {
                listViewClasses.Items.Clear();

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

                    listViewItem.Tag = classObj;
                    listViewClasses.Items.Add(listViewItem);
                }

                // Auto-size based on content once after load
                foreach (ColumnHeader column in listViewClasses.Columns)
                    column.Width = -2;
            }
            finally
            {
                listViewClasses.EndUpdate();
            }
        }

        private void AdjustFormSize()
        {
            // Re-assert sensible widths after auto-size
            listViewClasses.Columns[0].Width = 120; // Day of Week
            listViewClasses.Columns[1].Width = 100; // Time
            listViewClasses.Columns[2].Width = 220; // Class Name
            listViewClasses.Columns[3].Width = 140; // Class Location
            listViewClasses.Columns[4].Width = 160; // Session Name
            listViewClasses.Columns[5].Width = 160; // Teachers

            listViewClasses.Width = listViewClasses.Columns.Cast<ColumnHeader>().Sum(c => c.Width)
                                      + SystemInformation.VerticalScrollBarWidth;

            if (listViewClasses.Items.Count > 0)
            {
                int rowH = listViewClasses.Items[0].Bounds.Height;
                listViewClasses.Height = Math.Min(listViewClasses.Items.Count * rowH, 400);
            }
            else
            {
                listViewClasses.Height = 200;
            }

            // Position the button below the ListView aligned to the bottom left
            btnAddSelectedClasses.Location = new Point(10, listViewClasses.Bottom + 10);
            btnAddSelectedClasses.BringToFront();

            // Adjust overall form size/padding
            this.Width = Math.Max(this.Width, listViewClasses.Width + 40);
            this.Height = Math.Max(this.Height, listViewClasses.Bottom + 80);
        }

        private void ListViewClasses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ascending = !ascending;
            listViewClasses.ListViewItemSorter = new ListViewItemComparer(e.Column, ascending);
            listViewClasses.Sort();
        }

        private void btnAddSelectedClasses_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewClasses.SelectedItems)
            {
                var selectedClass = (Class)item.Tag;
                if (!SelectedClasses.Any(c => c.ClassID == selectedClass.ClassID))
                    SelectedClasses.Add(selectedClass);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ---------- Session filter wiring ----------

        private void BindSessionsAndDefault()
        {
            var sessions = dbHelper.GetSessionsDataTable(); // ensure it's ordered by StartDate in DB helper

            cmbSessionFilter.DisplayMember = "SessionName";
            cmbSessionFilter.ValueMember = "SessionID";
            cmbSessionFilter.DataSource = sessions;

            var defaultId = GetDefaultSessionId(sessions);
            if (defaultId.HasValue)
                cmbSessionFilter.SelectedValue = defaultId.Value;

            _sessionsLoaded = true;

            // Initial filtered load
            ReloadClassesForSelectedSession();
        }

        private int? GetDefaultSessionId(DataTable sessions)
        {
            if (sessions == null || sessions.Rows.Count == 0) return null;

            DateTime today = DateTime.Today;
            DataRow inProgress = null, nextFuture = null;

            foreach (DataRow r in sessions.Rows)
            {
                if (!DateTime.TryParse(Convert.ToString(r["StartDate"]), out var start)) continue;
                if (!DateTime.TryParse(Convert.ToString(r["EndDate"]), out var end)) continue;

                if (start <= today && today <= end)
                {
                    inProgress = r;
                    break; // exact hit wins
                }

                if (start >= today)
                {
                    if (nextFuture == null ||
                        DateTime.Parse(Convert.ToString(r["StartDate"])) <
                        DateTime.Parse(Convert.ToString(nextFuture["StartDate"])))
                    {
                        nextFuture = r;
                    }
                }
            }

            var pick = inProgress ?? nextFuture;
            return pick != null ? (int?)Convert.ToInt32(pick["SessionID"]) : null;
        }

        private void cmbSessionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_sessionsLoaded) return; // ignore initial binding churn
            ReloadClassesForSelectedSession();
        }

        private void ReloadClassesForSelectedSession()
        {
            if (cmbSessionFilter.SelectedValue == null)
            {
                // Fallback: show all
                var all = dbHelper.GetClassesDataTable();
                PopulateClassListView(all);
                AdjustFormSize();
                return;
            }

            int sessionId = Convert.ToInt32(cmbSessionFilter.SelectedValue);

            // Requires the new helper method:
            // public DataTable GetClassesBySessionIdDataTable(int sessionId)
            var dt = dbHelper.GetClassesBySessionIdDataTable(sessionId);
            PopulateClassListView(dt);
            AdjustFormSize();
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
            int returnVal = string.Compare(((ListViewItem)x).SubItems[col].Text,
                                           ((ListViewItem)y).SubItems[col].Text,
                                           StringComparison.CurrentCulture);
            return ascending ? returnVal : -returnVal;
        }
    }
}
