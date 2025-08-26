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

        // NEW: bounds for the new date controls
        private Rectangle originalLblStartDateBounds;
        private Rectangle originalLblEndDateBounds;
        private Rectangle originalDtpStartDateBounds;
        private Rectangle originalDtpEndDateBounds;

        public AddSessionForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            // Start near parent
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Sensible defaults
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddMonths(3);

            // Keep end >= start
            dtpStartDate.ValueChanged += (s, e) =>
            {
                if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
                    dtpEndDate.Value = dtpStartDate.Value.Date;
            };

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

            // NEW: capture bounds for date controls
            originalLblStartDateBounds = lblStartDate.Bounds;
            originalLblEndDateBounds = lblEndDate.Bounds;
            originalDtpStartDateBounds = dtpStartDate.Bounds;
            originalDtpEndDateBounds = dtpEndDate.Bounds;
        }

        private void AddSessionForm_Resize(object sender, EventArgs e)
        {
            // Resize the controls when the form is resized
            ResizeControl(txtSessionName, originalTxtSessionNameBounds);
            ResizeControl(btnSave, originalBtnSaveBounds);
            ResizeControl(btnCancel, originalBtnCancelBounds);

            // NEW: resize date controls
            ResizeControl(lblStartDate, originalLblStartDateBounds);
            ResizeControl(lblEndDate, originalLblEndDateBounds);
            ResizeControl(dtpStartDate, originalDtpStartDateBounds);
            ResizeControl(dtpEndDate, originalDtpEndDateBounds);
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
            var sessionName = (txtSessionName.Text ?? string.Empty).Trim();
            var start = dtpStartDate.Value.Date;
            var end = dtpEndDate.Value.Date;

            if (string.IsNullOrWhiteSpace(sessionName))
            {
                MessageBox.Show("Please enter a session name.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSessionName.Focus();
                return;
            }

            if (end < start)
            {
                MessageBox.Show("End date cannot be before start date.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return;
            }

            try
            {
                // Persist to DB (use the overload that accepts dates)
                // Make sure DatabaseHelper has: AddSession(string name, DateTime start, DateTime end)
                dbHelper.AddSession(sessionName, start, end);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save session.\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
