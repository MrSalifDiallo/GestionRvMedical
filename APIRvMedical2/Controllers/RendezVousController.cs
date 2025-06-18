using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIRvMedical2.Models;
using System.Data.Entity;

namespace APIRvMedical2.Controllers
{
    public class RendezVousController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/RendezVous
        public IEnumerable<RendezVous> Get()
        {
            return db.AllRendezvous.Include(r => r.Patient).Include(r => r.Medecin).ToList();
        }

        // GET: api/RendezVous/5
        public IHttpActionResult Get(int id)
        {
            var rv = db.AllRendezvous.Include(r => r.Patient).Include(r => r.Medecin).FirstOrDefault(r => r.IdRv == id);
            if (rv == null)
                return NotFound();
            return Ok(rv);
        }

        // GET: api/RendezVous/by-patient?idPatient=1
        [HttpGet]
        [Route("api/RendezVous/by-patient")]
        public IHttpActionResult GetByPatient(int idPatient)
        {
            var rvs = db.AllRendezvous.Where(r => r.IdPatient == idPatient).ToList();
            return Ok(rvs);
        }

        // GET: api/RendezVous/by-medecin?idMedecin=1
        [HttpGet]
        [Route("api/RendezVous/by-medecin")]
        public IHttpActionResult GetByMedecin(int idMedecin)
        {
            var rvs = db.AllRendezvous.Where(r => r.IdMedecin == idMedecin).ToList();
            return Ok(rvs);
        }

        // POST: api/RendezVous
        public IHttpActionResult Post(RendezVous rv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.AllRendezvous.Add(rv);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = rv.IdRv }, rv);
        }

        // PUT: api/RendezVous/5
        public IHttpActionResult Put(int id, RendezVous rv)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != rv.IdRv)
                return BadRequest();
            db.Entry(rv).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/RendezVous/5
        public IHttpActionResult Delete(int id)
        {
            var rv = db.AllRendezvous.Find(id);
            if (rv == null)
                return NotFound();
            db.AllRendezvous.Remove(rv);
            db.SaveChanges();
            return Ok(rv);
        }
    }
}