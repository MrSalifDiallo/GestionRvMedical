using Google.Protobuf.WellKnownTypes;
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

namespace WindowsFormsApp1.View
{
    public partial class frmPatients : Form
    {
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

        private void ResetForm()
        {
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtPoids.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            cbbGroupeSanguin.SelectedIndex = 0; // 🔄 CHANGÉ – Réinitialise sur "Sélectionnez..."
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            ResetForm();
            cbbGroupeSanguin.DataSource = LoadCbbGroupeSanguins(); // 🔄 CHANGÉ – utilise le service
            cbbGroupeSanguin.DisplayMember = "Text";  // Afficher le texte du groupe sanguin
            cbbGroupeSanguin.ValueMember = "Value";   // La valeur utilisée lors de la sélection
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
            var grpsang = service.GetListeGroupesSanguins(); // 🔄 CHANGÉ – appel service WCF
            List<SelectListView> ListeGS = new List<SelectListView>();

            ListeGS.Add(new SelectListView { Text = "Sélectionnez le groupe sanguin", Value = "" });

            foreach (var onegrp in grpsang)
            {
                ListeGS.Add(new SelectListView
                {
                    Text = onegrp.CodeGroupeSanguin,
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
            ServiceMetier.Patient p = new ServiceMetier.Patient();
            p.Adresse = txtAdresse.Text;
            p.TEL = txtTelephone.Text;

            // 🔄 CHANGÉ – Gestion plus robuste pour éviter erreurs de format
            if (!float.TryParse(txtPoids.Text, out float poids))
            {
                MessageBox.Show("Poids invalide.");
                return;
            }
            if (!float.TryParse(txtTaille.Text, out float taille))
            {
                MessageBox.Show("Taille invalide.");
                return;
            }

            p.Poids = poids;
            p.Taille = taille;
            p.NomPrenom = txtNomPrenom.Text;
            p.Email = txtEmail.Text;

            // On va Vérifier si un groupe sanguin a été sélectionné
            if (cbbGroupeSanguin.SelectedItem != null)
            {
                // Récupérer l'objet SelectListView sélectionné
                SelectListView selectedItem = (SelectListView)cbbGroupeSanguin.SelectedItem;

                // 🔄 CHANGÉ – Utiliser la liste retournée par le service pour retrouver le groupe
                var listeGroupes = service.GetListeGroupesSanguins();
                var selectedGroup = listeGroupes.FirstOrDefault(gs => gs.CodeGroupeSanguin == selectedItem.Value);

                // Vérifier si le groupe sanguin a été trouvé
                if (selectedGroup != null)
                {
                    p.GroupeSanguin = selectedGroup; // Assigner l'objet GroupeSanguin
                }
                else
                {
                    MessageBox.Show("Le groupe sanguin sélectionné est invalide.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un groupe sanguin.");
                return;
            }

            service.AddPatient(p); // 🔄 CHANGÉ – appel du service uniquement

            //Capter les erreurs
            //try
            //{
            //    bd.SaveChanges();
            //    MessageBox.Show("Patient Ajouté");
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            //{
            //    foreach (var validationErrors in ex.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            MessageBox.Show($"Propriété : {validationError.PropertyName} - Erreur : {validationError.ErrorMessage}");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Erreur : {ex.Message}");
            //}
            ResetForm();
        }

        private void txtPoids_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
