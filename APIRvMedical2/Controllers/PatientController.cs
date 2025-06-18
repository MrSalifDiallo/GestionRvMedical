using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using APIRvMedical2.Models;

namespace APIRvMedical2.Controllers
{
    public class PatientController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        // GET: api/Patient
        public async Task<IHttpActionResult> GetPatients()
        {
            var patients = await db.Patients.Include(p => p.GroupeSanguin).ToListAsync();
            return Ok(patients);
        }

        // GET: api/Patient/5
        public async Task<IHttpActionResult> GetPatient(int id)
        {
            var patient = await db.Patients.Include(p => p.GroupeSanguin).FirstOrDefaultAsync(p => p.IdU == id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        // POST: api/Patient
        public async Task<IHttpActionResult> PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Patients.Add(patient);
            await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = patient.IdU }, patient);
        }

        // PUT: api/Patient/5
        public async Task<IHttpActionResult> PutPatient(int id, Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != patient.IdU)
                return BadRequest();
            db.Entry(patient).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Patient/5
        public async Task<IHttpActionResult> DeletePatient(int id)
        {
            var patient = await db.Patients.FindAsync(id);
            if (patient == null)
                return NotFound();
            db.Patients.Remove(patient);
            await db.SaveChangesAsync();
            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}