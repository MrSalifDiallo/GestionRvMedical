using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Report;
using WindowsFormsApp1.View;
using WindowsFormsApp1.Helper;
namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateAdmin();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConexion());
        }
        static void CreateAdmin()
        {
            BdRvMedicalContext bd = new BdRvMedicalContext();
           int adminInBd = bd.Utilisateurs.Where(a => a.identifiant.ToLower() == "admin").Count();
            if (adminInBd == 0)
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
                bd.Utilisateurs.Add(admin);
                bd.SaveChanges();
            }
        }
    }
}
