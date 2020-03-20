using Microsoft.EntityFrameworkCore.Migrations;

namespace Lampu.Entities.Migrations
{
    public partial class initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lampu",
                columns: table => new
                {
                    IdLampu = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NamaLampu = table.Column<string>(maxLength: 7, nullable: false),
                    StockLampu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lampu", x => x.IdLampu);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lampu");
        }
    }
}
