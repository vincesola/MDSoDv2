using System.Data;
using ClosedXML.Excel;

namespace MDSoDv2
{
    public static class WorksheetExtensions
    {
        public static DataTable ToDataTable(this IXLWorksheet worksheet)
        {
            var dataTable = new DataTable();
            bool firstRow = true;

            foreach (var row in worksheet.Rows())
            {
                if (firstRow)
                {
                    foreach (var cell in row.Cells())
                    {
                        dataTable.Columns.Add(cell.Value.ToString());
                    }
                    firstRow = false;
                }
                else
                {
                    dataTable.Rows.Add();
                    int i = 0;
                    foreach (var cell in row.Cells())
                    {
                        dataTable.Rows[dataTable.Rows.Count - 1][i] = cell.Value;
                        i++;
                    }
                }
            }

            return dataTable;
        }
    }
}