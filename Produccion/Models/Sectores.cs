using System;
using System.Collections.Generic;

namespace Produccion.Models
{
    public partial class Sectores
    {
        public Sectores()
        {
            Articulos = new HashSet<Articulo>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdSector { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Articulo> Articulos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
