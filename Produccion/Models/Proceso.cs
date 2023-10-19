using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Produccion.Models
{
    public partial class Proceso
    {
        public Proceso()
        {
            Programacions = new HashSet<Programacion>();
        }
        [Key]
        public int IdProceso { get; set; }
        [Required]
        [DisplayName("Proceso")]
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
