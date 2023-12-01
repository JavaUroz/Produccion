using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Programacion
    {
        public Programacion()
        {
            Produccions = new HashSet<Produccion>();
        }
        [Key]
        public int IdProgramacion { get; set; }
        [DisplayName(" Orden de producción")]
        public int OrdenProduccion { get; set; }
        public int ProcesoId { get; set; }
        [DisplayName("Cod. Artículo")]
        public string? ArticuloCod { get; set; }
        [DisplayName("Cantidad")]
        public double CantidadProgramada { get; set; }
        public string? Estado { get; set; }
        [DisplayName("supervidor")]
        public string? UsuarioId { get; set; }
        [DisplayName("Artículo")]
        public virtual Articulo? ArticuloCodNavigation { get; set; }
        [DisplayName("Proceso")]
        public virtual Proceso? Proceso { get; set; }
        [DisplayName("Supervisor")]
        public virtual Usuarios? Usuario { get; set; }
        public virtual ICollection<Produccion> Produccions { get; set; }
    }
}
