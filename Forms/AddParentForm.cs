using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace MDSoDv2
{
    public partial class AddParentForm : BaseForm
    {
        public Parent ParentData { get; private set; }
        private string studentPhoneNumber;
        private string studentEmail;

        // Variables to store original form size and control bounds for resizing
        private Size originalFormSize;
        private Rectangle originalTxtFirstNameBounds;
        private Rectangle originalTxtLastNameBounds;
        private Rectangle originalTxtPhoneNumberBounds;
        private Rectangle originalTxtEmailBounds;
        private Rectangle originalTxtRelationshipBounds;
        private Rectangle originalBtnSaveBounds;
        private Rectangle originalChkSameAsStudentPhone;
        private Rectangle originalChkSameAsStudentEmail;

        public AddParentForm(Form parent, string studentPhoneNumber, string studentEmail)
        {
            InitializeComponent();
            this.studentPhoneNumber = studentPhoneNumber;
            this.studentEmail = studentEmail;
            InitializePlaceholders();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form

            // Add the resize event handler
            this.Load += AddParentForm_Load;
            this.Resize += AddParentForm_Resize;
        }

        private void AddParentForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalTxtFirstNameBounds = txtFirstName.Bounds;
            originalTxtLastNameBounds = txtLastName.Bounds;
            originalTxtPhoneNumberBounds = txtPhoneNumber.Bounds;
            originalTxtEmailBounds = txtEmail.Bounds;
            originalTxtRelationshipBounds = txtRelationship.Bounds;
            originalBtnSaveBounds = btnSave.Bounds;
            originalChkSameAsStudentPhone = chkSameAsStudentPhone.Bounds;
            originalChkSameAsStudentEmail = chkSameAsStudentEmail.Bounds;
        }

        private void AddParentForm_Resize(object sender, EventArgs e)
        {
            // Call the ResizeControl method for each control
            ResizeControl(txtFirstName, originalTxtFirstNameBounds);
            ResizeControl(txtLastName, originalTxtLastNameBounds);
            ResizeControl(txtPhoneNumber, originalTxtPhoneNumberBounds);
            ResizeControl(txtEmail, originalTxtEmailBounds);
            ResizeControl(txtRelationship, originalTxtRelationshipBounds);
            ResizeControl(btnSave, originalBtnSaveBounds);
            ResizeControl(chkSameAsStudentPhone, originalChkSameAsStudentPhone);
            ResizeControl(chkSameAsStudentEmail, originalChkSameAsStudentEmail);
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
            SetPlaceholder(txtFirstName, "First Name");
            SetPlaceholder(txtLastName, "Last Name");
            SetPlaceholder(txtPhoneNumber, "Phone Number");
            SetPlaceholder(txtEmail, "Email");
            SetPlaceholder(txtRelationship, "Relationship");
        }

        private void SetPlaceholder(MaterialTextBox textBox, string placeholder)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void RemovePlaceholder(MaterialTextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            var textBox = sender as MaterialTextBox;
            RemovePlaceholder(textBox, textBox.Tag.ToString());
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            var textBox = sender as MaterialTextBox;
            SetPlaceholder(textBox, textBox.Tag.ToString());
        }

        private void chkSameAsStudentPhone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSameAsStudentPhone.Checked)
            {
                txtPhoneNumber.Text = studentPhoneNumber;
                txtPhoneNumber.Enabled = false; // Disable the field to prevent manual edits
            }
            else
            {
                txtPhoneNumber.Text = "";
                txtPhoneNumber.Enabled = true; // Re-enable for manual input
            }
        }

        private void chkSameAsStudentEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSameAsStudentEmail.Checked)
            {
                txtEmail.Text = studentEmail;
                txtEmail.Enabled = false; // Disable the field to prevent manual edits
            }
            else
            {
                txtEmail.Text = "";
                txtEmail.Enabled = true; // Re-enable for manual input
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                ParentData = new Parent
                {
                    FirstName = txtFirstName.Text == "First Name" ? "" : txtFirstName.Text,
                    LastName = txtLastName.Text == "Last Name" ? "" : txtLastName.Text,
                    PhoneNumber = txtPhoneNumber.Text == "Phone Number" ? "" : txtPhoneNumber.Text,
                    Email = txtEmail.Text == "Email" ? "" : txtEmail.Text,
                    Relationship = txtRelationship.Text == "Relationship" ? "" : txtRelationship.Text
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            string errorMessage = "";

            // Skip phone number validation if 'Same as Student' is checked
            if (!chkSameAsStudentPhone.Checked)
            {
                // Validate phone number format
                if (!string.IsNullOrEmpty(txtPhoneNumber.Text) && txtPhoneNumber.Text != "Phone Number")
                {
                    if (!Regex.IsMatch(txtPhoneNumber.Text, @"^\(\d{3}\) \d{3}-\d{4}$"))
                    {
                        isValid = false;
                        errorMessage += "Phone number must be in the format (###) ###-####.\n";
                    }
                }
            }

            // Skip email validation if 'Same as Student' is checked
            if (!chkSameAsStudentEmail.Checked)
            {
                // Validate email format
                if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text != "Email")
                {
                    if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    {
                        isValid = false;
                        errorMessage += "Invalid email format.\n";
                    }
                }
            }

            // Validate relationship field
            if (string.IsNullOrEmpty(txtRelationship.Text) || txtRelationship.Text == "Relationship")
            {
                isValid = false;
                errorMessage += "Relationship field is required.\n";
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        private void txtPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text.Length == 10 && !txtPhoneNumber.Text.Contains("("))
            {
                txtPhoneNumber.Text = $"({txtPhoneNumber.Text.Substring(0, 3)}) {txtPhoneNumber.Text.Substring(3, 3)}-{txtPhoneNumber.Text.Substring(6, 4)}";
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text != "Email")
            {
                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Invalid email format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
