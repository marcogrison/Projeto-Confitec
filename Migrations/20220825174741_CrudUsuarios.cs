using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Confitec.Migrations
{
    public partial class CrudUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NiveisEscolares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveisEscolares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SobrenomeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NivelEscolarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_NiveisEscolares_NivelEscolarId",
                        column: x => x.NivelEscolarId,
                        principalTable: "NiveisEscolares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NiveisEscolares",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Infantil" },
                    { 2, "Fundamental" },
                    { 3, "Médio" },
                    { 4, "Superior" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "DataNascimento", "EmailUsuario", "NivelEscolarId", "NomeUsuario", "SobrenomeUsuario" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 7, 7, 2, 0, 0, 0, DateTimeKind.Unspecified), "jjesus@gmail.com", 1, "Jorge", "de Jesus" },
                    { 2, new DateTime(1985, 9, 3, 2, 0, 0, 0, DateTimeKind.Unspecified), "enascimento@gmail.com", 2, "Emilio", "Nascimento" },
                    { 3, new DateTime(1999, 10, 20, 2, 0, 0, 0, DateTimeKind.Unspecified), "fahrenheitizin@gmail.com", 3, "João", "Fahrenheit" },
                    { 4, new DateTime(1990, 12, 24, 2, 0, 0, 0, DateTimeKind.Unspecified), "cleytrambiq@gmail.com", 1, "Cleysson", "Trambique" },
                    { 5, new DateTime(1995, 7, 17, 2, 0, 0, 0, DateTimeKind.Unspecified), "jordanJu@gmail.com", 4, "Julio", "Jordan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NivelEscolarId",
                table: "Usuarios",
                column: "NivelEscolarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "NiveisEscolares");
        }
    }
}
