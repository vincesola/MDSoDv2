using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class NewStudentSignUpForm : Form
    {
        private List<Student> stagedStudents = new List<Student>();
        private DatabaseHelper dbHelper;

        public NewStudentSignUpForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            InitializePlaceholders();
            InitializeStateComboBox();
            InitializeStudentDataGridView();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form
        }

        private void InitializePlaceholders()
        {
            SetPlaceholder(txtParentFirstName, "Parent First Name");
            SetPlaceholder(txtParentLastName, "Parent Last Name");
            SetPlaceholder(txtStreetAddress, "Street Address");
            SetPlaceholder(txtCity, "City");
            SetPlaceholder(txtZipCode, "Zip Code");
            SetPlaceholder(txtPhoneNumber, "Phone Number");
            SetPlaceholder(txtEmail, "Email");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = SystemColors.GrayText;
                textBox.Tag = placeholder; // Store the placeholder in the Tag property
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void InitializeStateComboBox()
        {
            cmbState.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbState.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbState.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            cmbState.Items.AddRange(new string[]
            {
                "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID",
                "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS",
                "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK",
                "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV",
                "WI", "WY"
            });
        }

        private void InitializeStudentDataGridView()
        {
            dgvStudents.DataSource = null; // Reset the data source
            dgvStudents.Columns.Clear();
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.ReadOnly = true;

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name"
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name"
            });

            RefreshStudentGrid();
        }

        private void RefreshStudentGrid()
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = stagedStudents;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (var addStudentForm = new AddStudentForm(this))
            {
                if (addStudentForm.ShowDialog() == DialogResult.OK)
                {
                    var newStudent = addStudentForm.NewStudent; // Access the NewStudent property directly
                                                                // Inherit the address details from the NewStudentSignUpForm
                    newStudent.StreetAddress = txtStreetAddress.Text;
                    newStudent.City = txtCity.Text;
                    newStudent.State = cmbState.Text;
                    newStudent.ZipCode = txtZipCode.Text;
                    newStudent.PhoneNumber = txtPhoneNumber.Text;
                    newStudent.FamilyEmail = txtEmail.Text;

                    stagedStudents.Add(newStudent);
                    RefreshStudentGrid();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                // Save the first student to get the StudentID
                if (stagedStudents.Count > 0)
                {
                    var student = stagedStudents[0];
                    int studentID = dbHelper.AddStudent(student);

                    // Create a Parent object and associate with the student
                    var newParent = new Parent
                    {
                        FirstName = txtParentFirstName.Text,
                        LastName = txtParentLastName.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text,
                        Relationship = "Parent", // Assuming a default relationship
                        StudentID = studentID // Assign the newly generated StudentID
                    };

                    dbHelper.AddParent(newParent);
                }

                MessageBox.Show("New student and parent successfully signed up.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                // Assuming dgvStudents is the DataGridView that lists the students
                int selectedIndex = dgvStudents.SelectedRows[0].Index;
                if (selectedIndex != -1)
                {
                    stagedStudents.RemoveAt(selectedIndex); // Remove the student from the staged list
                    RefreshStudentGrid(); // Refresh the grid to reflect changes
                }
            }
            else
            {
                MessageBox.Show("Please select a student to remove.");
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            string errorMessage = "";

            if (string.IsNullOrEmpty(txtParentFirstName.Text) || txtParentFirstName.Text == "Parent First Name")
            {
                isValid = false;
                errorMessage += "Parent First Name is required.\n";
            }

            if (string.IsNullOrEmpty(txtParentLastName.Text) || txtParentLastName.Text == "Parent Last Name")
            {
                isValid = false;
                errorMessage += "Parent Last Name is required.\n";
            }

            if (stagedStudents.Count == 0)
            {
                isValid = false;
                errorMessage += "At least one student is required.\n";
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }
    }
}