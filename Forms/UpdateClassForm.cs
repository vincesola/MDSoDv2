using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class UpdateClassForm : BaseForm
    {
        private Class selectedClass;
        private DatabaseHelper dbHelper;

        public UpdateClassForm(Form parent, Class classToEdit)
        {
            InitializeComponent();

            // Store the passed Class object
            selectedClass = classToEdit;

            // Set the form's position to be on the same screen as the parent
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Populate form fields with data from the selectedClass object
            txtClassName.Text = selectedClass.ClassName;

            // Populate dropdowns (ComboBoxes) with the appropriate values
            cmbClassLocation.SelectedItem = selectedClass.ClassLocation;
            cmbDayOfWeek.SelectedItem = selectedClass.DayOfWeek;
            cmbTime.SelectedItem = selectedClass.Time;

            // Populate Teachers (assuming chkTeachers is a CheckedListBox)
            PopulateTeachers(selectedClass.Teachers);

            // Set the session in the ComboBox
            PopulateSessions(selectedClass.SessionName);

            PopulateTimeSlots(selectedClass.Time);

            PopulateDayOfWeek(selectedClass.DayOfWeek);

            PopulateClassLocations(selectedClass.ClassLocation);
        }

        private void PopulateClassLocations(string classLocation)
        {
            cmbClassLocation.Items.Clear();
            cmbClassLocation.Items.AddRange(new object[] { "Downstairs", "Main Floor", "Stage" });

            cmbClassLocation.SelectedIndex = cmbClassLocation.FindStringExact(classLocation);
        }

        private void PopulateDayOfWeek(string dayOfWeek)
        {
            cmbDayOfWeek.Items.Clear();
            cmbDayOfWeek.Items.AddRange(new object[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });

            cmbDayOfWeek.SelectedIndex = cmbDayOfWeek.FindStringExact(dayOfWeek);
        }

        private void PopulateTimeSlots(string time)
        {
            cmbTime.Items.Clear();
            DateTime startTime = DateTime.Today.AddHours(9); // 9:00 AM
            DateTime endTime = DateTime.Today.AddHours(21); // 9:00 PM

            while (startTime <= endTime)
            {
                cmbTime.Items.Add(startTime.ToString("hh:mm tt"));
                startTime = startTime.AddMinutes(15);
            }

            cmbTime.SelectedIndex = cmbTime.FindStringExact(time);
        }

        private void PopulateTeachers(string teachers)
        {
            // Ensure dbHelper is instantiated
            if (dbHelper == null)
            {
                dbHelper = new DatabaseHelper();
            }

            // Get all teachers
            var allTeachers = dbHelper.GetAllTeachers();

            // Check if the list of teachers is null
            if (allTeachers == null)
            {
                MessageBox.Show("No teachers found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear the CheckedListBox
            chkTeachers.Items.Clear();

            // Populate the CheckedListBox with all teachers
            foreach (var teacher in allTeachers)
            {
                // Ensure teacher is not null and has a Name property
                if (teacher != null)
                {
                    string teacherName = teacher.TeacherName; // Adjust this according to the actual property
                                                              // Add each teacher's name to the list, checking if the teacher is in the 'teachers' string
                    chkTeachers.Items.Add(teacherName, teachers.Contains(teacherName));
                }
            }
        }

        private void PopulateSessions(string sessionName)
        {
            // Assuming you have a method to get all possible sessions
            var sessions = dbHelper.GetAllSessions(); // Replace with actual method to get sessions
            cmbSession.DataSource = sessions;
            cmbSession.DisplayMember = "SessionName";
            cmbSession.ValueMember = "SessionID";

            // Select the correct session
            cmbSession.SelectedIndex = cmbSession.FindStringExact(sessionName);
        }

        private void PopulateSessions()
        {
            var sessions = dbHelper.GetAllSessions(); // This method should return a list of sessions

            cmbSession.Items.Clear();
            foreach (var session in sessions)
            {
                cmbSession.Items.Add(session.SessionName); // Assuming session has a property 'SessionName'
            }

            // Optionally, set the default selected item if needed
            if (cmbSession.Items.Count > 0)
            {
                cmbSession.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Update selectedClass object with form data
            selectedClass.ClassName = txtClassName.Text;
            selectedClass.ClassLocation = cmbClassLocation.Text;
            selectedClass.DayOfWeek = cmbDayOfWeek.Text;
            selectedClass.Time = cmbTime.Text;
            selectedClass.Teachers = string.Join(",", chkTeachers.CheckedItems.Cast<string>());

            // Ensure that SessionID is correctly set from the selected session
            if (cmbSession.SelectedValue is int sessionId)
            {
                selectedClass.SessionID = sessionId;
            }
            else
            {
                MessageBox.Show("Failed to get the correct SessionID. Please ensure a session is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save to database using DatabaseHelper (implement the update logic in DatabaseHelper)
            var dbHelper = new DatabaseHelper();
            dbHelper.UpdateClass(selectedClass);

            // Close the form and return OK result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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