using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public class CustomToolTipForm : Form
    {
        private Label label;
        private string lastMessage = "";

        public CustomToolTipForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            BackColor = Color.LightYellow;
            Padding = new Padding(6);
            AutoSize = true;
            TopMost = true; // pour ne pas être caché
            Opacity = 0.95;

            label = new Label()
            {
                AutoSize = true,
                MaximumSize = new Size(300, 0),
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 9),
            };

            Controls.Add(label);
        }

        public void ShowMessage(string message, Control anchorControl, int offsetX = 0, int offsetY = -30)
        {
            if (Visible && message == lastMessage)
                return; // ⚠️ Déjà affiché → on ne refait rien

            lastMessage = message;
            label.Text = message;

            var location = anchorControl.PointToScreen(new Point(offsetX, offsetY));
            Location = location;

            Show();
            BringToFront();
        }

        public void HideMessage()
        {
            lastMessage = ""; // ✅ Réinitialise pour autoriser le prochain affichage
            Hide();
        }
    }
}
