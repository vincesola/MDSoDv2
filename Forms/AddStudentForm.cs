using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class AddStudentForm : BaseForm
    {
        private List<Parent> stagedParents = new List<Parent>();
        private List<Class> stagedClasses = new List<Class>(); // List to hold selected classes
        private DatabaseHelper dbHelper;
        public Student NewStudent { get; private set; }

        // Variables to store original size and positions
        private Size originalFormSize;

        private Rectangle originalTxtFirstNameBounds;
        private Rectangle originalTxtLastNameBounds;
        private Rectangle originalTxtDateOfBirthBounds;
        private Rectangle originalTxtStreetAddressBounds;
        private Rectangle originalTxtCityBounds;
        private Rectangle originalTxtZipCodeBounds;
        private Rectangle originalTxtPhoneNumberBounds;
        private Rectangle originalTxtFamilyEmailBounds;
        private Rectangle originalChkActiveBounds;
        private Rectangle originalBtnSaveBounds;
        private Rectangle originalBtnAddParentBounds;
        private Rectangle originalBtnRemoveParentBounds;
        private Rectangle originalBtnAddClassBounds;
        private Rectangle originalBtnRemoveClassBounds;
        private Rectangle originalDgvParentsBounds;
        private Rectangle originalDgvClassesBounds;
        private Rectangle originalCmbStateBounds;

        public AddStudentForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            stagedParents = new List<Parent>();
            stagedClasses = new List<Class>();

            InitializePlaceholders();
            InitializeParentDataGridView();
            InitializeClassDataGridView();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Store original control sizes and positions
            this.Load += AddStudentForm_Load;
            this.Resize += AddStudentForm_Resize;
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            // Store original size and position of controls
            originalFormSize = this.Size;
            originalTxtFirstNameBounds = txtFirstName.Bounds;
            originalTxtLastNameBounds = txtLastName.Bounds;
            originalTxtDateOfBirthBounds = txtDateOfBirth.Bounds;
            originalTxtStreetAddressBounds = txtStreetAddress.Bounds;
            originalTxtCityBounds = txtCity.Bounds;
            originalTxtZipCodeBounds = txtZipCode.Bounds;
            originalTxtPhoneNumberBounds = txtPhoneNumber.Bounds;
            originalTxtFamilyEmailBounds = txtFamilyEmail.Bounds;
            originalChkActiveBounds = chkActive.Bounds;
            originalBtnSaveBounds = btnSave.Bounds;
            originalBtnAddParentBounds = btnAddParent.Bounds;
            originalBtnRemoveParentBounds = btnRemoveParent.Bounds;
            originalBtnAddClassBounds = btnAddClass.Bounds;
            originalBtnRemoveClassBounds = btnRemoveClass.Bounds;
            originalDgvParentsBounds = dgvParents.Bounds;
            originalDgvClassesBounds = dgvClasses.Bounds;
            originalCmbStateBounds = cmbState.Bounds;
        }

        private void AddStudentForm_Resize(object sender, EventArgs e)
        {
            // Call the method to resize controls when the form is resized
            ResizeControl(txtFirstName, originalTxtFirstNameBounds);
            ResizeControl(txtLastName, originalTxtLastNameBounds);
            ResizeControl(txtDateOfBirth, originalTxtDateOfBirthBounds);
            ResizeControl(txtStreetAddress, originalTxtStreetAddressBounds);
            ResizeControl(txtCity, originalTxtCityBounds);
            ResizeControl(txtZipCode, originalTxtZipCodeBounds);
            ResizeControl(txtPhoneNumber, originalTxtPhoneNumberBounds);
            ResizeControl(txtFamilyEmail, originalTxtFamilyEmailBounds);
            ResizeControl(chkActive, originalChkActiveBounds);
            ResizeControl(btnSave, originalBtnSaveBounds);
            ResizeControl(btnAddParent, originalBtnAddParentBounds);
            ResizeControl(btnRemoveParent, originalBtnRemoveParentBounds);
            ResizeControl(btnAddClass, originalBtnAddClassBounds);
            ResizeControl(btnRemoveClass, originalBtnRemoveClassBounds);
            ResizeControl(dgvParents, originalDgvParentsBounds);
            ResizeControl(dgvClasses, originalDgvClassesBounds);
            ResizeControl(cmbState, originalCmbStateBounds);
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

        private void InitializePlaceholders()
        {
            SetPlaceholder(txtFirstName, "First Name");
            SetPlaceholder(txtLastName, "Last Name");
            SetPlaceholder(txtDateOfBirth, "Date Of Birth");
            SetPlaceholder(txtStreetAddress, "Street Address");
            SetPlaceholder(txtCity, "City");
            SetPlaceholder(txtZipCode, "Zip Code");
            SetPlaceholder(txtPhoneNumber, "Phone Number");
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
            if (textBox != null && textBox.Text == textBox.Tag.ToString())
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

        // Validate Phone Number (format: (XXX) XXX-XXXX)
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

        private void InitializeParentDataGridView()
        {
            dgvParents.DataSource = null; // Reset the data source
            dgvParents.Columns.Clear();
            dgvParents.AutoGenerateColumns = false;
            dgvParents.ReadOnly = true;

            dgvParents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name"
            });

            dgvParents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name"
            });

            dgvParents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Phone Number"
            });

            dgvParents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email"
            });

            dgvParents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Relationship",
                HeaderText = "Relationship"
            });

            RefreshParentGrid();
        }

        private void RefreshParentGrid()
        {
            dgvParents.DataSource = null;
            dgvParents.DataSource = stagedParents;
        }

        private void InitializeClassDataGridView()
        {
            dgvClasses.DataSource = null; // Reset the data source
            dgvClasses.Columns.Clear();
            dgvClasses.AutoGenerateColumns = false;

            dgvClasses.ReadOnly = true; // Ensure DataGridView is read-only

            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClassName", // Column for class name
                HeaderText = "Class Name"
            });

            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClassLocation", // Column for class location
                HeaderText = "Class Location"
            });

            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionName", // Ensure that this matches the property name in your class
                HeaderText = "Session Name"
            });

            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DayOfWeek", // Column for day of the week
                HeaderText = "Day Of Week"
            });

            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Time", // Column for class time
                HeaderText = "Time"
            });

            dgvClasses.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Teachers", // Column for teachers
                HeaderText = "Teachers"
            });

            RefreshClassGrid();
        }

        private void RefreshClassGrid()
        {
            dgvClasses.DataSource = null;
            dgvClasses.DataSource = stagedClasses;
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
                RefreshParentGrid();
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
            try
            {
                // Validate student inputs
                if (ValidateStudentInputs())
                {
                    NewStudent = new Student
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        DateOfBirth = txtDateOfBirth.Text,
                        StreetAddress = txtStreetAddress.Text,
                        City = txtCity.Text,
                        State = cmbState.Text, // This references the cmbState defined in Designer.cs
                        ZipCode = txtZipCode.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        FamilyEmail = txtFamilyEmail.Text,
                        Active = true
                    };

                    // Add the new student to the database and get the generated StudentID
                    int studentID = dbHelper.AddStudent(NewStudent);

                    // Add staged parents to the database
                    foreach (var parent in stagedParents)
                    {
                        parent.StudentID = studentID; // Assign the generated StudentID
                        dbHelper.AddParent(parent);
                    }

                    // Associate staged classes with the student
                    foreach (var classItem in stagedClasses)
                    {
                        dbHelper.AddStudentClass(studentID, classItem.ClassID); // Assuming this method exists
                    }

                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex) when (ex.Message.Contains("Student with the same First Name, Last Name, and Date of Birth already exists"))
            {
                // Display a user-friendly message
                MessageBox.Show("A student with the same First Name, Last Name, and Date of Birth already exists.",
                                "Duplicate Student",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Log or handle other potential exceptions if needed
                MessageBox.Show($"An error occurred while saving the student: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnSaveAndAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate student inputs
                if (ValidateStudentInputs())
                {
                    NewStudent = new Student
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        DateOfBirth = txtDateOfBirth.Text,
                        StreetAddress = txtStreetAddress.Text,
                        City = txtCity.Text,
                        State = cmbState.Text, // This references the cmbState defined in Designer.cs
                        ZipCode = txtZipCode.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        FamilyEmail = txtFamilyEmail.Text,
                        Active = true
                    };

                    // Add the new student to the database and get the generated StudentID
                    int studentID = dbHelper.AddStudent(NewStudent);

                    // Add staged parents to the database
                    foreach (var parent in stagedParents)
                    {
                        parent.StudentID = studentID; // Assign the generated StudentID
                        dbHelper.AddParent(parent);
                    }

                    // Associate staged classes with the student
                    foreach (var classItem in stagedClasses)
                    {
                        dbHelper.AddStudentClass(studentID, classItem.ClassID); // Assuming this method exists
                    }

                    MessageBox.Show("Student added successfully! You can now add another student.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearForm(); // Clear the form to allow adding a new student
                }
            }
            catch (Exception ex) when (ex.Message.Contains("Student with the same First Name, Last Name, and Date of Birth already exists"))
            {
                // Display a user-friendly message
                MessageBox.Show("A student with the same First Name, Last Name, and Date of Birth already exists.",
                                "Duplicate Student",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Log or handle other potential exceptions if needed
                MessageBox.Show($"An error occurred while saving the student: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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

        private void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDateOfBirth.Text = "";
            txtStreetAddress.Text = "";
            txtCity.Text = "";
            txtZipCode.Text = "";
            txtPhoneNumber.Text = "";
            txtFamilyEmail.Text = "";
            chkActive.Checked = false;
            cmbState.SelectedIndex = 0; // Reset the dropdown to the first state option

            // Clear grids for Parents and Classes
            stagedParents.Clear();
            stagedClasses.Clear();
            RefreshParentGrid();
            RefreshClassGrid();
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
    }
}