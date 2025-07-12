using MetierRvMedical.Model;
using Microsoft.Extensions.Logging;
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
    public partial class frmApiPhpSpecialite : Form
    {
        public frmApiPhpSpecialite()
        {
            InitializeComponent();
        }
        Utils utils = new Utils();

        private void frmApiPhpSpecialite_Load(object sender, EventArgs e)
        {
            LoadSpecialiteInDataGridViewPHP();
        }
        /// <summary>
        /// Fonction pour récupérer la liste des spécialités depuis l'API PHP
        /// </summary>
        /// <returns></returns>
        public List<Specialite> servGetListSpecialiteWithPhp()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Specialite>();
            // OBSOLETE: client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServeurApiPHP"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = client.GetAsync(System.Configuration.ConfigurationManager.AppSettings["gl2021/Values/GetEmployees"]).Result;
            string url = utils.BuildApiPhpUrl("getAll", "specialites");
            // Utilisation de l'URL construite pour la requête
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Specialite>>(responseData);
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
                var specialites = servGetListSpecialiteWithPhp();
                if (specialites != null && specialites.Count > 0)
                {
                    // Créer un DataTable pour le DataGridView
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Code Specialite", typeof(string));
                    dt.Columns.Add("Nom Specialite", typeof(string));
                    // Remplir le DataTable avec les données des spécialités
                    foreach (var specialite in specialites)
                    {
                        dt.Rows.Add(specialite.CodeSpecialite, specialite.NomSpecialite);
                    }

                    // Assigner le DataTable au DataGridView
                    dgSoins.DataSource = dt;

                    // Personnalisation de l'affichage pour Guna2DataGridView
                    dgSoins.ColumnHeadersVisible = true;
                    dgSoins.EnableHeadersVisualStyles = false;
                    dgSoins.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
                    dgSoins.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgSoins.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgSoins.AutoResizeColumnHeadersHeight();
                    dgSoins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgSoins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgSoins.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Aucune spécialité trouvée ou erreur lors du chargement des données.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
