using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Model
{
    public class Utilisateur:Personne
    {

        [MaxLength(20)]
        public string identifiant { get; set; }

        [MaxLength(250)]
        public string MotDePasse { get; set; }
        public bool? statut { get; set; }

    }

}
