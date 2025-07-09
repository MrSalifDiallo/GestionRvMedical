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
    public partial class frmApiPhpAgenda : Form
    {
        public frmApiPhpAgenda()
        {
            InitializeComponent();
            LoadAgendaInDataGridViewPHP();
        }

        public void LoadAgendaInDataGridViewPHP()
        {
            try
            {
                // Remplace par ta méthode réelle pour récupérer les agendas
                var agendas = new List<dynamic> {
                    new { IdAgenda = 1, Date = DateTime.Today, Medecin = "Dr. Diallo", Statut = "Ouvert" },
                    new { IdAgenda = 2, Date = DateTime.Today.AddDays(1), Medecin = "Dr. Manga", Statut = "Fermé" }
                };
                if (agendas != null && agendas.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdAgenda", typeof(int));
                    dt.Columns.Add("Date", typeof(DateTime));
                    dt.Columns.Add("Medecin", typeof(string));
                    dt.Columns.Add("Statut", typeof(string));
                    foreach (var a in agendas)
                    {
                        dt.Rows.Add(a.IdAgenda, a.Date, a.Medecin, a.Statut);
                    }
                    dgAgenda.DataSource = dt;
                    dgAgenda.ColumnHeadersVisible = true;
                    dgAgenda.EnableHeadersVisualStyles = false;
                    dgAgenda.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243); // Bleu clair
                    dgAgenda.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgAgenda.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgAgenda.AutoResizeColumnHeadersHeight();
                    dgAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgAgenda.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des agendas : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
