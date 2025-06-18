using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using APIRvMedical2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRvMedical2
{
    public class Personne
    {
        [Key]
        public int IdU { get; set; }

        //Chaine Caractere toujours la taille required

        [Required, MaxLength(160)]
        public string NomPrenom { get; set; }
        [Required, MaxLength, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, MaxLength(15)]

        public string Adresse { get; set; }
        [Required, MaxLength(20)]
        public string TEL { get; set; }
    }
}
