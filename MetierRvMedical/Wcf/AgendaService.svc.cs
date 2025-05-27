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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AgendaService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AgendaService.svc ou AgendaService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AgendaService : IAgendaService
    {
        private AgendaMetier metier = new AgendaMetier();
        public List<Agenda> LoadAgenda(DateTime datetoday) => metier.LoadAgenda(datetoday);

        public void DoWork()
        {
        }

        public List<Dictionary<string, object>> LoadCreneauxByDate(
            DateTime dateRecherche) => metier.LoadCreneauxByDate(dateRecherche);

        public List<Dictionary<string, object>> CreneauxByHoraire(DateTime dateRecherche)
            => metier.CreneauxByHoraire(dateRecherche);
        public List<int> ListeTimeCreneau(DateTime dateRecherche) =>
                    metier.ListeTimeCreneau(dateRecherche);
        public List<Dictionary<string, object>> CreneauxByHoraireMedecin(DateTime dateRecherche, int idMedecin)=>
            metier.CreneauxByHoraireMedecin(dateRecherche, idMedecin);
    }
}
