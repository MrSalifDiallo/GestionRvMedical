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
    public class Agenda
    {
        [Key]
        public int IdAgenda { get; set; }

        [Required] // Ajout de [Required] pour rendre la colonne NOT NULL
        public DateTime DatePlanifie { get; set; } // Suppression du ? pour rendre la colonne NOT NULL

        [MaxLength(100)]
        public string Titre { get; set; }

        [Required, MaxLength(10)] // Ajout de [Required] pour rendre la colonne NOT NULL
        public string HeureDebut { get; set; } // Suppression du ? pour rendre la colonne NOT NULL

        [Required, MaxLength(10)] // Ajout de [Required] pour rendre la colonne NOT NULL
        public string HeureFin { get; set; } // Suppression du ? pour rendre la colonne NOT NULL

        public int Creneau { get; set; } // Déjà NOT NULL

        [MaxLength(100)]
        public string Lieu { get; set; }

        [MaxLength(50)]
        public string statut { get; set; }

        [Required] // Ajout de [Required] pour rendre la colonne NOT NULL
        public int IdMedecin { get; set; } // Suppression du ? pour rendre la colonne NOT NULL

        [ForeignKey("IdMedecin")]
        public Medecin Medecin { get; set; }

        public virtual ICollection<Creneau> Creneaux { get; set; }

        public virtual ICollection<RendezVous> RendezVous { get; set; }
    }
}