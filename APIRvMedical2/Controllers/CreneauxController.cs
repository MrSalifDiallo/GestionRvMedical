using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIRvMedical2.Models;
using System.Data.Entity;

namespace APIRvMedical2.Controllers
{
    public class CreneauxController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/Creneaux
        public IEnumerable<Creneau> Get()
        {
            return db.Creneaux.ToList();
        }

        // GET: api/Creneaux/5
        public IHttpActionResult Get(int id)
        {
            var creneau = db.Creneaux.Find(id);
            if (creneau == null)
                return NotFound();
            return Ok(creneau);
        }

        // GET: api/Creneaux/by-date?date=2024-06-01
        [HttpGet]
        [Route("api/Creneaux/by-date")]
        public IHttpActionResult GetByDate(string date)
        {
            if (!System.DateTime.TryParse(date, out System.DateTime dateRecherche))
                return BadRequest("Format de date invalide");
            var creneaux = db.Creneaux.Where(c => c.Date == dateRecherche).ToList();
            return Ok(creneaux);
        }

        // POST: api/Creneaux
        public IHttpActionResult Post(Creneau creneau)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Creneaux.Add(creneau);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = creneau.IdCreneau }, creneau);
        }

        // PUT: api/Creneaux/5
        public IHttpActionResult Put(int id, Creneau creneau)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != creneau.IdCreneau)
                return BadRequest();
            db.Entry(creneau).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/Creneaux/5
        public IHttpActionResult Delete(int id)
        {
            var creneau = db.Creneaux.Find(id);
            if (creneau == null)
                return NotFound();
            db.Creneaux.Remove(creneau);
            db.SaveChanges();
            return Ok(creneau);
        }
    }
}