using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIRvMedical2.Models;
using System.Data.Entity;

namespace APIRvMedical2.Controllers
{
    public class AdminsController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/Admins
        public IEnumerable<Admin> Get()
        {
            return db.Admins.ToList();
        }

        // GET: api/Admins/5
        public IHttpActionResult Get(int id)
        {
            var admin = db.Admins.Find(id);
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }

        // POST: api/Admins
        public IHttpActionResult Post(Admin admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Admins.Add(admin);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = admin.IdU }, admin);
        }

        // PUT: api/Admins/5
        public IHttpActionResult Put(int id, Admin admin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != admin.IdU)
                return BadRequest();
            db.Entry(admin).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/Admins/5
        public IHttpActionResult Delete(int id)
        {
            var admin = db.Admins.Find(id);
            if (admin == null)
                return NotFound();
            db.Admins.Remove(admin);
            db.SaveChanges();
            return Ok(admin);
        }
    }
}