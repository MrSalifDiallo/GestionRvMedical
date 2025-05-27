using MetierRvMedical.Helper;
using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MetierRvMedical.Services
{
    public class AuthentificationMetier
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();
        Utils utils = new Utils();

        public bool CheckAdmin()
        {
            try
            {
                int adminInBd = bd.Utilisateurs.Count(a => a.identifiant.ToLower() == "admin");
                return adminInBd == 0;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur dans CheckAdmin");
                utils.WriteDataError("Erreur dans CheckAdmin", ex.ToString());
                return false;
            }
        }

        public bool AddFirstUser()
        {
            try
            {
                bool checkadmin = CheckAdmin();
                if (!checkadmin) return false;

                Utilisateur admin = new Utilisateur
                {
                    identifiant = "admin",
                    MotDePasse = Helper.CryptString.GetMd5Hash("passer"),
                    NomPrenom = "User",
                    Adresse = "UserAdresse",
                    TEL = "UseTel",
                    Email = "user@example.com",
                    statut = true,
                    IdRole = bd.Roles.FirstOrDefault(a => a.Code.ToLower() == "admin")?.Id ?? 0
                };

                bd.Utilisateurs.Add(admin);
                bd.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur DbUpdate dans AddFirstUser");
                utils.WriteDataError("Erreur lors de l'ajout du premier utilisateur (DbUpdate)", ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur générale dans AddFirstUser");
                utils.WriteDataError("Erreur lors de l'ajout du premier utilisateur", ex.ToString());
                return false;
            }
        }

        public bool CheckUser(string identifiantinbd, string mdp)
        {
            try
            {
                string mdpCrypt = Helper.CryptString.GetMd5Hash(mdp);
                var leUser = bd.Utilisateurs
                    .Where(a => a.identifiant.ToLower() == identifiantinbd)
                    .AsEnumerable()
                    .FirstOrDefault(a => a.MotDePasse == mdpCrypt);
                
                return leUser != null;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur dans CheckUser");
                utils.WriteDataError("Erreur lors de la vérification de l'utilisateur", ex.ToString());
                return false;
            }
        }

        public Utilisateur UserInformation(string identifiantinbd, string mdp)
        {
            try
            {
                string mdpCrypt = Helper.CryptString.GetMd5Hash(mdp);
                var utilisateur = bd.Utilisateurs
                    .Include(u => u.Role) //Permet de charger Role avec la clé etrangere IdRole
                    .FirstOrDefault(a => a.identifiant.ToLower() == identifiantinbd && a.MotDePasse == mdpCrypt);

                return utilisateur;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur dans UserInformation");
                utils.WriteDataError("Erreur lors de la récupération des informations utilisateur", ex.ToString());
                return null;
            }
        }

    }
}