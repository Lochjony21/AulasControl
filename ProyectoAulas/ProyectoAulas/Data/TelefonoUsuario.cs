//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoAulas.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TelefonoUsuario
    {
        public int IdTelefono { get; set; }
        public string IdUsuario { get; set; }
        public int Telefono { get; set; }
        public int Estado { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
