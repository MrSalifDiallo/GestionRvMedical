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
    public partial class frmApiPhpRv : Form
    {
        public frmApiPhpRv()
        {
            InitializeComponent();
            LoadRvInDataGridViewPHP();
        }

        public void LoadRvInDataGridViewPHP()
        {
            try
            {
                // Remplace par ta méthode réelle pour récupérer les rendez-vous
                var rvs = new List<dynamic> {
                    new { IdRv = 1, Patient = "Salif Diallo", Date = DateTime.Today, Statut = "Validé" },
                    new { IdRv = 2, Patient = "Ousseynou Manga", Date = DateTime.Today.AddDays(1), Statut = "En attente" }
                };
                if (rvs != null && rvs.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdRv", typeof(int));
                    dt.Columns.Add("Patient", typeof(string));
                    dt.Columns.Add("Date", typeof(DateTime));
                    dt.Columns.Add("Statut", typeof(string));
                    foreach (var rv in rvs)
                    {
                        dt.Rows.Add(rv.IdRv, rv.Patient, rv.Date, rv.Statut);
                    }
                    dgRv.DataSource = dt;
                    dgRv.ColumnHeadersVisible = true;
                    dgRv.EnableHeadersVisualStyles = false;
                    dgRv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 67, 54); // Rouge
                    dgRv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgRv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgRv.AutoResizeColumnHeadersHeight();
                    dgRv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgRv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgRv.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des rendez-vous : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
