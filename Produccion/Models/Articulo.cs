using System;
using System.Collections.Generic;

namespace Produccion.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Programacions = new HashSet<Programacion>();
        }

        public int IdArticulo { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public int SectorId { get; set; }

        public virtual Sectores Sector { get; set; } = null!;
        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
