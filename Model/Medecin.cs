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
    public class Medecin: Utilisateur
    {
        
        public int? IdSpecialite { get; set; }
        [ForeignKey("IdSpecialite")]

        public virtual Specialite Specialite { get; set; }


        [MaxLength(100)]
        public string NumeroOrdre { get; set; }

        public virtual ICollection<Agenda> Agendas { get; set; }
      

    }

 
}
