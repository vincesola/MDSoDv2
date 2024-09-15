using System.Windows.Forms;

namespace MDSoDv2
{
    public partial class ParentForm : BaseForm
    {
        public ParentForm(Form parent)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(parent.Location.X + 20, parent.Location.Y + 20); // Offset slightly from the parent form
        }
    }
}