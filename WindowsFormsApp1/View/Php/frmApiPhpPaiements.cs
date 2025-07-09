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
    public partial class frmApiPhpPaiements : Form
    {
        public frmApiPhpPaiements()
        {
            InitializeComponent();
            LoadPaiementsInDataGridViewPHP();
        }

        public void LoadPaiementsInDataGridViewPHP()
        {
            try
            {
                // Remplace par ta méthode réelle pour récupérer les paiements
                var paiements = new List<dynamic> {
                    new { IdPaiement = 1, Montant = 100.0, Date = DateTime.Now, Moyen = "CB", Statut = "Validé" },
                    new { IdPaiement = 2, Montant = 50.0, Date = DateTime.Now, Moyen = "Espèces", Statut = "En attente" }
                };
                if (paiements != null && paiements.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdPaiement", typeof(int));
                    dt.Columns.Add("Montant", typeof(double));
                    dt.Columns.Add("Date", typeof(DateTime));
                    dt.Columns.Add("Moyen", typeof(string));
                    dt.Columns.Add("Statut", typeof(string));
                    foreach (var p in paiements)
                    {
                        dt.Rows.Add(p.IdPaiement, p.Montant, p.Date, p.Moyen, p.Statut);
                    }
                    dgPaiements.DataSource = dt;
                    dgPaiements.ColumnHeadersVisible = true;
                    dgPaiements.EnableHeadersVisualStyles = false;
                    dgPaiements.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 193, 7); // Jaune
                    dgPaiements.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dgPaiements.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgPaiements.AutoResizeColumnHeadersHeight();
                    dgPaiements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgPaiements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgPaiements.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des paiements : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
