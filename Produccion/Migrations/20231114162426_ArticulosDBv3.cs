using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producciones.Migrations
{
    public partial class ArticulosDBv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programacions_Articulos_ArticuloId",
                table: "Programacions");

            migrationBuilder.DropIndex(
                name: "IX_Programacions_ArticuloId",
                table: "Programacions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "IdArticulo",
                table: "Articulos");

            migrationBuilder.AddColumn<string>(
                name: "Articuloart_CodGen",
                table: "Programacions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "art_CodGen",
                table: "Articulos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "art_CodGen");

            migrationBuilder.CreateIndex(
                name: "IX_Programacions_Articuloart_CodGen",
                table: "Programacions",
                column: "Articuloart_CodGen");

            migrationBuilder.AddForeignKey(
                name: "FK_Programacions_Articulos_Articuloart_CodGen",
                table: "Programacions",
                column: "Articuloart_CodGen",
                principalTable: "Articulos",
                principalColumn: "art_CodGen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programacions_Articulos_Articuloart_CodGen",
                table: "Programacions");

            migrationBuilder.DropIndex(
                name: "IX_Programacions_Articuloart_CodGen",
                table: "Programacions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Articuloart_CodGen",
                table: "Programacions");

            migrationBuilder.AlterColumn<string>(
                name: "art_CodGen",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "IdArticulo",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "IdArticulo");

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
    }
}
