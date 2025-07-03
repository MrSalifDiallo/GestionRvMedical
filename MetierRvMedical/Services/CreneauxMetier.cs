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

        public int AddCreneaux(Creneau creneau)
        {
            try
            {
                bd.Creneaux.Add(creneau);
                bd.SaveChanges();
                return creneau.IdCreneau; // Retourne l'ID généré
            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "frmRendezVous-btnValider_Click - Erreur");
                utils.WriteDataError("frmRendezVous-btnValider_Click - Erreur", ex.ToString());
                return -1;
            }
        }
    }
}