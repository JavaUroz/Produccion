﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Sectores
    {
        [Key]
        public int IdSector { get; set; }
        [Required]
        [DisplayName("Sector")]
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Articulo> Articulos { get; set; } = new HashSet<Articulo>();
        public virtual ICollection<Usuarios> Usuarios { get; set; } = new HashSet<Usuarios>();
    }
}
