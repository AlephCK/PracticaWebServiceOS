using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AppCoreModel
{

    [DataContract]
    public class Acreditacion
    {
        [DataMember(Name = "Matricula")]
        public string Matricula { get; set; }
        [DataMember(Name = "creditos")]
        public int creditos { get; set; }
        [DataMember(Name = "aceptado")]
        public bool aceptado { get; set; }
        [DataMember(Name = "costoTotal")]
        public decimal costoTotal { get; set; }

    }
}
