using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierRvMedical.Model;

namespace MetierRvMedical.Model
{
    public class Utilisateur:Personne
    {

        [MaxLength(50)]
        public string identifiant { get; set; }

        [MaxLength(100)]
        public string MotDePasse { get; set; }
        public bool? statut { get; set; }
        public int? IdRole { get; set; }
        [ForeignKey("IdRole")]
        public virtual Role Role { get; set; } // Navigation property
    }

}
