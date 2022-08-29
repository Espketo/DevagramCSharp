using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevagramCSharp.Migrations
{
    public partial class PublicacaoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguidores_Usuarios_IdUsuarioSeguidor",
                table: "Seguidores");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuarioSeguidor",
                table: "Seguidores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdSeguidor",
                table: "Seguidores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Publicacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_IdUsuario",
                table: "Publicacoes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidores_Usuarios_IdUsuarioSeguidor",
                table: "Seguidores",
                column: "IdUsuarioSeguidor",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguidores_Usuarios_IdUsuarioSeguidor",
                table: "Seguidores");

            migrationBuilder.DropTable(
                name: "Publicacoes");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuarioSeguidor",
                table: "Seguidores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdSeguidor",
                table: "Seguidores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidores_Usuarios_IdUsuarioSeguidor",
                table: "Seguidores",
                column: "IdUsuarioSeguidor",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
