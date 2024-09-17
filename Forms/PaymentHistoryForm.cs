using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class PaymentHistoryForm : BaseForm
    {
        private int studentId;
        private DatabaseHelper dbHelper;

        // Variables to store original size and positions
        private Size originalFormSize;
        private Rectangle originalFlowPanelBounds;

        public PaymentHistoryForm(Form parent, int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            dbHelper = new DatabaseHelper();

            // Fetch the student details using the studentId
            Student student = dbHelper.GetStudentById(studentId);
            if (student != null)
            {
                // Set the form's text to include the student's name
                this.Text = $"Payment History - {student.FirstName} {student.LastName}";
            }

            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(50); // Add padding to simulate border

            // Set the starting position near the parent form
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Store original control sizes and positions
            this.Load += PaymentHistoryForm_Load;
            this.Resize += PaymentHistoryForm_Resize;

            LoadPaymentHistory();
        }


        private void PaymentHistoryForm_Load(object sender, EventArgs e)
        {
            // Store original size and position of controls
            originalFormSize = this.Size;
            originalFlowPanelBounds = flowPanel.Bounds;
        }

        private void PaymentHistoryForm_Resize(object sender, EventArgs e)
        {
            // Call the method to resize controls when the form is resized
            ResizeControl(flowPanel, originalFlowPanelBounds);
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

        private void LoadPaymentHistory()
        {
            var classes = dbHelper.GetClassesByStudentId(studentId);
            foreach (var classObj in classes)
            {
                // Create a panel for each class
                var classPanel = new Panel
                {
                    AutoSize = true,
                    Width = flowPanel.Width - 20,
                    BorderStyle = BorderStyle.None,
                    Padding = new Padding(5),
                    Margin = new Padding(5)
                };

                // Create a label for session and class name
                var lblClass = new Label
                {
                    Text = $"{classObj.SessionName} - {classObj.ClassName}",
                    AutoSize = true,
                    Font = new Font("Roboto", 12F, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Margin = new Padding(0, 0, 0, 0) // Add bottom margin for separation
                };
                classPanel.Controls.Add(lblClass);

                // Get payments for this student class using StudentClassID
                var payments = dbHelper.GetPaymentsForStudentClass(classObj.StudentClassID); // Correctly use StudentClassID
                var paymentPanel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    Margin = new Padding(0, 0, 0, 0) // Add top margin for separation
                };

                foreach (var payment in payments)
                {
                    // Create a panel for each payment due date and icon
                    var paymentPanelItem = new FlowLayoutPanel
                    {
                        AutoSize = true,
                        FlowDirection = FlowDirection.TopDown, // Stack vertically (label then icon)
                        Margin = new Padding(20)
                    };

                    // Create a label for the payment due date (MM/YYYY) above the icon
                    var lblPaymentDueDate = new Label
                    {
                        Text = payment.PaymentDueDate.ToString("MM/yyyy"),
                        AutoSize = true,
                        Font = new Font("Roboto", 8F),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(0, 0, 0, 0) // Margin for spacing between label and icon
                    };
                    paymentPanelItem.Controls.Add(lblPaymentDueDate);

                    // Add the payment icon
                    var icon = GetPaymentIcon(payment.PaymentReceived, payment.PaymentDueDate);
                    paymentPanelItem.Controls.Add(icon);

                    paymentPanel.Controls.Add(paymentPanelItem);
                }

                classPanel.Controls.Add(paymentPanel);
                flowPanel.Controls.Add(classPanel);
            }
        }



        private Control GetPaymentControl(PaymentRecord paymentRecord)
        {
            // Create a container panel for each payment record
            var paymentPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2, // One row for the labels and one row for the icon
                AutoSize = true,
                Margin = new Padding(5),
                Padding = new Padding(0),
            };

            // Add the labels with PaymentDueDate and PaymentID
            var labelsPanel = new Panel { AutoSize = true };

            // Display PaymentDueDate (MM/YYYY) and PaymentID
            var lblPaymentInfo = new Label
            {
                Text = $"{paymentRecord.PaymentDueDate.ToString("MM/yyyy")} (ID: {paymentRecord.PaymentID})",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            labelsPanel.Controls.Add(lblPaymentInfo);

            // Add the icon below the labels
            var iconPanel = new Panel { AutoSize = true };
            iconPanel.Controls.Add(GetPaymentIcon(paymentRecord.PaymentReceived, paymentRecord.PaymentDueDate));

            // Add both panels to the TableLayoutPanel
            paymentPanel.Controls.Add(labelsPanel, 0, 0);
            paymentPanel.Controls.Add(iconPanel, 0, 1);

            return paymentPanel;
        }

        private Image ScaleImage(Image image, float scale)
        {
            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            Bitmap scaledImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(scaledImage))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));
            }
            return scaledImage;
        }

        private Control GetPaymentIcon(bool paymentReceived, DateTime paymentDueDate)
        {
            PictureBox icon = new PictureBox
            {
                Size = new Size(30, 30), // Adjust this size as needed
                Margin = new Padding(2),
                SizeMode = PictureBoxSizeMode.CenterImage // This centers the image inside the PictureBox
            };

            // Scale the image to 20% of its original size
            float scale = 0.2f;

            if (paymentReceived)
            {
                icon.Image = ScaleImage(Properties.Resources.green_check, scale); // Replace with the actual name
            }
            else if (!paymentReceived && paymentDueDate < DateTime.Now)
            {
                icon.Image = ScaleImage(Properties.Resources.red_cross, scale); // Replace with the actual name
            }
            else
            {
                icon.Image = ScaleImage(Properties.Resources.empty_box, scale); // Replace with the actual name
            }

            return icon;
        }
    }
}
