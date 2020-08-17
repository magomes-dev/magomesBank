using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagomesBank.Infra.Data.Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaCorrente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoMovimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContaCorrente = table.Column<int>(nullable: false),
                    DataMovimento = table.Column<DateTime>(nullable: false),
                    ValorMovimento = table.Column<decimal>(nullable: false),
                    TipoMovimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoMovimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CC_HISTMOVIMENTOS",
                        column: x => x.IdContaCorrente,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_UsuarioId",
                table: "ContaCorrente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMovimento_IdContaCorrente",
                table: "HistoricoMovimento",
                column: "IdContaCorrente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoMovimento");

            migrationBuilder.DropTable(
                name: "ContaCorrente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
