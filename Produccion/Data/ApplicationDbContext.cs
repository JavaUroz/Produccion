﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Producciones.Models;

namespace Producciones.Data
{
    public partial class ApplicationDbContext : IdentityDbContext <Usuarios> 
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Produccion> Produccions { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<Sectores> Sectores { get; set; } = null!;
        
    }
}
