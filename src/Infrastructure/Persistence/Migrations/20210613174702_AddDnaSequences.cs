using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mercadolibre_challenge.Infrastructure.Persistence.Migrations
{
    public partial class AddDnaSequences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DnaSequences",
                columns: table => new
                {
                    Sequence = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsMutant = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DnaSequences", x => x.Sequence);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DnaSequences");
        }
    }
}
