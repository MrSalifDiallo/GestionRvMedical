using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class SelectListView
    {
        [MaxLength(200)]

        public string Value { get; set; }
        [MaxLength(200)]
        public string Text { get; set; }
    }
}
