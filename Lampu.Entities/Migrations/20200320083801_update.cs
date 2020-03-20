using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lampu.Entities.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdLampu",
                table: "lampu",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdLampu",
                table: "lampu",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
