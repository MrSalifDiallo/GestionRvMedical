using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;
using WindowsFormsApp1.View.GunaUi;
using MetierRvMedical.Model;
namespace WindowsFormsApp1
{
    public partial class frmConnexion : Form
    {
        //BdRvMedicalContext bd=new BdRvMedicalContext();  
        //private Utilisateur currentUser;  
        Utils utils= new Utils(); // ✅ Instance of Utils class for logging
        AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient(); // ✅ Service WCF for General Method

        public frmConnexion()
        {
            InitializeComponent();
            //this.WindowState=FormWindowState.Maximized; // Set the form to maximized state

        }

        private void frmConnexion_Load(object sender, EventArgs e)
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

        private async void btnConnexion_Click(object sender, EventArgs e)
        {
            // Input validation
            //if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
            //{
            //    lblMessage.Text = "Veuillez saisir votre identifiant";
            //    txtIdentifiant.Focus();
            //    return;
            //}
            
            //if (string.IsNullOrWhiteSpace(txtMotdePasse.Text))
            //{
            //    lblMessage.Text = "Veuillez saisir votre mot de passe";
            //    txtMotdePasse.Focus();
            //    return;
            //}
            
            // Clear previous messages
            //lblMessage.Text = "";
            
            // Disable controls during authentication
            //btnConnexion.Enabled = false;
            //txtIdentifiant.Enabled = false;
            //txtMotdePasse.Enabled = false;
            //lblMessage.Text = "Authentification en cours...";
            
            //ServiceMetierAuthentification.AuthentificationServiceClient serviceAuthentification = new ServiceMetierAuthentification.AuthentificationServiceClient(); // ✅ Service WCF for General Method  
            string identifiantinbd = txtIdentifiant.Text.ToLower();
            string mdp = txtMotdePasse.Text;
            try
            {
                // Check if the user exists in the database
                Application.DoEvents();
                
                bool existinguser = allService.CheckUser(identifiantinbd, mdp);
                if (existinguser)
                {
                    Application.DoEvents();
                    
                    var verificationuser = allService.UserInformation(identifiantinbd, mdp);
                    if (verificationuser != null)
                    {
                        Application.DoEvents();
                        Utilisateur mappedUser = verificationuser;
                        frmLoading _load = new frmLoading();

                        // Souscription à l'événement de fin de chargement
                        _load.LoadingCompleted += (s, args) =>
                        {
                            frmMDI f = new frmMDI(mappedUser);
                            f.Show();
                            _load.Hide();
                        };

                        _load.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
                        // Re-enable controls when user verification fails
                        btnConnexion.Enabled = true;
                        txtIdentifiant.Enabled = true;
                        txtMotdePasse.Enabled = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Identifiant ou Mot de Passe incorrect";
                    // Re-enable controls when authentication fails
                    btnConnexion.Enabled = true;
                    txtIdentifiant.Enabled = true;
                    txtMotdePasse.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // More specific error handling
                if (ex is System.ServiceModel.CommunicationException)
                {
                    lblMessage.Text = "Erreur de connexion au service";
                }
                else if (ex is MySql.Data.MySqlClient.MySqlException)
                {
                    lblMessage.Text = "Erreur de base de données";
                }
                else if (ex is System.Net.WebException)
                {
                    lblMessage.Text = "Erreur de connexion réseau";
                }
                else
                {
                    lblMessage.Text = "Erreur système inattendue";
                }
                
                Utils.WriteLogSystem(ex.ToString(), "frmConnexion-BtnConnexion");
                utils.WriteDataError("Erreur lors de la vérification de l'utilisateur", ex.ToString());
            }
            finally
            {
                // Always re-enable controls regardless of success or failure
                btnConnexion.Enabled = true;
                txtIdentifiant.Enabled = true;
                txtMotdePasse.Enabled = true;
            }
           // var verificationuser = serviceAuthentification.UserInformation(identifiantinbd, mdp);
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AutoResizeAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                // ou bien : ctrl.Dock = DockStyle.Fill;
                AutoResizeAllControls(ctrl); // Récursion pour les enfants
            }
        }

        private void splitter2_SplitterMoved_1(object sender, SplitterEventArgs e)
        {

        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
