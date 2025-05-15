using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Creneau
    {
        [Key]
        public int IdCreneau { get; set; }

        public int IdAgenda { get; set; }   
        [ForeignKey("IdAgenda")]
        public virtual Agenda Agenda { get; set; }

        [Column(TypeName = "Date")]  // Cela vous permet de spécifier que seul la date est stockée.
        public DateTime Date { get; set; }
        [MaxLength(25)]
        public string HeureDebut { get; set; }
        [MaxLength(25)]
        public string HeureFin { get; set; }   

        public bool Disponible { get; set; } 
    }
    }
