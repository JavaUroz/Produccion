using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producciones.Migrations
{
    public partial class Programacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programacions_AspNetUsers_SupervisorNavigationId",
                table: "Programacions");

            migrationBuilder.DropColumn(
                name: "ArticuloId",
                table: "Programacions");

            migrationBuilder.RenameColumn(
                name: "SupervisorNavigationId",
                table: "Programacions",
                newName: "UsuariosId");

            migrationBuilder.RenameIndex(
                name: "IX_Programacions_SupervisorNavigationId",
                table: "Programacions",
                newName: "IX_Programacions_UsuariosId");

            migrationBuilder.AddColumn<string>(
                name: "art_CodGen",
                table: "Programacions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Programacions_AspNetUsers_UsuariosId",
                table: "Programacions",
                column: "UsuariosId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programacions_AspNetUsers_UsuariosId",
                table: "Programacions");

            migrationBuilder.DropColumn(
                name: "art_CodGen",
                table: "Programacions");

            migrationBuilder.RenameColumn(
                name: "UsuariosId",
                table: "Programacions",
                newName: "SupervisorNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Programacions_UsuariosId",
                table: "Programacions",
                newName: "IX_Programacions_SupervisorNavigationId");

            migrationBuilder.AddColumn<int>(
                name: "ArticuloId",
                table: "Programacions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Programacions_AspNetUsers_SupervisorNavigationId",
                table: "Programacions",
                column: "SupervisorNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
