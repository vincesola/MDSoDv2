using System;
using System.Data;
using ClosedXML.Excel;

namespace MDSoDv2
{
    public static class ExcelHelper
    {
        public static void ExportToExcel(string filePath, DataTable students, DataTable classes, DataTable teachers, DataTable payments, DataTable sessions)
        {
            using (var workbook = new XLWorkbook())
            {
                var studentSheet = workbook.Worksheets.Add(students, "Students");
                var classSheet = workbook.Worksheets.Add(classes, "Classes");
                var teacherSheet = workbook.Worksheets.Add(teachers, "Teachers");
                var paymentSheet = workbook.Worksheets.Add(payments, "Payments");
                var sessionSheet = workbook.Worksheets.Add(sessions, "Sessions");

                // Ensure DateOfBirth is stored as text
                FormatDateOfBirthColumnAsText(studentSheet);
                FormatDateColumns(paymentSheet);

                workbook.SaveAs(filePath);
            }
        }

        public static void ImportFromExcel(string filePath, out DataTable students, out DataTable classes, out DataTable teachers, out DataTable payments, out DataTable sessions)
        {
            students = new DataTable();
            classes = new DataTable();
            teachers = new DataTable();
            payments = new DataTable();
            sessions = new DataTable();

            using (var workbook = new XLWorkbook(filePath))
            {
                var studentSheet = workbook.Worksheet("Students");
                var classSheet = workbook.Worksheet("Classes");
                var teacherSheet = workbook.Worksheet("Teachers");
                var paymentSheet = workbook.Worksheet("Payments");
                var sessionSheet = workbook.Worksheet("Sessions");

                students = ToDataTable(studentSheet);
                classes = ToDataTable(classSheet);
                teachers = ToDataTable(teacherSheet);
                payments = ToDataTable(paymentSheet);
                sessions = ToDataTable(sessionSheet);
            }
        }

        private static void FormatDateColumns(IXLWorksheet worksheet)
        {
            foreach (var column in worksheet.ColumnsUsed())
            {
                if (column.FirstCell().Value.ToString().Contains("Date"))
                {
                    column.Style.DateFormat.Format = "MM/dd/yyyy";
                }
            }
        }

        private static void FormatDateOfBirthColumnAsText(IXLWorksheet worksheet)
        {
            int dateOfBirthColumnIndex = 4; // Assuming the "DateOfBirth" column is the fourth column

            foreach (var row in worksheet.RowsUsed())
            {
                var cell = row.Cell(dateOfBirthColumnIndex);

                // Set the cell format to text
                cell.Style.NumberFormat.SetFormat("@");

                if (cell.DataType == XLDataType.DateTime)
                {
                    // Convert DateTime to string in the desired format and prepend with apostrophe
                    cell.Value = "'" + cell.GetDateTime().ToString("MM/dd/yyyy");
                }
                else
                {
                    // Ensure the value is treated as text by prepending a single quote
                    cell.Value = "'" + cell.GetString();
                }
            }
        }

        private static DataTable ToDataTable(IXLWorksheet worksheet)
        {
            var dataTable = new DataTable();
            bool firstRow = true;

            foreach (var row in worksheet.RowsUsed())
            {
                if (firstRow)
                {
                    foreach (var cell in row.CellsUsed())
                    {
                        dataTable.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                else
                {
                    var dataRow = dataTable.NewRow();
                    int i = 0;
                    foreach (var cell in row.CellsUsed())
                    {
                        dataRow[i] = cell.Value;
                        i++;
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
