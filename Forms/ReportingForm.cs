using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class ReportingForm : BaseForm
    {
        private DatabaseHelper dbHelper;
        private Size originalFormSize;
        private Rectangle originalBtnAllUnknownsBounds;
        private Rectangle originalBtnClassSheets;

        public ReportingForm(Form parent)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            // Set form's position
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Hook up form load and resize events
            this.Load += ReportingForm_Load;
            this.Resize += ReportingForm_Resize;
        }

        private void ReportingForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalBtnAllUnknownsBounds = btnAllUnknowns.Bounds;
            originalBtnClassSheets = btnClassSheets.Bounds;
        }

        private void ReportingForm_Resize(object sender, EventArgs e)
        {
            // Resize controls when form resizes
            ResizeControl(btnAllUnknowns, originalBtnAllUnknownsBounds);
            ResizeControl(btnClassSheets, originalBtnClassSheets);
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

        private void btnAllUnknowns_Click(object sender, EventArgs e)
        {
            // Open the UnknownsForm when the button is clicked
            var unknownsForm = new UnknownsForm(this);
            unknownsForm.Show();
        }
        private void btnClassSheets_Click(object sender, EventArgs e)
        {
            // Open the ClassSheetForm
            var classSheetForm = new ClassSheetForm(this);
            classSheetForm.ShowDialog();
        }
    }
}
