using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Producciones.Models;

namespace Producciones.Data
{
    public partial class ProduccionContext : IdentityDbContext<Usuarios>
    {
        public ProduccionContext()
        {
        }

        public ProduccionContext(DbContextOptions<ProduccionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Proceso> Procesos { get; set; } = null!;
        public virtual DbSet<Produccion> Produccions { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<ArticulosProduccion> ArticulosProduccions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.ArtCodGen);

                entity.Property(e => e.ArtCodGen).HasColumnName("art_CodGen");

                entity.Property(e => e.ArtAplLoteAut).HasColumnName("art_AplLoteAut");

                entity.Property(e => e.ArtCircCpra).HasColumnName("art_CircCpra");

                entity.Property(e => e.ArtCircProd).HasColumnName("art_CircProd");

                entity.Property(e => e.ArtCircStock).HasColumnName("art_CircStock");

                entity.Property(e => e.ArtCircVta).HasColumnName("art_CircVta");

                entity.Property(e => e.ArtCtrlStock).HasColumnName("art_CtrlStock");

                entity.Property(e => e.ArtDescAdic).HasColumnName("art_DescAdic");

                entity.Property(e => e.ArtDescGen).HasColumnName("art_DescGen");

                entity.Property(e => e.ArtFecMod).HasColumnName("art_FecMod");

                entity.Property(e => e.ArtInclEnLisP).HasColumnName("art_InclEnLisP");

                entity.Property(e => e.ArtLoteMaximo).HasColumnName("art_LoteMaximo");

                entity.Property(e => e.ArtLoteMinimo).HasColumnName("art_LoteMinimo");

                entity.Property(e => e.ArtLoteMultiplo).HasColumnName("art_LoteMultiplo");

                entity.Property(e => e.ArtPrBase).HasColumnName("art_PrBase");

                entity.Property(e => e.ArtTipo).HasColumnName("art_Tipo");

                entity.Property(e => e.ArtclaCod).HasColumnName("artcla_Cod");

                entity.Property(e => e.Artda1Cod).HasColumnName("artda1_Cod");

                entity.Property(e => e.Artda2Cod).HasColumnName("artda2_Cod");

                entity.Property(e => e.ArtmonCodigoPrBase).HasColumnName("artmon_CodigoPrBase");

                entity.Property(e => e.ArtmtcaCodigoPrBase).HasColumnName("artmtca_CodigoPrBase");

                entity.Property(e => e.ArtproCod).HasColumnName("artpro_Cod");

                entity.Property(e => e.ArttivCodVta).HasColumnName("arttiv_CodVta");

                entity.Property(e => e.ArtusuCodigo).HasColumnName("artusu_Codigo");
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.IdProceso);
            });

            modelBuilder.Entity<Produccion>(entity =>
            {
                entity.HasKey(e => e.IdProduccion);

                entity.HasIndex(e => e.ProgramacionId, "IX_Produccions_ProgramacionId");

                entity.HasIndex(e => e.UsuarioId, "IX_Produccions_ResposableNavigationId");

                entity.HasOne(d => d.Programacion)
                    .WithMany(p => p.Produccions)
                    .HasForeignKey(d => d.ProgramacionId);

                entity.HasOne(d => d.ResponsableNavigation)
                    .WithMany(p => p.Produccions)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<ArticulosProduccion>(entity =>
            {
                entity.HasKey(e => e.IdArtProd);

                entity.ToTable("ArticulosProduccion");

                entity.Property(e => e.CodGenArt).HasMaxLength(450);
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion);

                entity.HasIndex(e => e.ProcesoId, "IX_Programacions_ProcesoId");

                entity.HasIndex(e => e.UsuarioId, "IX_Programacions_UsuarioId");

                entity.Property(e => e.ArticuloCod).HasMaxLength(450);

                entity.HasOne(d => d.ArticuloCodNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.ArticuloCod)
                    .HasConstraintName("FK_Programacions_Articulos");

                entity.HasOne(d => d.Proceso)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.ProcesoId);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(e => new { e.LoginProvider, e.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(e => new { e.UserId, e.RoleId });
            
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
