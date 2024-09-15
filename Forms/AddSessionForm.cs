using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class AddSessionForm : BaseForm
    {
        private DatabaseHelper dbHelper;

        // Variables for resizing
        private Size originalFormSize;

        private Rectangle originalTxtSessionNameBounds;
        private Rectangle originalBtnSaveBounds;
        private Rectangle originalBtnCancelBounds;

        public AddSessionForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form

            // Hook up form load and resize events
            this.Load += AddSessionForm_Load;
            this.Resize += AddSessionForm_Resize;
        }

        private void AddSessionForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds
            originalFormSize = this.Size;
            originalTxtSessionNameBounds = txtSessionName.Bounds;
            originalBtnSaveBounds = btnSave.Bounds;
            originalBtnCancelBounds = btnCancel.Bounds;
        }

        private void AddSessionForm_Resize(object sender, EventArgs e)
        {
            // Resize the controls when the form is resized
            ResizeControl(txtSessionName, originalTxtSessionNameBounds);
            ResizeControl(btnSave, originalBtnSaveBounds);
            ResizeControl(btnCancel, originalBtnCancelBounds);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sessionName = txtSessionName.Text;

            if (!string.IsNullOrEmpty(sessionName))
            {
                dbHelper.AddSession(new Session { SessionName = sessionName });
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a session name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}