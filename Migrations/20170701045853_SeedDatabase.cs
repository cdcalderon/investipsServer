using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Investips.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Porfolios (Name) VALUES ('Top 25 Porfolio')");
            migrationBuilder.Sql("INSERT INTO Porfolios (Name) VALUES ('Carlos Top10 Porfolio')");
            migrationBuilder.Sql("INSERT INTO Porfolios (Name) VALUES ('Lorena Fundamentals')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql("DELETE FROM Porfolios WHERE Name in ('Top 25 Porfolio', 'Carlos Top10 Porfolio', 'Lorena Fundamentals')");
        }
    }
}
