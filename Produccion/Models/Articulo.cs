using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Programacions = new HashSet<Programacion>();
            ArticulosProduccions = new HashSet<ArticulosProduccion>();
        }
        [Key]
        [DisplayName("Código")]
        public string ArtCodGen { get; set; } = null!;
        [DisplayName("Descripción")]
        public string? ArtDescGen { get; set; }
        [DisplayName("Un. Medida")]
        public string? ArtclaCod { get; set; }
        public string? ArtDescAdic { get; set; }
        public string? ArtproCod { get; set; }
        public string? Artda1Cod { get; set; }
        public string? Artda2Cod { get; set; }
        public string? ArttivCodVta { get; set; }
        public string? ArtTipo { get; set; }
        public bool ArtCtrlStock { get; set; }
        public string? ArtmonCodigoPrBase { get; set; }
        public string? ArtmtcaCodigoPrBase { get; set; }
        public double ArtPrBase { get; set; }
        public bool ArtCircStock { get; set; }
        public bool ArtCircCpra { get; set; }
        public bool ArtCircProd { get; set; }
        public bool ArtCircVta { get; set; }
        public bool ArtInclEnLisP { get; set; }
        public double ArtLoteMultiplo { get; set; }
        public double ArtLoteMinimo { get; set; }
        public double ArtLoteMaximo { get; set; }
        public DateTime ArtFecMod { get; set; }
        public string? ArtusuCodigo { get; set; }
        public string? ArtAplLoteAut { get; set; }

        public virtual ICollection<ArticulosProduccion> ArticulosProduccions { get; set; }
        public virtual ICollection<Programacion> Programacions { get; set; }
        
    }
}
