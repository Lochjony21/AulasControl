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
    
    public partial class Espacio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Espacio()
        {
            this.HorariosFijos = new HashSet<HorariosFijo>();
            this.Reservas = new HashSet<Reserva>();
        }
    
        public int IdEspacio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public string tipo { get; set; }
        public int Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorariosFijo> HorariosFijos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
