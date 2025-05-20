using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Model
{
    public class RendezVous
    {
        [Key]
        public int IdRv { get; set; }
        [Required]
        public DateTime DateRv { get; set; }
        [MaxLength(10)]
        public string Statut { get; set; }

        public int? IdSoin { get; set; }
        [ForeignKey ("IdSoin")]
        
        public virtual Soin Soin { get; set; }


        public int? IdPatient { get; set; }
        [ForeignKey("IdPatient")]

        public virtual Patient Patient { get; set; }


        public int? IdMedecin { get; set; }
        [ForeignKey("IdMedecin")]

        public virtual Medecin Medecin { get; set; }

        public int? IdCreneau { get; set; }  // Le créneau réservé
        [ForeignKey("IdCreneau")]
        public virtual Creneau Creneau { get; set; }
    }
}
