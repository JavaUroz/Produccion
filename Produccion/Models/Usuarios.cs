using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public class Usuarios : IdentityUser
    {                    
        [DisplayName("Nombre")]
        public string? Nombre { get; set; }
        [DisplayName("Apellido")]
        public string? Apellido { get; set; }
        public string? Sector {  get; set; } // Producción, Conformado
        public virtual ICollection<Produccion> Produccions { get; set; } = new HashSet<Produccion>();
        public virtual ICollection<Programacion> Programacions { get; set; } = new HashSet<Programacion>();

    }
}