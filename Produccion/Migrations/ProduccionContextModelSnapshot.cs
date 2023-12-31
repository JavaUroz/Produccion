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
    [DbContext(typeof(ProduccionContext))]
    partial class ProduccionContextModelSnapshot : ModelSnapshot
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Producciones.Models.Articulo", b =>
                {
                    b.Property<string>("ArtCodGen")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("art_CodGen");

                    b.Property<string>("ArtAplLoteAut")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("art_AplLoteAut");

                    b.Property<bool>("ArtCircCpra")
                        .HasColumnType("bit")
                        .HasColumnName("art_CircCpra");

                    b.Property<bool>("ArtCircProd")
                        .HasColumnType("bit")
                        .HasColumnName("art_CircProd");

                    b.Property<bool>("ArtCircStock")
                        .HasColumnType("bit")
                        .HasColumnName("art_CircStock");

                    b.Property<bool>("ArtCircVta")
                        .HasColumnType("bit")
                        .HasColumnName("art_CircVta");

                    b.Property<bool>("ArtCtrlStock")
                        .HasColumnType("bit")
                        .HasColumnName("art_CtrlStock");

                    b.Property<string>("ArtDescAdic")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("art_DescAdic");

                    b.Property<string>("ArtDescGen")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("art_DescGen");

                    b.Property<DateTime>("ArtFecMod")
                        .HasColumnType("datetime2")
                        .HasColumnName("art_FecMod");

                    b.Property<bool>("ArtInclEnLisP")
                        .HasColumnType("bit")
                        .HasColumnName("art_InclEnLisP");

                    b.Property<double>("ArtLoteMaximo")
                        .HasColumnType("float")
                        .HasColumnName("art_LoteMaximo");

                    b.Property<double>("ArtLoteMinimo")
                        .HasColumnType("float")
                        .HasColumnName("art_LoteMinimo");

                    b.Property<double>("ArtLoteMultiplo")
                        .HasColumnType("float")
                        .HasColumnName("art_LoteMultiplo");

                    b.Property<double>("ArtPrBase")
                        .HasColumnType("float")
                        .HasColumnName("art_PrBase");

                    b.Property<string>("ArtTipo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("art_Tipo");

                    b.Property<string>("ArtclaCod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artcla_Cod");

                    b.Property<string>("Artda1Cod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artda1_Cod");

                    b.Property<string>("Artda2Cod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artda2_Cod");

                    b.Property<string>("ArtmonCodigoPrBase")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artmon_CodigoPrBase");

                    b.Property<string>("ArtmtcaCodigoPrBase")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artmtca_CodigoPrBase");

                    b.Property<string>("ArtproCod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artpro_Cod");

                    b.Property<string>("ArttivCodVta")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("arttiv_CodVta");

                    b.Property<string>("ArtusuCodigo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artusu_Codigo");

                    b.HasKey("ArtCodGen");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("Producciones.Models.ArticulosProduccion", b =>
                {
                    b.Property<int>("IdArtProd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtProd"), 1L, 1);

                    b.Property<string>("ArticuloArtCodGen")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodGenArt")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProduccionId")
                        .HasColumnType("int");

                    b.HasKey("IdArtProd");

                    b.HasIndex("ArticuloArtCodGen");

                    b.HasIndex("ProduccionId");

                    b.ToTable("ArticulosProduccion", (string)null);
                });

            modelBuilder.Entity("Producciones.Models.Proceso", b =>
                {
                    b.Property<int>("IdProceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProceso"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProceso");

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
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartesFaltantes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgramacionId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdProduccion");

                    b.HasIndex(new[] { "ProgramacionId" }, "IX_Produccions_ProgramacionId");

                    b.HasIndex(new[] { "UsuarioId" }, "IX_Produccions_ResposableNavigationId");

                    b.ToTable("Produccions");
                });

            modelBuilder.Entity("Producciones.Models.Programacion", b =>
                {
                    b.Property<int>("IdProgramacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProgramacion"), 1L, 1);

                    b.Property<string>("ArticuloCod")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CantidadProgramada")
                        .HasColumnType("float");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrdenProduccion")
                        .HasColumnType("int");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdProgramacion");

                    b.HasIndex("ArticuloCod");

                    b.HasIndex(new[] { "ProcesoId" }, "IX_Programacions_ProcesoId");

                    b.HasIndex(new[] { "UsuarioId" }, "IX_Programacions_UsuarioId");

                    b.ToTable("Programacions");
                });

            modelBuilder.Entity("Producciones.Models.Usuarios", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Producciones.Models.ArticulosProduccion", b =>
                {
                    b.HasOne("Producciones.Models.Articulo", null)
                        .WithMany("ArticulosProduccions")
                        .HasForeignKey("ArticuloArtCodGen");

                    b.HasOne("Producciones.Models.Produccion", null)
                        .WithMany("ArticulosProduccions")
                        .HasForeignKey("ProduccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Producciones.Models.Produccion", b =>
                {
                    b.HasOne("Producciones.Models.Programacion", "Programacion")
                        .WithMany("Produccions")
                        .HasForeignKey("ProgramacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Producciones.Models.Usuarios", "ResponsableNavigation")
                        .WithMany("Produccions")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Programacion");

                    b.Navigation("ResponsableNavigation");
                });

            modelBuilder.Entity("Producciones.Models.Programacion", b =>
                {
                    b.HasOne("Producciones.Models.Articulo", "ArticuloCodNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("ArticuloCod")
                        .HasConstraintName("FK_Programacions_Articulos");

                    b.HasOne("Producciones.Models.Proceso", "Proceso")
                        .WithMany("Programacions")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Producciones.Models.Usuarios", "Usuario")
                        .WithMany("Programacions")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("ArticuloCodNavigation");

                    b.Navigation("Proceso");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Producciones.Models.Articulo", b =>
                {
                    b.Navigation("ArticulosProduccions");

                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Producciones.Models.Proceso", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Producciones.Models.Produccion", b =>
                {
                    b.Navigation("ArticulosProduccions");
                });

            modelBuilder.Entity("Producciones.Models.Programacion", b =>
                {
                    b.Navigation("Produccions");
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
