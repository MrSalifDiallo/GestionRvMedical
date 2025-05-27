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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAuthentificationService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAuthentificationService
    {
        [OperationContract]
        bool AddFirstUser();
        [OperationContract]
        bool CheckUser(string identifiantinbd, string mdp);
        [OperationContract]
        bool CheckAdmin();
        [OperationContract]
        Utilisateur UserInformation(string identifiantinbd, string mdp);
    }
}
