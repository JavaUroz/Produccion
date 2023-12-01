using System;
using System.Collections.Generic;

namespace Producciones.Models
{
    public partial class Produccion
    {
        public int IdProduccion { get; set; }
        public int ProgramacionId { get; set; }
        public double CantidadProducida { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public byte[] Foto { get; set; } = null!;
        public string Responsable { get; set; } = null!;
        public string? ResposableNavigationId { get; set; }
        public string? PartesFaltantes { get; set; }
        public string? Observaciones { get; set; }

        public virtual Programacion Programacion { get; set; } = null!;
        public virtual Usuarios? ResposableNavigation { get; set; }
    }
}
