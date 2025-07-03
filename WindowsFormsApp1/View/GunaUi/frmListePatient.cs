using MetierRvMedical.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using typeMetierService = MetierRvMedical.Model;

namespace WindowsFormsApp1.View.GunaUi
{
    public partial class frmListePatient : Form
    {
        AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient(); // ✅ Service WCF for General Method
        
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
        
        // --- Fonction générique commentée, à utiliser ailleurs si besoin ---

        /*
        public void LoadDataInDataGridView<T>(List<T> data,
            DataGridView dataGridView,
            List<(string columnName, Type columnType, string propertyName)> columns,
            string emptyMessage = "Aucune donnée trouvée ou erreur lors du chargement des données.")
        {
            try
            {
                if (data != null && data.Count > 0)
                {
                    DataTable dt = new DataTable();
                    // Création des colonnes
                    foreach (var col in columns)
                        dt.Columns.Add(col.columnName, col.columnType);

                    // Remplissage des lignes
                    foreach (var item in data)
                    {
                        var values = columns.Select(col =>
                        {
                            var prop = typeof(T).GetProperty(col.propertyName);
                            if (prop != null)
                            {
                                // Cas particulier pour GroupeSanguin (afficher le code si c'est un objet)
                                if (col.propertyName == "GroupeSanguin")
                                {
                                    var groupeSanguinObj = prop.GetValue(item);
                                    if (groupeSanguinObj != null)
                                    {
                                        var codeProp = groupeSanguinObj.GetType().GetProperty("CodeGroupeSanguin");
                                        return codeProp != null ? codeProp.GetValue(groupeSanguinObj) : groupeSanguinObj.ToString();
                                    }
                                    return null;
                                }
                                return prop.GetValue(item);
                            }
                            return null;
                        }).ToArray();
                        dt.Rows.Add(values);
                    }

                    dataGridView.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(emptyMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
        // --- Fin fonction générique ---

        // Nouvelle méthode pour remplir le DataGridView manuellement
        private void RemplirDataGridViewPatients(List<typeMetierService.Patient> patients)
        {
            /*guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.Rows.Clear();*/

            // Ajout des colonnes (adapter selon les besoins)
            //guna2DataGridView1.Columns.Add("NomPrenom", "Nom Prénom");
            //guna2DataGridView1.Columns.Add("Telephone", "Téléphone");
            //guna2DataGridView1.Columns.Add("Adresse", "Adresse");
            //guna2DataGridView1.Columns.Add("DateNaissance", "Date de Naissance");
            //guna2DataGridView1.Columns.Add("GroupeSanguin", "Groupe Sanguin");

            foreach (var patient in patients)
            {
                int rowIndex = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[rowIndex].Cells[0].Value = "";
/*                guna2DataGridView1.Rows[rowIndex].Cells[1].Value ="";
*/                guna2DataGridView1.Rows[rowIndex].Cells[2].Value = patient.NomPrenom;
                guna2DataGridView1.Rows[rowIndex].Cells[3].Value = patient.Email;
                guna2DataGridView1.Rows[rowIndex].Cells[4].Value = patient.TEL;
                guna2DataGridView1.Rows[rowIndex].Cells[5].Value = patient.Adresse;
/*                guna2DataGridView1.Rows[rowIndex].Cells[7].Value = patient.DateNaissance?.ToString("dd/MM/yyyy");
*/                // Pour le groupe sanguin, il faut vérifier la structure de l'objet
                //if (patient.GroupeSanguin != null)
                //{
                //    var codeProp = patient.GroupeSanguin.GetType().GetProperty("CodeGroupeSanguin");
                //    guna2DataGridView1.Rows[rowIndex].Cells[4].Value = codeProp != null ? codeProp.GetValue(patient.GroupeSanguin) : patient.GroupeSanguin.ToString();
                //}
                //else
                //{
                //    guna2DataGridView1.Rows[rowIndex].Cells[4].Value = "";
                //}
            }
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
