using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
namespace WindowsFormsApp1
{
    public partial class frmConexion : Form
    {
        BdRvMedicalContext bd=new BdRvMedicalContext();
        public frmConexion()
        {
            InitializeComponent();

        }

        private void frmConexion_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitter2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            var leUser=bd.Utilisateurs.Where(a=>a.identifiant.ToLower()==txtIdentifiant.Text.ToLower()).FirstOrDefault();
            if (leUser != null)
            {
                
            }
            else
            {
                lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
            }
                Utilisateur ut = new Utilisateur();

            frmMDI f = new frmMDI();
            f.Show();
            this.Hide();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
