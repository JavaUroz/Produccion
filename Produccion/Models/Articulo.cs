using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Produccion.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Programacions = new HashSet<Programacion>();
        }
        [Key]
        public int IdArticulo { get; set; }
        [Required]
        [DisplayName("Código")]
        public int Codigo { get; set; }
        [Required]
        [DisplayName("Artículo")]
        public string Nombre { get; set; } = null!;
        [Required]
        [DisplayName("Sector")]
        public int SectorId { get; set; }

        public virtual Sectores Sector { get; set; } = null!;
        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
