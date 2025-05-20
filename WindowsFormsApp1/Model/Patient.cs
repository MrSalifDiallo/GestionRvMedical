using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WindowsFormsApp1.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace WindowsFormsApp1.Model
{
    public class Patient:Personne
    {
        [Required]
        public int IdGroupeSanguin { get; set; } // Clé étrangère stockée en base

        [ForeignKey("IdGroupeSanguin")]
        public GroupeSanguin GroupeSanguin { get; set; } // Relation avec l'entité GroupeSanguin

        [Required]
        public float? Poids {  get; set; }

        [Required]
        public float? Taille { get; set; }

        [Required]
        public DateTime? DateNaissance { get; set; }
    }

}
