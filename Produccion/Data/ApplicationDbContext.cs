using System;
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

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Proceso> Procesos { get; set; } = null!;
        public virtual DbSet<Produccion> Produccions { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<Sectores> Sectores { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.IdArticulo)
                    .HasName("PK__Articulo__C0D7258D4BA32075");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("FK_Articulos_Sectores");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__A3C02A1047FBEF71");

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();

                entity.Property(e => e.Denominacion).HasMaxLength(50);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FEF86B6072E4B4FD");

                entity.ToTable("Estado");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.IdProceso)
                    .HasName("PK__Procesos__1C00FFF0DD221100");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Produccion>(entity =>
            {
                entity.HasKey(e => e.IdProduccion)
                    .HasName("PK__Producci__6632E91D4AB5216F");

                entity.ToTable("Produccion");

                entity.HasIndex(e => e.ProgramacionId, "IX_Produccion_ProgramacionId");

                entity.HasIndex(e => e.Responsable, "IX_Produccion_Responsable");

                entity.Property(e => e.Fin).HasColumnType("datetime");

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Inicio).HasColumnType("datetime");

                entity.HasOne(d => d.Programacion)
                    .WithMany(p => p.Produccions)
                    .HasForeignKey(d => d.ProgramacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produccion_Programacion");

                entity.HasOne(d => d.ResponsableNavigation)
                    .WithMany(p => p.Produccions)
                    .HasForeignKey(d => d.Responsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produccion_Usuarios");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion);

                entity.ToTable("Programacion");

                entity.HasIndex(e => e.ArticuloId, "IX_Programacion_ArticuloId");

                entity.HasIndex(e => e.EstadoId, "IX_Programacion_EstadoId");

                entity.HasIndex(e => e.ProcesoId, "IX_Programacion_ProcesoId");

                entity.HasIndex(e => e.Supervisor, "IX_Programacion_Supervisor");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Articulos");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Estado");

                entity.HasOne(d => d.Proceso)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.ProcesoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Procesos");

                entity.HasOne(d => d.SupervisorNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.Supervisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programacion_Usuarios1");
            });

            modelBuilder.Entity<Sectores>(entity =>
            {
                entity.HasKey(e => e.IdSector);

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            modelBuilder.Entity<Usuarios>(entity =>
            {
                //entity.HasKey(e => e.IdUser)
                //    .HasName("PK__Usuarios__1788CCACD1CB2D57");

                entity.HasIndex(e => e.CategoriaId, "IX_Usuarios_CategoriaId");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IdCate__4AB81AF0");

                entity.HasOne(d => d.Sector)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.SectorId)
                    .HasConstraintName("FK_Usuarios_Sectores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
