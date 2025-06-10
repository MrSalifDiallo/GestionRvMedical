using MetierRvMedical.Helper;
using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierRvMedical.Services
{
    public class RvMetier
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();
        Utils utils = new Utils();

        public bool AddRendezVous(RendezVous rv)
        {
            try
            {
                bd.AllRendezvous.Add(rv);
                bd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "frmRendezVous-btnValider_Click - Erreur");
                utils.WriteDataError("frmRendezVous-btnValider_Click - Erreur", ex.ToString());
                return false;
            }
        }

    }
}