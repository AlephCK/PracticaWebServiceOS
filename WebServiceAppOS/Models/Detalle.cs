using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebServiceAppOS.Data;

namespace WebServiceAppOS.Models
{
    public class Detalle
    {
       [Key]
        public int numEmision { get; set; }
        public decimal montoCredito { get; set; }
        public int cantidadEstudiante { get; set; }
        public DateTime fechaTransmision { get; set; }
    }
}
