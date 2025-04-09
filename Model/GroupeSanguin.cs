using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class GroupeSanguin
    {
        [Key]
        public int IdGroupeSanguin { get; set; } // Id unique
        [Required,MaxLength(3)]
        public string CodeGroupeSanguin { get; set; } // Ex : "O+", "A-", etc.
        [Required,MaxLength(20)]
        public string NomGroupeSanguin { get; set; } 
    }
}
