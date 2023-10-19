using System;
using System.Collections.Generic;

namespace Produccion.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Programacions = new HashSet<Programacion>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
