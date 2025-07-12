using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceSendMail.Helper
{
    public class Utils
    {
        /// <summary>
        /// Ecrire un message d'erreur au niveau du Système
        /// Permet de Logger dans le système
        /// </summary>
        /// <param name="erreur">Le Message d'erreur</param>
        /// <param name="libelle">Le Titre de l'erreur</param>
        public static void WriteLogSystem(string erreur, string libelle,string sourceOfLogging)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = sourceOfLogging;
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.FailureAudit, 101, 1);
            }
        }
    }
}
