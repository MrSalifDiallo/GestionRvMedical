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
