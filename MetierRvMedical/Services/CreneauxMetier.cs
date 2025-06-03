using MetierRvMedical.Helper;
using MetierRvMedical.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierRvMedical.Services
{
    public class CreneauxMetier
    {
        BdRvMedicalContext bd = new BdRvMedicalContext();

        Utils utils = new Utils();

        public bool AddCreneaux(Creneau creneau)
        {
            try
            {
                bd.Creneaux.Add(creneau);
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