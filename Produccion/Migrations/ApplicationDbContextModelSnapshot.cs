﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Producciones.Data;

#nullable disable

namespace Producciones.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Producciones.Models.Articulo", b =>
                {
                    b.Property<int>("IdArticulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArticulo"), 1L, 1);

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.HasKey("IdArticulo")
                        .HasName("PK__Articulo__C0D7258D4BA32075");

                    b.HasIndex("SectorId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Producciones.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Denominacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria")
                        .HasName("PK__Categori__A3C02A1047FBEF71");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Producciones.Models.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdEstado")
                        .HasName("PK__Estado__FEF86B6072E4B4FD");

                    b.ToTable("Estado", (string)null);
                });

            modelBuilder.Entity("Producciones.Models.Proceso", b =>
                {
                    b.Property<int>("IdProceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProceso"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdProceso")
                        .HasName("PK__Procesos__1C00FFF0DD221100");

                    b.ToTable("Procesos");
                });

            modelBuilder.Entity("Producciones.Models.Produccion", b =>
                {
                    b.Property<int>("IdProduccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduccion"), 1L, 1);

                    b.Property<double>("CantidadProducida")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Fin")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("image");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime");

                    b.Property<int>("ProgramacionId")
                        .HasColumnType("int");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdProduccion")
                        .HasName("PK__Producci__6632E91D4AB5216F");

                    b.HasIndex(new[] { "ProgramacionId" }, "IX_Produccion_ProgramacionId");

                    b.HasIndex(new[] { "Responsable" }, "IX_Produccion_Responsable");

                    b.ToTable("Produccion", (string)null);
                });

            modelBuilder.Entity("Producciones.Models.Programacion", b =>
                {
                    b.Property<int>("IdProgramacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProgramacion"), 1L, 1);

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<double>("CantidadProgramada")
                        .HasColumnType("float");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int>("OrdenProduccion")
                        .HasColumnType("int");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<string>("Supervisor")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdProgramacion");

                    b.HasIndex(new[] { "ArticuloId" }, "IX_Programacion_ArticuloId");

                    b.HasIndex(new[] { "EstadoId" }, "IX_Programacion_EstadoId");

                    b.HasIndex(new[] { "ProcesoId" }, "IX_Programacion_ProcesoId");

                    b.HasIndex(new[] { "Supervisor" }, "IX_Programacion_Supervisor");

                    b.ToTable("Programacion", (string)null);
                });

            modelBuilder.Entity("Producciones.Models.Sectores", b =>
                {
                    b.Property<int>("IdSector")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSector"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdSector");

                    b.ToTable("Sectores");
                });

            modelBuilder.Entity("Producciones.Models.Usuarios", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Autorizado")
                        .HasColumnType("bit");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.HasIndex(new[] { "CategoriaId" }, "IX_Usuarios_CategoriaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Producciones.Models.Articulo", b =>
                {
                    b.HasOne("Producciones.Models.Sectores", "Sector")
                        .WithMany("Articulos")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Articulos_Sectores");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Producciones.Models.Produccion", b =>
                {
                    b.HasOne("Producciones.Models.Programacion", "Programacion")
                        .WithMany("Produccions")
                        .HasForeignKey("ProgramacionId")
                        .IsRequired()
                        .HasConstraintName("FK_Produccion_Programacion");

                    b.HasOne("Producciones.Models.Usuarios", "ResponsableNavigation")
                        .WithMany("Produccions")
                        .HasForeignKey("Responsable")
                        .IsRequired()
                        .HasConstraintName("FK_Produccion_Usuarios");

                    b.Navigation("Programacion");

                    b.Navigation("ResponsableNavigation");
                });

            modelBuilder.Entity("Producciones.Models.Programacion", b =>
                {
                    b.HasOne("Producciones.Models.Articulo", "Articulo")
                        .WithMany("Programacions")
                        .HasForeignKey("ArticuloId")
                        .IsRequired()
                        .HasConstraintName("FK_Programacion_Articulos");

                    b.HasOne("Producciones.Models.Estado", "Estado")
                        .WithMany("Programacions")
                        .HasForeignKey("EstadoId")
                        .IsRequired()
                        .HasConstraintName("FK_Programacion_Estado");

                    b.HasOne("Producciones.Models.Proceso", "Proceso")
                        .WithMany("Programacions")
                        .HasForeignKey("ProcesoId")
                        .IsRequired()
                        .HasConstraintName("FK_Programacion_Procesos");

                    b.HasOne("Producciones.Models.Usuarios", "SupervisorNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("Supervisor")
                        .IsRequired()
                        .HasConstraintName("FK_Programacion_Usuarios1");

                    b.Navigation("Articulo");

                    b.Navigation("Estado");

                    b.Navigation("Proceso");

                    b.Navigation("SupervisorNavigation");
                });

            modelBuilder.Entity("Producciones.Models.Usuarios", b =>
                {
                    b.HasOne("Producciones.Models.Categoria", "Categoria")
                        .WithMany("Usuarios")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("FK__Usuarios__IdCate__4AB81AF0");

                    b.HasOne("Producciones.Models.Sectores", "Sector")
                        .WithMany("Usuarios")
                        .HasForeignKey("SectorId")
                        .HasConstraintName("FK_Usuarios_Sectores");

                    b.Navigation("Categoria");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Producciones.Models.Articulo", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Producciones.Models.Categoria", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Producciones.Models.Estado", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Producciones.Models.Proceso", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Producciones.Models.Programacion", b =>
                {
                    b.Navigation("Produccions");
                });

            modelBuilder.Entity("Producciones.Models.Sectores", b =>
                {
                    b.Navigation("Articulos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Producciones.Models.Usuarios", b =>
                {
                    b.Navigation("Produccions");

                    b.Navigation("Programacions");
                });
#pragma warning restore 612, 618
        }
    }
}
