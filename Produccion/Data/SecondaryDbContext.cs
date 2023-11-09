using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Producciones.Models;

namespace Producciones.Data
{
    public class SecondaryDbContext : DbContext
    {
        public SecondaryDbContext() 
        { 
        }
        public SecondaryDbContext(DbContextOptions<SecondaryDbContext> options)
            : base(options) 
        {
        }
        public DbSet<Articulo> Articulos { get; set; }
    }
}