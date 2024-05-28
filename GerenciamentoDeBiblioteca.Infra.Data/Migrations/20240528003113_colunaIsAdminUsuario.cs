using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeBiblioteca.Infra.Data.Migrations
{
    public partial class colunaIsAdminUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Usuario");
        }
    }
}
