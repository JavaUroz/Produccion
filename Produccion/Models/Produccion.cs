using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Produccion
    {
        public Produccion()
        {
            ArticulosProduccions = new HashSet<ArticulosProduccion>();
        }
        [Key]
        public int IdProduccion { get; set; }
        [DisplayName("Orden de producción")]
        public int ProgramacionId { get; set; }
        [DisplayName("Cantidad")]
        public double CantidadProducida { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public byte[]? Foto { get; set; }
        public string? UsuarioId { get; set; }
        [DisplayName("Piezas faltantes")]
        public string? PartesFaltantes { get; set; }
        public string? Observaciones { get; set; }
        [DisplayName("Programación")]
        public virtual Programacion? Programacion { get; set; }
        [DisplayName("Responsable")]
        public virtual Usuarios? ResponsableNavigation { get; set; }

        public virtual ICollection<ArticulosProduccion> ArticulosProduccions { get; set; }
    }
}
