using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class PaymentForm : BaseForm
    {
        private DatabaseHelper dbHelper;
        private int selectedStudentId = -1; // To track selected student ID

        // Variables to store original size and positions
        private Size originalFormSize;

        private Rectangle originalTxtSearchBounds;
        private Rectangle originalDgvStudentsBounds;
        private Rectangle originalBtnPaymentHistoryBounds;
        private Rectangle originalBtnGeneratePaymentsBounds;

        public PaymentForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            LoadStudents();

            // Set form properties
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(50); // Add padding to simulate border

            // Set the starting position near the parent form
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Store original control sizes and positions
            this.Load += PaymentForm_Load;
            this.Resize += PaymentForm_Resize;

            // Add DataGridView event handlers
            dgvStudents.CellClick += DgvStudents_CellClick;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // Store original size and position of controls
            originalFormSize = this.Size;
            originalTxtSearchBounds = txtSearch.Bounds;
            originalDgvStudentsBounds = dgvStudents.Bounds;
            originalBtnPaymentHistoryBounds = btnPaymentHistory.Bounds;
            originalBtnGeneratePaymentsBounds = btnGeneratePayments.Bounds;
        }

        private void PaymentForm_Resize(object sender, EventArgs e)
        {
            // Call the method to resize controls when the form is resized
            ResizeControl(txtSearch, originalTxtSearchBounds);
            ResizeControl(dgvStudents, originalDgvStudentsBounds);
            ResizeControl(btnPaymentHistory, originalBtnPaymentHistoryBounds);
            ResizeControl(btnGeneratePayments, originalBtnGeneratePaymentsBounds);
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
            var studentsTable = dbHelper.GetAllStudentsDataTable();
            dgvStudents.DataSource = studentsTable;
            dgvStudents.Columns["StudentID"].Visible = false; // Hide the StudentID column
        }

        private void DgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked a valid row, and not the header
            if (e.RowIndex >= 0)
            {
                // Fetch the selected student ID from the DataGridView
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            var studentsTable = dbHelper.GetAllStudentsDataTable();

            DataView dv = studentsTable.DefaultView;
            dv.RowFilter = $"FirstName LIKE '%{searchText}%' OR LastName LIKE '%{searchText}%'";
            dgvStudents.DataSource = dv.ToTable();
        }

        private void btnGeneratePayments_Click(object sender, EventArgs e)
        {
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
                if (selectedStudentId >= 0)
                {
                    // Open the PaymentHistoryForm
                    PaymentHistoryForm historyForm = new PaymentHistoryForm(this, selectedStudentId);
                    historyForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select a student to view payment history.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"An error occurred while retrieving the student's payment history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}