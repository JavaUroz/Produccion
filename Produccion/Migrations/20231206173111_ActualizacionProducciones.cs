using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producciones.Migrations
{
    public partial class ActualizacionProducciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Articulos",
            //    columns: table => new
            //    {
            //        art_CodGen = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        art_DescGen = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        artcla_Cod = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        art_DescAdic = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        artpro_Cod = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        artda1_Cod = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        artda2_Cod = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        arttiv_CodVta = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        art_Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        art_CtrlStock = table.Column<bool>(type: "bit", nullable: false),
            //        artmon_CodigoPrBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        artmtca_CodigoPrBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        art_PrBase = table.Column<double>(type: "float", nullable: false),
            //        art_CircStock = table.Column<bool>(type: "bit", nullable: false),
            //        art_CircCpra = table.Column<bool>(type: "bit", nullable: false),
            //        art_CircProd = table.Column<bool>(type: "bit", nullable: false),
            //        art_CircVta = table.Column<bool>(type: "bit", nullable: false),
            //        art_InclEnLisP = table.Column<bool>(type: "bit", nullable: false),
            //        art_LoteMultiplo = table.Column<double>(type: "float", nullable: false),
            //        art_LoteMinimo = table.Column<double>(type: "float", nullable: false),
            //        art_LoteMaximo = table.Column<double>(type: "float", nullable: false),
            //        art_FecMod = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        artusu_Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        art_AplLoteAut = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Articulos", x => x.art_CodGen);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Procesos",
            //    columns: table => new
            //    {
            //        IdProceso = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Procesos", x => x.IdProceso);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleClaims", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserClaims", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Programacions",
            //    columns: table => new
            //    {
            //        IdProgramacion = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrdenProduccion = table.Column<int>(type: "int", nullable: false),
            //        ProcesoId = table.Column<int>(type: "int", nullable: false),
            //        ArticuloCod = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
            //        CantidadProgramada = table.Column<double>(type: "float", nullable: false),
            //        Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Programacions", x => x.IdProgramacion);
            //        table.ForeignKey(
            //            name: "FK_Programacions_Articulos",
            //            column: x => x.ArticuloCod,
            //            principalTable: "Articulos",
            //            principalColumn: "art_CodGen");
            //        table.ForeignKey(
            //            name: "FK_Programacions_Procesos_ProcesoId",
            //            column: x => x.ProcesoId,
            //            principalTable: "Procesos",
            //            principalColumn: "IdProceso",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Programacions_Users_UsuarioId",
            //            column: x => x.UsuarioId,
            //            principalTable: "Users",
            //            principalColumn: "Id");
            //    });

            migrationBuilder.CreateTable(
                name: "Produccions",
                columns: table => new
                {
                    IdProduccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramacionId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducida = table.Column<double>(type: "float", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PartesFaltantes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produccions", x => x.IdProduccion);
                    table.ForeignKey(
                        name: "FK_Produccions_Programacions_ProgramacionId",
                        column: x => x.ProgramacionId,
                        principalTable: "Programacions",
                        principalColumn: "IdProgramacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produccions_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            //    migrationBuilder.CreateTable(
            //        name: "ArticulosProduccion",
            //        columns: table => new
            //        {
            //            IdArtProd = table.Column<int>(type: "int", nullable: false)
            //                .Annotation("SqlServer:Identity", "1, 1"),
            //            CodGenArt = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
            //            ProduccionId = table.Column<int>(type: "int", nullable: false),
            //            ArticuloArtCodGen = table.Column<string>(type: "nvarchar(450)", nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_ArticulosProduccion", x => x.IdArtProd);
            //            table.ForeignKey(
            //                name: "FK_ArticulosProduccion_Articulos_ArticuloArtCodGen",
            //                column: x => x.ArticuloArtCodGen,
            //                principalTable: "Articulos",
            //                principalColumn: "art_CodGen");
            //            table.ForeignKey(
            //                name: "FK_ArticulosProduccion_Produccions_ProduccionId",
            //                column: x => x.ProduccionId,
            //                principalTable: "Produccions",
            //                principalColumn: "IdProduccion",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateIndex(
            //        name: "IX_ArticulosProduccion_ArticuloArtCodGen",
            //        table: "ArticulosProduccion",
            //        column: "ArticuloArtCodGen");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_ArticulosProduccion_ProduccionId",
            //        table: "ArticulosProduccion",
            //        column: "ProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Produccions_ProgramacionId",
                table: "Produccions",
                column: "ProgramacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Produccions_ResposableNavigationId",
                table: "Produccions",
                column: "UsuarioId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Programacions_ArticuloCod",
            //        table: "Programacions",
            //        column: "ArticuloCod");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Programacions_ProcesoId",
            //        table: "Programacions",
            //        column: "ProcesoId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Programacions_UsuarioId",
            //        table: "Programacions",
            //        column: "UsuarioId");
            //}
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ArticulosProduccion");

            //migrationBuilder.DropTable(
            //    name: "RoleClaims");

            //migrationBuilder.DropTable(
            //    name: "Roles");

            //migrationBuilder.DropTable(
            //    name: "UserClaims");

            //migrationBuilder.DropTable(
            //    name: "UserLogins");

            //migrationBuilder.DropTable(
            //    name: "UserRoles");

            //migrationBuilder.DropTable(
            //    name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Produccions");

            //migrationBuilder.DropTable(
            //    name: "Programacions");

            //migrationBuilder.DropTable(
            //    name: "Articulos");

            //migrationBuilder.DropTable(
            //    name: "Procesos");

            //migrationBuilder.DropTable(
            //    name: "Users");
        }
    }
}
