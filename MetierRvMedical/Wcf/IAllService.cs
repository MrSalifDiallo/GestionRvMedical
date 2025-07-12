using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAllService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAllService
    {
        // Agenda Service Operations
        [OperationContract]
        List<Agenda> LoadAgenda(DateTime datetoday);
        [OperationContract]
        List<Dictionary<string, object>> LoadCreneauxByDate(DateTime dateRecherche);
        [OperationContract]
        List<Dictionary<string, object>> CreneauxByHoraire(DateTime dateRecherche);
        [OperationContract]
        List<int> ListeTimeCreneau(DateTime dateRecherche);
        [OperationContract]
        List<Dictionary<string, object>> CreneauxByHoraireMedecin(DateTime dateRecherche, int idMedecin);


        // Authentification Service Operations
        [OperationContract]
        bool AddFirstUser();
        [OperationContract]
        bool CheckUser(string identifiantinbd, string mdp);
        [OperationContract]
        bool CheckAdmin();
        [OperationContract]
        Utilisateur UserInformation(string identifiantinbd, string mdp);

        //General Service Operations
        [OperationContract]
        List<string> GetPhoneNumbersForAutoComplete(int limit);

        [OperationContract]
        List<Soin> GetListSoins();

        [OperationContract]
        List<GroupeSanguin> GetListeGroupesSanguins();

        //Patient Service Operations
        [OperationContract]
        List<Patient> GetListePatients();
        [OperationContract]
        bool AddPatient(Patient patient);
        [OperationContract]
        bool UpdatePatient(Patient patient);
        [OperationContract]
        bool RemovePatient(Patient patient);
        [OperationContract]
        Patient ResearchPatient(string phoneNumberInput);

        //Creneaux Service Operations
        [OperationContract]
         int AddCreneaux(Creneau creneau);

        // RendezVous Service Operations
        [OperationContract]
        bool AddRendezVous(RendezVous rv);

    }
}
