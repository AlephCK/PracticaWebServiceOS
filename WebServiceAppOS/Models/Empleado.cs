using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebServiceAppOS.Models
{
      public class Empleado
        {
            public int Id { get; set; }
            public string Cedula_Empleado { get; set; }
            public string Cuenta_Empleado { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public decimal Sueldo { get; set; }
        }
}
