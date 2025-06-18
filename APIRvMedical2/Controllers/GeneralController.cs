using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIRvMedical2.Models;

namespace APIRvMedical2.Controllers
{
    public class GeneralController : ApiController
    {
        private BdRvMedicalContext db = new BdRvMedicalContext();

        [HttpGet]
        [Route("api/general/phones")]
        public IHttpActionResult GetPhoneNumbers(int limit = 5)
        {
            var phones = db.Patients
                .OrderBy(p => p.TEL)
                .Take(limit)
                .Select(p => p.TEL + " - " + p.NomPrenom)
                .ToList();
            return Ok(phones);
        }

        [HttpGet]
        [Route("api/general/soins")]
        public IHttpActionResult GetSoins()
        {
            return Ok(db.Soins.ToList());
        }

        [HttpGet]
        [Route("api/general/groupesanguins")]
        public IHttpActionResult GetGroupesSanguins()
        {
            return Ok(db.GroupeSanguins.ToList());
        }
    }
}