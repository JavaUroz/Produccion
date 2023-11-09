﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Producciones.Models
{
    public partial class Produccion
    {
        [Key]
        public int IdProduccion { get; set; }
        [Required]
        [DisplayName("Programación")]
        public int ProgramacionId { get; set; }
        [DisplayName("Cantidad producida")]
        public double CantidadProducida { get; set; }
        [Required]
        [DisplayName("Inicio")]
        public DateTime Inicio { get; set; }
        [DisplayName("Fin")]
        public DateTime? Fin { get; set; }
        [Required]
        [DisplayName("Foto")]
        public byte[]? Foto { get; set; }
        [Required]
        [DisplayName("Resposable")]
        public string Responsable {  get; set; }

        public virtual Usuarios? ResposableNavigation { get; set; } = null!;
        public virtual Programacion? Programacion { get; set; } = null!;
    }
}
