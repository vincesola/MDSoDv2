using System;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace MDSoDv2
{
    public class BaseForm : MaterialForm
    {
        // Declare the readonly MaterialSkinManager
        private readonly MaterialSkinManager materialSkinManager;
        private const int borderWidth = 1;  // Border width for focused and non-focused forms

        public BaseForm()
        {
            // Initialize MaterialSkinManager in the constructor
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Purple700,   // Darker shade of Fuchsia
                Primary.Purple900,   // Even darker shade for dark themes
                Primary.Purple500,   // Light shade for toolbar and other light elements
                Accent.Pink400,      // Fuchsia-like accent for highlights
                TextShade.WHITE      // Keep text white for readability
            );

            // Set the form's border and padding
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderWidth); // Add padding to simulate border

            // Hook up events
            this.Resize += (sender, e) => Invalidate(); // Repaint the border when resizing
        }

        // Custom painting of border
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the custom border around the form
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                Color.Fuchsia, borderWidth, ButtonBorderStyle.Solid,  // Left
                Color.Fuchsia, borderWidth, ButtonBorderStyle.Solid,  // Top
                Color.Fuchsia, borderWidth, ButtonBorderStyle.Solid,  // Right
                Color.Fuchsia, borderWidth, ButtonBorderStyle.Solid); // Bottom
        }
    }
}
