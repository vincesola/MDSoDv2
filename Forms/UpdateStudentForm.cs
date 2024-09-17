using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class UpdateStudentForm : BaseForm
    {
        private DatabaseHelper dbHelper;
        private Student student;
        private List<Parent> stagedParents;
        private List<Class> stagedClasses; // To hold classes associated with the student

        // Variables to store original form size and control bounds
        private Size originalFormSize;

        private Rectangle originalTxtFirstNameBounds;
        private Rectangle originalTxtLastNameBounds;
        private Rectangle originalTxtDateOfBirthBounds;
        private Rectangle originalTxtStreetAddressBounds;
        private Rectangle originalTxtCityBounds;
        private Rectangle originalCmbStateBounds;
        private Rectangle originalTxtZipCodeBounds;
        private Rectangle originalTxtPhoneNumberBounds;
        private Rectangle originalTxtFamilyEmailBounds;
        private Rectangle originalChkActiveBounds;
        private Rectangle originalBtnSaveBounds;
        private Rectangle originalDgvParentsBounds;
        private Rectangle originalBtnAddParentBounds;
        private Rectangle originalBtnRemoveParentBounds;
        private Rectangle originalDgvClassesBounds;
        private Rectangle originalBtnAddClassBounds;
        private Rectangle originalBtnRemoveClassBounds;

        public UpdateStudentForm(Form parent, Student student)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.student = student;
            stagedParents = new List<Parent>();
            stagedClasses = new List<Class>(); // Initialize staged classes

            InitializeStateMaterialComboBox();
            LoadStudentDetails();
            LoadParents();
            LoadStudentClasses(student.StudentID); // Load classes associated with the student
            InitializePlaceholders();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form

            // Add the resize event handler
            this.Load += UpdateStudentForm_Load;
            this.Resize += UpdateStudentForm_Resize;
        }

        private void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalTxtFirstNameBounds = txtFirstName.Bounds;
            originalTxtLastNameBounds = txtLastName.Bounds;
            originalTxtDateOfBirthBounds = txtDateOfBirth.Bounds;
            originalTxtStreetAddressBounds = txtStreetAddress.Bounds;
            originalTxtCityBounds = txtCity.Bounds;
            originalCmbStateBounds = cmbState.Bounds;
            originalTxtZipCodeBounds = txtZipCode.Bounds;
            originalTxtPhoneNumberBounds = txtPhoneNumber.Bounds;
            originalTxtFamilyEmailBounds = txtFamilyEmail.Bounds;
            originalChkActiveBounds = chkActive.Bounds;
            originalBtnSaveBounds = btnSave.Bounds;
            originalDgvParentsBounds = dgvParents.Bounds;
            originalBtnAddParentBounds = btnAddParent.Bounds;
            originalBtnRemoveParentBounds = btnRemoveParent.Bounds;
            originalDgvClassesBounds = dgvClasses.Bounds;
            originalBtnAddClassBounds = btnAddClass.Bounds;
            originalBtnRemoveClassBounds = btnRemoveClass.Bounds;
        }

        private void UpdateStudentForm_Resize(object sender, EventArgs e)
        {
            // Call the ResizeControl method for each control
            ResizeControl(txtFirstName, originalTxtFirstNameBounds);
            ResizeControl(txtLastName, originalTxtLastNameBounds);
            ResizeControl(txtDateOfBirth, originalTxtDateOfBirthBounds);
            ResizeControl(txtStreetAddress, originalTxtStreetAddressBounds);
            ResizeControl(txtCity, originalTxtCityBounds);
            ResizeControl(cmbState, originalCmbStateBounds);
            ResizeControl(txtZipCode, originalTxtZipCodeBounds);
            ResizeControl(txtPhoneNumber, originalTxtPhoneNumberBounds);
            ResizeControl(txtFamilyEmail, originalTxtFamilyEmailBounds);
            ResizeControl(chkActive, originalChkActiveBounds);
            ResizeControl(btnSave, originalBtnSaveBounds);
            ResizeControl(dgvParents, originalDgvParentsBounds);
            ResizeControl(btnAddParent, originalBtnAddParentBounds);
            ResizeControl(btnRemoveParent, originalBtnRemoveParentBounds);
            ResizeControl(dgvClasses, originalDgvClassesBounds);
            ResizeControl(btnAddClass, originalBtnAddClassBounds);
            ResizeControl(btnRemoveClass, originalBtnRemoveClassBounds);
        }

        private void ResizeControl(Control control, Rectangle originalBounds)
        {
            // Calculate the ratio based on the new form size and original size
            float xRatio = (float)this.Width / originalFormSize.Width;
            float yRatio = (float)this.Height / originalFormSize.Height;

            // Calculate the new bounds for the control
            int newX = (int)(originalBounds.X * xRatio);
            int newY = (int)(originalBounds.Y * yRatio);
            int newWidth = (int)(originalBounds.Width * xRatio);
            int newHeight = (int)(originalBounds.Height * yRatio);

            // Apply the new bounds to the control
            control.Bounds = new Rectangle(newX, newY, newWidth, newHeight);
        }

        private void InitializePlaceholders()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
                SetPlaceholder(txtFirstName, "First Name");

            if (string.IsNullOrEmpty(txtLastName.Text))
                SetPlaceholder(txtLastName, "Last Name");

            if (string.IsNullOrEmpty(txtDateOfBirth.Text))
                SetPlaceholder(txtDateOfBirth, "Date Of Birth");

            if (string.IsNullOrEmpty(txtStreetAddress.Text))
                SetPlaceholder(txtStreetAddress, "Street Address");

            if (string.IsNullOrEmpty(txtCity.Text))
                SetPlaceholder(txtCity, "City");

            if (string.IsNullOrEmpty(txtZipCode.Text))
                SetPlaceholder(txtZipCode, "Zip Code");

            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
                SetPlaceholder(txtPhoneNumber, "Phone Number");

            if (string.IsNullOrEmpty(txtFamilyEmail.Text))
                SetPlaceholder(txtFamilyEmail, "Family Email");
        }

        private void SetPlaceholder(MaterialTextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = SystemColors.GrayText;
            textBox.Tag = placeholder; // Store the placeholder in the Tag property
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            var textBox = sender as MaterialTextBox;
            if (textBox != null && textBox.Tag != null && textBox.Text == textBox.Tag.ToString()) // Ensure Tag is not null
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            var textBox = sender as MaterialTextBox;

            if (textBox != null)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    // Placeholder logic
                    textBox.Text = textBox.Tag.ToString();
                    textBox.ForeColor = SystemColors.GrayText;
                }
                else
                {
                    // Validate specific text boxes
                    if (textBox == txtDateOfBirth)
                    {
                        ValidateDateOfBirth(textBox);
                    }
                    else if (textBox == txtZipCode)
                    {
                        ValidateZipCode(textBox);
                    }
                    else if (textBox == txtPhoneNumber)
                    {
                        ValidatePhoneNumber(textBox);
                    }
                    else if (textBox == txtFamilyEmail)
                    {
                        ValidateFamilyEmail(textBox);
                    }
                }
            }
        }

        // Validate Date of Birth (MM/DD/YYYY) and assume 20YY if only YY is given
        private void ValidateDateOfBirth(MaterialTextBox textBox)
        {
            string input = Regex.Replace(textBox.Text, @"\D", ""); // Remove all non-numeric characters

            if (input.Length == 8) // Assume MMDDYYYY format
            {
                string month = input.Substring(0, 2);
                string day = input.Substring(2, 2);
                string year = input.Substring(4, 4);

                textBox.Text = $"{month}/{day}/{year}";
            }
            else if (input.Length == 6) // Assume MMDDYY format, convert to 20YY
            {
                string month = input.Substring(0, 2);
                string day = input.Substring(2, 2);
                string year = $"20{input.Substring(4, 2)}"; // Assume 20YY for YY

                textBox.Text = $"{month}/{day}/{year}";
            }
            else
            {
                MessageBox.Show("Invalid Date of Birth. Please enter in MM/DD/YYYY format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
            }

            // Check if it's a valid date after formatting
            if (!DateTime.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Invalid date. Please enter a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
            }
        }

        // Validate Zip Code (5 digits)
        private void ValidateZipCode(MaterialTextBox textBox)
        {
            string input = textBox.Text;
            if (!Regex.IsMatch(input, @"^\d{5}$"))
            {
                MessageBox.Show("Invalid Zip Code. Please enter a 5-digit zip code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
            }
        }

        // Validate Phone Number (format: (XXX)XXX-XXXX)
        private void ValidatePhoneNumber(MaterialTextBox textBox)
        {
            string input = Regex.Replace(textBox.Text, @"\D", ""); // Remove all non-numeric characters

            if (input.Length == 10)
            {
                textBox.Text = $"({input.Substring(0, 3)}){input.Substring(3, 3)}-{input.Substring(6, 4)}";
            }
            else
            {
                MessageBox.Show("Invalid Phone Number. Please enter a 10-digit phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
            }
        }

        // Validate Family Email (must contain "@" and "." after it)
        private void ValidateFamilyEmail(MaterialTextBox textBox)
        {
            string input = textBox.Text;
            if (!Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid Email. Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
            }
        }

        private void InitializeStateMaterialComboBox()
        {
            cmbState.Items.Clear();
            cmbState.Hint = "State";
            cmbState.Items.AddRange(new object[]
            {
                "KS", "MO"
            });

            cmbState.SelectedIndex = -1; // No state selected by default
        }

        private void LoadStudentDetails()
        {
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtDateOfBirth.Text = student.DateOfBirth;
            txtStreetAddress.Text = student.StreetAddress;
            txtCity.Text = student.City;
            cmbState.SelectedItem = student.State;
            txtZipCode.Text = student.ZipCode;
            txtPhoneNumber.Text = student.PhoneNumber;
            txtFamilyEmail.Text = student.FamilyEmail;
            chkActive.Checked = student.Active;
        }

        private void LoadParents()
        {
            var parents = dbHelper.GetParentsByStudentId(student.StudentID);
            stagedParents.AddRange(parents); // Load existing parents into stagedParents
            RefreshParentGrid();
        }

        private void LoadStudentClasses(int studentId)
        {
            // Get only the classes assigned to the specific student
            var classes = dbHelper.GetClassesByStudentId(studentId);

            // Clear any previously staged classes before adding the new ones
            stagedClasses.Clear();

            // Load the student's classes into stagedClasses
            stagedClasses.AddRange(classes);

            // Refresh the class grid to show the student's assigned classes
            RefreshClassGrid();
        }


        private bool ValidateStudentInputs()
        {
            bool isValid = true;
            string errorMessage = "";

            if (string.IsNullOrEmpty(txtFirstName.Text) || txtFirstName.Text == "First Name")
            {
                isValid = false;
                errorMessage += "First Name is required.\n";
            }

            if (string.IsNullOrEmpty(txtLastName.Text) || txtLastName.Text == "Last Name")
            {
                isValid = false;
                errorMessage += "Last Name is required.\n";
            }

            if (string.IsNullOrEmpty(txtDateOfBirth.Text) || txtDateOfBirth.Text == "Date Of Birth")
            {
                isValid = false;
                errorMessage += "Date Of Birth is required.\n";
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private void RefreshParentGrid()
        {
            dgvParents.DataSource = null;
            dgvParents.DataSource = stagedParents;
            dgvParents.Columns["ParentID"].Visible = false;
            dgvParents.Columns["StudentID"].Visible = false;
        }

        private void RefreshClassGrid()
        {
            dgvClasses.DataSource = null;
            dgvClasses.DataSource = stagedClasses;
            dgvClasses.Columns["ClassID"].Visible = false;
            dgvClasses.Columns["SessionID"].Visible = false; // Hide session ID, ensure SessionName is displayed

            // Hide StudentClassID column
            if (dgvClasses.Columns.Contains("StudentClassID"))
            {
                dgvClasses.Columns["StudentClassID"].Visible = false;
            }
        }


        private void btnAddParent_Click(object sender, EventArgs e)
        {
            string studentPhoneNumber = txtPhoneNumber.Text;
            string studentEmail = txtFamilyEmail.Text;

            using (var addParentForm = new AddParentForm(this, studentPhoneNumber, studentEmail))
            {
                if (addParentForm.ShowDialog() == DialogResult.OK)
                {
                    stagedParents.Add(addParentForm.ParentData);
                    RefreshParentGrid();
                }
            }
        }

        private void btnRemoveParent_Click(object sender, EventArgs e)
        {
            if (dgvParents.SelectedRows.Count > 0)
            {
                var index = dgvParents.SelectedRows[0].Index;
                stagedParents.RemoveAt(index);
                RefreshParentGrid(); // Refresh the grid after removing the row
            }
            else
            {
                MessageBox.Show("Please select a parent to remove.");
            }
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            using (var addClassForm = new AddClassForm(this))
            {
                if (addClassForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedClasses = addClassForm.SelectedClasses;
                    foreach (var classItem in selectedClasses)
                    {
                        if (!stagedClasses.Any(c => c.ClassID == classItem.ClassID))
                        {
                            stagedClasses.Add(classItem);
                        }
                    }
                    RefreshClassGrid();
                }
            }
        }

        private void btnRemoveClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.SelectedRows.Count > 0)
            {
                var index = dgvClasses.SelectedRows[0].Index;
                stagedClasses.RemoveAt(index);
                RefreshClassGrid();
            }
            else
            {
                MessageBox.Show("Please select a class to remove.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate student inputs
            if (ValidateStudentInputs())
            {
                // Update student details
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.DateOfBirth = txtDateOfBirth.Text;
                student.StreetAddress = txtStreetAddress.Text;
                student.City = txtCity.Text;
                student.State = cmbState.SelectedItem.ToString();
                student.ZipCode = txtZipCode.Text;
                student.PhoneNumber = txtPhoneNumber.Text;
                student.FamilyEmail = txtFamilyEmail.Text;
                student.Active = chkActive.Checked;

                dbHelper.UpdateStudent(student);

                // Update parents
                var existingParents = dbHelper.GetParentsByStudentId(student.StudentID);
                foreach (var existingParent in existingParents)
                {
                    if (!stagedParents.Any(p => p.ParentID == existingParent.ParentID))
                    {
                        dbHelper.DeleteParent(existingParent.ParentID);
                    }
                }

                foreach (var parent in stagedParents)
                {
                    if (parent.ParentID == 0)
                    {
                        parent.StudentID = student.StudentID;
                        dbHelper.AddParent(parent);
                    }
                    else
                    {
                        dbHelper.UpdateParent(parent);
                    }
                }

                // Update classes
                var existingClasses = dbHelper.GetClassesByStudentId(student.StudentID);

                // Identify classes to be removed
                var classesToRemove = existingClasses.Where(c => !stagedClasses.Any(sc => sc.StudentClassID == c.StudentClassID)).ToList();
                foreach (var classToRemove in classesToRemove)
                {
                    dbHelper.RemoveStudentClass(student.StudentID, classToRemove.ClassID);
                }

                // Identify classes to be added
                var classesToAdd = stagedClasses.Where(sc => !existingClasses.Any(c => c.StudentClassID == sc.StudentClassID)).ToList();
                foreach (var classToAdd in classesToAdd)
                {
                    dbHelper.AddStudentClass(student.StudentID, classToAdd.ClassID);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logic to handle the state change, such as validation or updating the UI
            if (cmbState.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid state.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Handle the state selection change, if needed
                // For example, you can fetch data or enable/disable other fields based on state
                string selectedState = cmbState.SelectedItem.ToString();
                Console.WriteLine($"Selected state: {selectedState}");
            }
        }

        private void dgvParents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the user clicked on a valid row and not the header
            if (e.RowIndex >= 0)
            {
                dgvParents.Rows[e.RowIndex].Selected = true; // Select the clicked row
            }
        }
    }
}