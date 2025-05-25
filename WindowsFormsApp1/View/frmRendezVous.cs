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
        BdRvMedicalContext bd = new BdRvMedicalContext();
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
            serviceAgenda.LoadAgenda(selectedDate);
            //LoadAgenda(selectedDate);
            LoadBloodGroups();  // Charger les groupes sanguins
            cbbSoins.DataSource = LoadCbbSoins();
            cbbSoins.DisplayMember = "Text";  // Ce que tu veux afficher dans le ComboBox
            cbbSoins.ValueMember = "Value";   // La valeur associée à chaque item

            var durations = new List<int> { 15, 30, 45, 60 }; // Durées en minutes
            cbbDureeCreneaux.DataSource = LoadCbbDureeCreneaux(selectedDate);  // ComboBox avec les durées disponibles
            cbbDureeCreneaux.DisplayMember = "Text";
            cbbDureeCreneaux.ValueMember = "Value";

            cbbMedecin.DataSource=LoadCbbMedecin(selectedDate);
            cbbMedecin.DisplayMember = "Text";
            cbbMedecin.ValueMember = "Value";
            //var timeSlots = LoadCbbTimeCreneaux(selectedDate);
            /*if (timeSlots.Any())
            {
                cbbCreneauHoraire.DataSource = timeSlots;
                cbbCreneauHoraire.DisplayMember = "Text";
                cbbCreneauHoraire.ValueMember = "Value";
            }
            else
            {
                MessageBox.Show("Aucun créneau disponible pour cette date.");
            }*/
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

        private List<SelectListView> LoadCbbMedecin(DateTime selectedDate)
        {
            // Liste de médecins
            List<SelectListView> ListeMedecins = new List<SelectListView>();

            // Ajouter un élément par défaut
            SelectListView def = new SelectListView();
            def.Text = "Sélectionnez un médecin...";
            def.Value = "";
            ListeMedecins.Add(def);

            
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



            // Récupérer les médecins disponibles pour la date sélectionnée
            //var medecinsDisponibles = bd.Agendas
            //                            .Where(a => a.DatePlanifie == selectedDate) // Filtrer selon la date choisie
            //                            .Select(a => a.Medecin)  // Assurez-vous que Medecin est une relation de clé étrangère
            //                            .Distinct()
            //                            .ToList(); 

            // Récupérer les médecins disponibles pour la date sélectionnée en joignant Agendas et Creneaux
            //var medecinsDisponibles = bd.Agendas
            //    .Join(
            //        bd.Creneaux,                          // Deuxième table à joindre
            //        agenda => agenda.IdAgenda,           // Clé étrangère dans Agendas
            //        creneau => creneau.IdCreneau,                // Clé primaire dans Creneaux
            //        (agenda, creneau) => new { agenda, creneau } // Résultat de la jointure
            //    )
            //    .Where(joined => joined.agenda.DatePlanifie == selectedDate) // Filtrer par date
            //    .Select(joined => joined.agenda.Medecin)  // Sélectionner les médecins
            //    .Distinct()  // Éviter les doublons
            //    .ToList();

           //ar medecinDisponibles=


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
            // Liste de médecins
            List<SelectListView> ListeDureeCreneaux = new List<SelectListView>();

            


            var Creneaux = serviceAgenda.LoadCreneauxByDate(selectedDate)
                .Where(c =>
                    c["date"].ToString() == selectedDate.ToString("yyyy-MM-dd") &&
                    Convert.ToBoolean(c["estOccupe"]) == false &&
                    (!idMedecin.HasValue || Convert.ToInt32(c["idMedecin"]) == idMedecin.Value)
                )
                .GroupBy(c => Convert.ToString(c["creneau"]))
                .Select(g => g.First())
                .Select(c => new
                {
                    Creneau = c["creneau"].ToString(),
                    Date = c["date"].ToString(),
                })
                .ToList();
            if (Creneaux.Count()>1)
            {
                // Ajouter un élément par défaut
                SelectListView def = new SelectListView();
                def.Text = "Sélectionnez un créneau...";
                def.Value = "";
                ListeDureeCreneaux.Add(def);
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
                if (Creneaux.Count()==1)
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
                    SelectListView def = new SelectListView();
                    def.Text = "Aucun Time Creneau...";
                    def.Value = "";
                    ListeDureeCreneaux.Add(def);
                }
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
            var patient = new Patient
            {
                NomPrenom = servicePatient.NomPrenom,
                Adresse = servicePatient.Adresse,
                Email = servicePatient.Email,
                TEL = servicePatient.TEL,
                Poids = servicePatient.Poids,
                Taille = servicePatient.Taille,
                GroupeSanguin = servicePatient.GroupeSanguin != null
                    ? new GroupeSanguin
                    {
                        CodeGroupeSanguin = servicePatient.GroupeSanguin.CodeGroupeSanguin
                    }
                    : null
            };

            // Activer les champs si la valeur est null ou vide, sinon désactiver les champs
            txtNomPrenom.Enabled = string.IsNullOrEmpty(patient.NomPrenom);
            txtAdresse.Enabled = string.IsNullOrEmpty(patient.Adresse);
            txtEmail.Enabled = string.IsNullOrEmpty(patient.Email);
            txtPoids.Enabled = patient.Poids == null || patient.Poids == 0; // Peut aussi vérifier si Poids est égal à 0 (si c'est le cas)
            txtTaille.Enabled = patient.Taille == null || patient.Taille == 0; // Même logique pour la taille
            cbbGroupeSanguin.Enabled = string.IsNullOrEmpty(patient.GroupeSanguin?.CodeGroupeSanguin); // Vérifie si le groupe sanguin est null ou vide
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


        
        private List<SelectListView> LoadCbbTimeCreneaux(DateTime date)
        {
            List<SelectListView> Listetime = new List<SelectListView>();

            // Récupérer l'agenda pour la date donnée
            var agenda = bd.Agendas.FirstOrDefault(a => a.DatePlanifie == date);
            if (agenda == null) {
                Listetime.Add(new SelectListView { Text = "Aucun Créneau Disponible", Value = "" });
                return Listetime;
                    }; // Si aucun agenda trouvé, on retourne une liste vide.

            // Convertir HeureDebut et HeureFin en DateTime
            DateTime heureDebut = DateTime.ParseExact(agenda.HeureDebut, "HH:mm", CultureInfo.InvariantCulture);
            DateTime heureFin = DateTime.ParseExact(agenda.HeureFin, "HH:mm", CultureInfo.InvariantCulture);

            // Ajouter un élément par défaut
            Listetime.Add(new SelectListView { Text = "Sélectionnez un créneau", Value = "" });

            // Générer les créneaux
            while (heureDebut < heureFin)
            {
                DateTime nextTime = heureDebut.AddMinutes(agenda.Creneau);

                // Vérifier si ce créneau est déjà pris
                var heureDebutFormatted = TimeSpan.ParseExact(heureDebut.ToString("HH:mm"), "hh\\:mm", CultureInfo.InvariantCulture);

                // Récupérer tous les créneaux pour la date donnée
                var creneauxForDate = bd.Creneaux
                    .Where(c => c.Date == date)
                    .ToList(); // Charger les données en mémoire

                bool isSlotOccupied = creneauxForDate
                    .Any(c => TimeSpan.ParseExact(c.HeureDebut, "hh\\:mm", CultureInfo.InvariantCulture) == heureDebutFormatted);

                if (!isSlotOccupied)
                {
                    // Ajouter le créneau si disponible
                    Listetime.Add(new SelectListView
                    {
                        Text = $"{heureDebut.ToShortTimeString()} - {nextTime.ToShortTimeString()}",
                        Value = $"{heureDebut.ToShortTimeString()} - {nextTime.ToShortTimeString()}"
                    });
                }

                // Passer au créneau suivant
                heureDebut = nextTime;
            }

            return Listetime;
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


            var typesCreneaux = serviceAgenda.ListeTimeCreneau(date,null);
            int nombrecreneau = 0;

            foreach (var typeCreneau in typesCreneaux)
            {
                var tousCreneaux = serviceAgenda.CreneauxByHoraire(date)
                                     .Where(c => c["TimeCreneau"].ToString() == typeCreneau.ToString() &&
                                                (!idMedecin.HasValue || (c.ContainsKey("idMedecin") && Convert.ToInt32(c["idMedecin"]) == idMedecin.Value)))
                                     .ToList();
                //var tousCreneaux = serviceAgenda.CreneauxByHoraire(date)

                //                     .Where(c => c["TimeCreneau"].ToString() == typeCreneau.ToString() &&
                //                            Convert.ToBoolean(c["estOccupe"]) == false &&
                //                            (!idMedecin.HasValue || Convert.ToInt32(c["idMedecin"]) == idMedecin.Value))
                //                     .Select(c => new
                //                     {
                //                         Creneau = c["creneau"].ToString(),
                //                         Horaire = c["heureDebut"].ToString() + "-" + c["heureFin"].ToString(),
                //                         Date = c["date"].ToString(),
                //                     })
                //                     .ToList();

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
            lblMessageCreneaux.Text = $"Créneaux:{nombrecreneau}";
        }


        //public List<Dictionary<string, object>> CreneauxByHoraire(DateTime dateRecherche)
        //{
        //    var creneaux =serviceAgenda.LoadCreneauxByDate(dateRecherche);

        //    var resultat = creneaux
        //        .GroupBy(c => new
        //        {
        //            HeureDebut = c["heureDebut"].ToString(),
        //            HeureFin = c["heureFin"].ToString(),
        //            TimeCreneau = c["creneau"].ToString(),
        //        })
        //        .Select(g =>
        //        {
        //            int total = g.Count();
        //            int occupe = g.Count(x => Convert.ToBoolean(x["estOccupe"]));
        //            int libre = total - occupe;

        //            return new Dictionary<string, object>
        //            {
        //                ["horaire"] = $"{g.Key.HeureDebut} - {g.Key.HeureFin}",
        //                ["nombre"] = total,
        //                ["occupe"] = occupe,
        //                ["libre"] = libre,
        //                ["TimeCreneau"] = g.Key.TimeCreneau,
        //                ["estOccupe"] = occupe > 0 // true si au moins un est occupé
        //            };
        //        })
        //        .ToList();

        //    return resultat;
        //}


        private void dtRendezVous_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtRendezVous.Value.Date;
            lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} :";
            GetTableCreneau(listView1, selectedDate);
            cbbMedecin.DataSource = LoadCbbMedecin(selectedDate);
        }

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
                    var listeCreneaux = LoadCbbDureeCreneaux(selectedDate, idMedecin);
                    cbbDureeCreneaux.DataSource = null;
                    cbbDureeCreneaux.Items.Clear();

                    cbbDureeCreneaux.DataSource = listeCreneaux;
                    cbbDureeCreneaux.DisplayMember = "Text";
                    cbbDureeCreneaux.ValueMember = "Value";

                    //lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()} : {correspondance.Text}";
                }
                else
                {
                    // Valeur invalide
                    cbbDureeCreneaux.DataSource = null;
                    cbbDureeCreneaux.Items.Clear();
                    //lblMessageCreneaux.Text = $"Créneaux disponibles pour le {selectedDate.ToShortDateString()}";
                    LoadCbbDureeCreneaux(selectedDate);
                }
            }
            else
            {
                // Aucun médecin correspondant
                cbbDureeCreneaux.DataSource = null;
                cbbDureeCreneaux.Items.Clear();
                LoadCbbDureeCreneaux(selectedDate);
               // lblMessageCreneaux.Text = "Aucun médecin correspondant.";
            }
        }

    }
}
