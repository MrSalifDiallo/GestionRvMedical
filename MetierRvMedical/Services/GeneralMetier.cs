using MetierRvMedical.Helper;
using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

namespace MetierRvMedical.Services
{
    public class GeneralMetier
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();
        Utils utils=new Utils();

        /// <summary>
        /// Retourne la liste des numéros de téléphone pour une autocomplétion
        /// </summary>
        public List<string> GetPhoneNumbersForAutoComplete(int limit = 5)
        {
            var rawPhones = bd.Patients
                              .OrderBy(p => p.TEL)
                              .Take(limit)
                              .Select(p => new { p.TEL, p.NomPrenom })
                              .ToList(); 
            var phoneDetails = rawPhones
                               .Select(p => $"{p.TEL} - {p.NomPrenom}")
                               .ToList();

            return phoneDetails;
        }

        public List<Soin> GetListSoins()
        {
            return bd.Soins.ToList();

        }

        public List<GroupeSanguin> GetListeGroupesSanguins()
        {
            return bd.GroupeSanguins.ToList();
        }
        public bool  CheckAdmin()
        {
            int adminInBd = bd.Utilisateurs.Where(a => a.identifiant.ToLower() == "admin").Count();
            if (adminInBd==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddFirstUser()
        {
            bool checkadmin = CheckAdmin();
            if (checkadmin)
            {
                Utilisateur admin = new Utilisateur();
                admin.identifiant = "admin";
                admin.MotDePasse = Helper
                    .CryptString.GetMd5Hash("passer");
                admin.NomPrenom = "User";
                admin.Adresse = "UserAdresse";
                admin.TEL = "UseTel";
                admin.Email = "user@example.com";
                admin.statut = true;
                admin.IdRole = bd.Roles.Where(a=>a.Code.ToLower()=="Admin").FirstOrDefault().Id; // Assuming ID for the admin role
                try
                {

                    bd.Utilisateurs.Add(admin);
                    bd.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Utils.WriteLogSystem(ex.ToString(), "frmPatients-Connexion - Erreur");
                    utils.WriteDataError("frmConnexion-AddDefaultUser- Erreur", ex.ToString());
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

        public bool CheckUser(string identifiantinbd, string mdp)
        {
            string mdpCrypt = Helper.CryptString.GetMd5Hash(mdp);
            var leUser = bd.Utilisateurs
               .Where(a => a.identifiant.ToLower() == identifiantinbd)
               .AsEnumerable() // passe en LINQ to Objects après le filtre SQL
               .FirstOrDefault(a => a.MotDePasse == mdp);
            if (leUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
          
    }
}
