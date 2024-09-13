using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class PasswordForm : BaseForm
    {
        private readonly DatabaseHelper dbHelper;
        private const string encryptionKey = "ailzPsEZ55da7oBXJGvu8SpS7Klt/yg5vPAKnBtqIDM7NOxlDnIHFqc97kOnCNcE"; // Replace with a secure key

        // Property to indicate if the password is correct
        public bool IsAuthenticated { get; private set; } = false;

        public PasswordForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Initialize the database helper
        }

        // Handler for the Submit button click
        private void btnOk_Click(object sender, EventArgs e)
        {
            SubmitPassword();
        }

        // New method to handle password validation
        //private void SubmitPassword()
        //{
        //    // Retrieve the encrypted password from the database
        //    string encryptedStoredPassword = dbHelper.GetConfigurationValue("BackOfficePassword");

        //    if (encryptedStoredPassword != null)
        //    {
        //        // Encrypt the entered password using the same key
        //        string enteredPassword = txtPassword.Text;
        //        string encryptedEnteredPassword = DatabaseHelper.EncryptString(enteredPassword, encryptionKey);

        //        // Compare encrypted values
        //        if (encryptedStoredPassword == encryptedEnteredPassword)
        //        {
        //            IsAuthenticated = true;
        //            this.DialogResult = DialogResult.OK; // Close the form with OK result
        //        }
        //        else
        //        {
        //            MessageBox.Show("Incorrect Password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtPassword.Clear();
        //            txtPassword.Focus();
        //        }
        //    }
        //    else
        //    {
        //        // No password exists, prompt the user to set a new one
        //        DialogResult result = MessageBox.Show("No password is set for BackOffice. Would you like to set a new password now?",
        //                                              "Set Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (result == DialogResult.Yes)
        //        {
        //            string newPassword = PromptForNewPassword();

        //            if (!string.IsNullOrEmpty(newPassword))
        //            {
        //                // Encrypt the new password
        //                string encryptedNewPassword = DatabaseHelper.EncryptString(newPassword, encryptionKey);

        //                // Store the new encrypted password in the configuration table
        //                dbHelper.SetConfigurationValue("BackOfficePassword", encryptedNewPassword);

        //                MessageBox.Show("Password has been set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                IsAuthenticated = true;
        //                this.DialogResult = DialogResult.OK; // Close the form with OK result
        //            }
        //        }
        //        else
        //        {
        //            this.DialogResult = DialogResult.Cancel;
        //        }
        //    }
        //}

        private void SubmitPassword()
        {
            string enteredPassword = txtPassword.Text;
            string storedEncryptedPassword = dbHelper.GetConfigurationValue("BackOfficePassword");

            // Check if the "BackOfficePassword" exists in the configuration table
            if (string.IsNullOrEmpty(storedEncryptedPassword))
            {
                // No password exists, so prompt the user to set a new password
                MessageBox.Show("No password is set for Back Office. Please enter a new password.", "Set Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Encrypt the entered password and store it in the database
                string encryptedNewPassword = DatabaseHelper.EncryptString(enteredPassword, encryptionKey);
                dbHelper.SetConfigurationValue("BackOfficePassword", encryptedNewPassword);

                MessageBox.Show("New password has been set successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsAuthenticated = true;
                this.DialogResult = DialogResult.OK;
                return;
            }

            // Encrypt the entered password to compare with the stored encrypted password
            string encryptedEnteredPassword = DatabaseHelper.EncryptString(enteredPassword, encryptionKey);

            // Compare the encrypted versions
            if (encryptedEnteredPassword == storedEncryptedPassword)
            {
                IsAuthenticated = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Show the stored and entered encrypted passwords for debugging
                MessageBox.Show($"Stored Encrypted Password: {storedEncryptedPassword}\n" +
                                $"Entered Encrypted Password: {encryptedEnteredPassword}",
                                "Debug: Encrypted Password Comparison",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }




        // Helper method to prompt the user for a new password
        private string PromptForNewPassword()
        {
            string newPassword = null;
            using (var form = new Form())
            {
                form.Text = "Set New Password";
                var passwordTextBox = new MaterialTextBox2
                {
                    UseSystemPasswordChar = true, // Set this property to mask the password input
                    Width = 250,
                    Hint = "Enter New Password",
                    Dock = DockStyle.Fill
                };

                var btnOk = new MaterialButton
                {
                    Text = "OK",
                    Dock = DockStyle.Bottom,
                    DialogResult = DialogResult.OK
                };

                form.Controls.Add(passwordTextBox);
                form.Controls.Add(btnOk);
                form.AcceptButton = btnOk;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    newPassword = passwordTextBox.Text;
                }
            }

            return newPassword;
        }

        // Handler for the Enter key press in the password field
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // When Enter is pressed, submit the password
                SubmitPassword();
            }
        }

        // Handler for the Cancel button click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
