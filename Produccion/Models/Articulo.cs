using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Articulo
    {
        [Key]
        [DisplayName("Código")]
        public string art_CodGen { get; set; } = null!;        
        [DisplayName("Descripción")]
        public string art_DescGen { get; set; } = null!;
        [DisplayName("Unidad de medida")]
        public string artcla_Cod {  get; set; } = null!;
        //[DisplayName("Tipo")] // id del tipo sea articulo o proceso
        //public string art_Tipo { get; set; } = null!;
    }
}
