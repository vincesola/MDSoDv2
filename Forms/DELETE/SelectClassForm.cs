using System;
using System.Data;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class SelectClassForm : Form
    {
        private DatabaseHelper dbHelper;
        public Class SelectedClass { get; private set; }

        public SelectClassForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadClasses();
        }

        private void LoadClasses()
        {
            DataTable classesTable = dbHelper.GetClassesWithSessionNames();
            dgvClasses.DataSource = classesTable;

            // Adjust column visibility and headers
            dgvClasses.Columns["ClassID"].Visible = false; // Hide the ClassID column
            dgvClasses.Columns["SessionName"].HeaderText = "Session Name"; // Set a friendly header for SessionName
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count > 0)
            {
                DataRowView selectedRow = dgvClasses.SelectedRows[0].DataBoundItem as DataRowView;
                SelectedClass = new Class
                {
                    ClassID = Convert.ToInt32(selectedRow["ClassID"]),
                    ClassName = selectedRow["ClassName"].ToString(),
                    ClassLocation = selectedRow["ClassLocation"].ToString(),
                    SessionName = selectedRow["SessionName"].ToString() // Ensure your Class object has a SessionName property
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a class.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}