using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class frmRendezVous : Form
    {
        //BdRvMedicalContext bd = new BdRvMedicalContext();
        bool patientTrouve = false;
        AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient(); // ✅ Service WCF for General Method
        //ServiceMetierGeneral.GeneralServiceClient serviceGeneral = new ServiceMetierGeneral.GeneralServiceClient(); // ✅ Service WCF for General Method
        //ServiceMetierPatient.PatientServiceClient servicePatient = new ServiceMetierPatient.PatientServiceClient(); // ✅ Service WCF for All Model Patient Method
        //ServiceMetierAgenda.AgendaServiceClient serviceAgenda = new ServiceMetierAgenda.AgendaServiceClient(); // ✅ Service WCF for Method Agenda
        //ServiceMetierRendezVous.RendezVousServiceClient serviceRendezVous = new ServiceMetierRendezVous.RendezVousServiceClient(); // ✅ Service WCF for Method Rendez Vous
        //ServiceMetierCreneau.CreneauxServiceClient serviceCreneau = new ServiceMetierCreneau.CreneauxServiceClient(); // ✅ Service WCF for Method Creneau
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
            DateTime selectedDate = new DateTime(2025, 05, 21);
            //DateTime selectedDate = dtRendezVous.Value.Date;
            dtRendezVous.Value = selectedDate;
            GetTableCreneau(listView1, new DateTime(2025, 05, 21));
           //lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} :";
            LoadPhoneNumbers();
            //serviceAgenda.LoadAgenda(selectedDate);
            LoadBloodGroups();  // Charger les groupes sanguins
            cbbSoins.DataSource = LoadCbbSoins();
            cbbSoins.DisplayMember = "Text";  // Ce que tu veux afficher dans le ComboBox
            cbbSoins.ValueMember = "Value";   // La valeur associée à chaque item

            //cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);  // ComboBox avec les durées disponibles
            cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(new DateTime(2025,05,21));  // ComboBox avec les durées disponibles
            cbbDureeCreneaux.DisplayMember = "Text";
            cbbDureeCreneaux.ValueMember = "Value";

            cbbMedecin.DataSource=LoadCbbMedecin(new DateTime(2025, 05, 21));
            cbbMedecin.DisplayMember = "Text";
            cbbMedecin.ValueMember = "Value";

            cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(new DateTime(2025, 05, 21));
            cbbCreneauHoraire.DisplayMember = "Text";
            cbbCreneauHoraire.ValueMember = "Value";
        }

        private void LoadPhoneNumbers(int limit = 5)
        {
            var phoneList = allService.GetPhoneNumbersForAutoComplete(limit);

            AutoCompleteStringCollection phoneCollection = new AutoCompleteStringCollection();
            phoneCollection.AddRange((string[])phoneList.ToArray());

            cbbTelephone.AutoCompleteCustomSource = phoneCollection;
            cbbTelephone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTelephone.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void LoadBloodGroups()
        {
            // Récupérer tous les groupes sanguins depuis la base de données

            var bloodGroups = allService.GetListeGroupesSanguins();

            // Ajouter chaque groupe sanguin au ComboBox
            cbbGroupeSanguin.Items.Clear();  // Effacer les anciens items, si nécessaires
            foreach (var group in bloodGroups)
            {
                cbbGroupeSanguin.Items.Add(group.CodeGroupeSanguin); // Ajoute chaque groupe sanguin
            }
        }

        private List<SelectListView> LoadCbbSoins()
        {
            var allSoins = allService.GetListSoins();
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
        
        private List<SelectListView> LoadCbbMedecin(DateTime selectedDate)
        {
            // Liste de médecins
            List<SelectListView> ListeMedecins = new List<SelectListView>();

            // Ajouter un élément par défaut
            SelectListView def = new SelectListView();
            var medecinsDisponibles = allService.LoadCreneauxByDate(selectedDate)
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
            if (medecinsDisponibles.Any())
            {
                ListeMedecins.Add(CreateDefaultItem("Sélectionnez un médecin..."));
                foreach (var medecindispo in medecinsDisponibles)
                {
                    SelectListView item = new SelectListView();
                    item.Text = medecindispo.Medecin; // Corrected to directly use the Medecin property
                    item.Value = medecindispo.IdMedecin.ToString(); // Convert the integer IdMedecin to a string
                    ListeMedecins.Add(item);

                }
            }
            else
            {
                ListeMedecins.Add(CreateDefaultItem("Aucun Médecin..."));
            }

                return ListeMedecins;
        }

        private List<SelectListView> LoadCbbDureeCreneaux(DateTime selectedDate, int? idMedecin = null)
        {
            // Liste des creneaux disponibles pour la date sélectionnée
            List<SelectListView> ListeDureeCreneaux = new List<SelectListView>();
                var Creneaux = (idMedecin == null) ?
                    allService.LoadCreneauxByDate(selectedDate)
                    .Where(c =>
                        c["date"].ToString() == selectedDate.ToString("yyyy-MM-dd")
                        &&
                        Convert.ToBoolean(c["estOccupe"]) == false
                    )
                    .GroupBy(c => Convert.ToString(c["creneau"]))
                    .Select(c => c.First())
                    .Select(c => new
                    {
                        Creneau = c["creneau"].ToString(),
                        Date = c["date"].ToString(),
                    })
                    .ToList()
                    :
                    //Si on a l'id du medecin
                    allService.LoadCreneauxByDate(selectedDate)
                    .Where(c =>
                        c["date"].ToString() == selectedDate.ToString("yyyy-MM-dd") 
                        &&
                        Convert.ToBoolean(c["estOccupe"]) == false 
                        &&
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
                    ListeDureeCreneaux.Add(CreateDefaultItem("Sélectionnez une durée..."));
                    foreach (var oneCreneau in Creneaux)
                    {
                        SelectListView item = new SelectListView();
                        item.Text = oneCreneau.Creneau; 
                        item.Value = oneCreneau.Creneau.ToString(); 
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


        private List<SelectListView> LoadCbbCreneauxHoraire(DateTime selectedDate, int? idMedecin = null, int?TimeCreneau=null)
        {
            // Liste des creneaux disponibles pour la date sélectionnée
            List<SelectListView> ListeDureeCreneaux = new List<SelectListView>();
            var Creneaux = (!idMedecin.HasValue) ?
                allService.CreneauxByHoraire(selectedDate)
                .Where(c =>Convert.ToBoolean(c["estOccupe"]) == false)
                .Select(c => new
                {
                    Horaire = c.ContainsKey("horaire") ? c["horaire"].ToString() : string.Empty,
                    DureeCreneau = c.ContainsKey("TimeCreneau") ? c["TimeCreneau"]:string.Empty
                })
                .ToList()
                :
                //Si on a l'id du medecin
                allService.CreneauxByHoraireMedecin(selectedDate, idMedecin.Value)
                .Where(c => Convert.ToBoolean(c["estOccupe"]) == false)
                .Select(c => new
                {
                    Horaire = c.ContainsKey("horaire") ? c["horaire"].ToString() : string.Empty,
                    DureeCreneau = c.ContainsKey("TimeCreneau") ? c["TimeCreneau"] : string.Empty
                })
                .ToList();
            if (Creneaux.Any())
            {
                // Ajouter un élément par défaut
                var specificCreneauByTime = (!TimeCreneau.HasValue) ?
                    Creneaux.ToList()
                    :
                    Creneaux.Where(c => c.DureeCreneau.ToString() == TimeCreneau.ToString())
                    .ToList();

                if (specificCreneauByTime.Count() > 1)
                {
                    ListeDureeCreneaux.Add(CreateDefaultItem("Sélectionnez un créneau..."));
                    foreach (var oneCreneau in specificCreneauByTime)
                    {
                        SelectListView item = new SelectListView();
                        item.Text = oneCreneau.Horaire; // Corrected to directly use the Medecin property
                        item.Value = oneCreneau.Horaire.ToString(); // Convert the integer IdMedecin to a string
                        ListeDureeCreneaux.Add(item);
                    }
                }
                else
                {
                    if (specificCreneauByTime.Count() == 1)
                    {
                        foreach (var oneCreneau in specificCreneauByTime)
                        {
                            SelectListView item = new SelectListView();
                            item.Text = oneCreneau.Horaire; // Corrected to directly use the Medecin property
                            item.Value = oneCreneau.Horaire.ToString(); // Convert the integer IdMedecin to a string
                            ListeDureeCreneaux.Add(item);
                        }
                    }
                    else
                    {
                        // Ajouter un élément par défaut
                        ListeDureeCreneaux.Add(CreateDefaultItem("Aucun Creneau Horaire..."));
                    }
                }

            }
            else
            {
                // Ajouter un élément par défaut
                ListeDureeCreneaux.Add(CreateDefaultItem("Aucun Creneau Horaire..."));
            }

            return ListeDureeCreneaux;
        }

        // ... existing code ...
        private bool ValidateComboBoxes()

        {
            // Si des erreurs existent, on les affiche
          
            StringBuilder erreurs = new StringBuilder();
            if (cbbMedecin.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbMedecin.SelectedItem).Value))
            {
                erreurs.AppendLine("Veuillez sélectionner un médecin.");
            }

            if (cbbDureeCreneaux.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbDureeCreneaux.SelectedItem).Value))
            {
                erreurs.AppendLine("Veuillez sélectionner une durée de créneau.");
            }

            if (cbbCreneauHoraire.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbCreneauHoraire.SelectedItem).Value))
            {
                erreurs.AppendLine("Veuillez sélectionner un créneau horaire.");
            }

            if (cbbSoins.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbSoins.SelectedItem).Value))
            {
                erreurs.AppendLine("Veuillez sélectionner un soin.");
            }
            if (erreurs.Length > 0)
            {
                MessageBox.Show(erreurs.ToString(), "Erreurs de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
        /// <summary>
        /// Pour faire une mise a jour des champs autocompletés apres une mise a jour du numéro du patient 
        /// </summary>
        /// <param name="phoneNumberInput"></param>
        private void UpdatePatientDetails(string phoneNumberInput)
        {
            var patient=allService.ResearchPatient(phoneNumberInput);
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

        /// <summary>
        /// Desactiver les champs apres une autocompletion a travers le numéro de patient
        /// </summary>
        /// <param name="servicePatient"></param>
        private void DisableFields(AllServiceMetier.Patient servicePatient)
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

        /// <summary>
        /// Pour activer les champs de patient a nouveau
        /// </summary>
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

        /// <summary>
        /// Pour remplir la liste view 
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="date"></param>
        /// <param name="idMedecin"></param>
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


            var typesCreneaux = allService.ListeTimeCreneau(date);
            if (typesCreneaux != null && typesCreneaux.Any())
            {
                // La liste n'est pas vide → on peut l'utiliser
                lblTabMessage.Text = "";
            }
            else
            {
                // La liste est vide OU nulle → rien à afficher / à faire
                lblTabMessage.Text= "Aucun créneau disponible pour cette date.";
            }

            int nombrecreneau = 0;

            foreach (var typeCreneau in typesCreneaux)
            {
                var tousCreneaux = (idMedecin == null)
                ? allService.CreneauxByHoraire(date)
                    .Where(c => c["TimeCreneau"].ToString() == typeCreneau.ToString())
                    .ToList()
                : allService.CreneauxByHoraireMedecin(date, (int)idMedecin)
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
            //Rechargement du tableau
            GetTableCreneau(listView1, selectedDate);
            //Rehargement des Medecins avec un creneau dispo avec cette date
            cbbMedecin.DataSource = LoadCbbMedecin(selectedDate);
            //Rechargement des Creneaux Dispos
            cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate);
            //Rechargement des Durées Créneaux de cette date
            cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
        }
        private SelectListView CreateDefaultItem(string text) =>
        new SelectListView { Text = text, Value = "" };

        private void cbbSoins_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbSoins.SelectedItem != null)
            {
                SelectListView selectedItem = (SelectListView)cbbSoins.SelectedItem;
                // Rechercher le soin correspondant dans la base de données
                var allSoins = allService.GetListSoins();
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
            
            //cbbDureeCreneaux.DataSource = null;
            //cbbDureeCreneaux.Items.Clear();
            if (cbbMedecin.SelectedItem is SelectListView selectedMedecin &&
                int.TryParse(selectedMedecin.Value, out int idMedecin) &&
                idMedecin != 0)
            {
                GetTableCreneau(listView1,selectedDate, idMedecin);
                cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate, idMedecin);
                cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate, idMedecin);
                lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} : {selectedMedecin.Text}";
            }
            else
            {
                GetTableCreneau(listView1, selectedDate);
                cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
                cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate);
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
                    //ResetComboBox(cbbDureeCreneaux);
                    lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} : {correspondance.Text}";
                    GetTableCreneau(listView1, selectedDate, idMedecin);
                    cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate, idMedecin);
                    cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate, idMedecin);
                }
                else
                {
                    // Valeur invalide
                    //ResetComboBox(cbbDureeCreneaux);
                    //cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
                    lblMessageCreneaux.Text = "Aucun médecin correspondant...";
                    GetTableCreneau(listView1, selectedDate);
                    cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
                    cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate);
                }
            }
            else
            {

                GetTableCreneau(listView1, selectedDate);
                cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);
                cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate);
                lblMessageCreneaux.Text = "Aucun médecin correspondant.";
            }
        }

        private void cbbDureeCreneaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtRendezVous.Value.Date;
            int selectedidMedecin = 0;
            if (cbbMedecin.SelectedItem is SelectListView selectedMedecin &&
                int.TryParse(selectedMedecin.Value, out selectedidMedecin))
            {
                if (cbbDureeCreneaux.SelectedItem is SelectListView selectedCreneau &&
                    int.TryParse(selectedCreneau.Value, out int dureecreneau))
                {
                    cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate, selectedidMedecin, dureecreneau);
                }
            }
            else
            {
                if (cbbDureeCreneaux.SelectedItem is SelectListView selectedCreneau &&
                    int.TryParse(selectedCreneau.Value, out int dureecreneau))
                {
                    cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate, null, dureecreneau);
                }
            }
        }

        private void cbbCreneauHoraire_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime selectedDate = dtRendezVous.Value.Date;
            //GetTableCreneau(listView1, selectedDate);
        }

        private void btnValidezRv_Click(object sender, EventArgs e)
        {
            if (ValidateComboBoxes())
            {
                ServiceMetierCreneau.Creneau creneau = new ServiceMetierCreneau.Creneau(); // ✅ Instance of WCF Service for Creneau
                ServiceMetierRendezVous.RendezVous serviceRendezVous = new ServiceMetierRendezVous.RendezVous(); // ✅ Instance of WCF Service for RendezVous

                // Heure de début (ex: "08:00 - 08:15" → on garde juste "08:00")
                string horaire = ((SelectListView)cbbCreneauHoraire.SelectedItem).Value;
                string heureDebutStr = horaire.Substring(0, 5); // "08:00"
                creneau.HeureDebut = heureDebutStr;

                // Durée en minutes (ex: "15")
                int dureeMinutes = int.Parse(((SelectListView)cbbDureeCreneaux.SelectedItem).Value);

                // Calcul de l'heure de fin
                DateTime heureDebut = DateTime.ParseExact(heureDebutStr, "HH:mm", null);
                DateTime heureFin = heureDebut.AddMinutes(dureeMinutes);
                creneau.HeureFin = heureFin.ToString("HH:mm");
                creneau.IdAgenda = Convert.ToInt32(((SelectListView)cbbMedecin.SelectedItem).Value); // Id du médecin sélectionné

            }
            ;
            //if (ValidateComboBoxes())
            //{
            //    btnValidezRv.Enabled = false;
            //}
            //else
            //{
            //    btnValidezRv.Enabled = true;
            //}
        }
    }
}
