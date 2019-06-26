using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServiceAppOS.Models
{
    [NotMapped]
    public class Acreditacion
    {
        [Key]
        public string Matricula { get; set; }
        public int creditos { get; set; }
        public bool aceptado { get; set; }
        public decimal costoTotal { get; set; }



    }
}
