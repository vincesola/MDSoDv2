using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class AddNewClassForm : BaseForm
    {
        private int classId = 0;
        private DatabaseHelper dbHelper;
        private ClassForm parentForm;

        // Variables to store original size for resizing logic
        private Size originalFormSize;

        private Rectangle originalTxtClassNameBounds;
        private Rectangle originalCmbClassLocationBounds;
        private Rectangle originalCmbDayOfWeekBounds;
        private Rectangle originalCmbTimeBounds;
        private Rectangle originalChkTeachersBounds;
        private Rectangle originalCmbSessionBounds;
        private Rectangle originalBtnSaveBounds;
        private Rectangle originalBtnCancelBounds;
        private Rectangle originalBtnAddSessionBounds;

        public AddNewClassForm(ClassForm parent)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form
            this.parentForm = parent;
            dbHelper = new DatabaseHelper();

            LoadTeachers();
            PopulateTimeSlots();
            PopulateSessions();
            PopulateDayOfWeek();
            PopulateClassLocations();

            // Hook up form load and resize events
            this.Load += AddNewClassForm_Load;
            this.Resize += AddNewClassForm_Resize;
            chkTeachers.CheckOnClick = true;
        }

        private void AddNewClassForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalTxtClassNameBounds = txtClassName.Bounds;
            originalCmbClassLocationBounds = cmbClassLocation.Bounds;
            originalCmbDayOfWeekBounds = cmbDayOfWeek.Bounds;
            originalCmbTimeBounds = cmbTime.Bounds;
            originalChkTeachersBounds = chkTeachers.Bounds;
            originalCmbSessionBounds = cmbSession.Bounds;
            originalBtnSaveBounds = btnSave.Bounds;
            originalBtnCancelBounds = btnCancel.Bounds;
            originalBtnAddSessionBounds = btnAddSession.Bounds;
        }

        private void AddNewClassForm_Resize(object sender, EventArgs e)
        {
            // Resize controls when form resizes
            ResizeControl(txtClassName, originalTxtClassNameBounds);
            ResizeControl(cmbClassLocation, originalCmbClassLocationBounds);
            ResizeControl(cmbDayOfWeek, originalCmbDayOfWeekBounds);
            ResizeControl(cmbTime, originalCmbTimeBounds);
            ResizeControl(chkTeachers, originalChkTeachersBounds);
            ResizeControl(cmbSession, originalCmbSessionBounds);
            ResizeControl(btnSave, originalBtnSaveBounds);
            ResizeControl(btnCancel, originalBtnCancelBounds);
            ResizeControl(btnAddSession, originalBtnAddSessionBounds);
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

        private void LoadTeachers()
        {
            var teachers = dbHelper.GetAllTeachers();
            chkTeachers.Items.Clear();

            // Add each teacher to the checked list box
            foreach (var teacher in teachers)
            {
                chkTeachers.Items.Add(teacher.TeacherName, false);
            }

            // Apply custom style to CheckedListBox
            StyleCheckedListBox();
        }

        private void StyleCheckedListBox()
        {
            // Custom styling to align with MaterialSkin design
            chkTeachers.BackColor = Color.White;
            chkTeachers.BorderStyle = BorderStyle.None;
            chkTeachers.Font = new Font("Roboto", 12);
            chkTeachers.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkTeachers.ItemHeight = 30;
            chkTeachers.MultiColumn = true; // Optional: Make it multi-column
        }

        private void PopulateTimeSlots()
        {
            cmbTime.Items.Clear();
            DateTime startTime = DateTime.Today.AddHours(9); // 9:00 AM
            DateTime endTime = DateTime.Today.AddHours(21); // 9:00 PM

            while (startTime <= endTime)
            {
                cmbTime.Items.Add(startTime.ToString("hh:mm tt"));
                startTime = startTime.AddMinutes(15);
            }
        }

        private void PopulateSessions()
        {
            var sessions = dbHelper.GetAllSessions();
            cmbSession.DisplayMember = "SessionName";
            cmbSession.ValueMember = "SessionID";
            cmbSession.DataSource = sessions;
        }

        private void PopulateClassLocations()
        {
            cmbClassLocation.Items.Clear();
            cmbClassLocation.Items.AddRange(new object[] { "Downstairs", "Main Floor", "Stage" });
        }

        private void PopulateDayOfWeek()
        {
            cmbDayOfWeek.Items.Clear();
            cmbDayOfWeek.Items.AddRange(new object[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedSessionValue = cmbSession.SelectedValue;

            if (selectedSessionValue == null)
            {
                MessageBox.Show("Please select a session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbClassLocation.SelectedItem == null)
            {
                MessageBox.Show("Please select a class location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedTeachers = chkTeachers.CheckedItems.Cast<string>().ToArray();
            var classDetails = new Class
            {
                ClassID = classId,
                SessionID = (int)selectedSessionValue,
                ClassName = txtClassName.Text,
                ClassLocation = cmbClassLocation.SelectedItem.ToString(),
                DayOfWeek = cmbDayOfWeek.SelectedItem.ToString(),
                Time = cmbTime.SelectedItem.ToString(),
                Teachers = string.Join(",", selectedTeachers)
            };

            if (classId > 0)
            {
                dbHelper.UpdateClass(classDetails);
            }
            else
            {
                dbHelper.AddClass(classDetails);
            }

            // Reload the class list in the parent form
            parentForm.LoadClasses();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            string newSessionName = AddSessionPrompt.ShowDialog("Enter new session name:", "Add Session");
            if (!string.IsNullOrWhiteSpace(newSessionName))
            {
                var newSession = new Session { SessionName = newSessionName };
                dbHelper.AddSession(newSession);
                PopulateSessions();
                cmbSession.SelectedValue = newSession.SessionID;
            }
        }
    }
}