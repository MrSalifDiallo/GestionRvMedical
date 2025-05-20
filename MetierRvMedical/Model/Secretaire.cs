using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierRvMedical.Model;

namespace MetierRvMedical.Model
{
    public class Secretaire:Utilisateur
    {
        [MaxLength(15)]
        public string TelephoneFixe{ get; set; }

      
    }
}
