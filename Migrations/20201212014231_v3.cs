using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Scilicet.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Cursos");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Cursos",
                type: "TEXT",
                nullable: true);
        }
    }
}
