﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace MDSoDv2
{
    public partial class ClassForm : BaseForm
    {
        private DatabaseHelper dbHelper;

        // Variables to store original size for resizing logic
        private Size originalFormSize;
        private Rectangle originalCmbSessionBounds;
        private Rectangle originalDgvClassesBounds;
        private Rectangle originalBtnAddClassBounds;
        private Rectangle originalBtnDeleteClassBounds;

        public ClassForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadSessions();

            // Set form's position
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Hook up form load and resize events
            this.Load += ClassForm_Load;
            this.Resize += ClassForm_Resize;

            // Hook up DataGridView cell click event
            dgvClasses.CellClick += DgvClasses_CellClick;
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalCmbSessionBounds = cmbSession.Bounds;
            originalDgvClassesBounds = dgvClasses.Bounds;
            originalBtnAddClassBounds = btnAddClass.Bounds;
            originalBtnDeleteClassBounds = btnDeleteClass.Bounds;
        }

        private void ClassForm_Resize(object sender, EventArgs e)
        {
            // Resize controls when form resizes
            ResizeControl(cmbSession, originalCmbSessionBounds);
            ResizeControl(dgvClasses, originalDgvClassesBounds);
            ResizeControl(btnAddClass, originalBtnAddClassBounds);
            ResizeControl(btnDeleteClass, originalBtnDeleteClassBounds);
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
            var sessions = dbHelper.GetAllSessions();
            cmbSession.DataSource = sessions;
            cmbSession.DisplayMember = "SessionName";
            cmbSession.ValueMember = "SessionID";
            cmbSession.SelectedIndexChanged += CmbSession_SelectedIndexChanged;
            LoadClasses(); // Load classes for the first session
        }

        private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClasses();
        }

        public void LoadClasses()
        {
            int selectedSessionId = (int)cmbSession.SelectedValue;
            var classesTable = dbHelper.GetClassesBySessionId(selectedSessionId);
            dgvClasses.DataSource = classesTable;
            dgvClasses.Refresh();
            dgvClasses.Columns["ClassID"].Visible = false; // Hide the ClassID column
            dgvClasses.Columns["SessionID"].Visible = false; // Hide the SessionID column
        }

        private void DgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked on a valid row and not the header
            if (e.RowIndex >= 0)
            {
                // Select the entire row
                dgvClasses.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            using (var addNewClassForm = new AddNewClassForm(this))
            {
                if (addNewClassForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSessions(); // Reload sessions when AddNewClassForm is closed
                    LoadClasses(); // Reload classes when AddClassForm is closed
                }
            }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count > 0)
            {
                int selectedClassId = Convert.ToInt32(dgvClasses.SelectedRows[0].Cells["ClassID"].Value);

                var confirmResult = MessageBox.Show("Are you sure to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    dbHelper.DeleteClass(selectedClassId);
                    LoadClasses(); // Refresh the class list after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a class to delete.");
            }
        }
    }
}
