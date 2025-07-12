using CrystalDecisions.ReportAppServer;
using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.View.Api
{
    public partial class frmApiPhpMoyenPayments : Form
    {
        public frmApiPhpMoyenPayments()
        {
            InitializeComponent();
            LoadMoyenPaymentsInDataGridViewPHP();
        }
        Utils utils = new Utils();

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


        /// <summary>
        /// Fonction pour récupérer la liste des spécialités depuis l'API PHP
        /// </summary>
        /// <returns></returns>
        public List<MoyenPayment> servGetListMoyenPaymentWithPhp()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<MoyenPayment>();
            // OBSOLETE: client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServeurApiPHP"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = client.GetAsync(System.Configuration.ConfigurationManager.AppSettings["gl2021/Values/GetEmployees"]).Result;
            string url = utils.BuildApiPhpUrl("getAll", "moyenpayments");
            // Utilisation de l'URL construite pour la requête
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MoyenPayment>>(responseData);
            }
            return services;
        }

        /// <summary>
        /// Fonction pour charger les spécialités dans le DataGridView
        /// </summary>
        public void LoadSpecialiteInDataGridViewPHP()
        {
            try
            {
                var moyenPayments = servGetListMoyenPaymentWithPhp();
                if (moyenPayments != null && moyenPayments.Count > 0)
                {
                    // Créer un DataTable pour le DataGridView
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Code Paiement", typeof(string));
                    dt.Columns.Add("Libellé", typeof(string));
                    dt.Columns.Add("Reference", typeof(string));
                    // Remplir le DataTable avec les données des spécialités
                    foreach (var moyenPayment in moyenPayments)
                    {
                        dt.Rows.Add(moyenPayment.CodePayment, moyenPayment.Libelle,moyenPayment.Libelle);
                    }

                    // Assigner le DataTable au DataGridView
                    dgMoyenPayments.DataSource = dt;

                    // Personnalisation de l'affichage pour Guna2DataGridView
                    dgMoyenPayments.ColumnHeadersVisible = true;
                    dgMoyenPayments.EnableHeadersVisualStyles = false;
                    dgMoyenPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
                    dgMoyenPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgMoyenPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgMoyenPayments.AutoResizeColumnHeadersHeight();
                    dgMoyenPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgMoyenPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgMoyenPayments.ReadOnly = true;
                }
                else
                {

                    MessageBox.Show("Aucun Moyen de Paiement trouvé ou erreur lors du chargement des données.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                utils.WriteDataError("frmApiPhpSpecialite/LoadSpecialiteInDataGridViewPHP", ex.ToString());
                Utils.WriteLogSystem(ex.ToString(), "WriteFileError");
                MessageBox.Show($"Erreur lors du chargement des spécialités : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
