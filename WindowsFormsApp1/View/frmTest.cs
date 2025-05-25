using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.View
{
    public partial class frmTest : Form
    {
        ServiceMetierAgenda.AgendaServiceClient serviceAgenda = new ServiceMetierAgenda.AgendaServiceClient(); // ✅ Service WCF
        public frmTest()
        {
            InitializeComponent();
            
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Creneau", typeof(int));
            table.Columns.Add("Horaires", typeof(string));
            table.Columns.Add("Nombre", typeof(int));
            table.Columns.Add("Medecin", typeof(string));
            table.Columns.Add("Disponible", typeof(string));

            table.Rows.Add(15, "08h00 - 08h15\n08h15 - 08h30\n08h30 - 08h45\n08h45 - 09h00", 4, "Dr. Kouadio", "08h15 - 08h30\n08h45 - 09h00");
            table.Rows.Add(30, "09h00 - 09h30\n09h30 - 10h00", 2, "Dr. Konan", "09h30 - 10h00");
            table.Rows.Add(45, "10h00 - 10h45\n10h45 - 11h30", 2, "Dr. Ouattara", "10h45 - 11h30");
            //dtGridView1 = new DataGridView();
            dtGridView1.DataSource = table;
            dtGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //For ListView
            ChargerDonneesBrutes(listView1);
            //listView1.View = System.Windows.Forms.View.Details;
            //listView1.Columns.Add("Creneau", 70);
            //listView1.Columns.Add("Horaire", 120);
            //listView1.Columns.Add("Medecin", 120);
            //listView1.Columns.Add("Disponible", 80);

            //// Exemple : 15 min pour Dr Kouadio            
            ////listView1.Items.Add(new ListViewItem(new[] { "", "", "", "" }));
            //listView1.Items.Add(new ListViewItem(new[] { "", "08h00 - 08h15", "Dr. Kouadio", "Non" }));
            //listView1.Items.Add(new ListViewItem(new[] { "--- 15 min ---", "08h15 - 08h30", "Dr. Kouadio", "Oui" }));
            //listView1.Items.Add(new ListViewItem(new[] { "", "08h30 - 08h45", "Dr. Kouadio", "Non" }));
            //listView1.Items.Add(new ListViewItem(new[] { "", "08h45 - 09h00", "Dr. Kouadio", "Oui" }));

            //// Exemple : 30 min pour Dr Konan
            //listView1.Items.Add(new ListViewItem(new[] { "", "", "", "" }));
            //listView1.Items.Add(new ListViewItem(new[] { "--- 30 min ---", "09h00 - 09h30", "Dr. Konan", "Non" }));
            //listView1.Items.Add(new ListViewItem(new[] { "", "09h30 - 10h00", "Dr. Konan", "Oui" }));





            //For TableLayout
            var horaires = new List<string> { "08h00 - 08h15", "08h15 - 08h30", "08h30 - 08h45", "08h45 - 09h00" };
            var dispo = new HashSet<string> { "08h15 - 08h30", "08h45 - 09h00" };

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = horaires.Count + 1;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // Entêtes
            tableLayoutPanel1.Controls.Add(new Label { Text = "Horaire", AutoSize = true }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label { Text = "Disponible", AutoSize = true }, 1, 0);

            // Lignes
            for (int i = 0; i < horaires.Count; i++)
            {
                var horaire = horaires[i];
                tableLayoutPanel1.Controls.Add(new Label { Text = horaire, AutoSize = false }, 0, i + 1);

                bool isDispo = dispo.Contains(horaire);
                var checkbox = new CheckBox { Checked = !isDispo };
                tableLayoutPanel1.Controls.Add(checkbox, 1, i + 1);
            }

            treeView1.Nodes.Clear();

            // Exemple : Groupe 15 min
            TreeNode node15 = new TreeNode("Créneau : 15 minutes");

            node15.Nodes.Add(new TreeNode("08h00 - 08h15 | Dr. Kouadio | Non disponible"));
            node15.Nodes.Add(new TreeNode("08h15 - 08h30 | Dr. Kouadio | ✅ Disponible"));
            node15.Nodes.Add(new TreeNode("08h30 - 08h45 | Dr. Kouadio | Non disponible"));
            node15.Nodes.Add(new TreeNode("08h45 - 09h00 | Dr. Kouadio | ✅ Disponible"));

            treeView1.Nodes.Add(node15);

            // Exemple : Groupe 30 min
            TreeNode node30 = new TreeNode("Créneau : 30 minutes");

            node30.Nodes.Add(new TreeNode("09h00 - 09h30 | Dr. Konan | Non disponible"));
            node30.Nodes.Add(new TreeNode("09h30 - 10h00 | Dr. Konan | ✅ Disponible"));

            treeView1.Nodes.Add(node30);

            // Optionnel : tout déplier par défaut
            treeView1.ExpandAll();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChargerDonneesBrutes(ListView listView)
        {
            listView.Items.Clear();
            listView.View = System.Windows.Forms.View.Details;
            listView.FullRowSelect = true;

            // Colonnes
            listView.Columns.Clear();
            listView.Columns.Add("Creneau", 100);
            listView.Columns.Add("Horaire", 75);
            listView.Columns.Add("Nombre", 49);
            listView.Columns.Add("Disponible", 100);
            listView.Columns.Add("Occupé", 100);

            DateTime date = new DateTime(2025, 5, 21);

            var typesCreneaux = serviceAgenda.ListeTimeCreneau(date,null);

            foreach (var typeCreneau in typesCreneaux)
            {
                var tousCreneaux = serviceAgenda.CreneauxByHoraire(date)
                                     .Where(c => c["TimeCreneau"].ToString() == typeCreneau.ToString())
                                     .ToList();

                if (tousCreneaux.Count == 0)
                    continue;

                int indexTitre = tousCreneaux.Count / 2;

                for (int i = 0; i < tousCreneaux.Count; i++)
                {
                    var creneau = tousCreneaux[i];
                    var texteCreneau = (i == indexTitre) ? $"{typeCreneau} min" : "";

                    int libre = Convert.ToInt32(creneau["libre"]);
                    int occupe = Convert.ToInt32(creneau["occupe"]);

                    string dispoTexte = $"{libre} libre(s)";
                    string occupeTexte = $"{occupe} occupé(s)";

                    var item = new ListViewItem(new[]
                    {
                texteCreneau,
                creneau["horaire"].ToString(),
                creneau["nombre"].ToString(),
                dispoTexte,
                occupeTexte,
            });

                    item.UseItemStyleForSubItems = false;

                    if (i == indexTitre)
                    {
                        item.SubItems[0].ForeColor = Color.Black;
                        item.SubItems[0].Font = new Font(listView.Font, FontStyle.Bold);
                    }

                    Color dispoColor = libre < 1 ? Color.Red : Color.Green;

                    for (int col = 1; col <= item.SubItems.Count - 1; col++)
                    {
                        item.SubItems[col].ForeColor = dispoColor;
                    }

                    listView.Items.Add(item);
                }

                // Ligne de séparation
                var separator = new ListViewItem(new[]
                {
            "────────────", "────────────────────────", "────────────", "────────────", "────────────"
        });
                separator.ForeColor = Color.Gray;
                separator.Font = new Font(listView.Font, FontStyle.Italic);
                listView.Items.Add(separator);
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //        // -------- Données 15 min --------
        //        var items15 = new List<string[]>
        //{
        //    new[] { "", "08h00 - 08h15", "Dr. Kouadio", "Non" },
        //    new[] { "", "08h15 - 08h30", "Dr. Kouadio", "Oui" },
        //    new[] { "", "08h30 - 08h45", "Dr. Kouadio", "Non" },
        //    new[] { "", "08h45 - 09h00", "Dr. Kouadio", "Oui" }
        //};
        //        //items15.Add(new[] { "", "09h00 - 09h15", "Dr. Kouadio", "Non" });


        //        int index15 = items15.Count / 2; // fonctionne bien pour impair et pair
        //        items15[index15][0] = "15 min"; // Ajouter uniquement sur une ligne existante

        //        for (int i = 0; i < items15.Count; i++)
        //        {
        //            var ligne = items15[i];
        //            var item = new ListViewItem(ligne);
        //            item.UseItemStyleForSubItems = false;

        //            // Ligne du titre du creneau
        //            if (i == index15)
        //            {
        //                // Colonne 0 (Creneau) en noir gras
        //                item.SubItems[0].ForeColor = Color.Black;
        //                item.SubItems[0].Font = new Font(listView1.Font, FontStyle.Bold);
        //            }

        //            // Appliquer la couleur rouge/verte sur colonnes 1 à 3
        //            Color dispoColor = ligne[3] == "Non" ? Color.Red : Color.Green;

        //            for (int col = 1; col <= 3; col++)
        //            {
        //                item.SubItems[col].ForeColor = dispoColor;
        //            }

        //            listView1.Items.Add(item);
        //        }



        //        // Ligne de séparation (trait visuel)
        //        var separator = new ListViewItem(new[] { "────────────", "────────────────────────", "────────────────────────", "────────────" });
        //        separator.ForeColor = Color.Gray;
        //        separator.Font = new Font(listView1.Font, FontStyle.Italic);
        //        listView1.Items.Add(separator);


        //        // -------- Données 30 min --------
        //        var items30 = new List<string[]>
        //{
        //    new[] { "", "09h00 - 09h30", "Dr. Konan", "Non" },
        //    new[] { "", "09h30 - 10h00", "Dr. Konan", "Oui" }
        //};

        //        int index30 = items30.Count / 2;
        //        items30[index30][0] = "30 min";

        //        for (int i = 0; i < items30.Count; i++)
        //        {
        //            var ligne = items30[i];
        //            var item = new ListViewItem(ligne);
        //            item.UseItemStyleForSubItems = false;

        //            // Ligne du titre du creneau
        //            if (i == index30)
        //            {
        //                // Colonne 0 (Creneau) en noir gras
        //                item.SubItems[0].ForeColor = Color.Black;
        //                item.SubItems[0].Font = new Font(listView1.Font, FontStyle.Bold);
        //            }

        //            // Appliquer la couleur rouge/verte sur colonnes 1 à 3
        //            Color dispoColor = ligne[3] == "Non" ? Color.Red : Color.Green;

        //            for (int col = 1; col <= 3; col++)
        //            {
        //                item.SubItems[col].ForeColor = dispoColor;
        //            }

        //            listView1.Items.Add(item);
        //        }

        //    }

    }
}
