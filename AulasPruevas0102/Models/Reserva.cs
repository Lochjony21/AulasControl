//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AulasPruevas0102.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int CodigoReservante { get; set; }
        public Nullable<int> IdEspacio { get; set; }
        public Nullable<int> IdBloque { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public string confirmacion { get; set; }
    
        public virtual BloqueHora BloqueHora { get; set; }
        public virtual Espacio Espacio { get; set; }
    }
}
