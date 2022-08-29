using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevagramCSharp.Migrations
{
    public partial class TabelaSeguidores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSeguidor = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioSeguido = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioSeguidor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguidores_Usuarios_IdUsuarioSeguido",
                        column: x => x.IdUsuarioSeguido,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seguidores_Usuarios_IdUsuarioSeguidor",
                        column: x => x.IdUsuarioSeguidor,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_IdUsuarioSeguido",
                table: "Seguidores",
                column: "IdUsuarioSeguido");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_IdUsuarioSeguidor",
                table: "Seguidores",
                column: "IdUsuarioSeguidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguidores");
        }
    }
}
