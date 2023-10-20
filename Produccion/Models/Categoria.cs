using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Usuarios = new HashSet<Usuarios>();
        }
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [DisplayName("Categoría")]
        public string Denominacion { get; set; } = null!;

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
