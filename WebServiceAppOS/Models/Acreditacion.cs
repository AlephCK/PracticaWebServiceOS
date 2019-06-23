using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebServiceAppOS.Models
{
   public class Acreditacion
    {
        [Key]
        public string Matricula { get; set; }
        public int Creditos { get; set; }
        public decimal CostoTotal { get; set; }
        public bool Aceptado { get; set; }


    }
}
