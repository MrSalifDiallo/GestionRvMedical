using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;
using WindowsFormsApp1.View;
using MetierRvMedical.Model;
using WindowsFormsApp1.View.Api;
namespace WindowsFormsApp1
    {
        public partial class frmMDI : Form
        {
            public string role;
            private Utilisateur utilisateurConnecte;

        public Utilisateur user { get; internal set; }

        public frmMDI(Utilisateur utilisateurConnecte)
        {
            InitializeComponent();
            this.utilisateurConnecte = utilisateurConnecte;
        }

        private void frmMDI_Load(object sender, EventArgs e)
            {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
            if (utilisateurConnecte.Role.Code.ToLower() == "Admin".ToLower())
                {
                    //Menu a cacher ou montrer pour Admin
                    //rendezToolStripMenuItem.Visible = false;
                }
                //lblUserBienvenue.Text = $"Bienvenue {utilisateurConnecte.NomPrenom}"; // Affiche le nom de l'utilisateur connecté
            }

            // Fonction générique pour ouvrir un formulaire MDI


            private void btn_Add_Click(object sender, EventArgs e)
            {

            }

            private void btn_Edit_Click(object sender, EventArgs e)
            {

            }

            private void btn_Delete_Click(object sender, EventArgs e)
            {

            }

            private void btn_view_Click(object sender, EventArgs e)
            {

            }

            private void btn_Refresh_Click(object sender, EventArgs e)
            {

            }

            private void btn_Cancel_Click(object sender, EventArgs e)
            {

            }

            private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {

            }

            private void docToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

            private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                fermer();
            frmPatients f = new frmPatients();
                f.MdiParent = this;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }

            private void toolStripButton1_ButtonClick(object sender, EventArgs e)
            {

            }

            private void toolStripButton2_Click(object sender, EventArgs e)
            {

            }

            private void rendezToolStripMenuItem_Click(object sender, EventArgs e)
            {
                //OpenMdiChildForm(); // Ouvre frmRendezVous
                fermer();
            frmRendezVous f = new frmRendezVous();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
            }
        private void fermer()
        {
            Form[] charr = this.MdiChildren;

            //For each child form set the window state to Maximized 
            foreach (Form chform in charr)
            {
/*                chform.WindowState = FormWindowState.Maximized;
*/                chform.Close();
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
            {

            }

            private void toolStripDropDownButton1_Click(object sender, EventArgs e)
            {

            }

            private void docteursToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

            private void toolStripButton2_Click_2(object sender, EventArgs e)
            {

            }


            private void btn_close_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }

            private void rendezVousToolStripMenuItem1_Click(object sender, EventArgs e)
            {
           
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

        private void toolStripDropDownApi_Click(object sender, EventArgs e)
        {

        }

        private void toolStripApiPatient_Click(object sender, EventArgs e)
        {
            fermer();
            frmRendezVous f = new frmRendezVous();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void soinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void soinsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fermer();
            frmApiPhpSoins f = new frmApiPhpSoins();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            fermer();
            frmApiPhpAgenda f = new frmApiPhpAgenda();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void creneauxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmApiPhpCreneaux f = new frmApiPhpCreneaux();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void groupeSanguinsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moyenPaimentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmApiPhpMoyenPayments f = new frmApiPhpMoyenPayments();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void paiementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmApiPhpPaiements f = new frmApiPhpPaiements();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void rendezVousToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fermer();
            frmApiPhpRv f = new frmApiPhpRv();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmApiPhpRoles f = new frmApiPhpRoles();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void specialitéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmApiPhpSpecialite f = new frmApiPhpSpecialite();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void patientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void assistantMedecinToolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void medecinsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adminsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
