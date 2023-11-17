using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Producciones.Models
{
    public partial class Proceso
    {
        [Key]        
        public int IdProceso { get; set; }
        [DisplayName("Descripción")]
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
    }
}
