using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Report;
using WindowsFormsApp1.View;
using WindowsFormsApp1.Helper;
using WindowsFormsApp1.View.Api;
using WindowsFormsApp1.View.GunaUi;
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
            Application.Run(new frmConnexion());

            //A Décommenter lors d'essai d'un frm
/*            Application.Run(new frmListePatient());
*/        }
        static void CreateAdmin()
        {
            // La méthode AddFirstUser contient déjà la logique de vérification
            AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient();
            allService.AddFirstUser();
        }
    }
}
