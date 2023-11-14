using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producciones.Migrations
{
    public partial class ArticulosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    art_CodGen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    art_DescGen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    artcla_Cod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.IdArticulo);
                });

            migrationBuilder.CreateTable(
                name: "Proceso",
                columns: table => new
                {
                    IdProceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proceso", x => x.IdProceso);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programacions_ProcesoId",
                table: "Programacions",
                column: "ProcesoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programacions_Proceso_ProcesoId",
                table: "Programacions",
                column: "ProcesoId",
                principalTable: "Proceso",
                principalColumn: "IdProceso",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programacions_Proceso_ProcesoId",
                table: "Programacions");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Proceso");

            migrationBuilder.DropIndex(
                name: "IX_Programacions_ProcesoId",
                table: "Programacions");
        }
    }
}
