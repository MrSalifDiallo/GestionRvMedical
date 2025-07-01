using MetierRvMedical.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1.View.GunaUi
{
    public partial class frmTest : Form
    {
        Utils utils = new Utils(); // ✅ Instance of Utils class for logging
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient(); // ✅ Service WCF for General Method
            //ServiceMetierAuthentification.AuthentificationServiceClient serviceAuthentification = new ServiceMetierAuthentification.AuthentificationServiceClient(); // ✅ Service WCF for General Method  
            string identifiantinbd = txtIdentifiant.Text.ToLower();
            string mdp = txtMotdePasse.Text;
            try
            {
                // Check if the user exists in the database
                //if (existinguser)
                //{
                //    frmMDI f = new frmMDI(); // Create an instance of frmMDI with the mapped user
                //    f.Show();
                //    this.Hide();
                //}
                //else
                //{
                //    lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
                //}
                bool existinguser = allService.CheckUser(identifiantinbd, mdp);
                if (existinguser)
                {
                    var verificationuser = allService.UserInformation(identifiantinbd, mdp);
                    if (verificationuser != null)
                    {

                        ////frmMDI f = new frmMDI(mappedUser); // Create an instance of frmMDI with the mapped user
                        //if (CryptString.GetMd5Hash(mdp)==CryptString.GetMd5Hash("passer"))
                        //{
                        //    frmChangePassword form = new frmChangePassword();
                        //    form.Show();
                        //    this.Hide();
                        //}
                        //else
                        //{
                        // Map the ServiceMetierAuthentification.Utilisateur to WindowsFormsApp1.Model.Utilisateur  
                        AllServiceMetier.Utilisateur mappedUser = verificationuser;
                        frmMDI f = new frmMDI(mappedUser); // Create an instance of frmMDI with the mapped user
                        f.Show();
                        this.Hide();
                        //}
                    }
                    else
                    {
                        lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
                    }
                }
                else
                {
                    lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
                }
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "frmMdi-BtnConnexion");
                utils.WriteDataError("Erreur lors de la vérification de l'utilisateur", ex.ToString());
            }
            // var verificationuser = serviceAuthentification.UserInformation(identifiantinbd, mdp);

        }
    }
}
