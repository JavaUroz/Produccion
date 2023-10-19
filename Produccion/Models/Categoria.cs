using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Produccion.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Usuarios = new HashSet<Usuario>();
        }
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [DisplayName("Categoría")]
        public string Denominacion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
