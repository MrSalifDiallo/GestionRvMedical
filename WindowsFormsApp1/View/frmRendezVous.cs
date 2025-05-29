using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using WindowsFormsApp1.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.Security.Cryptography;

namespace WindowsFormsApp1.View
{
    public partial class frmRendezVous : Form
    {
        //BdRvMedicalContext bd = new BdRvMedicalContext();
        bool patientTrouve = false;
        ServiceMetierGeneral.GeneralServiceClient serviceGeneral = new ServiceMetierGeneral.GeneralServiceClient(); // ✅ Service WCF for General Method
        ServiceMetierPatient.PatientServiceClient servicePatient = new ServiceMetierPatient.PatientServiceClient(); // ✅ Service WCF for All Model Patient Method
        ServiceMetierAgenda.AgendaServiceClient serviceAgenda = new ServiceMetierAgenda.AgendaServiceClient(); // ✅ Service WCF

        public frmRendezVous()
        {
            InitializeComponent();
            frmConfiuration();
        }

        private void frmConfiuration()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;  // Supprimer les boutons de contrôle
            this.ShowIcon = false;    // Supprimer l'icône
            this.ShowInTaskbar = false; // Ne pas afficher dans la barre des tâches
            txtSoin.Enabled = false;  // Désactivation du champ de prix
            //panel2.Visible = false;
            pnlimpression.Visible = false;
        }

        private void frmRendezVous_Load(object sender, EventArgs e)
        {
            ResetForm();
            DateTime selectedDate = dtRendezVous.Value.Date;
            GetTableCreneau(listView1, selectedDate);
            lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} :";
            LoadPhoneNumbers();
            //serviceAgenda.LoadAgenda(selectedDate);
            LoadBloodGroups();  // Charger les groupes sanguins
            cbbSoins.DataSource = LoadCbbSoins();
            cbbSoins.DisplayMember = "Text";  // Ce que tu veux afficher dans le ComboBox
            cbbSoins.ValueMember = "Value";   // La valeur associée à chaque item

            cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);  // ComboBox avec les durées disponibles
            cbbDureeCreneaux.DisplayMember = "Text";
            cbbDureeCreneaux.ValueMember = "Value";

            cbbMedecin.DataSource=LoadCbbMedecin(selectedDate);
            cbbMedecin.DisplayMember = "Text";
            cbbMedecin.ValueMember = "Value";


        }

        private void LoadPhoneNumbers(int limit = 5)
        {
            var phoneList = serviceGeneral.GetPhoneNumbersForAutoComplete(limit);

            AutoCompleteStringCollection phoneCollection = new AutoCompleteStringCollection();
            phoneCollection.AddRange((string[])phoneList.ToArray());

            cbbTelephone.AutoCompleteCustomSource = phoneCollection;
            cbbTelephone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTelephone.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void LoadBloodGroups()
        {
            // Récupérer tous les groupes sanguins depuis la base de données

            var bloodGroups = serviceGeneral.GetListeGroupesSanguins();

            // Ajouter chaque groupe sanguin au ComboBox
            cbbGroupeSanguin.Items.Clear();  // Effacer les anciens items, si nécessaires
            foreach (var group in bloodGroups)
            {
                cbbGroupeSanguin.Items.Add(group.CodeGroupeSanguin); // Ajoute chaque groupe sanguin
            }
        }

        private List<SelectListView> LoadCbbSoins()
        {
            var allSoins = serviceGeneral.GetListSoins();
            List<SelectListView> ListeSoins = new List<SelectListView>();
            SelectListView def = new SelectListView();
            def.Text = "Selectionnez un soin...";
            def.Value = "";
            ListeSoins.Add(def);
            foreach (var onegrp in allSoins)
            {
                SelectListView a = new SelectListView();
                a.Text = onegrp.NameSoin;
                a.Value = onegrp.NameSoin.ToString();
                ListeSoins.Add(a);
            }
            return ListeSoins;

        }
        //private List<SelectListView> LoadCbbHoraireCreneau(DateTime daterecherche)
        //{
        //    ResetComboBox(cbbCreneauHoraire);
        //    int leMedecin = 0;
        //    if (cbbMedecin.SelectedItem is SelectListView selectedItem &&
        //        int.TryParse(selectedItem.Value, out int id))
        //    {
        //        leMedecin = id;
        //    }
        //    //int leMedecin = 0;
        //    //if (cbbMedecin.SelectedItem is SelectListView selectedItem &&
        //    //    int.TryParse(selectedItem.Value, out int id))
        //    //{
        //    //    leMedecin = id;
        //    //}

        //    //ListeHoraireCreneau.Add(CreateDefaultItem("Sélectionnez un créneau horaire..."));

        //    //var creneaux = (leMedecin == 0)
        //    //    ? serviceAgenda.CreneauxByHoraire(daterecherche)
        //    //        .Where(c => c.ContainsKey("horaire") && c.ContainsKey("creneau"))
        //    //        .Select(c => new
        //    //        {
        //    //            Horaire = c["horaire"]?.ToString(),
        //    //            Creneau = c["creneau"]?.ToString(),
        //    //            MedecinId = c.ContainsKey("idMedecin") && c["idMedecin"] != null
        //    //                        ? Convert.ToInt32(c["idMedecin"])
        //    //                        : 0
        //    //        })
        //    //        .ToList()
        //    //    : serviceAgenda.CreneauxByHoraireMedecin(daterecherche, leMedecin)
        //    //        .Where(c => c.ContainsKey("horaire") && c.ContainsKey("creneau"))
        //    //        .Select(c => new
        //    //        {
        //    //            Horaire = c["horaire"]?.ToString(),
        //    //            Creneau = c["creneau"]?.ToString(),
        //    //            MedecinId = leMedecin
        //    //        })
        //    //        .ToList();

        //    //foreach (var item in creneaux)
        //    //{
        //    //    ListeHoraireCreneau.Add(new SelectListView
        //    //    {
        //    //        Text = item.Horaire,
        //    //        Value = $"{item.Creneau}-{item.MedecinId}"
        //    //    });
        //    //}

        //    return ListeHoraireCreneau;

        //}
        private List<SelectListView> LoadCbbMedecin(DateTime selectedDate)
        {
            // Liste de médecins
            List<SelectListView> ListeMedecins = new List<SelectListView>();

            // Ajouter un élément par défaut
            SelectListView def = new SelectListView();
            ListeMedecins.Add(CreateDefaultItem("Sélectionnez un médecin..."));
            var medecinsDisponibles = serviceAgenda.LoadCreneauxByDate(selectedDate)
                            .Where(c => c["date"].ToString() == selectedDate.ToString("yyyy-MM-dd") &&
                                        Convert.ToBoolean(c["estOccupe"]) == false)
                            .GroupBy(c => Convert.ToInt32(c["idMedecin"]))
                            .Select(g => g.First())
                            .Select(c => new
                            {
                                IdMedecin = Convert.ToInt32(c["idMedecin"]),
                                Medecin = c["medecin"].ToString(),
                                Creneau = c["creneau"].ToString(),
                                Date = c["date"].ToString(),
                                HeureDebut = c["heureDebut"].ToString(),
                                HeureFin = c["heureFin"].ToString()
                            })
                            .ToList();
            // Ajouter les médecins au ComboBox
            foreach (var medecindispo in medecinsDisponibles)
            {
                SelectListView item = new SelectListView();
                item.Text = medecindispo.Medecin; // Corrected to directly use the Medecin property
                item.Value = medecindispo.IdMedecin.ToString(); // Convert the integer IdMedecin to a string
                ListeMedecins.Add(item);
            }

            return ListeMedecins;
        }

        private List<SelectListView> LoadCbbDureeCreneaux(DateTime selectedDate, int? idMedecin = null)
        {
            // Liste des creneaux disponibles pour la date sélectionnée
            List<SelectListView> ListeDureeCreneaux = new List<SelectListView>();
                var Creneaux = (idMedecin == null) ?
                    serviceAgenda.LoadCreneauxByDate(selectedDate)
                    .Where(c =>
                    c["date"].ToString() == selectedDate.ToString("yyyy-MM-dd")
                    &&
                    Convert.ToBoolean(c["estOccupe"]) == false
                    )
                    .GroupBy(c => Convert.ToString(c["creneau"]))
                    .Select(g => g.First())
                    .Select(c => new
                    {
                        Creneau = c["creneau"].ToString(),
                        Date = c["date"].ToString(),
                    })
                    .ToList()
                    :
                    //Si on a l'id du medecin
                    serviceAgenda.LoadCreneauxByDate(selectedDate)
                .Where(c =>
                    c["date"].ToString() == selectedDate.ToString("yyyy-MM-dd") &&
                    Convert.ToBoolean(c["estOccupe"]) == false &&
                    (Convert.ToInt32(c["idMedecin"]) == idMedecin.Value)
                )
                .GroupBy(c => Convert.ToString(c["creneau"]))
                .Select(g => g.First())
                .Select(c => new
                {
                    Creneau = c["creneau"].ToString(),
                    Date = c["date"].ToString(),
                })
                .ToList();
            if (Creneaux.Any())
            {
                // Ajouter un élément par défaut
                if (Creneaux.Count()>1)
                {
                    ListeDureeCreneaux.Add(CreateDefaultItem("Sélectionnez un créneau..."));
                    foreach (var oneCreneau in Creneaux)
                    {
                        SelectListView item = new SelectListView();
                        item.Text = oneCreneau.Creneau; // Corrected to directly use the Medecin property
                        item.Value = oneCreneau.Creneau.ToString(); // Convert the integer IdMedecin to a string
                        ListeDureeCreneaux.Add(item);
                    }
                }
                else
                {
                    if (Creneaux.Count() == 1)
                    {
                        foreach (var oneCreneau in Creneaux)
                        {
                            SelectListView item = new SelectListView();
                            item.Text = oneCreneau.Creneau; // Corrected to directly use the Medecin property
                            item.Value = oneCreneau.Creneau.ToString(); // Convert the integer IdMedecin to a string
                            ListeDureeCreneaux.Add(item);
                        }
                    }
                    else
                    {
                        // Ajouter un élément par défaut
                        ListeDureeCreneaux.Add(CreateDefaultItem("Aucune Durée Creneau..."));
                    }
                }

            }
            else
            {
                // Ajouter un élément par défaut
                ListeDureeCreneaux.Add(CreateDefaultItem("Aucune Durée Creneau..."));
            }

            return ListeDureeCreneaux;
        }


        private void ResetForm()
        {
            txtNomPrenom.Clear();
            txtAdresse.Clear();
            txtEmail.Clear();
            txtPoids.Clear();
            txtTaille.Clear();
            cbbGroupeSanguin.SelectedIndex = -1;
            cbbTelephone.SelectedIndex = -1;
        }

        private void btnRenitialiser_Click(object sender, EventArgs e)
        {
            ResetForm();
            cbbTelephone.Text = string.Empty;  // Réinitialiser aussi le champ téléphone
            EnableAllFields();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            // Validation ou enregistrement des données si nécessaire
            MessageBox.Show("Données validées.");
            //panel2.Visible = true;
            pnlimpression.Visible = true;
        }

        private void cbbTelephone_TextChanged(object sender, EventArgs e)
        {
           // LoadPhoneNumbers();
            // Si le texte dans cbbTelephone change, on vérifie si le numéro correspond à un patient
            var phoneParts = cbbTelephone.Text.Split(new string[] { " - " }, StringSplitOptions.None);
            string phoneNumber = phoneParts[0].Trim(); // On prend uniquement le numéro

            // Charger les données du patient correspondant au numéro de téléphone
            UpdatePatientDetails(phoneNumber);
        }
        /// <summary>
        /// Cette fonction va permettre de supprimer le nom prenom dans le champs Telephone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbTelephone_Leave(object sender, EventArgs e)
        {
            // Lorsqu'on quitte le champ, on vérifie le numéro saisi
            var phoneParts = cbbTelephone.Text.Split(new string[] { " - " }, StringSplitOptions.None);
            if (phoneParts.Length > 0)
            {
                string phoneNumber = phoneParts[0].Trim(); // On garde uniquement le numéro de téléphone
                cbbTelephone.Text = phoneNumber; // Remet le numéro dans le champ
                patientTrouve = true;
            }
            else
            {
                patientTrouve = false;
                cbbTelephone.Text = string.Empty; // Si le champ est vide, on efface tout
            }
        }

        private void cbbTelephone_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lorsque l'utilisateur sélectionne une valeur dans la liste d'autocomplétion
            var selectedText = cbbTelephone.SelectedItem.ToString();
            var phoneParts = selectedText.Split(new string[] { " - " }, StringSplitOptions.None);

            if (phoneParts.Length > 0)
            {
                string phoneNumber = phoneParts[0].Trim(); // Garder uniquement le numéro de téléphone
                cbbTelephone.Text = phoneNumber; // Mettre à jour le champ avec le numéro
                UpdatePatientDetails(phoneNumber); // Mettre à jour les détails du patient
                // Recherche du patient correspondant au numéro de téléphone
            }
        }

        private void UpdatePatientDetails(string phoneNumberInput)
        {
            var patient=servicePatient.ResearchPatient(phoneNumberInput);
            if (patient != null) {
                // Si un patient est trouvé, on remplit les champs du formulaire avec les données du patient
                patientTrouve = true;
                txtNomPrenom.Text = patient.NomPrenom ?? string.Empty;
                txtAdresse.Text = patient.Adresse ?? string.Empty;
                txtEmail.Text = patient.Email ?? string.Empty;
                txtPoids.Text = patient.Poids?.ToString() ?? string.Empty;
                txtTaille.Text = patient.Taille?.ToString() ?? string.Empty;
                //cbbGroupeSanguin.SelectedItem = patient.GroupeSanguin.CodeGroupeSanguin;
                // Remplir le groupe sanguin dans le combo box
                if (patient.GroupeSanguin != null)
                {
                    cbbGroupeSanguin.SelectedItem = patient.GroupeSanguin.CodeGroupeSanguin ?? string.Empty;
                }
                DisableFields(patient);
            }
            else
            {
                // Si aucun patient n'est trouvé, on vide les champs
                patientTrouve = false;
                ResetForm();
                EnableAllFields();
            }
        }

        private void DisableFields(ServiceMetierPatient.Patient servicePatient)
        {
            // Convert the ServiceMetierPatient.Patient to WindowsFormsApp1.Model.Patient
            
            // Activer les champs si la valeur est null ou vide, sinon désactiver les champs
            txtNomPrenom.Enabled = string.IsNullOrEmpty(servicePatient.NomPrenom);
            txtAdresse.Enabled = string.IsNullOrEmpty(servicePatient.Adresse);
            txtEmail.Enabled = string.IsNullOrEmpty(servicePatient.Email);
            txtPoids.Enabled = servicePatient.Poids == null || servicePatient.Poids == 0; // Peut aussi vérifier si Poids est égal à 0 (si c'est le cas)
            txtTaille.Enabled = servicePatient.Taille == null || servicePatient.Taille == 0; // Même logique pour la taille
            cbbGroupeSanguin.Enabled = string.IsNullOrEmpty(servicePatient.GroupeSanguin?.CodeGroupeSanguin); // Vérifie si le groupe sanguin est null ou vide
        }

        private void EnableAllFields()
        {
            // Activer tous les champs de saisie
            txtNomPrenom.Enabled = true;
            txtAdresse.Enabled = true;
            txtEmail.Enabled = true;
            txtPoids.Enabled = true;
            txtTaille.Enabled = true;
            cbbGroupeSanguin.Enabled = true;  // Activer le ComboBox du groupe sanguin
        }

        private void btnImpression_Click(object sender, EventArgs e)
        {
            frmPrintTicket frmPrintTicket = new frmPrintTicket();
            frmPrintTicket.Show();
        }

        private void GetTableCreneau(ListView listView,DateTime date, int? idMedecin = null)
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

            //Remplissage combo box creneaux
            List<SelectListView> ListeHoraireCreneaux = new List<SelectListView>();
           // ResetComboBox(cbbCreneauHoraire);
            ListeHoraireCreneaux = LoadCbbDureeCreneaux(date,null);
            //ListeHoraireCreneaux.Add(CreateDefaultItem("Sélectionnez un créneau horaire..."));

            var typesCreneaux = serviceAgenda.ListeTimeCreneau(date);
            if (typesCreneaux != null && typesCreneaux.Any())
            {
                // La liste n’est pas vide → on peut l’utiliser
                lblTabMessage.Text = "";
            }
            else
            {
                // La liste est vide OU nulle → rien à afficher / à faire
                lblTabMessage.Text= "Aucun créneau disponible pour cette date.";
                ListeHoraireCreneaux = LoadCbbDureeCreneaux(date,null);
                cbbCreneauHoraire.DataSource = ListeHoraireCreneaux;
                cbbCreneauHoraire.DisplayMember = "Text";
                cbbCreneauHoraire.ValueMember = "Value";
            }

            int nombrecreneau = 0;

            foreach (var typeCreneau in typesCreneaux)
            {
                var tousCreneaux = (idMedecin == null)
                ? serviceAgenda.CreneauxByHoraire(date)
                    .Where(c => c["TimeCreneau"].ToString() == typeCreneau.ToString())
                    .ToList()
                : serviceAgenda.CreneauxByHoraireMedecin(date, (int)idMedecin)
                    .Where(c => c["TimeCreneau"].ToString() == typeCreneau.ToString())
                    .ToList();
                if (tousCreneaux.Count == 0)
                    continue;
                else
                {
                    int indexTitre = tousCreneaux.Count / 2;

                    for (int i = 0; i < tousCreneaux.Count; i++)
                    {
                        var creneau = tousCreneaux[i];
                        var texteCreneau = (i == indexTitre) ? $"{typeCreneau} min" : "";
                        int libre = creneau.ContainsKey("libre") && creneau["libre"] != null ? Convert.ToInt32(creneau["libre"]) : 0;
                        int occupe = creneau.ContainsKey("occupe") && creneau["occupe"] != null ? Convert.ToInt32(creneau["occupe"]) : 0;

                        string dispoTexte;
                        string occupeTexte;
                        if (idMedecin == null)
                        {
                            
                            string suffixLibre = libre > 1 ? "s" : "";
                            string suffixOccupe = occupe > 1 ? "s" : "";

                            dispoTexte = $"{libre} libre{suffixLibre}";
                            occupeTexte = $"{occupe} occupé{suffixOccupe}";
                        }
                        else
                        {
                            if (libre>=1)
                            {
                                dispoTexte = "Disponible";
                                occupeTexte = "-";
                            }
                            else
                            {
                                dispoTexte = "-";
                                occupeTexte = "Indisponible";
                            }
                           
                        }

                            var item = new ListViewItem(new[]
                            {
                        texteCreneau,
                        creneau["horaire"].ToString(),
                        creneau["nombre"].ToString(),
                        dispoTexte,
                        occupeTexte,
                    });
                        ListeHoraireCreneaux.Add(new SelectListView
                        {
                            Text = creneau["horaire"].ToString(),
                            Value = creneau["horaire"].ToString()
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
                }
                // Ligne de séparation
                var separator = new ListViewItem(new[]
                {
                    "────────────", "────────────────────────", "────────────", "────────────", "────────────"
                });
                separator.ForeColor = Color.Gray;
                separator.Font = new Font(listView.Font, FontStyle.Italic);
                listView.Items.Add(separator);
                nombrecreneau = +1;
            }
            lblMessageCreneaux.Text = $"Créneaux disponibles pour le {date.ToShortDateString()} :{nombrecreneau}";
        }
        private void dtRendezVous_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtRendezVous.Value.Date;
            lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} :";
            GetTableCreneau(listView1, selectedDate);
            cbbMedecin.DataSource = LoadCbbMedecin(selectedDate);
            
        }
        private void ResetComboBox(ComboBox comboBox)
        {
            comboBox.DataSource = null;
            comboBox.Items.Clear();
        }


        private SelectListView CreateDefaultItem(string text) =>
        new SelectListView { Text = text, Value = "" };

        private void cbbSoins_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbSoins.SelectedItem != null)
            {
                SelectListView selectedItem = (SelectListView)cbbSoins.SelectedItem;
                // Rechercher le soin correspondant dans la base de données
                var allSoins = serviceGeneral.GetListSoins();
                var selectedSoin = allSoins
                                           .FirstOrDefault(gs => gs.NameSoin == selectedItem.Value);

                if (selectedSoin != null)
                {
                    txtSoin.Text = selectedSoin.Price.ToString();
                }
                else
                {
                    txtSoin.Text = string.Empty; // Réinitialiser le champ de prix
                    return;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un soin.");
                txtSoin.Text = string.Empty; // Réinitialiser le champ de prix
                return;
            }
        }

        private void cbbMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtRendezVous.Value.Date;
            // Nettoyage d'abord
            cbbDureeCreneaux.DataSource = null;
            cbbDureeCreneaux.Items.Clear();
            if (cbbMedecin.SelectedItem is SelectListView selectedMedecin &&
                int.TryParse(selectedMedecin.Value, out int idMedecin) &&
                idMedecin != 0)
            {
                GetTableCreneau(listView1,selectedDate, idMedecin);
                var listeCreneaux = LoadCbbDureeCreneaux(selectedDate, idMedecin);

                cbbDureeCreneaux.DataSource = listeCreneaux;
                cbbDureeCreneaux.DisplayMember = "Text";
                cbbDureeCreneaux.ValueMember = "Value";

                //lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} : {selectedMedecin.Text}";
            }
            else
            {
                LoadCbbDureeCreneaux(selectedDate);
                //lblMessageCreneaux.Text = $"Aucun créneau disponible pour le {selectedDate.ToShortDateString()}";
            }

        }

        private void cbbMedecin_TextChanged(object sender, EventArgs e)
        {
            string texteTape = cbbMedecin.Text?.Trim().ToLower();
            var correspondance = cbbMedecin.Items.Cast<SelectListView>()
                .FirstOrDefault(item => item.Text.Trim().ToLower() == texteTape);
            DateTime selectedDate = dtRendezVous.Value.Date;
            if (correspondance != null)
            {
                // On force la sélection si ça correspond
                cbbMedecin.SelectedItem = correspondance;

                // On recharge les créneaux pour ce médecin

                if (int.TryParse(correspondance.Value, out int idMedecin))
                {
                    ResetComboBox(cbbDureeCreneaux);
                    cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
                    //lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} : {correspondance.Text}";
                }
                else
                {
                    // Valeur invalide
                    ResetComboBox(cbbDureeCreneaux);
                    cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
                    //lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()}";
                    LoadCbbDureeCreneaux(selectedDate);
                    GetTableCreneau(listView1, selectedDate);
                }
            }
            else
            {
                // Aucun médecin correspondant
                //cbbDureeCreneaux.Items.Clear();
                ResetComboBox(cbbDureeCreneaux);
                cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
                GetTableCreneau(listView1, selectedDate);
                // lblMessageCreneaux.Text = "Aucun médecin correspondant.";
            }
        }

        private void cbbDureeCreneaux_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbCreneauHoraire_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtRendezVous.Value.Date;
            GetTableCreneau(listView1, selectedDate);
        }


    }
}
