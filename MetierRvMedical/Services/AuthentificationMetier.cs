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
                Utils.WriteLogSystem($"Nombre d'admins trouvés: {adminInBd}", "CheckAdmin");
                
                if (adminInBd >= 1)
                {
                    Utils.WriteLogSystem("Admin existe déjà", "CheckAdmin");
                    return true;
                }
                
                Utils.WriteLogSystem("Aucun admin trouvé", "CheckAdmin");
                return false;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem($"Erreur dans CheckAdmin: {ex.Message}", "CheckAdmin");
                utils.WriteDataError("Erreur dans CheckAdmin", ex.ToString());
                return false;
            }
        }

        public bool AddFirstUser()
        {
            try
            {
                bool checkadmin = CheckAdmin();
                Utils.WriteLogSystem($"CheckAdmin retourne: {checkadmin}", "AddFirstUser");
                
                if (checkadmin)
                {
                    Utils.WriteLogSystem("Admin existe déjà, on ne crée pas de nouvel admin", "AddFirstUser");
                    return false;
                }

                // Vérifier si le rôle admin existe
                var roleAdmin = bd.Roles.FirstOrDefault(a => a.Code.ToLower() == "admin");
                if (roleAdmin == null)
                {
                    Utils.WriteLogSystem("Le rôle admin n'existe pas dans la base de données", "AddFirstUser");
                    return false;
                }

                Utilisateur admin = new Utilisateur
                {
                    identifiant = "admin",
                    MotDePasse = Helper.CryptString.GetMd5Hash("passer"),
                    NomPrenom = "User",
                    Adresse = "UserAdresse",
                    TEL = "UseTel",
                    Email = "user@example.com",
                    statut = true,
                    IdRole = roleAdmin.Id
                };

                bd.Utilisateurs.Add(admin);
                int result = bd.SaveChanges();
                Utils.WriteLogSystem($"Admin créé avec succès. Résultat SaveChanges: {result}", "AddFirstUser");
                return true;
            }
            catch (DbUpdateException ex)
            {
                Utils.WriteLogSystem($"Erreur DbUpdate dans AddFirstUser: {ex.Message}", "AddFirstUser");
                utils.WriteDataError("Erreur lors de l'ajout du premier utilisateur (DbUpdate)", ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem($"Erreur générale dans AddFirstUser: {ex.Message}", "AddFirstUser");
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