using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Produccion.Models
{
    public partial class Usuario : IdentityUser
    {
        public Usuario()
        {
            Produccions = new HashSet<Produccion>();
            Programacions = new HashSet<Programacion>();
        }

        //public int IdUser { get; set; }
        public string Nombre { get; set; } = null!;
        public int SectorId { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; } = null!;
        public virtual Sectores Sector { get; set; } = null!;
        public virtual ICollection<Produccion> Produccions { get; set; }
        public virtual ICollection<Programacion> Programacions { get; set; }
    }
}
