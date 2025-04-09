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
    public partial class frmPatients: Form
    {
        public frmPatients()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;  // Supprimer les boutons de contrôle
            this.ShowIcon = false;    // Supprimer l'icône
            this.ShowInTaskbar = false; // Ne pas afficher dans la barre des tâches

        }

        BdRvMedicalContext bd = new BdRvMedicalContext();
       
        private void ResetForm()
        {
            txtAdresse.Text=string.Empty;
            txtEmail.Text = string.Empty;
            txtNomPrenom.Text = string.Empty;
            txtPoids.Text = string.Empty; 
            txtTelephone.Text = string.Empty;
            cbbGroupeSanguin.SelectedValue = string.Empty;

        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            ResetForm();
            cbbGroupeSanguin.DataSource = LoadCbbGroupeSanguins();
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
            var grpsang = bd.GroupeSanguins.ToList();
            List<SelectListView> ListeGS = new List<SelectListView>();
            SelectListView def = new SelectListView();
            def.Text = "Selectionnez le groupe sanguin";
            def.Value = "";
            ListeGS.Add(def);
            foreach (var onegrp in grpsang)
            {
                SelectListView a = new SelectListView();
                a.Text = onegrp.CodeGroupeSanguin;
                a.Value = onegrp.CodeGroupeSanguin.ToString();
                ListeGS.Add(a);
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
            cbbGroupeSanguin.SelectedValue = LoadCbbGroupeSanguins();
            cbbGroupeSanguin.DisplayMember = "Text";  // Afficher le texte du groupe sanguin
            cbbGroupeSanguin.ValueMember = "Value";   // La valeur utilisée lors de la sélection
        }

        private void lblTelephone_Click(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Adresse = txtAdresse.Text;
            p.TEL = txtTelephone.Text;
            p.Poids = float.Parse(txtPoids.Text);
            p.Taille = float.Parse(txtPoids.Text);
            p.NomPrenom = txtNomPrenom.Text;
            p.Email = txtEmail.Text;
            // On va Vérifier si un groupe sanguin a été sélectionné
            if (cbbGroupeSanguin.SelectedItem != null)
            {
                // Récupérer l'objet SelectListView sélectionné
                SelectListView selectedItem = (SelectListView)cbbGroupeSanguin.SelectedItem;

                // Rechercher l'objet GroupeSanguin dans la base de données à l'aide de la valeur
                GroupeSanguin selectedGroup = bd.GroupeSanguins
                    .FirstOrDefault(gs => gs.CodeGroupeSanguin == selectedItem.Value);

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
            bd.Patients.Add(p);
            bd.SaveChanges();
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
