using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producciones.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Denominacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__A3C02A1047FBEF71", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estado__FEF86B6072E4B4FD", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    IdProceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Procesos__1C00FFF0DD221100", x => x.IdProceso);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectores",
                columns: table => new
                {
                    IdSector = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectores", x => x.IdSector);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Articulo__C0D7258D4BA32075", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Articulos_Sectores",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "IdSector",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    Autorizado = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Usuarios__IdCate__4AB81AF0",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_Usuarios_Sectores",
                        column: x => x.SectorId,
                        principalTable: "Sectores",
                        principalColumn: "IdSector");
                });

            migrationBuilder.CreateTable(
                name: "Programacion",
                columns: table => new
                {
                    IdProgramacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenProduccion = table.Column<int>(type: "int", nullable: false),
                    ProcesoId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    CantidadProgramada = table.Column<double>(type: "float", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Supervisor = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programacion", x => x.IdProgramacion);
                    table.ForeignKey(
                        name: "FK_Programacion_Articulos",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo");
                    table.ForeignKey(
                        name: "FK_Programacion_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "IdEstado");
                    table.ForeignKey(
                        name: "FK_Programacion_Procesos",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "IdProceso");
                    table.ForeignKey(
                        name: "FK_Programacion_Usuarios1",
                        column: x => x.Supervisor,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produccion",
                columns: table => new
                {
                    IdProduccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramacionId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducida = table.Column<double>(type: "float", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Foto = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producci__6632E91D4AB5216F", x => x.IdProduccion);
                    table.ForeignKey(
                        name: "FK_Produccion_Programacion",
                        column: x => x.ProgramacionId,
                        principalTable: "Programacion",
                        principalColumn: "IdProgramacion");
                    table.ForeignKey(
                        name: "FK_Produccion_Usuarios",
                        column: x => x.Responsable,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_SectorId",
                table: "Articulos",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produccion_ProgramacionId",
                table: "Produccion",
                column: "ProgramacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Produccion_Responsable",
                table: "Produccion",
                column: "Responsable");

            migrationBuilder.CreateIndex(
                name: "IX_Programacion_ArticuloId",
                table: "Programacion",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Programacion_EstadoId",
                table: "Programacion",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Programacion_ProcesoId",
                table: "Programacion",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Programacion_Supervisor",
                table: "Programacion",
                column: "Supervisor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CategoriaId",
                table: "Usuarios",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SectorId",
                table: "Usuarios",
                column: "SectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produccion");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Programacion");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Sectores");
        }
    }
}
