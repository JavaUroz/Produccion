using System;
using System.Collections.Generic;

namespace Produccion.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            Programacions = new HashSet<Programacion>();
        }

        public int IdProceso { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
