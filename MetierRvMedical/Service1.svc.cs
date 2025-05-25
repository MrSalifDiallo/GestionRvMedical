using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MetierRvMedical.Helper;


namespace MetierRvMedical
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        Utils utils = new Utils();
        BdRvMedicalContext bd =new BdRvMedicalContext();
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        /// <summary>
        /// Retourne la liste des Patients
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetListePatients()
        {
            return bd.Patients.ToList();
        }
        /// <summary>
        /// Retourne la liste des medecins
        /// </summary>
        /// <returns></returns>
        public List<Medecin> GetListeMedecins()
        {
            return bd.Medecins.ToList();
        }
        /// <summary>
        /// Retourne la liste des agendas
        /// </summary>
        /// <returns></returns>
        public List<Agenda> GetListeAgendas()
        {
            return bd.Agendas.ToList();
        }




        /// <summary>
        /// Ajout Patients dans la base
        /// </summary>
        /// <returns></returns>
        public bool AddPatient(Patient patient)
        {
            try
            {
                bd.Patients.Add(patient);
                bd.SaveChanges();
                return true;
            }
            catch(Exception ex){
                Utils.WriteLogSystem(ex.ToString(), "frmPatients-btnValider_Click - Erreur");
                utils.WriteDataError("frmPatients-btnValider_Click - Erreur", ex.ToString());
                return false;
            }
        }

        public bool RemovePatient(Patient patient) {
            try
            {
                bd.Entry(patient).State=EntityState.Deleted;
                bd.Patients.Remove(patient);
                return true;
            }
            catch (Exception ex)
            {
                // Analyse du type réel de l'exception ici
                if (ex is DbEntityValidationException dbEx)
                {
                    foreach (var eve in dbEx.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            utils.WriteDataError("Validation Error",
                                $"Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                        }
                    }
                    Utils.WriteLogSystem(dbEx.ToString(), "Validation Exception");
                }
                else if (ex is DbUpdateException updateEx)
                {
                    var inner = updateEx.InnerException?.InnerException;
                    string message = inner != null ? inner.Message : updateEx.Message;
                    utils.WriteDataError("Update Error", message);
                    Utils.WriteLogSystem(updateEx.ToString(), "Update Exception");
                }
                else if (ex is InvalidOperationException invalidOp)
                {
                    utils.WriteDataError("Invalid Operation", invalidOp.Message);
                    Utils.WriteLogSystem(invalidOp.ToString(), "InvalidOperationException");
                }
                else
                {
                    utils.WriteDataError("Unexpected Error", ex.Message);
                    Utils.WriteLogSystem(ex.ToString(), "Unhandled Exception");
                }

                return false;
            }
        }

        public bool UpdatePatient(Patient patient)
        {
            try
            {
                bd.Entry(patient).State=EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "-Erreur");
                utils.WriteDataError("Erreur-", ex.ToString());
                return false;
            }
        }

        public List<GroupeSanguin> GetListeGroupesSanguins()
        {
            return bd.GroupeSanguins.ToList();
        }
    }
}
