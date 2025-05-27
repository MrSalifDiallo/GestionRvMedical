using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAgendaService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAgendaService
    {
        [OperationContract]
        void DoWork();
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
    }
}
