using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_Rent_API.Migrations
{
    /// <inheritdoc />
    public partial class AddLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    postalCode = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
