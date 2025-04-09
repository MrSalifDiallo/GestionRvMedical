using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class ClassReportTicketRv
    {
        //Un rapport pas d'element nul ni Id
        public string NomPrenom { get; set; }

        public DateTime DateNaissance { get; set; }


        public DateTime DateRv { get; set; }

        public string Medecin { get; set; }
        public string HeureRv { get; set; }
        public byte[] DataQr { get; set; }
    }
}
