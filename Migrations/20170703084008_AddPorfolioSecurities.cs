using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investips.Migrations
{
    public partial class AddPorfolioSecurities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Securities_Porfolios_PorfolioId",
                table: "Securities");

            migrationBuilder.DropIndex(
                name: "IX_Securities_PorfolioId",
                table: "Securities");

            migrationBuilder.DropColumn(
                name: "PorfolioId",
                table: "Securities");

            migrationBuilder.CreateTable(
                name: "PorfolioSecurities",
                columns: table => new
                {
                    PorfolioId = table.Column<int>(nullable: false),
                    SecurityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorfolioSecurities", x => new { x.PorfolioId, x.SecurityId });
                    table.ForeignKey(
                        name: "FK_PorfolioSecurities_Porfolios_PorfolioId",
                        column: x => x.PorfolioId,
                        principalTable: "Porfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PorfolioSecurities_Securities_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Securities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PorfolioSecurities_SecurityId",
                table: "PorfolioSecurities",
                column: "SecurityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PorfolioSecurities");

            migrationBuilder.AddColumn<int>(
                name: "PorfolioId",
                table: "Securities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Securities_PorfolioId",
                table: "Securities",
                column: "PorfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Securities_Porfolios_PorfolioId",
                table: "Securities",
                column: "PorfolioId",
                principalTable: "Porfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
