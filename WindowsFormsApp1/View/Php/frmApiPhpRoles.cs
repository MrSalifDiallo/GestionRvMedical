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
using MetierRvMedical.Model;
namespace WindowsFormsApp1.View.Api
{
    public partial class frmApiPhpRoles : Form
    {
        public frmApiPhpRoles()
        {
            InitializeComponent();
            LoadRolesInDataGridViewPHP();
        }


        Utils utils = new Utils();
        public void LoadRolesInDataGridViewPHP()
        {
            try
            {
                // Remplace par ta méthode réelle pour récupérer les rôles
                var Roles = servGetListRolesWithPhp();
                if (Roles != null && Roles.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Code", typeof(string));
                    dt.Columns.Add("Description", typeof(string));
                    foreach (var r in Roles)
                    {
                        dt.Rows.Add(r.Code, r.Description);
                    }
                    dgRoles.DataSource = dt;
                    dgRoles.ColumnHeadersVisible = true;
                    dgRoles.EnableHeadersVisualStyles = false;
                    dgRoles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176); // Violet
                    dgRoles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgRoles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgRoles.AutoResizeColumnHeadersHeight();
                    dgRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgRoles.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des rôles : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public List<Role> servGetListRolesWithPhp()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Role>();
            // OBSOLETE: client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
            client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServeurApiPHP"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = client.GetAsync(System.Configuration.ConfigurationManager.AppSettings["gl2021/Values/GetEmployees"]).Result;
            string url = utils.BuildApiPhpUrl("getAll", "Roles");
            // Utilisation de l'URL construite pour la requête
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Role>>(responseData);
            }
            return services;
        }

    }
}
