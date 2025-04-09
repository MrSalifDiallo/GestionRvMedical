using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using WindowsFormsApp1.Model;
using System.Collections.Generic;
using System.Globalization;

namespace WindowsFormsApp1.View
{
    public partial class frmRendezVous : Form
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();
        bool patientTrouve = false;

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
            panel2.Visible = false;
            pnlimpression.Visible = false;
        }

        private void frmRendezVous_Load(object sender, EventArgs e)
        {
            ResetForm();
            DateTime selectedDate = dtRendezVous.Value.Date;
            LoadPhoneNumbers();
            LoadAgenda(selectedDate);
            LoadBloodGroups();  // Charger les groupes sanguins
            cbbSoins.DataSource = LoadCbbSoins();
            cbbSoins.DisplayMember = "Text";  // Ce que tu veux afficher dans le ComboBox
            cbbSoins.ValueMember = "Value";   // La valeur associée à chaque item

            var durations = new List<int> { 15, 30, 45, 60 }; // Durées en minutes
            cbbDureeCreneaux.DataSource = durations;  // ComboBox avec les durées disponibles


            cbbMedecin.DataSource=LoadCbbMedecin(selectedDate);
            cbbMedecin.DisplayMember = "Text";
            cbbMedecin.ValueMember = "Value";
            var timeSlots = LoadCbbTimeCreneaux(selectedDate);
            if (timeSlots.Any())
            {
                cbbCreneauHoraire.DataSource = timeSlots;
                cbbCreneauHoraire.DisplayMember = "Text";
                cbbCreneauHoraire.ValueMember = "Value";
            }
            else
            {
                MessageBox.Show("Aucun créneau disponible pour cette date.");
            }
        }

        private void LoadPhoneNumbers()
        {
            var phoneDetails = bd.Patients.Take(5).OrderBy(p=>p.TEL)
                .Select(p => new
            {
                p.TEL,
                p.NomPrenom,
            }).ToList();

            AutoCompleteStringCollection phoneCollection = new AutoCompleteStringCollection();

            foreach (var detail in phoneDetails)
            {
                string formattedEntry = $"{detail.TEL} - {detail.NomPrenom}";
                phoneCollection.Add(formattedEntry);
            }

            cbbTelephone.AutoCompleteCustomSource = phoneCollection;
            cbbTelephone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbTelephone.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void LoadBloodGroups()
        {
            // Récupérer tous les groupes sanguins depuis la base de données
            var bloodGroups = bd.GroupeSanguins.ToList();

            // Ajouter chaque groupe sanguin au ComboBox
            cbbGroupeSanguin.Items.Clear();  // Effacer les anciens items, si nécessaires
            foreach (var group in bloodGroups)
            {
                cbbGroupeSanguin.Items.Add(group.CodeGroupeSanguin); // Ajoute chaque groupe sanguin
            }
        }

        private List<SelectListView> LoadCbbSoins()
        {
            var allSoins = bd.Soins.ToList();
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

            // Récupérer les médecins disponibles pour la date sélectionnée
            //var medecinsDisponibles = bd.Agendas
            //                            .Where(a => a.DatePlanifie == selectedDate) // Filtrer selon la date choisie
            //                            .Select(a => a.Medecin)  // Assurez-vous que Medecin est une relation de clé étrangère
            //                            .Distinct()
            //                            .ToList();

            // Récupérer les médecins disponibles pour la date sélectionnée en joignant Agendas et Creneaux
            var medecinsDisponibles = bd.Agendas
                .Join(
                    bd.Creneaux,                          // Deuxième table à joindre
                    agenda => agenda.IdAgenda,           // Clé étrangère dans Agendas
                    creneau => creneau.IdCreneau,                // Clé primaire dans Creneaux
                    (agenda, creneau) => new { agenda, creneau } // Résultat de la jointure
                )
                .Where(joined => joined.agenda.DatePlanifie == selectedDate) // Filtrer par date
                .Select(joined => joined.agenda.Medecin)  // Sélectionner les médecins
                .Distinct()  // Éviter les doublons
                .ToList();


            // Ajouter les médecins au ComboBox
            foreach (var medecin in medecinsDisponibles)
            {
                SelectListView item = new SelectListView();
                item.Text = medecin.NomPrenom; // Assurez-vous que vous récupérez le bon attribut du médecin
                item.Value = medecin.IdU.ToString(); // Assurez-vous que vous utilisez l'ID pour la valeur
                ListeMedecins.Add(item);
            }

            return ListeMedecins;
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
            panel2.Visible = true;
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

                // Recherche du patient correspondant au numéro de téléphone
                var patient = bd.Patients.Include(p => p.GroupeSanguin).FirstOrDefault(p => p.TEL == phoneNumber);

                if (patient != null)
                {
                    // Si un patient est trouvé, remplir les champs
                    patientTrouve = true;
                    txtNomPrenom.Text = patient.NomPrenom ?? string.Empty;
                    txtAdresse.Text = patient.Adresse ?? string.Empty;
                    txtEmail.Text = patient.Email ?? string.Empty;
                    txtPoids.Text = patient.Poids?.ToString() ?? string.Empty;
                    txtTaille.Text = patient.Taille?.ToString() ?? string.Empty;
                    // Remplir le groupe sanguin
                    if (patient.GroupeSanguin != null)
                    {
                        // Sélectionner le groupe sanguin dans le ComboBox
                        cbbGroupeSanguin.SelectedItem = patient.GroupeSanguin.CodeGroupeSanguin ?? string.Empty;
                    }
                }
                else
                {
                    // Si aucun patient trouvé, réinitialiser les champs
                    patientTrouve = false;
                    ResetForm();
                }
            }
        }

        private void UpdatePatientDetails(string phoneNumberInput)
        {
            // Vérifie si le texte dans le champ cbbTelephone est valide
            if (!string.IsNullOrEmpty(phoneNumberInput))
            {
                // Recherche du patient en utilisant seulement le numéro de téléphone (avant le premier " - ")
                var phoneParts = phoneNumberInput.Split(new string[] { " - " }, StringSplitOptions.None);
                if (phoneParts.Length > 0)
                {
                    string phoneNumber = phoneParts[0].Trim(); // On prend uniquement le numéro

                    var patient = bd.Patients.Include(p => p.GroupeSanguin).FirstOrDefault(p => p.TEL == phoneNumber);

                    if (patient != null)
                    {
                        // Si un patient est trouvé, on remplit les champs du formulaire avec les données du patient
                        patientTrouve = true;
                        txtNomPrenom.Text = patient.NomPrenom ?? string.Empty;
                        txtAdresse.Text = patient.Adresse ?? string.Empty;
                        txtEmail.Text = patient.Email ?? string.Empty;
                        txtPoids.Text = patient.Poids?.ToString() ?? string.Empty;
                        txtTaille.Text = patient.Taille?.ToString() ?? string.Empty;

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
            }
            else
            {
                // Si le champ est vide, on vide également les champs
                patientTrouve = false;
                EnableAllFields();
            }
        }

        private void DisableFields(Patient patient)
        {
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dtRendezVous.Value.Date;

            //
            var timeSlots = LoadCbbTimeCreneaux(selectedDate);
            if (timeSlots.Any())
            {
                cbbCreneauHoraire.DataSource = timeSlots;
                cbbCreneauHoraire.DisplayMember = "Text";
                cbbCreneauHoraire.ValueMember = "Value";
            }
            else
            {
                MessageBox.Show("Aucun créneau disponible pour cette date.");
            }

            cbbMedecin.DataSource = LoadCbbMedecin(selectedDate);
            cbbMedecin.DisplayMember = "Text";
            cbbMedecin.ValueMember = "Value";
        }


        private void LoadAgenda(DateTime datetoday)
        {
            var agenda = bd.Agendas.Select(a => new
            {
                a.HeureDebut,
                a.HeureFin,
                a.DatePlanifie
            }).Where(a => a.DatePlanifie==datetoday).ToList();
            dgEssai.DataSource = agenda;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSoins.SelectedItem != null)
            {
                SelectListView selectedItem = (SelectListView)cbbSoins.SelectedItem;

                Soin selectedSoin = bd.Soins
                    .FirstOrDefault(gs => gs.NameSoin == selectedItem.Value);

                if (selectedSoin != null)
                {
                    txtSoin.Text = selectedSoin.Price.ToString();
                }
                //else
                //{
                //    MessageBox.Show($"1. Le soin sélectionné '{selectedSoin}' est invalide.");
                //    return;
                //}
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un soin.");
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImpression_Click(object sender, EventArgs e)
        {
            frmPrintTicket frmPrintTicket = new frmPrintTicket();
            frmPrintTicket.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
