using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public class Usuarios : IdentityUser
    {
        public Usuarios()
        {
            Produccions = new HashSet<Produccion>();
            Programacions = new HashSet<Programacion>();
        }
                    
        [DisplayName("Nombre")]
        public string? Nombre { get; set; }
        [DisplayName("Apellido")]
        public string? Apellido { get; set; }
            
        [DisplayName("Sector")]
        public int? SectorId { get; set; } = 1;
        [DisplayName("Categoría")]
        public int? CategoriaId { get; set; } = 1;
        [DisplayName("Autorizado")]
        public bool Autorizado { get; set; } = false;
        [DisplayName("Autorizado")]
      
        public virtual Categoria? Categoria { get; set; }
        public virtual Sectores? Sector { get; set; } = null!;
        public virtual ICollection<Produccion> Produccions { get; set; }
        public virtual ICollection<Programacion> Programacions { get; set; }

    }
}