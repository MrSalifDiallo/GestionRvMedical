using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierRvMedical.Model;

namespace WindowsFormsApp1.Helper
{
    public class Utils
    {
        BdRvMedicalContext db=new BdRvMedicalContext();
        /// <summary>
        /// Pour Rédiger les Erreurs au niveau de la Base de Donnée.
        /// Donc Log dans la Base de Donnée
        /// </summary>
        /// <param name="TitreErreur"></param>
        /// <param name="erreur"></param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                Td_Erreur log = new Td_Erreur();
                log.DateErreur = DateTime.Now;
                log.DescriptionErreur = erreur.Length > 2000 ? erreur.Substring(0, 2000) : erreur;
                log.TitreErreur = TitreErreur;
                db.td_Erreurs.Add(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }

        }
        /// <summary>
        /// Ecrire un message d'erreur au niveau du Système
        /// Permet de Logger dans le système
        /// </summary>
        /// <param name="erreur">Le Message d'erreur</param>
        /// <param name="libelle">Le Titre de l'erreur</param>
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "GestionRVMedical";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.FailureAudit, 101, 1);
            }
        }

        /// <summary>
        /// Pour créer un fichier d'erreur
        /// </summary>
        /// <param name="message">le message d'erreur</param>
        /// <returns>retourne si le fichier est créer</returns>
        public bool CreateErrorFile(string message)
        {
            bool rep = false;
            string fileName = string.Format("{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Error/" + fileName + ".txt");
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.Create(path);
                bool fileUse = true;
                while (fileUse)
                {
                    try
                    {
                        System.IO.TextWriter writeFile = new StreamWriter(path, true);
                        writeFile.WriteLine("" + DateTime.Now);
                        writeFile.WriteLine(message);
                        writeFile.WriteLine("-------------------------------------------");
                        writeFile.Flush();
                        writeFile.Close();
                        writeFile = null;
                        fileUse = false;
                    }
                    catch (Exception e)
                    {
                        WriteLogSystem(e.ToString(), "CreateFile");
                    }
                }
                rep = true;
            }
            catch (IOException e)
            {
                WriteLogSystem(e.ToString(), "WriteFileError");
            }
            return rep;
        }



    }
}
