using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class SessionForm : BaseForm
    {
        private DatabaseHelper dbHelper;

        // Variables for resizing
        private Size originalFormSize;

        private Rectangle originalDgvSessionsBounds;
        private Rectangle originalBtnAddSessionBounds;
        private Rectangle originalBtnDeleteSessionBounds;

        public SessionForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadSessions();

            // Set the form's position and initialize MaterialSkin
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Hook up form load and resize events
            this.Load += SessionForm_Load;
            this.Resize += SessionForm_Resize;

            // Hook up DataGridView cell click event
            dgvSessions.CellClick += DgvSessions_CellClick;
        }

        private void SessionForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds
            originalFormSize = this.Size;
            originalDgvSessionsBounds = dgvSessions.Bounds;
            originalBtnAddSessionBounds = btnAddSession.Bounds;
            originalBtnDeleteSessionBounds = btnDeleteSession.Bounds;
        }

        private void SessionForm_Resize(object sender, EventArgs e)
        {
            // Resize the controls when the form is resized
            ResizeControl(dgvSessions, originalDgvSessionsBounds);
            ResizeControl(btnAddSession, originalBtnAddSessionBounds);
            ResizeControl(btnDeleteSession, originalBtnDeleteSessionBounds);
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
            var sessionsTable = dbHelper.GetSessionsDataTable();
            dgvSessions.DataSource = sessionsTable;
            dgvSessions.Columns["SessionID"].Visible = false; // Hide the SessionID column
        }

        // Event handler for DataGridView cell click
        private void DgvSessions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked on a valid row and not the header
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvSessions.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            // Open a dialog to add a new session
            using (var addSessionForm = new AddSessionForm(this))
            {
                if (addSessionForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSessions(); // Refresh the session list after adding
                }
            }
        }

        private void btnDeleteSession_Click(object sender, EventArgs e)
        {
            if (dgvSessions.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSessions.SelectedRows[0];
                int sessionId = Convert.ToInt32(selectedRow.Cells["SessionID"].Value);

                // Confirm deletion
                var confirmResult = MessageBox.Show("Are you sure to delete this session?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    dbHelper.DeleteSession(sessionId);
                    LoadSessions(); // Refresh the session list after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a session to delete.");
            }
        }
    }
}