using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MDSoDv2
{
    public class CustomButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Set up gradient colors
            Color color1 = Color.FromArgb(142, 36, 170);
            Color color2 = Color.FromArgb(106, 13, 173);

            // Create a rectangle for the button
            Rectangle rect = this.ClientRectangle;

            // Create a linear gradient brush
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.Vertical))
            {
                pevent.Graphics.FillRectangle(brush, rect);
            }

            // Draw the button text
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, rect, Color.Orange, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}