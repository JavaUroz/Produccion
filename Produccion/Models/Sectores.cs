using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Produccion.Models
{
    public partial class Sectores
    {
        public Sectores()
        {
            Articulos = new HashSet<Articulo>();
            Usuarios = new HashSet<Usuario>();
        }
        [Key]
        public int IdSector { get; set; }
        [Required]
        [DisplayName("Sector")]
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Articulo> Articulos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
