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
    
    public partial class Logueo
    {
        public int IdLogueo { get; set; }
        public string IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int Tipo { get; set; }
        public int Estado { get; set; }
    
        public virtual Usuario Usuario1 { get; set; }
    }
}
