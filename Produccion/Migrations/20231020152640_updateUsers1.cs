using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producciones.Migrations
{
    public partial class updateUsers1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Sectores",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Sectores",
                table: "Usuarios",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "IdSector");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Sectores",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "SectorId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Sectores",
                table: "Usuarios",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "IdSector",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
