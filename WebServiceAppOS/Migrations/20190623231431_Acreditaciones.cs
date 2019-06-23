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
                    creditos = table.Column<int>(nullable: false),
                    aceptado = table.Column<bool>(nullable: false),
                    costoTotal = table.Column<decimal>(nullable: false)
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
