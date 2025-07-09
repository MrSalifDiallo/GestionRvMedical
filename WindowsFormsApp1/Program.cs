using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Helper;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Report;
using WindowsFormsApp1.View;
using WindowsFormsApp1.View.Api;
using WindowsFormsApp1.View.GunaUi;
using WindowsFormsApp1.View.Medecin;
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
            CreateTicketsFolder();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*            Application.Run(new frmConnexion());
            */
            //A Décommenter lors d'essai d'un frm

            Application.Run(new frmPatients());
        }
        static void CreateAdmin()
        {
            // La méthode AddFirstUser contient déjà la logique de vérification
            AllServiceMetier.AllServiceClient allService = new AllServiceMetier.AllServiceClient();
            allService.AddFirstUser();
        }

        static void CreateTicketsFolder()
        {
            string dossier = Path.Combine(Application.StartupPath, "TicketsPDF");
            if (!Directory.Exists(dossier))
            {
                Directory.CreateDirectory(dossier);
                Console.WriteLine($"Dossier créé : {dossier}");
            }
            else
            {
                Console.WriteLine("Dossier TicketsPDF déjà présent.");
            }
        }
    }
}
