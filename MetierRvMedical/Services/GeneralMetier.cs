using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

namespace MetierRvMedical.Services
{
    public class GeneralMetier
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();

        /// <summary>
        /// Retourne la liste des numéros de téléphone pour une autocomplétion
        /// </summary>
        public List<string> GetPhoneNumbersForAutoComplete(int limit = 5)
        {
            var rawPhones = bd.Patients
                              .OrderBy(p => p.TEL)
                              .Take(limit)
                              .Select(p => new { p.TEL, p.NomPrenom })
                              .ToList(); 
            var phoneDetails = rawPhones
                               .Select(p => $"{p.TEL} - {p.NomPrenom}")
                               .ToList();

            return phoneDetails;
        }

        public List<Soin> GetListSoins()
        {
            return bd.Soins.ToList();

        }









    }
}
