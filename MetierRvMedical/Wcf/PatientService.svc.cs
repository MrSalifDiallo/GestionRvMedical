using MetierRvMedical.Model;
using MetierRvMedical.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "PatientService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez PatientService.svc ou PatientService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class PatientService : IPatientService
    {
        private PatientMetier metier = new PatientMetier();

        public List<Patient> GetListePatients() => metier.GetListePatients();

        public bool AddPatient(Patient patient) => metier.AddPatient(patient);

        public bool UpdatePatient(Patient patient) => metier.UpdatePatient(patient);

        public bool RemovePatient(Patient patient) => metier.RemovePatient(patient);

        public List<GroupeSanguin> GetListeGroupesSanguins() => metier.GetListeGroupesSanguins();

        public Patient ResearchPatient(string phoneNumberInput) => metier.ResearchPatient(phoneNumberInput);
    }
}
