using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIRvMedical2.Models
{
    public class InfosRendezVous
    {
        public int IdMedecin { get; set; }
        public string NomMedecin { get; set; }
        public int DureeCreneau { get; set; }
        [MaxLength (50)]
        public string Horaire { get; set; }
        public int IdSoin { get; set; }
        public string NomSoin { get; set; }
    }
}