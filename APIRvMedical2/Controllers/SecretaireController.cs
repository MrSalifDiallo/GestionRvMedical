using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIRvMedical2.Models;
using System.Data.Entity;

namespace APIRvMedical2.Controllers
{
    public class SecretaireController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/Secretaire
        public IEnumerable<Secretaire> Get()
        {
            return db.Secretaires.ToList();
        }

        // GET: api/Secretaire/5
        public IHttpActionResult Get(int id)
        {
            var secretaire = db.Secretaires.Find(id);
            if (secretaire == null)
                return NotFound();
            return Ok(secretaire);
        }

        // POST: api/Secretaire
        public IHttpActionResult Post(Secretaire secretaire)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Secretaires.Add(secretaire);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = secretaire.IdU }, secretaire);
        }

        // PUT: api/Secretaire/5
        public IHttpActionResult Put(int id, Secretaire secretaire)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != secretaire.IdU)
                return BadRequest();
            db.Entry(secretaire).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/Secretaire/5
        public IHttpActionResult Delete(int id)
        {
            var secretaire = db.Secretaires.Find(id);
            if (secretaire == null)
                return NotFound();
            db.Secretaires.Remove(secretaire);
            db.SaveChanges();
            return Ok(secretaire);
        }
    }
}