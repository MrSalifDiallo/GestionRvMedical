using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IRendezVousService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IRendezVousService
    {
        [OperationContract]
        bool AddRendezVous(RendezVous rv);
    }
}
