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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AuthentificationService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AuthentificationService.svc ou AuthentificationService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AuthentificationService : IAuthentificationService
    {
        private AuthentificationMetier metier = new AuthentificationMetier();
        public bool AddFirstUser() => metier.AddFirstUser();
        public bool CheckUser(string identifiantinbd, string mdp)
        {
            return metier.CheckUser(identifiantinbd, mdp);
        }
        public bool CheckAdmin() => metier.CheckAdmin();
        public Utilisateur UserInformation(string identifiantinbd, string mdp)=> metier.UserInformation(identifiantinbd, mdp);
    }
}
