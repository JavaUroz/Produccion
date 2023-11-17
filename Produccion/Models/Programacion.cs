using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Programacion
    {
        [Key]
        public int IdProgramacion { get; set; }
        [Required]
        [DisplayName("Orden de producción")]
        public int OrdenProduccion { get; set; }
        [Required]
        [DisplayName("Proceso")]
        public int ProcesoId { get; set; }
        [Required]
        [DisplayName("Artículo")]
        public string? art_CodGen { get; set; }
        [Required]
        [DisplayName("Cantidad programada")]
        public double CantidadProgramada { get; set; }
        [Required]
        [DisplayName("Estado")]
        public string? Estado { get; set; } // Pendiente, En Proceso, Finalizado
        [Required]
        [DisplayName("Supervisor")]
        public string? Supervisor { get; set; }
        public virtual Articulo? Articulo { get; set; }
        public virtual Proceso? Proceso { get; set; }
        public virtual ICollection<Produccion> Produccions { get; set; } = new List<Produccion>();
    }
}
