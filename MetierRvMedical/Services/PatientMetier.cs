using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MetierRvMedical.Helper;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;

namespace MetierRvMedical.Services
{
    public class PatientMetier
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();
        Utils utils = new Utils();

        /// <summary>
        /// Ajout Patients dans la base de donnée
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
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "frmPatients-btnValider_Click - Erreur");
                utils.WriteDataError("frmPatients-btnValider_Click - Erreur", ex.ToString());
                return false;
            }
        }


        /// <summary>
        /// Supprime un patient de la base de données
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public bool RemovePatient(Patient patient)
        {
            try
            {
                bd.Entry(patient).State = EntityState.Deleted;
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
                /// <summary> Erreur Sql
                else if (ex is SqlException sqlEx)
                {
                    utils.WriteDataError("SQL Error", sqlEx.Message);
                    Utils.WriteLogSystem(sqlEx.ToString(), "SQL Exception");
                }
                else
                {
                    utils.WriteDataError("Unexpected Error", ex.Message);
                    Utils.WriteLogSystem(ex.ToString(), "Unhandled Exception");
                }

                return false;
            }
        }

        /// <summary>
        /// Set up Patient dans la base de donnée
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>

        public bool UpdatePatient(Patient patient)
        {
            try
            {
                bd.Entry(patient).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "UpdatePatient");
                return false;
            }
        }

        public List<Patient> GetListePatients()
        {
            return bd.Patients.ToList();
        }

        /// <summary>
        /// Génération de la liste des Groupes Sanguins
        /// </summary>
        /// <returns></returns>
        public List<GroupeSanguin> GetListeGroupesSanguins()
        {
            return bd.GroupeSanguins.ToList();
        }

        /// <summary>
        /// Trouve les infos du patient a travers son numéro de téléphone
        /// </summary>
        /// <param name="phoneNumberInput"></param>
        /// <returns></returns>
        public Patient ResearchPatient(string phoneNumberInput)
        {
            if (string.IsNullOrWhiteSpace(phoneNumberInput))
                return null;

            // Extraire le numéro avant le " - "
            var phoneParts = phoneNumberInput.Split(new[] { " - " }, StringSplitOptions.None);
            if (phoneParts.Length == 0)
                return null;

            string phoneNumber = phoneParts[0].Trim();

            // Recherche du patient
            var patient = bd.Patients
                                    .Include(p => p.GroupeSanguin) //Permet de charger le groupe sanguin avec la clé etrangere IdGroupeSanguin
                                    .FirstOrDefault(p => p.TEL == phoneNumber);
            return patient; // Retourne le patient ou null s'il n'existe pas
        }


    }
}
