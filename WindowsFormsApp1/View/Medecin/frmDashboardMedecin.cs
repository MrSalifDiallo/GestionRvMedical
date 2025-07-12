using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View.Medecin
{
    public partial class frmDashboardMedecin : Form
    {
        public frmDashboardMedecin()
        {
            InitializeComponent();
            frmConfiguration(); // Appel de la méthode pour configurer le formulaire
        }

        private void frmConfiguration()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized; // Définit l'état du formulaire sur maximisé
            /*            this.ShowIcon = false;    // Supprimer l'icône
            *//*            this.ShowInTaskbar = false; // Ne pas afficher dans la barre des tâches
            */
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
