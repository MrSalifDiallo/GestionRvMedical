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
    public partial class frmApiPhpMoyenPayments : Form
    {
        public frmApiPhpMoyenPayments()
        {
            InitializeComponent();
            LoadMoyenPaymentsInDataGridViewPHP();
        }

        public void LoadMoyenPaymentsInDataGridViewPHP()
        {
            try
            {
                // Remplace par ta méthode réelle pour récupérer les moyens de paiement
                var moyens = new List<dynamic> {
                    new { IdMoyen = 1, Libelle = "Carte Bancaire", Type = "CB" },
                    new { IdMoyen = 2, Libelle = "Espèces", Type = "Cash" }
                };
                if (moyens != null && moyens.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdMoyen", typeof(int));
                    dt.Columns.Add("Libelle", typeof(string));
                    dt.Columns.Add("Type", typeof(string));
                    foreach (var m in moyens)
                    {
                        dt.Rows.Add(m.IdMoyen, m.Libelle, m.Type);
                    }
                    dgMoyenPayments.DataSource = dt;
                    dgMoyenPayments.ColumnHeadersVisible = true;
                    dgMoyenPayments.EnableHeadersVisualStyles = false;
                    dgMoyenPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 188, 212); // Cyan
                    dgMoyenPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgMoyenPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgMoyenPayments.AutoResizeColumnHeadersHeight();
                    dgMoyenPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgMoyenPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgMoyenPayments.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des moyens de paiement : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
