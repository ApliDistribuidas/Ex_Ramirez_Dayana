//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrestamosLibros
    {
        public int PrestamoID { get; set; }
        public int LibroID { get; set; }
        public int UsuarioID { get; set; }
        public Nullable<System.DateTime> FechaPrestamo { get; set; }
        public Nullable<System.DateTime> FechaDevolucion { get; set; }
        public string Estado { get; set; }
    }
}
