using MetierRvMedical.Helper;
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
        Utils utils=new Utils();

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



        /// <summary>
        /// Retrieves a list of all available soins.
        /// </summary>
        /// <remarks>This method queries the underlying data source to retrieve all soins. The returned
        /// list is a snapshot of the data at the time of the call.</remarks>
        /// <returns>A list of <see cref="Soin"/> objects representing the available soins.  Returns an empty list if no soins
        /// are found.</returns>
        public List<Soin> GetListSoins()
        {
            return bd.Soins.ToList();

        }
        /// <summary>
        /// Retrieves a list of all blood groups from the database.
        /// </summary>
        /// <remarks>This method queries the database for all blood groups and returns them as a list. 
        /// Ensure that the database context is properly initialized and contains data before calling this
        /// method.</remarks>
        /// <returns>A list of <see cref="GroupeSanguin"/> objects representing the blood groups.  Returns an empty list if no
        /// blood groups are found.</returns>
        public List<GroupeSanguin> GetListeGroupesSanguins()
        {
            return bd.GroupeSanguins.ToList();
        }
          
    }
}
