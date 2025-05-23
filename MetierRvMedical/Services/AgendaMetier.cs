using MetierRvMedical.Helper;
using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;


namespace MetierRvMedical.Services
{
    public class AgendaMetier
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();

        Utils utils = new Utils();

        /// <summary>
        /// Retourne la liste des agendas pour une date donnée
        /// </summary>
        /// <param name="datetoday"></param>
        /// <returns></returns>
        public List<Agenda> LoadAgenda(DateTime datetoday)
        {
            try
            {
                // .Where(a => DbFunctions.TruncateTime(a.DatePlanifie) == datetoday.Date)
                //Pour eviter la comparaison entre de la date en jour mois annnée
                var agenda = bd.Agendas
                           .Where(a => a.DatePlanifie.HasValue &&
                                       a.DatePlanifie.Value.Day == datetoday.Day &&
                                       a.DatePlanifie.Value.Month == datetoday.Month &&
                                       a.DatePlanifie.Value.Year == datetoday.Year)
                           .Include(m => m.Medecin) // Inclure la navigation vers Medecin
                           .ToList();
                return agenda;
            }
            catch (Exception ex)
            {
                // Gérer l'exception (journaliser, relancer, etc.)
                Utils.WriteLogSystem(ex.ToString(), "Erreur lors du chargement de l'agenda - Erreur");
                utils.WriteDataError("Erreur lors du chargement de l'agenda : - Erreur", ex.ToString());
                return null;
            }

        }

        // Liste des créneaux distincts pour une date donnée
        /// <summary>
        /// Liste des créneaux distincts pour une date donnée 
        /// </summary>
        /// <param name="dateRecherche"></param>
        /// <returns></returns>
        public List<int> ListeTimeCreneau(DateTime dateRecherche)
        {
            // Utilisation de LoadAgenda pour récupérer les agendats
            var agenda = LoadAgenda(dateRecherche);

            // Extraction des créneaux distincts
            var distinctCreneaux = agenda
                                    .Select(a => a.Creneau) // Récupère les créneaux en tant qu'entiers
                                    .Distinct() // Évite les doublons
                                    .OrderBy(c => c) // 🔥 TRIER ici
                                    .ToList(); // Convertit en liste
            return distinctCreneaux;
        }

       

        /// <summary>
        /// Générer un tableau des créneaux pour une date donnée.Si le créneau est déjà pris, il est marqué comme occupé.
        /// </summary>
        /// <param name="agendas"></param>
        /// <param name="dateRecherche"></param>
        /// <param name="creneauxPrises"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> LoadCreneauxByDate(
            DateTime dateRecherche)
        {
            var tableau = new List<Dictionary<string, object>>();
            // Utilisation de LoadAgenda pour récupérer les agendas pour la date donnée
            var agendas = LoadAgenda(dateRecherche);
            // Récupérer tous les créneaux pour la date donnée
            var creneauxPrises = bd.Creneaux
                .Where(c => c.Date == dateRecherche)
                .ToList();
            foreach (var a in agendas)
            {
                // Convertir HeureDebut et HeureFin en DateTime
                DateTime heureDebut = DateTime.ParseExact(a.HeureDebut, "HH:mm", CultureInfo.InvariantCulture);
                DateTime heureFin = DateTime.ParseExact(a.HeureFin, "HH:mm", CultureInfo.InvariantCulture);
                // Générer les créneaux
                while (heureDebut < heureFin)
                {
                    DateTime nextTime = heureDebut.AddMinutes(a.Creneau);

                    // Vérifier si ce créneau est déjà pris
                    var heureDebutFormatted = TimeSpan.ParseExact(heureDebut.ToString("HH:mm"), "hh\\:mm", CultureInfo.InvariantCulture);
                    var heureFinFormatted = TimeSpan.ParseExact(nextTime.ToString("HH:mm"), "hh\\:mm", CultureInfo.InvariantCulture);
                    bool isSlotOccupied = creneauxPrises
                        .Where(c => c.IdAgenda == a.IdAgenda) // filtre ici
                        .Any(c => TimeSpan.ParseExact(c.HeureDebut, "hh\\:mm", CultureInfo.InvariantCulture) == heureDebutFormatted &&
                        TimeSpan.ParseExact(c.HeureFin, "hh\\:mm", CultureInfo.InvariantCulture) == heureFinFormatted);

                    /*if (!isSlotOccupied)
                    {
                        tableau.Add(new Dictionary<string, object>
                        {
                            ["IdAgenda"] = a.IdAgenda,
                            ["idMedecin"] = a.IdMedecin,
                            ["medecin"] = a.Medecin.NomPrenom,
                            ["creneau"] = a.Creneau,
                            ["date"] = dateRecherche.ToString("yyyy-MM-dd"),
                            ["heureDebut"] = heureDebut.ToString("HH:mm"),
                            ["heureFin"] = nextTime.ToString("HH:mm"),
                            ["estOccupe"] = isSlotOccupied
                        });
                    }*/
                    tableau.Add(new Dictionary<string, object>
                    {
                        ["IdAgenda"] = a.IdAgenda,
                        ["idMedecin"] = a.IdMedecin,
                        ["medecin"] = a.Medecin.NomPrenom,
                        ["creneau"] = a.Creneau,
                        ["date"] = dateRecherche.ToString("yyyy-MM-dd"),
                        ["heureDebut"] = heureDebut.ToString("HH:mm"),
                        ["heureFin"] = nextTime.ToString("HH:mm"),
                        ["estOccupe"] = isSlotOccupied
                    });
                    // Passer au créneau suivant
                    heureDebut = nextTime;
                }
            }
            return tableau;
        }

        /// <summary>
        /// Va Grouper les créneaux par plages d'horaires
        /// </summary>
        /// <param name="dateRecherche"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> CreneauxByHoraire(DateTime dateRecherche)
        {
            var creneaux = LoadCreneauxByDate(dateRecherche);

            var resultat = creneaux
                .GroupBy(c => new
                {
                    HeureDebut = c["heureDebut"].ToString(),
                    HeureFin = c["heureFin"].ToString(),
                    TimeCreneau = c["creneau"].ToString(),
                })
                .Select(g =>
                {
                    int total = g.Count();
                    int occupe = g.Count(x => Convert.ToBoolean(x["estOccupe"]));
                    int libre = total - occupe;

                    return new Dictionary<string, object>
                    {
                        ["horaire"] = $"{g.Key.HeureDebut} - {g.Key.HeureFin}",
                        ["nombre"] = total,
                        ["occupe"] = occupe,
                        ["libre"] = libre,
                        ["TimeCreneau"] = g.Key.TimeCreneau,
                        ["estOccupe"] = occupe > 0 // true si au moins un est occupé
                    };
                })
                .ToList();

            return resultat;
        }

    }
}