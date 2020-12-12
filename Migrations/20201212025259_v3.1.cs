using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Scilicet.Migrations
{
    public partial class v31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Cursos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Cursos");
        }
    }
}
