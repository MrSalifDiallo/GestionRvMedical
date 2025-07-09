using CrystalDecisions.Windows.Forms;
using MetierRvMedical.Wcf;
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
using WindowsFormsApp1.AllServiceMetier;
using WindowsFormsApp1.Model;
using typeMetierService=MetierRvMedical.Model;

namespace WindowsFormsApp1.View
{
    public partial class frmRendezVous : Form
    {
        
        //BdRvMedicalContext bd = new BdRvMedicalContext();
        bool patientTrouve = false;
        AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient(); // ✅ Service WCF for General Method
        DateTime todayDate = DateTime.Now; // Date du jour
        typeMetierService.InfosRendezVous infos = new typeMetierService.InfosRendezVous();
        DateTime selectedDate = new DateTime(2025, 05, 21);
        typeMetierService.Patient patientInfos = new typeMetierService.Patient();

        private StringBuilder erreurs = new StringBuilder(); // Pour stocker les erreurs de validation
        private FormValidator formValidator;
        private FormValidator formValidator2;
        public frmRendezVous()
        {
            InitializeComponent();
            frmConfiguration();

            formValidator = new FormValidator(toolTip1, btnValidezRv, ValidateAndGetErrorsDual, gunaLabel1);
            formValidator2 = new FormValidator(toolTip1, btnPrevisualisez, ValidateAndGetErrorsDual, gunaLabel1);

            // Appel DRY
            var comboBoxes = new[] { cbbMedecin, cbbSoins, cbbDureeCreneaux, cbbCreneauHoraire, cbbGroupeSanguin };
            var textBoxes = new[] { txtPoids, txtTaille };
            var datePickers = new[] { dtDateNaissance };
            var buttons = new[] { btnValidezRv, btnPrevisualisez};

            AttachFieldObserversTo(formValidator, comboBoxes, textBoxes, datePickers);
            AttachFieldObserversTo(formValidator2, comboBoxes, textBoxes, datePickers);

        }
        private (string toolTipErrors, string labelErrors) ValidateAndGetErrorsDual()
        {
            var erreurs = new StringBuilder();

            if (cbbMedecin.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbMedecin.SelectedItem).Value))
                erreurs.AppendLine("Veuillez sélectionner un médecin.");

            if (cbbDureeCreneaux.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbDureeCreneaux.SelectedItem).Value))
                erreurs.AppendLine("Veuillez sélectionner une durée de créneau.");

            if (cbbCreneauHoraire.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbCreneauHoraire.SelectedItem).Value))
                erreurs.AppendLine("Veuillez sélectionner un créneau horaire.");

            if (cbbSoins.SelectedItem == null || string.IsNullOrEmpty(((SelectListView)cbbSoins.SelectedItem).Value))
                erreurs.AppendLine("Veuillez sélectionner un soin.");

            if (!patientTrouve)
            {
                if (!float.TryParse(txtPoids.Text, out _))
                    erreurs.AppendLine("Poids invalide.");

                if (!float.TryParse(txtTaille.Text, out _))
                    erreurs.AppendLine("Taille invalide.");

                if (dtDateNaissance.Value.Date >= DateTime.Now.Date)
                    erreurs.AppendLine("La date de naissance ne peut pas être aujourd'hui ou dans le futur.");

                if (cbbGroupeSanguin == null || cbbGroupeSanguin.Items.Count == 0 || cbbGroupeSanguin.SelectedItem == null)
                    erreurs.AppendLine("Veuillez sélectionner un groupe sanguin.");
                else
                {
                    var selectedItem = (SelectListView)cbbGroupeSanguin.SelectedItem;
                    if (string.IsNullOrEmpty(selectedItem.Value))
                        erreurs.AppendLine("Veuillez sélectionner un groupe sanguin.");
                }
            }

            string labelMessage = erreurs.ToString(); // avec \n
            string toolTipMessage = labelMessage.Replace(Environment.NewLine, "; "); // sur une ligne

            return (toolTipMessage, labelMessage);
        }



        private void AttachFieldObserversTo(FormValidator validator,
                                    ComboBox[] comboBoxes,
                                    TextBox[] textBoxes,
                                    DateTimePicker[] datePickers)
        {
            foreach (var cb in comboBoxes)
                cb.SelectedIndexChanged += (s, e) => validator.Validate();

            foreach (var tb in textBoxes)
                tb.TextChanged += (s, e) => validator.Validate();

            foreach (var dt in datePickers)
                dt.ValueChanged += (s, e) => validator.Validate();
            
        }

        private void frmConfiguration()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized; // Définit l'état du formulaire sur maximisé
            /*            this.ShowIcon = false;    // Supprimer l'icône
            *//*            this.ShowInTaskbar = false; // Ne pas afficher dans la barre des tâches
            */
            txtSoin.Enabled = false;  // Désactivation du champ de prix
            //panel2.Visible = false;
            toolTip1.UseFading = false;
            toolTip1.UseAnimation = false;
        }

        private void frmRendezVous_Load(object sender, EventArgs e)
        {
            ResetForm();
            //DateTime selectedDate = dtRendezVous.Value.Date;
            dtRendezVous.Value = selectedDate;
            GetTableCreneau(listView1, new DateTime(2025, 05, 21));
           //lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} :";
            LoadPhoneNumbers();
            //serviceAgenda.LoadAgenda(selectedDate);

            cbbGroupeSanguin.DataSource = LoadBloodGroups();
            cbbGroupeSanguin.DisplayMember = "Text";  // Afficher le texte du groupe sanguin
            cbbGroupeSanguin.ValueMember = "Value";   // La valeur utilisée lors de la sélection

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

        /// <summary>
        /// Liste des numéros de téléphone pour l'autocomplétion
        /// </summary>
        /// <param name="limit"></param>
        private void LoadPhoneNumbers(int limit = 5)
        {
            var phoneList = allService.GetPhoneNumbersForAutoComplete(limit);

            AutoCompleteStringCollection phoneCollection = new AutoCompleteStringCollection();
            phoneCollection.AddRange((string[])phoneList.ToArray());

            cbbTelephone.AutoCompleteCustomSource = phoneCollection;
            cbbTelephone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTelephone.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        /// <summary>
        /// Liste des groupes sanguins disponibles
        /// </summary>
        private List<SelectListView> LoadBloodGroups()
        {
            var grpsang = allService.GetListeGroupesSanguins(); // 🔄 CHANGÉ – appel service WCF
            List<SelectListView> ListeGS = new List<SelectListView>();

            ListeGS.Add(new SelectListView { Text = "Sélectionnez le groupe sanguin", Value = "" });

            foreach (var onegrp in grpsang)
            {
                ListeGS.Add(new SelectListView
                {
                    Text = onegrp.NomGroupeSanguin + "(" + onegrp.CodeGroupeSanguin + ")",
                    Value = onegrp.CodeGroupeSanguin
                });
            }
            return ListeGS;
            
/*            var bloodGroups = allService.GetListeGroupesSanguins().ToList();
*/            /*// Ajouter l'option "Sélectionnez un groupe sanguin..." en premier
            bloodGroups.Insert(0, new MetierRvMedical.Model.GroupeSanguin { IdGroupeSanguin = -1, CodeGroupeSanguin = "", NomGroupeSanguin = "Sélectionnez un groupe sanguin..." });
            cbbGroupeSanguin.DataSource = bloodGroups;
            cbbGroupeSanguin.DisplayMember = "NomGroupeSanguin";
            cbbGroupeSanguin.ValueMember = "IdGroupeSanguin";
            cbbGroupeSanguin.SelectedIndex = 0; // Sélection par défaut*/
        }

        /// <summary>
        /// Liste des soins disponibles pour le rendez-vous
        /// </summary>
        /// <returns></returns>
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
                a.Value = onegrp.IdSoin.ToString();
                ListeSoins.Add(a);
            }
            return ListeSoins;

        }
        /// <summary>
        /// Liste des médecins disponibles pour la date sélectionnée
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Liste des durées de créneaux disponibles pour la date sélectionnée
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <param name="idMedecin"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Fonction pour créer un élément par défaut dans la liste déroulante
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <param name="idMedecin"></param>
        /// <param name="TimeCreneau"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Renitialiser le formulaire après la soumission ou l'annulation
        /// </summary>
        private void ResetForm()
        {
            txtNomPrenom.Clear();
            txtAdresse.Clear();
            txtEmail.Clear();
            txtPoids.Clear();
            txtTaille.Clear();
            //Reset All ComboBox
            cbbGroupeSanguin.DataSource = LoadBloodGroups(); // Recharge la source de données
            cbbGroupeSanguin.SelectedIndex = 0;
            cbbTelephone.SelectedIndex = -1;
            dtDateNaissance.Value =DateTime.Now; // Utiliser DateTime.Now si la date de naissance est nulle
            /*cbbMedecin.DataSource = LoadCbbMedecin(todayDate);
            cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(todayDate);
            cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(todayDate);  // ComboBox avec les durées disponibles*/
            //cbbTelephone.Text = string.Empty; // Ne pas réinitialiser le champ téléphone ici
            EnableAllFields();
        }

        private void ResetDetailsRv()
        {
            DateTime defaultDate = new DateTime(2025, 05, 21);
            dtRendezVous.Value = defaultDate;
            cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(defaultDate);
            cbbMedecin.DataSource = LoadCbbMedecin(defaultDate);
            cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(defaultDate);
            cbbSoins.DataSource = LoadCbbSoins();
           cbbCreneauHoraire.SelectedIndex = 0;
            cbbMedecin.SelectedIndex = 0;
            cbbDureeCreneaux.SelectedIndex = 0;
            cbbSoins.SelectedIndex = 0;
        }
        private void btnRenitialiser_Click(object sender, EventArgs e)
        {
            ResetForm();
            cbbTelephone.Text = string.Empty;  // Réinitialiser aussi le champ téléphone
            EnableAllFields();
        }


        /// <summary>
        /// Lorsque le texte dans cbbTelephone change, on met à jour les détails du patient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbTelephone_TextChanged(object sender, EventArgs e)
        {
            string phoneNumber = cbbTelephone.Text.Trim();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                // Si le champ est vide, on réinitialise tout de suite
                patientTrouve = false;
                ResetForm();
                EnableAllFields();
                patientInfos = new typeMetierService.Patient();
            }
            else
            {
                var patient = allService.ResearchPatient(phoneNumber);
                if (patient != null)
                {
                    UpdatePatientDetails(phoneNumber);
                }
                else
                {
                    // On réinitialise uniquement les champs patient, pas le champ téléphone
                    patientTrouve = false;
                    ResetPatientFields();
                    EnableAllFields();
                    patientInfos = new typeMetierService.Patient();
                }
            }
        }

        // Réinitialise uniquement les champs patient (hors téléphone)
        private void ResetPatientFields()
        {
            txtNomPrenom.Text = "";
            txtAdresse.Text = "";
            txtEmail.Text = "";
            txtPoids.Text = "";
            txtTaille.Text = "";
            cbbGroupeSanguin.SelectedIndex = 0;
            dtDateNaissance.Value = DateTime.Now;
        }

        /// <summary>
        /// Cette fonction va permettre de supprimer le nom prenom dans le champs Telephone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbTelephone_Leave(object sender, EventArgs e)
        {
            var phoneParts = cbbTelephone.Text.Split(new string[] { " - " }, StringSplitOptions.None);
            if (phoneParts.Length > 0)
            {
                string phoneNumber = phoneParts[0].Trim();
                cbbTelephone.Text = phoneNumber;
                patientTrouve = true;
                UpdatePatientDetails(phoneNumber); // Recherche patient ici UNIQUEMENT
            }
            else
            {
                patientTrouve = false;
                cbbTelephone.Text = string.Empty;
            }
        }

        /// <summary>
        /// Lorsque l'utilisateur sélectionne une valeur dans la liste d'autocomplétion du téléphone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbTelephone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTelephone.SelectedItem != null)
            {
            var selectedText = cbbTelephone.SelectedItem.ToString();
            var phoneParts = selectedText.Split(new string[] { " - " }, StringSplitOptions.None);
            if (phoneParts.Length > 0)
            {
                    string phoneNumber = phoneParts[0].Trim();
                    cbbTelephone.Text = phoneNumber;
                    UpdatePatientDetails(phoneNumber); // Recherche patient si sélection d'une suggestion
                }
            }
        }

        /// <summary>
        /// Lorsque l'utilisateur sélectionne une valeur dans la liste d'autocomplétion (avec flèches ou souris)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbTelephone_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbTelephone.SelectedItem != null)
            {
                var selectedText = cbbTelephone.SelectedItem.ToString();
                var phoneParts = selectedText.Split(new string[] { " - " }, StringSplitOptions.None);
                if (phoneParts.Length > 0)
                {
                    string phoneNumber = phoneParts[0].Trim();
                    cbbTelephone.Text = phoneNumber;
                    UpdatePatientDetails(phoneNumber); // Recherche patient si sélection d'une suggestion
                }
            }
        }
        // Remplace la méthode UpdatePatientDetails par cette version sécurisée
        private void UpdatePatientDetails(string phoneNumberInput)
        {
            var patient = allService.ResearchPatient(phoneNumberInput);
            if (patient != null)
            {
                patientTrouve = true;
                txtNomPrenom.Text = patient.NomPrenom ?? string.Empty;
                txtAdresse.Text = patient.Adresse ?? string.Empty;
                txtEmail.Text = patient.Email ?? string.Empty;
                txtPoids.Text = patient.Poids?.ToString() ?? string.Empty;
                txtTaille.Text = patient.Taille?.ToString() ?? string.Empty;
                dtDateNaissance.Value = patient.DateNaissance ?? DateTime.Now;

                // Sélectionne le groupe sanguin de façon sécurisée
                if (patient.GroupeSanguin != null)
                {
                    // On cherche l'item correspondant dans la liste du ComboBox
                    foreach (var item in cbbGroupeSanguin.Items)
                    {
                        if (item is SelectListView slv && int.TryParse(slv.Value, out int idGS))
                        {
                            if (idGS == patient.GroupeSanguin.IdGroupeSanguin)
                            {
                                cbbGroupeSanguin.SelectedItem = item;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cbbGroupeSanguin.SelectedIndex = 0;
                }

                // Met à jour patientInfos avec le bon groupe sanguin si possible
                SelectListView selectedItem = cbbGroupeSanguin.SelectedItem as SelectListView;
                if (selectedItem != null && !string.IsNullOrEmpty(selectedItem.Value))
                {
                    var listeGroupes = allService.GetListeGroupesSanguins();
                    var selectedGroup = listeGroupes.FirstOrDefault(gs => gs.CodeGroupeSanguin == selectedItem.Value);
                    if (selectedGroup != null)
                    {
                        patientInfos.GroupeSanguin = selectedGroup;
                        patientInfos.IdGroupeSanguin = selectedGroup.IdGroupeSanguin;
                    }
                }
                else
                {
                    patientInfos = new typeMetierService.Patient(); // Réinitialiser les infos du patient
                }

                DisableFields(patient);
                patientInfos = patient; // Mettre à jour les infos du patient
            }
            else
            {
                patientTrouve = false;
                ResetPatientFields(); // Ne pas toucher au champ téléphone
                EnableAllFields();
                patientInfos = new typeMetierService.Patient(); // Réinitialiser les infos du patient
            }
        }

        /// <summary>
        /// Desactiver les champs apres une autocompletion a travers le numéro de patient
        /// </summary>
        /// <param name="servicePatient"></param>
        private void DisableFields(typeMetierService.Patient servicePatient)
        {
            // Convert the ServiceMetierPatient.Patient to WindowsFormsApp1.Model.Patient
            
            // Activer les champs si la valeur est null ou vide, sinon désactiver les champs
            txtNomPrenom.Enabled = string.IsNullOrEmpty(servicePatient.NomPrenom);
            txtAdresse.Enabled = string.IsNullOrEmpty(servicePatient.Adresse);
            txtEmail.Enabled = string.IsNullOrEmpty(servicePatient.Email);
            txtPoids.Enabled = servicePatient.Poids == null || servicePatient.Poids == 0; // Peut aussi vérifier si Poids est égal à 0 (si c'est le cas)
            txtTaille.Enabled = servicePatient.Taille == null || servicePatient.Taille == 0; // Même logique pour la taille
            cbbGroupeSanguin.Enabled = string.IsNullOrEmpty(servicePatient.GroupeSanguin?.CodeGroupeSanguin); // Vérifie si le groupe sanguin est null ou vide
            dtDateNaissance.Enabled = false;
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
            dtDateNaissance.Enabled = true;
        }

     /*   private void btnImpression_Click(object sender, EventArgs e)
        {
            frmPrintTicket frmPrintTicket = new frmPrintTicket();
            frmPrintTicket.Show();
        }*/

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

        /// <summary>
        /// Lorsqu'on change la date du rendez-vous, on recharge les créneaux disponibles pour cette date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// Changement de sélection dans le ComboBox des soins
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbSoins_SelectedIndexChanged(object sender, EventArgs e)

        {

            if (cbbSoins.SelectedItem != null)
            {
                SelectListView selectedItem = (SelectListView)cbbSoins.SelectedItem;
                // Rechercher le soin correspondant dans la base de données
                var allSoins = allService.GetListSoins();
                var selectedSoin = allSoins
                                           .FirstOrDefault(gs => gs.NameSoin == selectedItem.Text);

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


        ///Medecin Combo Box



        /// <summary>
        /// Lorsqu'on change le médecin sélectionné, on recharge les créneaux disponibles pour ce médecin et la date sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            bool trouve = SelectionnerCorrespondanceComboBox(cbbMedecin, texteTape);
            DateTime selectedDate = dtRendezVous.Value.Date;
            if (trouve)
            {
                // On recharge les créneaux pour ce médecin
                if (cbbMedecin.SelectedItem is SelectListView correspondance && int.TryParse(correspondance.Value, out int idMedecin))
                {
                    lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} : {correspondance.Text}";
                    GetTableCreneau(listView1, selectedDate, idMedecin);
                    cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate, idMedecin);
                    cbbCreneauHoraire.DataSource = LoadCbbCreneauxHoraire(selectedDate, idMedecin);
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


        ///ComboBox Creneaux Horaire


        /// <summary>
        /// Lorsque la durée des créneaux change, on recharge les créneaux horaires disponibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
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
        /// <summary>
        /// Lorsqu'on change le créneau horaire, on peut mettre à jour la liste des créneaux disponibles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbCreneauHoraire_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime selectedDate = dtRendezVous.Value.Date;
            //GetTableCreneau(listView1, selectedDate);
        }
        /// <summary>
        /// Valider le rendez-vous
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidezRv_Click(object sender, EventArgs e)
        {
            var (toolTipErrors, _) = ValidateAndGetErrorsDual(); // ignore labelErrors
            if (string.IsNullOrWhiteSpace(toolTipErrors))
            {
                infos= RecupererInfosComboBoxes();
                StringBuilder mmessagesInfos = new StringBuilder();
                typeMetierService.Creneau creneau=new typeMetierService.Creneau(); // ✅ Choix Type Creneau dans Metier
                typeMetierService.RendezVous serviceRendezVous=new typeMetierService.RendezVous();// Choix Type Rv dans Metier

                // Heure de début (ex: "08:00 - 08:15" → on garde juste "08:00")
                string horaireSelectionne=infos.Horaire.ToString();
                string heureDebutStr = horaireSelectionne.Substring(0, 5); // "08:00"
                creneau.HeureDebut = heureDebutStr;
            
                // Durée en minutes (ex: "15")
                int dureeMinutes =infos.DureeCreneau;

                // Calcul de l'heure de fin
                DateTime heureDebut = DateTime.ParseExact(heureDebutStr, "HH:mm", null);
                DateTime heureFin = heureDebut.AddMinutes(dureeMinutes);
                creneau.HeureFin = heureFin.ToString("HH:mm");
                creneau.IdAgenda = Convert.ToInt32(((SelectListView)cbbMedecin.SelectedItem).Value); // Id de l'agenda du médecin sélectionné
                creneau.Date = dtRendezVous.Value.Date; // Date du rendez-vous
                creneau.Disponible= true;

                try
                {
                    if (!patientTrouve)
                    {
                        // Si le patient n'est pas trouvé, on crée un nouveau patient
                        /*patientInfos.NomPrenom = txtNomPrenom.Text;
                        patientInfos.Adresse = txtAdresse.Text;
                        patientInfos.Email = txtEmail.Text;
                        patientInfos.Poids = string.IsNullOrEmpty(txtPoids.Text) ? (float?)null : float.Parse(txtPoids.Text);
                        patientInfos.Taille = string.IsNullOrEmpty(txtTaille.Text) ? (float?)null : float.Parse(txtTaille.Text);
                        patientInfos.DateNaissance = dtDateNaissance.Value.Date;
                        patientInfos.TEL = cbbTelephone.Text;*/
                        patientInfos=GetPatientInfos(patientInfos);
                        // Ajout du nouveau patient
                        
                        bool patientCree = allService.AddPatient(patientInfos);
                        if (patientCree)
                        {
                            LoadPhoneNumbers();
                            mmessagesInfos.AppendLine("Patient Ajouté avec Succès !");
                            //Permet de recuperer les infos du patient créé
                            var patientCreeInfos = allService.ResearchPatient(patientInfos.TEL);
                            if (patientCreeInfos != null)
                                patientInfos = patientCreeInfos;
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la création du nouveau patient.", "Erreurs Création", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    /*MessageBox.Show("Rendez-vous créé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    */
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception lors de la création du rendez-vous :\n" + ex.ToString());
                }
                // Remplacement de la logique de récupération d'agenda
                var creneaux = allService.LoadCreneauxByDate(dtRendezVous.Value.Date);
                var creneauTrouve = creneaux.FirstOrDefault(c =>
                    (int)c["idMedecin"] == infos.IdMedecin &&
                    c["date"].ToString() == dtRendezVous.Value.Date.ToString("yyyy-MM-dd") &&
                    c["heureDebut"].ToString() == creneau.HeureDebut &&
                    c["heureFin"].ToString() == creneau.HeureFin
                );


                if (creneauTrouve != null)
                {
                    int idAgenda = (int)creneauTrouve["IdAgenda"];
                    creneau.IdAgenda= idAgenda; // Assigner l'ID de l'agenda trouvé
                    int creneauCree = allService.AddCreneaux(creneau);

                    if (creneauCree > 0)
                    {
                        creneau.IdCreneau = creneauCree; // Utilise l'ID retourné
                        // Création du rendez-vous
                        serviceRendezVous.DateRv = dtRendezVous.Value.Date;
                        serviceRendezVous.Statut = "Validée";
                        serviceRendezVous.IdSoin = infos.IdSoin;
                        serviceRendezVous.IdPatient = patientInfos.IdU;
                        serviceRendezVous.IdMedecin = infos.IdMedecin;
                        serviceRendezVous.IdCreneau = creneau.IdCreneau; // Assigner l'ID du créneau créé
                        serviceRendezVous.IdAgenda = creneau.IdAgenda; // Assigner l'ID de l'agenda du médecin

                        // Debug : afficher toutes les valeurs
                        /*MessageBox.Show(
                            $"IdPatient={serviceRendezVous.IdPatient}\n" +
                            $"IdCreneau={serviceRendezVous.IdCreneau}\n" +
                            $"IdAgenda={serviceRendezVous.IdAgenda}\n" +
                            $"IdSoin={serviceRendezVous.IdSoin}\n" +
                            $"IdMedecin={serviceRendezVous.IdMedecin}\n" +
                            $"DateRv={serviceRendezVous.DateRv}\n" +
                            $"Statut={serviceRendezVous.Statut}"
                        );*/
                        bool addRv =allService.AddRendezVous(serviceRendezVous);
                        if (addRv)
                        {
                            mmessagesInfos.AppendLine("Rendez-Vous Ajouté avec Succès !");
                            MessageBox.Show(mmessagesInfos.ToString(), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetDetailsRv();
                            ResetForm();
                            cbbTelephone.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Le Rendez-Vous n'a pas été créé", "Erreurs Création RV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {               
                        MessageBox.Show("Erreur lors de la création du créneau.");
                    }
                }
                else
                {
                    MessageBox.Show("Aucun créneau/agenda trouvé pour ce médecin et cet horaire.");
                    // Gérer le cas d'erreur ici
                }
            };
        }

        private typeMetierService.Patient GetPatientInfos(typeMetierService.Patient patientInfos)
        {
            // Si le patient n'est pas trouvé, on crée un nouveau patient
            patientInfos.NomPrenom = txtNomPrenom.Text;
            patientInfos.Adresse = txtAdresse.Text;
            patientInfos.Email = txtEmail.Text;
            patientInfos.Poids = string.IsNullOrEmpty(txtPoids.Text) ? (float?)null : float.Parse(txtPoids.Text);
            patientInfos.Taille = string.IsNullOrEmpty(txtTaille.Text) ? (float?)null : float.Parse(txtTaille.Text);
            patientInfos.DateNaissance = dtDateNaissance.Value.Date;
            patientInfos.TEL = cbbTelephone.Text;

            return patientInfos;
        }


        public typeMetierService.InfosRendezVous RecupererInfosComboBoxes()
        {
            var infos = new typeMetierService.InfosRendezVous();

            // Médecin
            if (cbbMedecin.SelectedItem is SelectListView medecin)
            {
                infos.IdMedecin = int.Parse(medecin.Value);
                infos.NomMedecin = medecin.Text;
            }

            // Durée créneau
            if (cbbDureeCreneaux.SelectedItem is SelectListView duree)
            {
                infos.DureeCreneau = int.Parse(duree.Value);
            }

            // Horaire créneau
            if (cbbCreneauHoraire.SelectedItem is SelectListView horaire)
            {
                infos.Horaire = horaire.Value;
            }

            // Soin
            if (cbbSoins.SelectedItem is SelectListView soin)
            {
                infos.IdSoin = int.Parse(soin.Value);
                infos.NomSoin = soin.Text;
            }
            infos.DateRv = dtRendezVous.Value.Date;
            return infos;
        }

        /// <summary>
        /// Sélectionne dans le ComboBox l'item dont le texte correspond exactement (insensible à la casse et aux espaces).
        /// </summary>
        /// <param name="comboBox">Le ComboBox à traiter</param>
        /// <param name="texteTape">Le texte à comparer</param>
        /// <returns>true si une correspondance a été trouvée et sélectionnée, false sinon</returns>
        public bool SelectionnerCorrespondanceComboBox(ComboBox comboBox, string texteTape)
        {
            if (string.IsNullOrWhiteSpace(texteTape)) return false;

            var correspondance = comboBox.Items.Cast<SelectListView>()
                .FirstOrDefault(item => item.Text.Trim().ToLower() == texteTape.Trim().ToLower());

            if (correspondance != null)
            {
                comboBox.SelectedItem = correspondance;
                return true;
            }
            return false;
        }

   


        private void btnPrevisualisez_Click(object sender, EventArgs e)
        {

            var (toolTipErrors, _) = ValidateAndGetErrorsDual(); // ignore labelErrors

if (string.IsNullOrWhiteSpace(toolTipErrors))
            {
                infos = RecupererInfosComboBoxes();
                patientInfos = GetPatientInfos(patientInfos);
                frmPrintTicket frmPrintTicket = new frmPrintTicket(patientInfos, infos);
                frmPrintTicket.Show();
            }
            
            
        }



        
    }
}
