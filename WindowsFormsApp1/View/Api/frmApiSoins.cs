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
using WindowsFormsApp1.AllServiceMetier;

namespace WindowsFormsApp1.View.Api
{
    public partial class frmApiSoins : Form
    {
        public frmApiSoins()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Définit l'état du formulaire sur maximisé
            this.FormBorderStyle = FormBorderStyle.None; // Supprime la bordure du formulaire
        }

        private void frmApiSoins_Load(object sender, EventArgs e)
        {
            LoadSoinsInDataGridView();
        }

        // Fonction pour charger les soins dans le DataGridView
        public void LoadSoinsInDataGridView()
        {
            try
            {
                var soins = servGetListSoins();
                if (soins != null && soins.Count > 0)
                {
                    // Créer un DataTable pour le DataGridView
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID Soin", typeof(int));
                    dt.Columns.Add("Nom du Soin", typeof(string));
                    dt.Columns.Add("Durée", typeof(string));
                    dt.Columns.Add("Prix", typeof(int));
                    dt.Columns.Add("Catégorie", typeof(string));

                    // Remplir le DataTable avec les données des soins
                    foreach (var soin in soins)
                    {
                        dt.Rows.Add(soin.IdSoin, soin.NameSoin, soin.Duration, soin.Price, soin.Category);
                    }

                    // Assigner le DataTable au DataGridView
                    dtSoins.DataSource = dt;
                    
                }
                else
                {
                    MessageBox.Show("Aucun soin trouvé ou erreur lors du chargement des données.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des soins : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Soin> servGetListSoins()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Soin>();
            // OBSOLETE: client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServeurApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = client.GetAsync(System.Configuration.ConfigurationManager.AppSettings["gl2021/Values/GetEmployees"]).Result;
            var response = client.GetAsync("api/Soin/GetSoins").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Soin>>(responseData);
            }
            return services;
        }

        public bool AddSoin(Soin soin)
        {
            bool rep = false;
            string Id = soin.IdSoin > 0 ? soin.IdSoin.ToString() : "0";
            var values = new Dictionary<string, string>
                    {
                       { "IdSoin", Id },
                       { "NameSoin", soin.NameSoin },
                       { "Duration", soin.Duration },
                       { "Price", soin.Price.ToString() },
                       { "Category", soin.Category }
                    };
            var content = new FormUrlEncodedContent(values);
            try
            {
                using (var client = new HttpClient())
                {
                    // OBSOLETE: client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServeurApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync("api/Soin/PostSoin", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {

                    }

                }
            }
            catch (Exception ex)
            {

            }
            return rep;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
