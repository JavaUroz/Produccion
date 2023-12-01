using System;
using System.Collections.Generic;

namespace Producciones.Models
{
    public partial class Programacion
    {
        public Programacion()
        {
            Produccions = new HashSet<Produccion>();
        }

        public int IdProgramacion { get; set; }
        public int OrdenProduccion { get; set; }
        public int ProcesoId { get; set; }
        public string? ArticuloCod { get; set; }
        public double CantidadProgramada { get; set; }
        public string? Estado { get; set; }
        public string? UsuarioId { get; set; }

        public virtual Articulo? ArticuloCodNavigation { get; set; }
        public virtual Proceso? Proceso { get; set; }
        public virtual Usuarios? Usuario { get; set; }
        public virtual ICollection<Produccion> Produccions { get; set; }
    }
}
