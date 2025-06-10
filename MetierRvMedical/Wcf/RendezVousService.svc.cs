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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "RendezVousService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez RendezVousService.svc ou RendezVousService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class RendezVousService : IRendezVousService
    {
        private RvMetier metier = new RvMetier();

        public void DoWork()
        {
        }
        public bool AddRendezVous(RendezVous rv)=> metier.AddRendezVous(rv);
    }
}
