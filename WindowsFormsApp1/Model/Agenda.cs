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
    public class Agenda
    {
        [Key]
      public int IdAgenda { get; set; }

        public DateTime? DatePlanifie { get; set; }

        public string Titre { get; set; }

        public string HeureDebut { get; set; }

        public string HeureFin { get; set; }

        public int Creneau { get; set; }
        
        public string Lieu { get; set; }

        public string statut { get; set; }

        public int? IdMedecin { get; set;  }
        [ForeignKey("IdMedecin")]
        public Medecin Medecin { get; set; }

        public virtual ICollection<Creneau> Creneaux { get; set; }

        public virtual ICollection<RendezVous> RendezVous { get; set; }
    }
}
