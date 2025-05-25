using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierRvMedical.Services;
namespace TestService
{
     class ServiceAgenda
    {
        public static void AgendaMethod()
        {
            //Sans WCF
            var agendaMetier = new AgendaMetier();

            //Avec WCF
            //ServiceMetierAgenda.AgendaServiceClient service = new ServiceMetierAgenda.AgendaServiceClient();
            //var agendas = service.LoadAgenda(dateRecherche);


            // Demander à l'utilisateur une date
            DateTime dateRecherche;
            while (true)
            {
                Console.Write("Entrez une date au format yyyy-MM-dd (ex: 2025-05-23) : ");
                string input = Console.ReadLine().Trim();

                if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateRecherche))
                    break;

                Console.WriteLine("Format invalide. Veuillez réessayer.");
            }


            // 1. Charger les agendas
            Console.WriteLine("\n=== LoadAgenda ===");
            var agendas = agendaMetier.LoadAgenda(dateRecherche);
            //var agendas = agendaMetier.LoadAgenda(new DateTime(2025, 05, 21)); Debogage
            foreach (var a in agendas)
            {
                Console.WriteLine($"Agenda - Médecin: {a.Medecin?.NomPrenom}, Créneau: {a.Creneau}, Heure: {a.HeureDebut} - {a.HeureFin}");
            }

            // 2. Liste des créneaux distincts
            Console.WriteLine("\n=== ListeTimeCreneau ===");
            var typesCreneaux = agendaMetier.ListeTimeCreneau(dateRecherche);
            foreach (var c in typesCreneaux)
            {
                Console.WriteLine($"Durée créneau: {c} minutes");
            }

            // 3. Créneaux par date
            Console.WriteLine("\n=== LoadCreneauxByDate ===");
            var listeCreneaux = agendaMetier.LoadCreneauxByDate(dateRecherche);
            foreach (var c in listeCreneaux)
            {
                Console.WriteLine($"Médecin: {c["medecin"]}, Heure: {c["heureDebut"]} - {c["heureFin"]}, Occupé: {c["estOccupe"]}");
            }

            // 4. Groupes par horaire
            Console.WriteLine("\n=== CreneauxByHoraire ===");
            var groupes = agendaMetier.CreneauxByHoraire(dateRecherche);
            foreach (var g in groupes)
            {
                Console.WriteLine($"Horaire: {g["horaire"]}, Total: {g["nombre"]}, Occupé: {g["occupe"]}, Libre: {g["libre"]}, MédecinId: {g["idMedecin"]}");
            }

            Console.WriteLine("\nFin du programme. Appuyez sur une touche pour quitter.");
            Console.ReadKey();
        }

    }
}
