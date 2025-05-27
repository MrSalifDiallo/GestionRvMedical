using System;
using System.Collections.Generic;
using MetierRvMedical.Services;

namespace ServiceTesting
{
    class ServiceAgenda
    {
        public static void AgendaMethod()
        {
            // Sans WCF
            var agendaMetier = new AgendaMetier();

            // Avec WCF (commenté ici pour utiliser la version locale)
            // ServiceMetierAgenda.AgendaServiceClient service = new ServiceMetierAgenda.AgendaServiceClient();
            // var agendas = service.LoadAgenda(dateRecherche);
            DateTime dateRecherche;
            while (true)
            {
                Console.Write("Entrez une date au format yyyy-MM-dd (ex: 2025-05-23) : ");
                string input = Console.ReadLine()?.Trim();
                if (input == null)
                {
                    Console.WriteLine("Entrée vide détectée.");
                    return;
                }

                if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateRecherche))
                    break;

                Console.WriteLine("Format de date invalide. Veuillez réessayer.");
            }

            // 2. Saisie de l'id médecin
            int idMedecin;
            while (true)
            {
                Console.Write("Entrez l'ID du médecin : ");
                string input2 = Console.ReadLine()?.Trim();
                if (input2 == null)
                {
                    Console.WriteLine("Entrée vide détectée.");
                    return;
                }

                if (int.TryParse(input2, out idMedecin))
                    break;

                Console.WriteLine("Format d'ID invalide. Veuillez entrer un nombre.");
            }

            // 1. Charger les agendas
            Console.WriteLine("\n=== LoadAgenda ===");
            var agendas = agendaMetier.LoadAgenda(dateRecherche);
            foreach (var a in agendas)
            {
                Console.WriteLine($"Agenda - Médecin: {a.Medecin?.NomPrenom}, Créneau: {a.Creneau}, Heure: {a.HeureDebut:HH:mm} - {a.HeureFin:HH:mm}");
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

            // 4. Groupes par horaire
            Console.WriteLine("\n=== CreneauxByHoraire&Medecin ===");
            var groupesparmedecin = agendaMetier.CreneauxByHoraireMedecin(dateRecherche, idMedecin);
            foreach (var g in groupesparmedecin)
            {
                Console.WriteLine($"Horaire: {g["horaire"]}, Total: {g["nombre"]}, Occupé: {g["occupe"]}, Libre: {g["libre"]}");
            }

            Console.WriteLine("\nFin du programme. Appuyez sur une touche pour quitter.");
            Console.ReadKey();
        }
    }
}
