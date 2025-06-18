using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIRvMedical2.Models;

namespace APIRvMedical2.Models
{
    public class Utilisateur:Personne
    {

        [MaxLength(50),Required]
        public string identifiant { get; set; }

        [MaxLength(100),Required]
        public string MotDePasse { get; set; }
        public bool? statut { get; set; }

        [Required]
        public int IdRole { get; set; } // Clé étrangère stockée en base

        [ForeignKey("IdRole")]
        public Role Role { get; set; } // Relation avec l'entité Role
    }

}
