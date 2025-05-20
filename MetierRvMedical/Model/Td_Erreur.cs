using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierRvMedical.Model
{
    public class Td_Erreur
    {
        [Key]
        public int Id_Erreur { get; set; }

        public DateTime DateErreur { get; set; } = DateTime.Now;
        [MaxLength(200)]
        public string TitreErreur { get; set; }
        [MaxLength(2000)]
        public string DescriptionErreur { get; set; }
    }
}
