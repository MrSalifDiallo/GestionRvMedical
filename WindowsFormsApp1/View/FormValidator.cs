using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public class FormValidator
    {
        private readonly ToolTip toolTip;
        private readonly Control button;
        private readonly Label errorLabel;
        private readonly Func<(string toolTipMessage, string labelMessage)> validationFunc;

        private string currentToolTipMessage = "";
        private bool isValid = true;

        public FormValidator(ToolTip toolTip, Control button, Func<(string, string)> validationFunc, Label errorLabel = null)
        {
            this.toolTip = toolTip ?? throw new ArgumentNullException(nameof(toolTip));
            this.button = button ?? throw new ArgumentNullException(nameof(button));
            this.validationFunc = validationFunc ?? throw new ArgumentNullException(nameof(validationFunc));
            this.errorLabel = errorLabel;

            this.button.MouseHover += Button_MouseHover;
            this.button.MouseLeave += Button_MouseLeave;
        }

        public void Validate()
        {
            var (toolTipError, labelError) = validationFunc();
            currentToolTipMessage = toolTipError;
            isValid = string.IsNullOrWhiteSpace(toolTipError);

            if (errorLabel != null)
            {
                errorLabel.Text = labelError;
                errorLabel.Visible = !isValid;
            }

            if (isValid)
            {
                button.Cursor = Cursors.Hand;
                SetButtonValidStyle();
            }
            else
            {
                button.Cursor = Cursors.No;
                SetButtonInvalidStyle();
            }
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            if (!isValid)
            {
                toolTip.Show(currentToolTipMessage, button, 0, -20);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(button);
        }

        private void SetButtonValidStyle()
        {
            dynamic btn = button;
            btn.HoverState.FillColor = System.Drawing.Color.Lime;
        }

        private void SetButtonInvalidStyle()
        {
            dynamic btn = button;
            btn.HoverState.FillColor = System.Drawing.Color.DarkGray;
        }
    }
}
