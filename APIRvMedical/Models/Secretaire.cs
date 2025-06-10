using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIRvMedical.Model;

namespace APIRvMedical.Model
{
    public class Secretaire:Utilisateur
    {
        [MaxLength(15)]
        public string TelephoneFixe{ get; set; }

      
    }
}
