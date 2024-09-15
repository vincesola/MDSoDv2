using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class MainForm : BaseForm
    {
        private Size originalFormSize;
        private Rectangle originalBtnStudentsBounds;
        private Rectangle originalBtnBackOfficeBounds;
        private Rectangle originalPictureBoxLogoBounds;

        public MainForm()
        {
            InitializeComponent();

            // Store the original sizes and positions
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            originalBtnStudentsBounds = btnStudents.Bounds;
            originalBtnBackOfficeBounds = btnBackOffice.Bounds;
            originalPictureBoxLogoBounds = pictureBoxLogo.Bounds;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ResizeControl(btnStudents, originalBtnStudentsBounds);
            ResizeControl(btnBackOffice, originalBtnBackOfficeBounds);
            ResizeControl(pictureBoxLogo, originalPictureBoxLogoBounds);
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

        private void btnStudents_Click(object sender, EventArgs e)
        {
            var studentForm = new StudentForm(this);
            studentForm.Show();
        }

        private void btnBackOffice_Click(object sender, EventArgs e)
        {
            using (var passwordForm = new PasswordForm())
            {
                var result = passwordForm.ShowDialog(this); // Pass 'this' as the owner to keep it centered

                if (result == DialogResult.OK && passwordForm.IsAuthenticated)
                {
                    var backOfficeForm = new BackOfficeForm(this);
                    backOfficeForm.Show();
                }
                else
                {
                    MessageBox.Show("Access Denied: Incorrect Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}