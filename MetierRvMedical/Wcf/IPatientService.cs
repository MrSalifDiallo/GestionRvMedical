using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IPatientService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        List<Patient> GetListePatients();
        [OperationContract]
        bool AddPatient(Patient patient);
        [OperationContract]
        bool UpdatePatient(Patient patient);
        [OperationContract]
        bool RemovePatient(Patient patient);
        [OperationContract]
        List<GroupeSanguin> GetListeGroupesSanguins();
        [OperationContract]
        Patient ResearchPatient(string phoneNumberInput);
    }
}
