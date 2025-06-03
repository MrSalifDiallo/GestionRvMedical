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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "CreneauxService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez CreneauxService.svc ou CreneauxService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class CreneauxService : ICreneauxService
    {
        // Implémentez ici les méthodes de votre service. Pour plus d'informations, consultez la documentation WCF.
        private CreneauxMetier metier = new CreneauxMetier();

        public bool AddCreneaux(Creneau creneau)=> metier.AddCreneaux(creneau);
    }
}
