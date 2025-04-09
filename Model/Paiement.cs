using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Paiement
    {
        [Key]
        public int IdPayment { get; set; }

        public int CodePay { get; set; }
    }
}
