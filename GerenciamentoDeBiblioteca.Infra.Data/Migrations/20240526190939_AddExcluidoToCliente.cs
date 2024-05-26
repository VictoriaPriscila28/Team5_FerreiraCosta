using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeBiblioteca.Infra.Data.Migrations
{
    public partial class AddExcluidoToCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Cliente");
        }
    }
}
