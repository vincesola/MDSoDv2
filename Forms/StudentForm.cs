using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;

namespace MDSoDv2
{
    public partial class StudentForm : BaseForm
    {
        private const int borderWidth = 50;  // Border width for focused and non-focused forms
        private DatabaseHelper dbHelper;
        private int selectedStudentId = -1; // To track selected student ID

        // Variables to store original size and positions
        private Size originalFormSize;
        private Rectangle originalTxtSearchBounds;
        private Rectangle originalChkSearchAllStudentsBounds;
        private Rectangle originalDgvStudentsBounds;
        private Rectangle originalBtnAddStudentBounds;
        private Rectangle originalBtnUpdateStudentBounds;
        private Rectangle originalBtnDeleteStudentBounds;

        public StudentForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            LoadStudents();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderWidth); // Add padding to simulate border

            // Set the starting position near the parent form
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Add DataGridView event handlers
            dgvStudents.CellClick += DgvStudents_CellClick;
            dgvStudents.CellDoubleClick += dgvStudents_CellDoubleClick;

            // Store original control sizes and positions
            this.Load += StudentForm_Load;
            this.Resize += StudentForm_Resize;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // Store original size and position of controls
            originalFormSize = this.Size;
            originalTxtSearchBounds = txtSearch.Bounds;
            originalChkSearchAllStudentsBounds = chkSearchAllStudents.Bounds;
            originalDgvStudentsBounds = dgvStudents.Bounds;
            originalBtnAddStudentBounds = btnAddStudent.Bounds;
            originalBtnUpdateStudentBounds = btnUpdateStudent.Bounds;
            originalBtnDeleteStudentBounds = btnDeleteStudent.Bounds;
        }

        private void StudentForm_Resize(object sender, EventArgs e)
        {
            // Call the method to resize controls when the form is resized
            ResizeControl(txtSearch, originalTxtSearchBounds);
            ResizeControl(chkSearchAllStudents, originalChkSearchAllStudentsBounds);
            ResizeControl(dgvStudents, originalDgvStudentsBounds);
            ResizeControl(btnAddStudent, originalBtnAddStudentBounds);
            ResizeControl(btnUpdateStudent, originalBtnUpdateStudentBounds);
            ResizeControl(btnDeleteStudent, originalBtnDeleteStudentBounds);
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

        private void LoadStudents()
        {
            DataTable studentsTable = chkSearchAllStudents.Checked
                ? dbHelper.GetAllStudentsDataTable()
                : dbHelper.GetActiveStudentsDataTable();

            // Check if data is retrieved
            if (studentsTable != null && studentsTable.Rows.Count > 0)
            {
                dgvStudents.DataSource = studentsTable;
                dgvStudents.Columns["StudentID"].Visible = false; // Hide the StudentID column
            }
            else
            {
                MessageBox.Show("No students found.", "Data Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked a valid row, and not the header
            if (e.RowIndex >= 0)
            {
                // Fetch the selected student ID from the DataGridView
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                //MessageBox.Show($"Selected Student ID: {selectedStudentId}", "Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user double-clicked a valid row, and not the header
            if (e.RowIndex >= 0)
            {
                // Fetch the selected student ID from the DataGridView
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);

                // Retrieve the selected student using the captured StudentID
                Student selectedStudent = dbHelper.GetStudentById(selectedStudentId);

                if (selectedStudent != null)
                {
                    // Open the UpdateStudentForm
                    var updateStudentForm = new UpdateStudentForm(this, selectedStudent);
                    updateStudentForm.ShowDialog();
                    LoadStudents(); // Refresh the student list after updating
                }
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private void chkSearchAllStudents_CheckedChanged(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void SearchStudents()
        {
            var searchTerm = txtSearch.Text.ToLower();
            DataTable studentsTable = chkSearchAllStudents.Checked
                ? dbHelper.GetAllStudentsDataTable()
                : dbHelper.GetActiveStudentsDataTable();

            var filteredRows = studentsTable.AsEnumerable()
                .Where(row => row.Field<string>("FirstName").ToLower().Contains(searchTerm) ||
                              row.Field<string>("LastName").ToLower().Contains(searchTerm));
            dgvStudents.DataSource = filteredRows.CopyToDataTable();
            dgvStudents.Columns["StudentID"].Visible = false; // Hide the StudentID column
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Open a form to add a new student
            var addStudentForm = new AddStudentForm(this);
            addStudentForm.ShowDialog();
            LoadStudents(); // Refresh the student list after adding
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (selectedStudentId >= 0)
            {
                // Retrieve the selected student using the captured StudentID
                Student selectedStudent = dbHelper.GetStudentById(selectedStudentId);

                if (selectedStudent != null)
                {
                    var updateStudentForm = new UpdateStudentForm(this, selectedStudent);
                    updateStudentForm.ShowDialog();
                    LoadStudents(); // Refresh the student list after updating
                }
            }
            else
            {
                MessageBox.Show("Please select a student to update.");
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (selectedStudentId >= 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    dbHelper.DeleteStudent(selectedStudentId);
                    LoadStudents(); // Refresh the student list after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }
    }
}
