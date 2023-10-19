using System;
using System.Collections.Generic;

namespace Produccion.Models
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
        public int ArticuloId { get; set; }
        public double CantidadProgramada { get; set; }
        public int EstadoId { get; set; }
        public string Supervisor { get; set; }

        public virtual Articulo Articulo { get; set; } = null!;
        public virtual Estado Estado { get; set; } = null!;
        public virtual Proceso Proceso { get; set; } = null!;
        public virtual Usuario SupervisorNavigation { get; set; } = null!;
        public virtual ICollection<Produccion> Produccions { get; set; }
    }
}
