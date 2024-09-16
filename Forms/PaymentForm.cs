using System;
using System.Data;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class PaymentForm : BaseForm
    {
        private DatabaseHelper dbHelper;

        public PaymentForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            // Load all students into the DataGridView
            LoadStudents();
        }

        private void LoadStudents()
        {
            // Get the DataTable containing all students
            var studentsTable = dbHelper.GetAllStudentsDataTable();

            // Set the DataGridView's DataSource to the DataTable
            dgvStudents.DataSource = studentsTable;
            dgvStudents.Columns["StudentID"].Visible = false; // Hide the StudentID column
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the search text and apply a filter to the DataTable
            string searchText = txtSearch.Text.ToLower();
            var studentsTable = dbHelper.GetAllStudentsDataTable();

            // Use DataView to filter the DataTable
            DataView dv = studentsTable.DefaultView;
            dv.RowFilter = $"FirstName LIKE '%{searchText}%' OR LastName LIKE '%{searchText}%'";
            dgvStudents.DataSource = dv.ToTable();
        }

        private void btnGeneratePayments_Click(object sender, EventArgs e)
        {
            // Generate payments for all records in the StudentClasses table
            var studentClasses = dbHelper.GetAllStudentClasses();
            foreach (var studentClass in studentClasses)
            {
                dbHelper.GenerateExpectedPayments(studentClass.StudentClassID);
            }
            MessageBox.Show("Payments generated successfully.");
        }

        private void btnPaymentHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Assuming the DataGridView is used to select the student
                if (dgvStudents.SelectedRows.Count > 0)
                {
                    // Ensure you are retrieving the correct type from the DataGridView
                    int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);

                    // Open the PaymentHistoryForm
                    PaymentHistoryForm historyForm = new PaymentHistoryForm(studentID);
                    historyForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select a student to view payment history.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (InvalidCastException ex)
            {
                // Display a more detailed message for debugging
                MessageBox.Show($"An error occurred while retrieving the student's payment history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}