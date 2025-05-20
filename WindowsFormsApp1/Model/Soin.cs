using System;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp1.Model
{
    public class Soin
    {
        [Key]
        public int IdSoin { get; set; }

        [Required, MaxLength(50)]
        public string NameSoin { get; set; }

        // Nouvelle propriété Duration
        [Required, MaxLength(50)]
        public string Duration { get; set; }

        // Nouvelle propriété Price
        [Required]
        public int Price { get; set; }

        // Nouvelle propriété Category
        [Required, MaxLength(100)]
        public string Category { get; set; }
    }
}
