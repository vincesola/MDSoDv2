using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class ClassSheetForm : BaseForm
    {
        private DatabaseHelper dbHelper;
        private List<Class> classList = new List<Class>();

        public ClassSheetForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            // Set form's position
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Load sessions and hook up events
            LoadSessions();
        }

        private void LoadSessions()
        {
            var sessions = dbHelper.GetAllSessions();

            cmbSessions.DataSource = sessions;
            cmbSessions.DisplayMember = "SessionName";
            cmbSessions.ValueMember = "SessionID";

            // Hook up event to load classes when session changes
            cmbSessions.SelectedIndexChanged += cmbSessions_SelectedIndexChanged;

            // Trigger loading classes for the first session
            if (cmbSessions.Items.Count > 0)
            {
                cmbSessions.SelectedIndex = 0;
            }
        }

        private void cmbSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClasses();
        }

        private void LoadClasses()
        {
            if (cmbSessions.SelectedValue == null || !int.TryParse(cmbSessions.SelectedValue.ToString(), out int selectedSessionId))
                return;

            // Get classes for the selected session
            classList = dbHelper.GetClassesBySessionIdWithStudents(selectedSessionId);

            chkListClasses.Items.Clear();

            foreach (var classObj in classList)
            {
                // Add the display text and maintain the mapping
                string displayText = $"{classObj.ClassName} - {classObj.ClassLocation} - {classObj.DayOfWeek} - {classObj.Time}";
                chkListClasses.Items.Add(displayText);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            bool selectAll = btnSelectAll.Text == "Select All";
            for (int i = 0; i < chkListClasses.Items.Count; i++)
            {
                chkListClasses.SetItemChecked(i, selectAll);
            }
            btnSelectAll.Text = selectAll ? "Deselect All" : "Select All";
        }

        private void btnPrintRosters_Click(object sender, EventArgs e)
        {
            if (chkListClasses.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one class.", "No Classes Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve the selected classes based on the checked items
            var selectedClasses = chkListClasses.CheckedItems.Cast<string>()
                .Select(displayText => classList.FirstOrDefault(c =>
                    $"{c.ClassName} - {c.ClassLocation} - {c.DayOfWeek} - {c.Time}" == displayText))
                .Where(c => c != null)
                .ToList();

            foreach (var classDetails in selectedClasses)
            {
                PrintRosterSheet(classDetails);
            }
        }

        private void PrintRosterSheet(Class classDetails)
        {
            if (cmbSessions.SelectedValue == null || !int.TryParse(cmbSessions.SelectedValue.ToString(), out int selectedSessionId))
            {
                MessageBox.Show("Invalid session selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var session = dbHelper.GetSessionByID(selectedSessionId);
            if (session == null)
            {
                MessageBox.Show("Failed to retrieve session details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var students = dbHelper.GetStudentsByClassId(classDetails.ClassID);
            var dates = GetSessionDates(session, classDetails.DayOfWeek);

            // Group dates by month
            var datesByMonth = dates.GroupBy(date => date.ToString("MMMM yyyy")).ToList();

            // Tracking variables for state across pages
            int currentMonthIndex = 0;
            bool morePages = false;

            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Set to landscape mode
            printDocument.PrintPage += (sender, e) =>
            {
                int yPos = 100; // Start position for rows
                int nameColumnWidth = 200; // Fixed width for names
                int dateColumnWidth = 100; // Fixed width for dates
                int xStart = 100; // Left margin

                // Check if all months have been printed
                if (currentMonthIndex >= datesByMonth.Count)
                {
                    e.HasMorePages = false;
                    return;
                }

                // Get the current month's dates and header
                var currentMonthGroup = datesByMonth[currentMonthIndex];
                string monthHeader = currentMonthGroup.Key;
                var monthDates = currentMonthGroup.ToList();

                // Print the header
                e.Graphics.DrawString($"Roster for {classDetails.ClassName} {classDetails.DayOfWeek} {classDetails.Time}  ({monthHeader})",
                    new Font("Arial", 16, FontStyle.Bold), Brushes.Black, xStart, yPos);
                yPos += 40;

                // Print column headers (Student + dates)
                e.Graphics.DrawString("Student", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, xStart, yPos);
                for (int i = 0; i < monthDates.Count; i++)
                {
                    e.Graphics.DrawString(monthDates[i].ToString("MM/dd"),
                        new Font("Arial", 12, FontStyle.Bold), Brushes.Black,
                        xStart + nameColumnWidth + (i * dateColumnWidth), yPos);
                }
                yPos += 30;

                // Print students and checkboxes
                foreach (var student in students)
                {
                    // Print the student's name with truncation if too long
                    string studentName = $"{student.FirstName} {student.LastName}";
                    if (studentName.Length > 20) // Arbitrary truncation limit
                    {
                        studentName = studentName.Substring(0, 17) + "...";
                    }
                    e.Graphics.DrawString(studentName, new Font("Arial", 12), Brushes.Black, xStart, yPos);

                    // Print checkboxes for each date
                    for (int i = 0; i < monthDates.Count; i++)
                    {
                        int checkBoxX = xStart + nameColumnWidth + (i * dateColumnWidth);
                        e.Graphics.DrawRectangle(Pens.Black, checkBoxX, yPos, 15, 15); // Draw checkbox
                    }

                    yPos += 30;

                    // Check if the page height is exceeded
                    if (yPos > e.MarginBounds.Bottom - 30)
                    {
                        morePages = true;
                        break;
                    }
                }

                // Move to the next month if no more space on this page
                if (!morePages)
                {
                    currentMonthIndex++;
                }

                // Indicate whether more pages are required
                e.HasMorePages = currentMonthIndex < datesByMonth.Count;
            };


            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };
            printPreviewDialog.ShowDialog();
        }


        private List<DateTime> GetSessionDates(Session session, string dayOfWeek)
        {
            var dates = new List<DateTime>();

            if (!Enum.TryParse(dayOfWeek, out DayOfWeek classDay))
                return dates;

            DateTime currentDate = session.StartDate;
            while (currentDate <= session.EndDate)
            {
                if (currentDate.DayOfWeek == classDay)
                {
                    dates.Add(currentDate);
                }
                currentDate = currentDate.AddDays(1);
            }

            return dates;
        }
    }
}
