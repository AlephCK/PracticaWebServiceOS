using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServiceAppOS.Migrations
{
    public partial class Acreditaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acreditaciones",
                columns: table => new
                {
                    Matricula = table.Column<string>(nullable: false),
                    Creditos = table.Column<int>(nullable: false),
                    CostoTotal = table.Column<decimal>(nullable: false),
                    Aceptado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acreditaciones", x => x.Matricula);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acreditaciones");
        }
    }
}
