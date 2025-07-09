using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View.Api
{
    public partial class frmApiPhpCreneaux : Form
    {
        public frmApiPhpCreneaux()
        {
            InitializeComponent();
            LoadCreneauxInDataGridViewPHP();
        }

        public void LoadCreneauxInDataGridViewPHP()
        {
            try
            {
                // Remplace par ta méthode réelle pour récupérer les créneaux
                var creneaux = new List<dynamic> {
                    new { IdCreneau = 1, Horaire = "08:00", Duree = "15 min", Disponible = true },
                    new { IdCreneau = 2, Horaire = "08:15", Duree = "15 min", Disponible = false }
                };
                if (creneaux != null && creneaux.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdCreneau", typeof(int));
                    dt.Columns.Add("Horaire", typeof(string));
                    dt.Columns.Add("Durée", typeof(string));
                    dt.Columns.Add("Disponible", typeof(bool));
                    foreach (var c in creneaux)
                    {
                        dt.Rows.Add(c.IdCreneau, c.Horaire, c.Duree, c.Disponible);
                    }
                    dgCreneaux.DataSource = dt;
                    dgCreneaux.ColumnHeadersVisible = true;
                    dgCreneaux.EnableHeadersVisualStyles = false;
                    dgCreneaux.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80); // Vert
                    dgCreneaux.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgCreneaux.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgCreneaux.AutoResizeColumnHeadersHeight();
                    dgCreneaux.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgCreneaux.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgCreneaux.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des créneaux : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
