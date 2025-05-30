﻿    using MySqlX.XDevAPI.Relational;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic.Devices;
    using WindowsFormsApp1.Model;

    using System.Windows.Forms;
    using WindowsFormsApp1.View;

namespace WindowsFormsApp1
    {
        public partial class frmMDI : Form
        {
            public string role;
            private ServiceMetierAuthentification.Utilisateur utilisateurConnecte;

        public ServiceMetierAuthentification.Utilisateur user { get; internal set; }

        public frmMDI(ServiceMetierAuthentification.Utilisateur utilisateurConnecte)
            {
                InitializeComponent();
                this.IsMdiContainer = true; // <-- Cette ligne est essentielle
                this.WindowState = FormWindowState.Maximized; // Définit l'état du formulaire sur maximisé
                this.FormBorderStyle = FormBorderStyle.None; // Supprime la bordure du formulaire
                this.ControlBox = false;  // Supprime les boutons de contrôle (fermer, réduire, agrandir)
                this.ShowIcon = false;    // Supprime l'icône dans la barre de titre
                this.ShowInTaskbar = false; // Ne pas afficher dans la barre des tâches
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
                //chform.WindowState = FormWindowState.Maximized;
                chform.Close();
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
            fermer();
            frmTest f = new frmTest();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;

        }

            private void label1_Click(object sender, EventArgs e)
            {

            }
        }
    }
