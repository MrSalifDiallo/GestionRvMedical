using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierRvMedical.Services
{
    public class AgendaMetier
    {
        BdRvMedicalContext bd=new BdRvMedicalContext();
        public List<Agenda> LoadAgenda(DateTime datetoday)
        {
            var agenda = bd.Agendas
                           .Where(a => a.DatePlanifie.HasValue &&
                                       a.DatePlanifie.Value.Day == datetoday.Day &&
                                       a.DatePlanifie.Value.Month == datetoday.Month &&
                                       a.DatePlanifie.Value.Year == datetoday.Year)
                           .ToList();
            return agenda;
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
                                    .ToList(); // Convertit en liste
            return distinctCreneaux;
        }




    }
}