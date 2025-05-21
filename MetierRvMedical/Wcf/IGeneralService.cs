using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace MetierRvMedical.Wcf
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IGeneralService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IGeneralService
    {
        [OperationContract]
        List<string> GetPhoneNumbersForAutoComplete(int limit);
    }
}
