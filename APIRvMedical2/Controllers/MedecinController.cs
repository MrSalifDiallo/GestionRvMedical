using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIRvMedical2.Models;
using System.Data.Entity;

namespace APIRvMedical2.Controllers
{
    public class MedecinController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/Medecin
        public IEnumerable<Medecin> Get()
        {
            return db.Medecins.ToList();
        }

        // GET: api/Medecin/5
        public IHttpActionResult Get(int id)
        {
            var medecin = db.Medecins.Find(id);
            if (medecin == null)
                return NotFound();
            return Ok(medecin);
        }

        // POST: api/Medecin
        public IHttpActionResult Post(Medecin medecin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Medecins.Add(medecin);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = medecin.IdU }, medecin);
        }

        // PUT: api/Medecin/5
        public IHttpActionResult Put(int id, Medecin medecin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != medecin.IdU)
                return BadRequest();
            db.Entry(medecin).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/Medecin/5
        public IHttpActionResult Delete(int id)
        {
            var medecin = db.Medecins.Find(id);
            if (medecin == null)
                return NotFound();
            db.Medecins.Remove(medecin);
            db.SaveChanges();
            return Ok(medecin);
        }
    }
}