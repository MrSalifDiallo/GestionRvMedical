using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierRvMedical.Model;

namespace MetierRvMedical.Model
{
    public class Specialite
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(10)]

        public string CodeSpecialite { get; set; }
        [Required, MaxLength(100)]

        public string NomSpecialite { get; set; }
    }
}
