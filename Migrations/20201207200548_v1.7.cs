using Microsoft.EntityFrameworkCore.Migrations;

namespace Digital_Scilicet.Migrations
{
    public partial class v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Usuarios_OwnerMail",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_OwnerMail",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "OwnerMail",
                table: "Cursos");

            migrationBuilder.CreateTable(
                name: "CursoUsuario",
                columns: table => new
                {
                    CursosID = table.Column<long>(type: "INTEGER", nullable: false),
                    OwnerMail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoUsuario", x => new { x.CursosID, x.OwnerMail });
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Cursos_CursosID",
                        column: x => x.CursosID,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Usuarios_OwnerMail",
                        column: x => x.OwnerMail,
                        principalTable: "Usuarios",
                        principalColumn: "Mail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_OwnerMail",
                table: "CursoUsuario",
                column: "OwnerMail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoUsuario");

            migrationBuilder.AddColumn<string>(
                name: "OwnerMail",
                table: "Cursos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_OwnerMail",
                table: "Cursos",
                column: "OwnerMail");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Usuarios_OwnerMail",
                table: "Cursos",
                column: "OwnerMail",
                principalTable: "Usuarios",
                principalColumn: "Mail",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
