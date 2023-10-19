using System;
using System.Collections.Generic;

namespace Produccion.Models
{
    public partial class Produccion
    {
        public int IdProduccion { get; set; }
        public int ProgramacionId { get; set; }
        public double CantidadProducida { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public string Responsable { get; set; }
        public byte[]? Foto { get; set; }

        public virtual Programacion Programacion { get; set; } = null!;
        public virtual Usuario ResponsableNavigation { get; set; } = null!;
    }
}
