//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desafio_Intelectah.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consulta
    {
        public int id { get; set; }
        public string paciente { get; set; }
        public string tipo_de_exame { get; set; }
        public System.DateTime data { get; set; }
        public System.TimeSpan hora { get; set; }
    
        public virtual Consulta Consulta1 { get; set; }
        public virtual Consulta Consulta2 { get; set; }
    }
}
