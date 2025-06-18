using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using APIRvMedical2.Models;

namespace APIRvMedical2.Controllers
{
    public class SoinController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/Soin
        public async Task<IHttpActionResult> GetSoins()
        {
            return Ok(await db.Soins.ToListAsync());
        }

        // GET: api/Soin/5
        public async Task<IHttpActionResult> GetSoinById(int id)
        {
            var soin = await db.Soins.FindAsync(id);
            if (soin == null)
                return NotFound();
            return Ok(soin);
        }

        // POST: api/Soin
        public async Task<IHttpActionResult> PostSoin(Soin soin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Soins.Add(soin);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = soin.IdSoin }, soin);
        }

        // PUT: api/Soin/5
        public async Task<IHttpActionResult> PutSoin(int id, Soin soin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != soin.IdSoin)
                return BadRequest();
            db.Entry(soin).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Soin/5
        public async Task<IHttpActionResult> DeleteSoin(int id)
        {
            var soin = await db.Soins.FindAsync(id);
            if (soin == null)
                return NotFound();
            db.Soins.Remove(soin);
            await db.SaveChangesAsync();
            return Ok(soin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}