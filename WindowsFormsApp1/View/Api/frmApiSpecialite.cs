using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetierRvMedical.Model;
using WindowsFormsApp1.Helper;
namespace WindowsFormsApp1.View.Api
{
    public partial class frmApiSpecialite : Form
    {
        public frmApiSpecialite()
        {
            InitializeComponent();
        }
        Utils utils = new Utils();
        private void RemplirDataGridViewPatients(List<Patient> patients)
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
    }
}
