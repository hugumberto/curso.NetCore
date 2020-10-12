using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ficheiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Extensao = table.Column<string>(nullable: true),
                    Tamanho = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficheiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Fornecedor = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    FicheiroId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibos_Ficheiros_FicheiroId",
                        column: x => x.FicheiroId,
                        principalTable: "Ficheiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReciboId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Qnt = table.Column<decimal>(nullable: false),
                    PUnit = table.Column<decimal>(nullable: false),
                    Iva = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Recibos_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ReciboId",
                table: "Items",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_FicheiroId",
                table: "Recibos",
                column: "FicheiroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "Ficheiros");
        }
    }
}
