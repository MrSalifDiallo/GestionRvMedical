using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class frmPatients : Form
    {
        Utils utils=new Utils();
        public frmPatients()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;  // Supprimer les boutons de contrôle
            this.ShowIcon = false;    // Supprimer l'icône
            this.ShowInTaskbar = false; // Ne pas afficher dans la barre des tâches
        }

        //BdRvMedicalContext bd = new BdRvMedicalContext(); // ❌ Supprimé – plus utilisé
        ServiceMetier.Service1Client service = new ServiceMetier.Service1Client(); // ✅ Service WCF
        ServiceMetierPatient.PatientServiceClient servicePatient = new ServiceMetierPatient.PatientServiceClient(); // ✅ Service WCF
        private void ResetForm()
        {
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtPoids.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            cbbGroupeSanguin.SelectedIndex = 0; // 🔄 CHANGÉ – Réinitialise sur "Sélectionnez..."
            dtDateNaissance.Value = DateTime.Now.Date;
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            DateTime selectedDate = dtDateNaissance.Value.Date;
            cbbGroupeSanguin.DataSource = LoadCbbGroupeSanguins(); // 🔄 CHANGÉ – utilise le service
            cbbGroupeSanguin.DisplayMember = "Text";  // Afficher le texte du groupe sanguin
            cbbGroupeSanguin.ValueMember = "Value";   // La valeur utilisée lors de la sélection
            ResetForm();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void grpSanguin_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private List<SelectListView> LoadCbbGroupeSanguins()
        {
            var grpsang = servicePatient.GetListeGroupesSanguins(); // 🔄 CHANGÉ – appel service WCF
            List<SelectListView> ListeGS = new List<SelectListView>();

            ListeGS.Add(new SelectListView { Text = "Sélectionnez le groupe sanguin", Value = "" });

            foreach (var onegrp in grpsang)
            {
                ListeGS.Add(new SelectListView
                {
                    Text = onegrp.NomGroupeSanguin + "(" + onegrp.CodeGroupeSanguin + ")",
                    Value = onegrp.CodeGroupeSanguin
                });
            }
            return ListeGS;
        }

        private void btnRenitialiser_Click(object sender, EventArgs e)
        {
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtTaille.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            
            cbbGroupeSanguin.DataSource = LoadCbbGroupeSanguins(); // 🔄 CHANGÉ – recharge à nouveau
            cbbGroupeSanguin.DisplayMember = "Text";  // Afficher le texte du groupe sanguin
            cbbGroupeSanguin.ValueMember = "Value";   // La valeur utilisée lors de la sélection
        }

        private void lblTelephone_Click(object sender, EventArgs e)
        {
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceMetierPatient.Patient p = new ServiceMetierPatient.Patient();
                //ServiceMetier.Patient p = new ServiceMetier.Patient();
                p.Adresse = txtAdresse.Text;
                p.TEL = txtTelephone.Text;

                StringBuilder erreurs = new StringBuilder();

                // Vérification du poids
                if (!float.TryParse(txtPoids.Text, out float poids))
                {
                    erreurs.AppendLine("Poids invalide.");
                }

                // Vérification de la taille
                if (!float.TryParse(txtTaille.Text, out float taille))
                {
                    erreurs.AppendLine("Taille invalide.");
                }

                // Vérification de la date de naissance
                if (dtDateNaissance.Value.Date >= DateTime.Now.Date)
                {
                    erreurs.AppendLine("La date de naissance ne peut pas être aujourd'hui ou dans le futur.");
                }

                // On vérifie que le groupe sanguin est sélectionné
                if (cbbGroupeSanguin.SelectedItem != null)
                {
                    SelectListView selectedItem = (SelectListView)cbbGroupeSanguin.SelectedItem;
                    var listeGroupes = servicePatient.GetListeGroupesSanguins();
                    var selectedGroup = listeGroupes.FirstOrDefault(gs => gs.CodeGroupeSanguin == selectedItem.Value);

                    if (selectedGroup != null)
                    {
                        p.GroupeSanguin = selectedGroup;
                        p.IdGroupeSanguin = selectedGroup.IdGroupeSanguin;
                    }
                    else
                    {
                        erreurs.AppendLine("Le groupe sanguin sélectionné est invalide.");
                    }
                }
                else
                {
                    erreurs.AppendLine("Veuillez sélectionner un groupe sanguin.");
                }

                // Si des erreurs existent, on les affiche
                if (erreurs.Length > 0)
                {
                    MessageBox.Show(erreurs.ToString(), "Erreurs de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                p.Poids = poids;
                p.Taille = taille;
                p.NomPrenom = txtNomPrenom.Text;
                p.Email = txtEmail.Text;
                p.DateNaissance=dtDateNaissance.Value.Date;
                bool resultat = servicePatient.AddPatient(p);

                if (resultat)
                {
                    MessageBox.Show("Patient ajouté avec succès !");
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du patient. Vérifiez les logs pour plus de détails.");
                }
            }
            catch (Exception ex)
            {
                //En C#, une méthode marquée comme static appartient à la classe elle-même, et non à une instance particulière de cette classe.
                //Cela signifie que tu n'as pas besoin de créer un objet de la classe pour y accéder. Tu peux appeler la méthode directement sur la classe.
                // Côté client, loguer l'erreur dans un fichier local ou un système de logs (facultatif)
                Utils.WriteLogSystem(ex.ToString(), "frmPatients-btnValider_Click - Erreur");
                utils.WriteDataError("frmPatients-btnValider_Click - Erreur", ex.ToString());

                // Afficher l'erreur à l'utilisateur
                MessageBox.Show("Une erreur inattendue est survenue: " + ex.Message);
            }

        }

        private void txtPoids_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
