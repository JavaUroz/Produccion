using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Producciones.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            Programacions = new HashSet<Programacion>();
        }

        public int IdProceso { get; set; }
        [DisplayName("Descripción proceso")]
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
