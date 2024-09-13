using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class BackOfficeForm : BaseForm
    {

        public BackOfficeForm(Form parent)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form

        }

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
