using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public class FormValidator
    {
        private readonly ToolTip toolTip;
        private readonly Control button;
        private readonly Label errorLabel; // optionnel : afficher erreur permanente sur form
        private readonly Func<string> validationFunc;

        private string currentErrorMessage = "";
        private bool isValid = true;

        public FormValidator(ToolTip toolTip, Control button, Func<string> validationFunc, Label errorLabel = null)
        {
            this.toolTip = toolTip ?? throw new ArgumentNullException(nameof(toolTip));
            this.button = button ?? throw new ArgumentNullException(nameof(button));
            this.validationFunc = validationFunc ?? throw new ArgumentNullException(nameof(validationFunc));
            this.errorLabel = errorLabel;


            // Event pour afficher/cacher tooltip au survol
            this.button.MouseHover += Button_MouseHover;
            this.button.MouseLeave += Button_MouseLeave;
        }

        // À appeler à chaque changement sur les champs du formulaire
        public void Validate()
        {
            currentErrorMessage = validationFunc();
            isValid = string.IsNullOrWhiteSpace(currentErrorMessage);

            // Mise à jour label d'erreur (optionnel)
            if (errorLabel != null)
            {
                errorLabel.Text = currentErrorMessage;
                errorLabel.Visible = !isValid;
            }

            // Mise à jour visuelle bouton
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
                toolTip.Show(currentErrorMessage, button, 0, -20);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(button);
        }

        // Méthodes personnalisables pour le style du bouton (adapter selon ta UI)
        private void SetButtonValidStyle()
        {
            // Exemple avec GunaButton, adapte selon ton bouton
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
