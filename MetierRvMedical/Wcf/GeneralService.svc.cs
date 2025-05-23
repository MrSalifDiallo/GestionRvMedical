using MetierRvMedical.Model;
using MetierRvMedical.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "GeneralService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez GeneralService.svc ou GeneralService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class GeneralService : IGeneralService
    {
        private GeneralMetier metier = new GeneralMetier();

        public List<string> GetPhoneNumbersForAutoComplete(int limit)
        {
            if (limit <= 0)
                limit = 5; // Application valeur par défaut
            return metier.GetPhoneNumbersForAutoComplete(limit);
        }
        public List<Soin> GetListSoins()=> metier.GetListSoins();
        public List<GroupeSanguin> GetListeGroupesSanguins() => metier.GetListeGroupesSanguins();

    }
}
