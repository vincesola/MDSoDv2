using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using MaterialSkin.Controls;

namespace MDSoDv2
{
    public partial class ClassSheetForm : BaseForm
    {
        private DatabaseHelper dbHelper;
        private List<Class> classList = new List<Class>(); // Initialize the list

        // Variables to store original size for resizing logic
        private Size originalFormSize;
        private Rectangle originalChkListClasses;
        private Rectangle originalBtnSelectAll;
        private Rectangle originalBtnPrintRosters;
        private Rectangle originalCmbSessions;

        public ClassSheetForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            // Set form's position
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Load classes into the checked list box
            LoadSessions();

            this.Load += ClassSheetForm_Load;
            this.Resize += ClassSheetForm_Resize;
        }

        private void ClassSheetForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalChkListClasses = chkListClasses.Bounds;
            originalBtnSelectAll = btnSelectAll.Bounds;
            originalBtnPrintRosters = btnPrintRosters.Bounds;
            originalCmbSessions = cmbSessions.Bounds;
        }

        private void ClassSheetForm_Resize(object sender, EventArgs e)
        {
            // Resize controls when form resizes
            ResizeControl(chkListClasses, originalChkListClasses);
            ResizeControl(btnSelectAll, originalBtnSelectAll);
            ResizeControl(btnPrintRosters, originalBtnPrintRosters);
            ResizeControl(cmbSessions, originalCmbSessions);
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
        private void LoadSessions()
        {
            var sessions = dbHelper.GetAllSessions(); // This should return a list of session objects with SessionID and SessionName

            // Set up ComboBox with sessions
            cmbSessions.DataSource = sessions;
            cmbSessions.DisplayMember = "SessionName"; // What is shown to the user
            cmbSessions.ValueMember = "SessionID"; // What is used as the value in code

            // Hook up the SelectedIndexChanged event
            cmbSessions.SelectedIndexChanged += cmbSessions_SelectedIndexChanged;

            // Select the first session by default, triggering the event
            if (cmbSessions.Items.Count > 0)
            {
                cmbSessions.SelectedIndex = -1;
            }
        }
        private void cmbSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClasses();
        }
        private void LoadClasses()
        {
            // Check if a session is selected and if SelectedValue is not null
            if (cmbSessions.SelectedValue == null || !int.TryParse(cmbSessions.SelectedValue.ToString(), out int selectedSessionId))
            {
                // No valid session selected, return early
                return;
            }

            // Get classes for the selected session with students assigned
            classList = dbHelper.GetClassesBySessionIdWithStudents(selectedSessionId); // Populate classList

            // Clear existing items in the checklist
            chkListClasses.Items.Clear();

            // Add the filtered classes to the checklist
            foreach (var classObj in classList)
            {
                // Combine the required properties into a single string for display
                string displayText = $"{classObj.ClassName} - {classObj.ClassLocation} - {classObj.DayOfWeek} - {classObj.Time}";

                // Add the combined string to the CheckedListBox
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
            // Get selected classes (cast items to Class)
            var selectedClasses = chkListClasses.CheckedItems.Cast<Class>().ToList();
            if (selectedClasses.Count == 0)
            {
                MessageBox.Show("Please select at least one class.", "No Classes Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate and print roster sheets
            foreach (var classDetails in selectedClasses)
            {
                PrintRosterSheet(classDetails);
            }
        }
        private void PrintRosterSheet(Class classDetails)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Set to landscape mode
            printDocument.PrintPage += (sender, e) =>
            {
                // Fetch students for the class
                var students = dbHelper.GetStudentsByClassId(classDetails.ClassID);
                int yPos = 100;

                // Print the header
                e.Graphics.DrawString($"Roster for {classDetails.ClassName} (ClassID: {classDetails.ClassID})", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 100, yPos);
                yPos += 40;

                // Define checkbox size
                int checkboxSize = 15;
                int checkboxPadding = 5;

                // Define the starting x position for checkboxes and student names
                int checkboxXPos = 100;
                int textXPos = checkboxXPos + checkboxSize + checkboxPadding;

                foreach (var student in students)
                {
                    // Draw a rectangle as a checkbox
                    e.Graphics.DrawRectangle(Pens.Black, checkboxXPos, yPos, checkboxSize, checkboxSize);

                    // Draw the student's name next to the checkbox
                    e.Graphics.DrawString($"{student.FirstName} {student.LastName}", new Font("Arial", 12), Brushes.Black, textXPos, yPos);
                    yPos += checkboxSize + checkboxPadding; // Move down by the size of the checkbox and padding
                }
            };

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

    }
}
