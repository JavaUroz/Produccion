using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Programacions = new HashSet<Programacion>();
        }
        [Key]
        public int IdEstado { get; set; }
        [Required]
        [DisplayName("Estado")]
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
