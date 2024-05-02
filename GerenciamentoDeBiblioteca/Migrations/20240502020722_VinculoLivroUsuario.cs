using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeBiblioteca.Migrations
{
    public partial class VinculoLivroUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Usuarios_UsuarioId",
                table: "Livros",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Usuarios_UsuarioId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_UsuarioId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Livros");
        }
    }
}
