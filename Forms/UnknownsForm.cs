using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Drawing.Printing;
using MaterialSkin.Controls;

namespace MDSoDv2
{
    public partial class UnknownsForm : BaseForm
    {
        // Variables to store original size and positions for resizing logic
        private Size originalFormSize;
        private Rectangle originalDgvUnknownsBounds;
        private Rectangle originalBtnSaveToFileBounds;
        private Rectangle originalBtnPrintBounds;

        public UnknownsForm(Form parent)
        {
            InitializeComponent();

            // Set form's position
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20);

            // Hook up form load and resize events
            this.Load += UnknownsForm_Load;
            this.Resize += UnknownsForm_Resize;

            LoadUnknowns();
        }

        private void UnknownsForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalDgvUnknownsBounds = dgvUnknowns.Bounds;
            originalBtnSaveToFileBounds = btnSaveToFile.Bounds;
            originalBtnPrintBounds = btnPrint.Bounds;
        }

        private void UnknownsForm_Resize(object sender, EventArgs e)
        {
            // Resize controls when form resizes
            ResizeControl(dgvUnknowns, originalDgvUnknownsBounds);
            ResizeControl(btnSaveToFile, originalBtnSaveToFileBounds);
            ResizeControl(btnPrint, originalBtnPrintBounds);
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

        private void LoadUnknowns()
        {
            var dbHelper = new DatabaseHelper();
            var unknowns = dbHelper.GetUnknowns();
            if (unknowns != null && unknowns.Any())
            {
                dgvUnknowns.DataSource = unknowns.Select(u => new
                {
                    u.EntityType,
                    u.FirstName,
                    u.LastName,
                    u.FieldWithUnknown
                }).ToList();

                // Attach the DataBindingComplete event
                dgvUnknowns.DataBindingComplete += DgvUnknowns_DataBindingComplete;
            }
        }

        private void DgvUnknowns_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Set AutoSizeMode for each column after data binding is complete
            dgvUnknowns.Columns["EntityType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUnknowns.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUnknowns.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Set the remaining space to be filled by 'FieldWithUnknown'
            dgvUnknowns.Columns["FieldWithUnknown"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Unknowns");
                        var dataTable = new DataTable();

                        // Add columns
                        dataTable.Columns.Add("EntityType");
                        dataTable.Columns.Add("FirstName");
                        dataTable.Columns.Add("LastName");
                        dataTable.Columns.Add("FieldWithUnknown");

                        // Add rows
                        foreach (DataGridViewRow row in dgvUnknowns.Rows)
                        {
                            dataTable.Rows.Add(row.Cells["EntityType"].Value,
                                               row.Cells["FirstName"].Value,
                                               row.Cells["LastName"].Value,
                                               row.Cells["FieldWithUnknown"].Value);
                        }

                        worksheet.Cell(1, 1).InsertTable(dataTable);
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Data saved to Excel file successfully.");
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            printDocument.DefaultPageSettings.Landscape = true; // Set to landscape
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvUnknowns.Width, this.dgvUnknowns.Height);
            dgvUnknowns.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvUnknowns.Width, this.dgvUnknowns.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
