using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceAppOS.Models;

namespace ClientOS.Models
{
    public class AcreditacionDetalle
    {
        public List<Detalle> detalles { get; set; }

        public List<Acreditacion> acreditaciones { get; set; }



    }
}
