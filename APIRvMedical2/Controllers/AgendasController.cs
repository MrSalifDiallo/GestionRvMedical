using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIRvMedical2.Models;
using System.Data.Entity;

namespace APIRvMedical2.Controllers
{
    public class AgendasController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/Agendas/date?date=2024-06-01
        [HttpGet]
        [Route("api/Agendas/date")]
        public IHttpActionResult GetAgendaByDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dateRecherche))
                return BadRequest("Format de date invalide");

            var agendas = db.Agendas
                .Include(a => a.Medecin)
                .Where(a => a.DatePlanifie.Year == dateRecherche.Year &&
                            a.DatePlanifie.Month == dateRecherche.Month &&
                            a.DatePlanifie.Day == dateRecherche.Day)
                .ToList();

            return Ok(agendas);
        }

        // GET: api/Agendas/creneaux-distincts?date=2024-06-01
        [HttpGet]
        [Route("api/Agendas/creneaux-distincts")]
        public IHttpActionResult GetDistinctCreneaux(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dateRecherche))
                return BadRequest("Format de date invalide");

            var creneaux = db.Agendas
                .Where(a => a.DatePlanifie.Year == dateRecherche.Year &&
                            a.DatePlanifie.Month == dateRecherche.Month &&
                            a.DatePlanifie.Day == dateRecherche.Day)
                .Select(a => a.Creneau)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            return Ok(creneaux);
        }

        // GET: api/Agendas/creneaux-by-date?date=2024-06-01
        [HttpGet]
        [Route("api/Agendas/creneaux-by-date")]
        public IHttpActionResult GetCreneauxByDate(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dateRecherche))
                return BadRequest("Format de date invalide");

            var agendas = db.Agendas
                .Include(a => a.Medecin)
                .Where(a => a.DatePlanifie.Year == dateRecherche.Year &&
                            a.DatePlanifie.Month == dateRecherche.Month &&
                            a.DatePlanifie.Day == dateRecherche.Day)
                .ToList();

            var creneaux = new List<object>();
            foreach (var a in agendas)
            {
                creneaux.Add(new {
                    a.IdAgenda,
                    a.IdMedecin,
                    Medecin = a.Medecin?.NomPrenom,
                    a.Creneau,
                    Date = a.DatePlanifie.ToString("yyyy-MM-dd"),
                    a.HeureDebut,
                    a.HeureFin
                });
            }
            return Ok(creneaux);
        }
    }
}