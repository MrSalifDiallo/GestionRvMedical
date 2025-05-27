using MetierRvMedical.Helper;
using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure; // Pour DbUpdateException
using System.Data.Entity.Validation;  // Pour DbEntityValidationException
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
                           .Where(a => 
                                       a.DatePlanifie.Day == datetoday.Day &&
                                       a.DatePlanifie.Month == datetoday.Month &&
                                       a.DatePlanifie.Year == datetoday.Year)
                           .Include(m => m.Medecin) // Inclure la navigation vers Medecin
                           .ToList();
                return agenda;
            }
            catch (DbEntityValidationException ex)
            {
                // Erreur de validation de données Entity Framework
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Utils.WriteLogSystem($"Validation error on property {validationError.PropertyName}: {validationError.ErrorMessage}", "Validation Entity Framework");
                    }
                }
                utils.WriteDataError("Erreur de validation lors du chargement de l'agenda : - Erreur", ex.ToString());
                return null;
            }
            catch (DbUpdateException ex)
            {
                // Erreur lors de la mise à jour ou de l'accès à la base de données
                Utils.WriteLogSystem(ex.ToString(), "Erreur lors de la mise à jour / accès BD dans LoadAgenda");
                utils.WriteDataError("Erreur de mise à jour base de données lors du chargement de l'agenda : - Erreur", ex.ToString());
                return null;
            }
            catch (InvalidOperationException ex)
            {
                // Par exemple, si Include ou la requête LINQ est mal formée
                Utils.WriteLogSystem(ex.ToString(), "InvalidOperationException dans LoadAgenda");
                utils.WriteDataError("Erreur d'opération invalide lors du chargement de l'agenda : - Erreur", ex.ToString());
                return null;
            }
            catch (Exception ex)
            {
                // Autres exceptions générales
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
            try
            {
                // Utilisation de LoadAgenda pour récupérer les agendats
                var agenda = LoadAgenda(dateRecherche)
                            .ToList();
                // Extraction des créneaux distincts
                var distinctCreneaux = agenda
                                        .Select(a => a.Creneau) // Récupère les créneaux en tant qu'entiers
                                        .Distinct() // Évite les doublons
                                        .OrderBy(c => c) // TRIER par ordre croissant
                                        .ToList(); // Convertit en liste
                return distinctCreneaux;
            }
            catch (ArgumentNullException ex)
            {
                // Chargement d'agenda retourne null, tentative d'accès à null
                Utils.WriteLogSystem(ex.ToString(), "ArgumentNullException dans ListeTimeCreneau");
                utils.WriteDataError("Erreur : donnée nulle lors du chargement des créneaux distincts : - Erreur", ex.ToString());
                return new List<int>();
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur lors de la récupération des créneaux distincts - Erreur");
                utils.WriteDataError("Erreur lors de la récupération des créneaux distincts : - Erreur", ex.ToString());
                return new List<int>();
            }
        }

        /// <summary>
        /// Générer un tableau des créneaux pour une date donnée.Si le créneau est déjà pris, il est marqué comme occupé.
        /// </summary>
        /// <param name="dateRecherche"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> LoadCreneauxByDate(DateTime dateRecherche)
        {
            try
            {
                var tableau = new List<Dictionary<string, object>>();
                // Utilisation de LoadAgenda pour récupérer les agendas pour la date donnée
                var agendas = LoadAgenda(dateRecherche);
                if (agendas == null)
                {
                    Utils.WriteLogSystem("LoadAgenda a retourné null dans LoadCreneauxByDate", "Erreur");
                    return tableau;
                }
                // Récupérer tous les créneaux pour la date donnée
                var creneauxPrises = bd.Creneaux
                    .Where(c => c.Date == dateRecherche)
                    .ToList();

                foreach (var a in agendas)
                {
                    // Convertir HeureDebut et HeureFin en DateTime
                    DateTime heureDebut;
                    DateTime heureFin;
                    try
                    {
                        heureDebut = DateTime.ParseExact(a.HeureDebut, "HH:mm", CultureInfo.InvariantCulture);
                        heureFin = DateTime.ParseExact(a.HeureFin, "HH:mm", CultureInfo.InvariantCulture);
                    }
                    catch (FormatException ex)
                    {
                        Utils.WriteLogSystem(ex.ToString(), $"FormatException sur heure début/fin agenda {a.IdAgenda}");
                        utils.WriteDataError($"Format invalide sur heure début/fin agenda {a.IdAgenda}", ex.ToString());
                        continue; // Passer à l'agenda suivant
                    }

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
            catch (DbUpdateException ex)
            {
                // Erreur base données lors du chargement des créneaux
                Utils.WriteLogSystem(ex.ToString(), "Erreur base données dans LoadCreneauxByDate");
                utils.WriteDataError("Erreur base données lors du chargement des créneaux par date : - Erreur", ex.ToString());
                return new List<Dictionary<string, object>>();
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur lors du chargement des créneaux par date - Erreur");
                utils.WriteDataError("Erreur lors du chargement des créneaux par date : - Erreur", ex.ToString());
                return new List<Dictionary<string, object>>();
            }
        }

        /// <summary>
        /// Va Grouper les créneaux par plages d'horaires
        /// </summary>
        /// <param name="dateRecherche"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> CreneauxByHoraire(DateTime dateRecherche)
        {
            try
            {
                var creneaux = LoadCreneauxByDate(dateRecherche);

                var resultat = creneaux
                    .GroupBy(c => new
                    {
                        HeureDebut = c["heureDebut"].ToString(),
                        HeureFin = c["heureFin"].ToString(),
                        TimeCreneau = c["creneau"].ToString(),
                        //IdMedecin = c["idMedecin"]
                    })
                    .Select(g =>
                    {
                        int total = g.Count();
                        int occupe = g.Count(x => Convert.ToBoolean(x["estOccupe"]));
                        int libre = total - occupe;

                        // Récupérer l'idMedecin depuis le premier élément du groupe
                        int idMedecin = g.First().ContainsKey("idMedecin") ? Convert.ToInt32(g.First()["idMedecin"]) : 0;
                        return new Dictionary<string, object>
                        {
                            ["horaire"] = $"{g.Key.HeureDebut} - {g.Key.HeureFin}",
                            ["nombre"] = total,
                            ["occupe"] = occupe,
                            ["libre"] = libre,
                            ["TimeCreneau"] = g.Key.TimeCreneau,
                            ["idMedecin"] = idMedecin, 
                            ["estOccupe"] = occupe > 0 // true si au moins un est occupé
                        };
                    })
                    .ToList();

                return resultat;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur lors du groupement des créneaux par horaire - Erreur");
                utils.WriteDataError("Erreur lors du groupement des créneaux par horaire : - Erreur", ex.ToString());
                return new List<Dictionary<string, object>>();
            }
        }


        /// <summary>
        /// Genere un tableau des créneaux pour une date donnée, groupés par horaire et par médecin.
        /// </summary>
        /// <param name="dateRecherche"></param>
        /// <param name="idMedecin"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> CreneauxByHoraireMedecin(DateTime dateRecherche, int idMedecin)
        {
            try
            {
                var creneaux = LoadCreneauxByDate(dateRecherche)
                    .Where(c => Convert.ToInt32(c["idMedecin"]) == idMedecin) // filtre ici avant le groupement
                    .ToList();

                var resultat = creneaux
                    .GroupBy(c => new
                    {
                        HeureDebut = c["heureDebut"].ToString(),
                        HeureFin = c["heureFin"].ToString(),
                        TimeCreneau = c["creneau"].ToString()
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
                            ["idMedecin"] = idMedecin, // ici tu le remets dans le résultat
                            ["estOccupe"] = occupe > 0
                        };
                    })
                    .OrderBy(r => r["horaire"])
                    .ToList();

                return resultat;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Erreur lors du groupement des créneaux par horaire - Erreur");
                utils.WriteDataError("Erreur lors du groupement des créneaux par horaire : - Erreur", ex.ToString());
                return new List<Dictionary<string, object>>();
            }
        }
    }
}
