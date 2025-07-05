using MetierRvMedical.Helper;
using MetierRvMedical.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using typeMetierService = MetierRvMedical.Model;
using utilsWinform = WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.View.GunaUi
{
    public partial class frmListePatient : Form
    {
        AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient(); // ✅ Service WCF for General Method
        utilsWinform.Utils utils = new utilsWinform.Utils();
        
        public frmListePatient()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Set the form to maximized state
            this.FormBorderStyle = FormBorderStyle.None; // Remove the border of the form
            // Load patients into the DataGridView when the form loads
            RemplirDataGridViewPatients(GetPatients());
        }

        private void frmListePatient_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Nouvelle méthode pour remplir le DataGridView manuellement
        private void RemplirDataGridViewPatients(List<typeMetierService.Patient> patients)
        {
            // --- Utilisation de la méthode utilitaire générique ---
                var columns = new List<(string columnName, Type columnType, string propertyName)>
                {
                    ("Nom", typeof(string), "NomPrenom"),
                    ("Email", typeof(string), "Email"),
                    ("Téléphone", typeof(string), "TEL"),
                    ("Adresse", typeof(string), "Adresse"),
                    ("Date de naissance", typeof(DateTime), "DateNaissance"),
                    ("Poids", typeof(float), "Poids"),
                    ("Taille", typeof(float), "Taille"),
                    ("Groupe Sanguin", typeof(string), "GroupeSanguin")
                };
                utils.LoadDataInDataGridView(patients, guna2DataGridView1, columns);
            /*foreach (var patient in patients)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "";
*//*            guna2DataGridView1.Rows[rowIndex].Cells[1].Value ="";
*//*            guna2DataGridView1.Rows[rowIndex].Cells[2].Value = patient.NomPrenom;
                guna2DataGridView1.Rows[rowIndex].Cells[3].Value = patient.Email;
                guna2DataGridView1.Rows[rowIndex].Cells[4].Value = patient.TEL;
                guna2DataGridView1.Rows[rowIndex].Cells[5].Value = patient.Adresse;
*//*                guna2DataGridView1.Rows[rowIndex].Cells[7].Value = patient.DateNaissance?.ToString("dd/MM/yyyy");
*//*                // Pour le groupe sanguin, il faut vérifier la structure de l'objet
                //if (patient.GroupeSanguin != null)
                //{
                //    var codeProp = patient.GroupeSanguin.GetType().GetProperty("CodeGroupeSanguin");
                //    guna2DataGridView1.Rows[rowIndex].Cells[4].Value = codeProp != null ? codeProp.GetValue(patient.GroupeSanguin) : patient.GroupeSanguin.ToString();
                //}
                //else
                //{
                //    guna2DataGridView1.Rows[rowIndex].Cells[4].Value = "";
                //}
            }*/
        }

        private List<typeMetierService.Patient> GetPatients()
        {
            try
            {
                return allService.GetListePatients()?.ToList() ?? new List<typeMetierService.Patient>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des patients : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<typeMetierService.Patient>();
            }
        }
    }
}
