using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producciones.Migrations
{
    public partial class ArticulosDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Programacions_ArticuloId",
                table: "Programacions",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programacions_Articulos_ArticuloId",
                table: "Programacions",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programacions_Articulos_ArticuloId",
                table: "Programacions");

            migrationBuilder.DropIndex(
                name: "IX_Programacions_ArticuloId",
                table: "Programacions");
        }
    }
}
