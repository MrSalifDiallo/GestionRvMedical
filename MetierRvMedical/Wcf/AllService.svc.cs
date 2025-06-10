using MetierRvMedical.Model;
using MetierRvMedical.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AllService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AllService.svc ou AllService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AllService : IAllService
    {
        /// <summary>
        /// Represents the business logic layer for managing agenda-related operations.
        /// </summary>
        /// <remarks>This field provides access to the <see cref="AgendaMetier"/> instance, which
        /// encapsulates the core functionality for handling agenda operations. It is intended for internal use within
        /// the class to perform agenda-related tasks.</remarks>
        private AgendaMetier metierAgenda = new AgendaMetier();
        public List<Agenda> LoadAgenda(DateTime datetoday) => metierAgenda.LoadAgenda(datetoday);

        public List<Dictionary<string, object>> LoadCreneauxByDate(
            DateTime dateRecherche) => metierAgenda.LoadCreneauxByDate(dateRecherche);

        public List<Dictionary<string, object>> CreneauxByHoraire(DateTime dateRecherche)
            => metierAgenda.CreneauxByHoraire(dateRecherche);
        public List<int> ListeTimeCreneau(DateTime dateRecherche) =>
                    metierAgenda.ListeTimeCreneau(dateRecherche);
        public List<Dictionary<string, object>> CreneauxByHoraireMedecin(DateTime dateRecherche, int idMedecin) =>
            metierAgenda.CreneauxByHoraireMedecin(dateRecherche, idMedecin);



        /// <summary>
        /// Represents the business logic layer for managing patients.
        /// </summary>
        /// <remarks>This field provides access to the <see cref="PatientMetier"/> instance,  which
        /// contains methods and operations related to patient management.</remarks>
        private PatientMetier metierPatient = new PatientMetier();

        public List<Patient> GetListePatients() => metierPatient.GetListePatients();

        public bool AddPatient(Patient patient) => metierPatient.AddPatient(patient);

        public bool UpdatePatient(Patient patient) => metierPatient.UpdatePatient(patient);

        public bool RemovePatient(Patient patient) => metierPatient.RemovePatient(patient);


        public Patient ResearchPatient(string phoneNumberInput) => metierPatient.ResearchPatient(phoneNumberInput);


        //Metier pour les médecins
        //private MedecinMetier metierMedecin = new MedecinMetier();


        //Metier pour l'authentification
        /// <summary>
        /// Provides authentication-related operations and services.
        /// </summary>
        /// <remarks>This field is an instance of <see cref="AuthentificationMetier"/>, which encapsulates
        /// the business logic for handling authentication processes. It can be used to perform tasks such as user
        /// login, token validation, and other authentication-related operations.</remarks>
        private AuthentificationMetier metierAuthentification = new AuthentificationMetier();

        public bool AddFirstUser() => metierAuthentification.AddFirstUser();

        public bool CheckUser(string identifiantinbd, string mdp)
        {
            return metierAuthentification.CheckUser(identifiantinbd, mdp);
        }

        public bool CheckAdmin() => metierAuthentification.CheckAdmin();

        public Utilisateur UserInformation(string identifiantinbd, string mdp) => metierAuthentification.UserInformation(identifiantinbd, mdp);


        //Metier pour les rendez-vous
        /// <summary>
        /// Represents the business logic layer for managing appointments.
        /// </summary>
        /// <remarks>This field provides access to the <see cref="RvMetier"/> instance, which contains
        /// methods and  functionality for handling appointment-related operations.</remarks>
        private RvMetier metierRendezVous = new RvMetier();

        public bool AddRendezVous(RendezVous rv)=> metierRendezVous.AddRendezVous(rv);


        //Metier pour les Creneaux
        /// <summary>
        /// Represents the business logic layer for managing time slots.
        /// </summary>
        /// <remarks>This field provides access to the <see cref="CreneauxMetier"/> instance,  which
        /// contains methods and operations related to time slot management.</remarks>
        private CreneauxMetier metierCreneau = new CreneauxMetier();
        public bool AddCreneaux(Creneau creneau)=> metierCreneau.AddCreneaux(creneau);



        //Metier pour les methodes generales
        /// <summary>
        /// Provides access to general business logic methods.
        /// </summary>
        /// <remarks>This field is intended to encapsulate an instance of <see cref="GeneralMetier"/>  for
        /// use in general-purpose operations. It is a private member and not accessible  outside the containing
        /// class.</remarks>
        private GeneralMetier metierGeneral = new GeneralMetier();

        public List<string> GetPhoneNumbersForAutoComplete(int limit)
        {
            if (limit <= 0)
                limit = 5; // Application valeur par défaut
            return metierGeneral.GetPhoneNumbersForAutoComplete(limit);
        }
        public List<Soin> GetListSoins() => metierGeneral.GetListSoins();
        public List<GroupeSanguin> GetListeGroupesSanguins()=> metierGeneral.GetListeGroupesSanguins();

    }
}
