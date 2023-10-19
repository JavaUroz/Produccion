using System;
using System.Collections.Generic;

namespace Produccion.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdCategoria { get; set; }
        public string Denominacion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
