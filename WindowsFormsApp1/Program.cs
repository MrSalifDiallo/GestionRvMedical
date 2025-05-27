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
            // Vérifier si l'utilisateur admin existe déjà dans la base de données
            ServiceMetierAuthentification.AuthentificationServiceClient serviceAuthentification = new ServiceMetierAuthentification.AuthentificationServiceClient(); // ✅ Service WCF for General Method
            bool adminExists = serviceAuthentification.CheckAdmin();
            if (adminExists)
            {
                serviceAuthentification.AddFirstUser();
            }
        }
    }
}
