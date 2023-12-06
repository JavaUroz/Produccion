using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class ArticulosProduccion
    {
        [Key]
        public int IdArtProd { get; set; }
        [DisplayName("Pieza faltante")]
        public string CodGenArt { get; set; } = null!;
        [DisplayName("Orden de Producción")]
        public int ProduccionId { get; set; }

        [DisplayName("Pieza faltante")]
        public virtual Articulo? ArticuloCodNavigation { get; set; }
        [DisplayName("Producción")]
        public virtual Produccion? Produccion { get; set; }
    }
}
