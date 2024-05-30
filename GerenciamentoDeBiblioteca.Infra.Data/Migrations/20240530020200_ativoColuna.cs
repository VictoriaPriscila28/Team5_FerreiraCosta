using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeBiblioteca.Infra.Data.Migrations
{
    public partial class ativoColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "Multas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiasAtraso = table.Column<int>(type: "int", nullable: false),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmprestimoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Multas_Emprestimo_EmprestimoId",
                        column: x => x.EmprestimoId,
                        principalTable: "Emprestimo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Multas_EmprestimoId",
                table: "Multas",
                column: "EmprestimoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Multas");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuario");
        }
    }
}
