using System;
using System.Collections.Generic;

namespace Producciones.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Programacions = new HashSet<Programacion>();
        }

        public string ArtCodGen { get; set; } = null!;
        public string? ArtDescGen { get; set; }
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

        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
