using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;

namespace MDSoDv2
{
    public partial class BackOfficeForm : BaseForm
    {
        private const int borderWidth = 50;  // Border width for focused and non-focused forms
        private Size originalFormSize;

        // Track the original bounds for controls
        private Rectangle originalBtnSessionBounds;
        private Rectangle originalBtnClassBounds;
        private Rectangle originalBtnTeacherBounds;
        private Rectangle originalBtnParentBounds;
        private Rectangle originalBtnPaymentBounds;
        private Rectangle originalBtnExportBounds;
        private Rectangle originalBtnImportBounds;
        private Rectangle originalTableLayoutPanelBounds;

        public BackOfficeForm(Form parent)
        {
            InitializeComponent();

            // Borderless form with padding
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderWidth);

            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form

            // Capture original size and control bounds
            this.Load += BackOfficeForm_Load;
            this.Resize += BackOfficeForm_Resize;
        }

        private void BackOfficeForm_Load(object sender, EventArgs e)
        {
            // Store original sizes and positions of controls
            originalFormSize = this.Size;
            originalBtnSessionBounds = btnSession.Bounds;
            originalBtnClassBounds = btnClass.Bounds;
            originalBtnTeacherBounds = btnTeacher.Bounds;
            originalBtnParentBounds = btnParent.Bounds;
            originalBtnPaymentBounds = btnPayment.Bounds;
            originalBtnExportBounds = btnExport.Bounds;
            originalBtnImportBounds = btnImport.Bounds;
            originalTableLayoutPanelBounds = tableLayoutPanel.Bounds;
        }

        private void BackOfficeForm_Resize(object sender, EventArgs e)
        {
            // Adjust the size and position of controls when the form is resized
            ResizeControl(btnSession, originalBtnSessionBounds);
            ResizeControl(btnClass, originalBtnClassBounds);
            ResizeControl(btnTeacher, originalBtnTeacherBounds);
            ResizeControl(btnParent, originalBtnParentBounds);
            ResizeControl(btnPayment, originalBtnPaymentBounds);
            ResizeControl(btnExport, originalBtnExportBounds);
            ResizeControl(btnImport, originalBtnImportBounds);
            ResizeControl(tableLayoutPanel, originalTableLayoutPanelBounds);
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

        // The rest of the existing button click events remain unchanged
        private void btnSession_Click(object sender, EventArgs e)
        {
            var sessionForm = new SessionForm(this);
            sessionForm.ShowDialog();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            var classForm = new ClassForm(this);
            classForm.ShowDialog();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            var teacherForm = new TeacherForm(this);
            teacherForm.ShowDialog();
        }

        private void btnParent_Click(object sender, EventArgs e)
        {
            var parentForm = new ParentForm(this);
            parentForm.ShowDialog();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            var paymentForm = new PaymentForm(this);
            paymentForm.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var dbHelper = new DatabaseHelper();
                    var students = dbHelper.GetStudentsDataTable();
                    var classes = dbHelper.GetClassesDataTable();
                    var teachers = dbHelper.GetTeachersDataTable();
                    var payments = dbHelper.GetPaymentsDataTable();
                    var sessions = dbHelper.GetSessionsDataTable();

                    ExcelHelper.ExportToExcel(sfd.FileName, students, classes, teachers, payments, sessions);
                    MessageBox.Show("Data exported successfully!");
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ExcelHelper.ImportFromExcel(ofd.FileName, out var students, out var classes, out var teachers, out var payments, out var sessions);

                    var dbHelper = new DatabaseHelper();
                    dbHelper.ImportStudentsFromDataTable(students);
                    dbHelper.ImportClassesFromDataTable(classes);
                    dbHelper.ImportTeachersFromDataTable(teachers);
                    dbHelper.ImportPaymentsFromDataTable(payments);
                    dbHelper.ImportSessionsFromDataTable(sessions);

                    MessageBox.Show("Data imported successfully!");
                }
            }
        }
    }
}
