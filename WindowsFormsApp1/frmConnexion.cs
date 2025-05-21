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
using WindowsFormsApp1.Helper;
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
            string identifiantinbd = txtIdentifiant.Text.ToLower();
            string mdp = CryptString.GetMd5Hash(txtMotDePasse.Text);

            var leUser = bd.Utilisateurs
                .Where(a => a.identifiant.ToLower() == identifiantinbd)
                .AsEnumerable() // passe en LINQ to Objects après le filtre SQL
                .FirstOrDefault(a => a.MotDePasse == mdp);

            //var leUser=bd.Utilisateurs.Where(a=>a.identifiant.ToLower()==txtIdentifiant.Text.ToLower() && a.MotDePasse==CryptString.GetMd5Hash(txtMotDePasse.Text) ).FirstOrDefault();
            if (leUser != null)
            {
                frmMDI f = new frmMDI();
                f.role = leUser.Role.Code;
                f.Show();
                this.Hide();
            }
            else
            {
                lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
            }
                //Utilisateur ut = new Utilisateur();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
