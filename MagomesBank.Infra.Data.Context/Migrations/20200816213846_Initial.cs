using System;
using MagomesBank.Domain.Services;
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

            byte[] passwordHash, passwordSalt;
            ServiceUsuario.CreatePasswordHash("123456", out passwordHash, out passwordSalt);

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] {"Id", "Nome", "Sobrenome", "Username", "PasswordHash", "PasswordSalt" },
                values: new object[] {
                    1,
                    "Matheus",
                    "Gomes",
                    "magomes",
                    passwordHash,
                    passwordSalt
                }); ;

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] {"Id", "Nome", "Sobrenome", "Username", "PasswordHash", "PasswordSalt" },
                values: new object[] {
                    2,
                    "Warren",
                    "Brasil",
                    "wabrasil",
                    passwordHash,
                    passwordSalt
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.InsertData(
                table: "ContaCorrente",
                columns: new[] { "Id", "UsuarioId", "Saldo", "DataCriacao"},
                values: new object[] {
                    1,
                    1,
                    50,
                    DateTime.Now
                });

            migrationBuilder.InsertData(
                table: "ContaCorrente",
                columns: new[] { "Id", "UsuarioId", "Saldo", "DataCriacao"},
                values: new object[] {
                    2,
                    2,
                    0,
                    DateTime.Now
                });

            migrationBuilder.CreateTable(
                name: "HistoricoMovimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaCorrenteId = table.Column<int>(nullable: false),
                    DataMovimento = table.Column<DateTime>(nullable: false),
                    ValorMovimento = table.Column<decimal>(nullable: false),
                    TipoMovimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoMovimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CC_HISTMOVIMENTOS",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_UsuarioId",
                table: "ContaCorrente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoMovimento_ContaCorrenteId",
                table: "HistoricoMovimento",
                column: "ContaCorrenteId");

            migrationBuilder.InsertData(
                table: "HistoricoMovimento",
                columns: new[] { "Id", "ContaCorrenteId", "DataMovimento", "ValorMovimento", "TipoMovimento" },
                values: new object[] {
                    1,
                    1,
                    DateTime.Now,
                    100,
                    1
                });

            migrationBuilder.InsertData(
                table: "HistoricoMovimento",
                columns: new[] { "Id", "ContaCorrenteId", "DataMovimento", "ValorMovimento", "TipoMovimento" },
                values: new object[] {
                    2,
                    1,
                    DateTime.Now,
                    50,
                    2
                });
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
