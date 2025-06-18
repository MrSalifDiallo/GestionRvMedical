using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using APIRvMedical2.Models;

namespace APIRvMedical2.Controllers
{
    public class GroupeSanguinController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/GroupeSanguin
        public async Task<IHttpActionResult> GetGroupesSanguins()
        {
            return Ok(await db.GroupeSanguins.ToListAsync());
        }

        // GET: api/GroupeSanguin/5
        public async Task<IHttpActionResult> GetGroupeSanguin(int id)
        {
            var gs = await db.GroupeSanguins.FindAsync(id);
            if (gs == null)
                return NotFound();
            return Ok(gs);
        }

        // POST: api/GroupeSanguin
        public async Task<IHttpActionResult> PostGroupeSanguin(GroupeSanguin gs)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.GroupeSanguins.Add(gs);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = gs.IdGroupeSanguin }, gs);
        }

        // PUT: api/GroupeSanguin/5
        public async Task<IHttpActionResult> PutGroupeSanguin(int id, GroupeSanguin gs)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != gs.IdGroupeSanguin)
                return BadRequest();
            db.Entry(gs).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/GroupeSanguin/5
        public async Task<IHttpActionResult> DeleteGroupeSanguin(int id)
        {
            var gs = await db.GroupeSanguins.FindAsync(id);
            if (gs == null)
                return NotFound();
            db.GroupeSanguins.Remove(gs);
            await db.SaveChangesAsync();
            return Ok(gs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}