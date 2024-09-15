using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class TeacherForm : BaseForm
    {
        private DatabaseHelper dbHelper;

        // Variables for resizing
        private Size originalFormSize;

        private Rectangle originalTxtTeacherNameBounds;
        private Rectangle originalLstTeachersBounds;
        private Rectangle originalBtnAddBounds;
        private Rectangle originalBtnRemoveBounds;

        public TeacherForm(Form parent)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form
            dbHelper = new DatabaseHelper();
            LoadTeachers();

            // Placeholder for teacher name input
            SetPlaceholderText(txtTeacherName, "Enter teacher's name");

            this.Load += TeacherForm_Load;
            this.Resize += TeacherForm_Resize;
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            // Store original form size and control bounds for resizing logic
            originalFormSize = this.Size;
            originalTxtTeacherNameBounds = txtTeacherName.Bounds;
            originalLstTeachersBounds = lstTeachers.Bounds;
            originalBtnAddBounds = btnAdd.Bounds;
            originalBtnRemoveBounds = btnRemove.Bounds;
        }

        private void TeacherForm_Resize(object sender, EventArgs e)
        {
            // Resize controls when the form resizes
            ResizeControl(txtTeacherName, originalTxtTeacherNameBounds);
            ResizeControl(lstTeachers, originalLstTeachersBounds);
            ResizeControl(btnAdd, originalBtnAddBounds);
            ResizeControl(btnRemove, originalBtnRemoveBounds);
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

        private void SetPlaceholderText(MaterialTextBox textBox, string placeholder)
        {
            textBox.Hint = placeholder; // Use MaterialTextBox hint as a placeholder
        }

        private void LoadTeachers()
        {
            var teachers = dbHelper.GetAllTeachers();

            // Clear existing items in the MaterialListBox
            lstTeachers.Items.Clear();

            // Manually populate the MaterialListBox
            foreach (var teacher in teachers)
            {
                var item = new MaterialListBoxItem
                {
                    Text = teacher.TeacherName,
                    Tag = teacher // Store the Teacher object in the Tag property
                };
                lstTeachers.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var teacherName = txtTeacherName.Text;
            if (!string.IsNullOrEmpty(teacherName))
            {
                dbHelper.AddTeacher(new Teacher { TeacherName = teacherName });
                LoadTeachers();
                txtTeacherName.Text = ""; // Clear the input field
            }
            else
            {
                MessageBox.Show("Please enter a teacher's name.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selectedItem = lstTeachers.SelectedItem as MaterialListBoxItem;
            if (selectedItem != null)
            {
                var selectedTeacher = selectedItem.Tag as Teacher;
                if (selectedTeacher != null)
                {
                    dbHelper.DeleteTeacher(selectedTeacher.TeacherID);
                    LoadTeachers();
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher to remove.");
            }
        }
    }
}