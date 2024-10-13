using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheapFly.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PretragaLeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    polazniAerodrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    odredisniAerodrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumPolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumPovratka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    brojPutnika = table.Column<int>(type: "int", nullable: false),
                    valuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ukupnaCijena = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    brojPresjedanja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PretragaLeta", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PretragaLeta");
        }
    }
}
