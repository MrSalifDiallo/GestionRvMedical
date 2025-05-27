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
        //BdRvMedicalContext bd=new BdRvMedicalContext();  
        //private Utilisateur currentUser;  
        Utils utils= new Utils(); // ✅ Instance of Utils class for logging
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
            ServiceMetierAuthentification.AuthentificationServiceClient serviceAuthentification = new ServiceMetierAuthentification.AuthentificationServiceClient(); // ✅ Service WCF for General Method  
            string identifiantinbd = txtIdentifiant.Text.ToLower();
            string mdp = txtMotDePasse.Text;
            try
            {
                // Check if the user exists in the database
                bool existinguser = serviceAuthentification.CheckUser(identifiantinbd, mdp);
                if (existinguser)
                {
                    frmMDI f = new frmMDI(); // Create an instance of frmMDI with the mapped user
                    f.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
                }
                //if (existinguser)
                //{
                //    var verificationuser = serviceAuthentification.UserInformation(identifiantinbd, mdp);
                //    if (verificationuser != null)
                //    {
                //        // Map the ServiceMetierAuthentification.Utilisateur to WindowsFormsApp1.Model.Utilisateur  
                //        Utilisateur mappedUser = new Utilisateur
                //        {
                //            identifiant = verificationuser.identifiant,
                //            MotDePasse = verificationuser.MotDePasse,
                //            statut = verificationuser.statut,
                //            IdRole = verificationuser.IdRole,
                //            Adresse = verificationuser.Adresse,
                //            Email = verificationuser.Email,
                //            TEL = verificationuser.TEL,
                //        };
                //        frmMDI f = new frmMDI(mappedUser); // Create an instance of frmMDI with the mapped user
                //        f.Show();
                //        this.Hide();
                //    }
                //    else
                //    {
                //        lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
                //    }
                //}
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "frmMdi-BtnConnexion");
                utils.WriteDataError("Erreur lors de la vérification de l'utilisateur", ex.ToString());
            }
           // var verificationuser = serviceAuthentification.UserInformation(identifiantinbd, mdp);
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
