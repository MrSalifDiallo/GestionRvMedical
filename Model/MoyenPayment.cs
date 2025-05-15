using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class MoyenPayment
    {
        [Key]
        public int IdModePayment { get; set; }

        [Required,MaxLength(50)]
        public string CodePayment { get; set; }

        [Required, MaxLength(100)]
        public string Libelle { get; set; }

        [Required, MaxLength(100)]
        public string Reference { get; set; }
    }
}
