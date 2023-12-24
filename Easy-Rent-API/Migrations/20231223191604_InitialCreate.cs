using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_Rent_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carTypologies",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carTypologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "powerSources",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_powerSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    places = table.Column<int>(type: "int", nullable: false),
                    plate = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    typologyId = table.Column<short>(type: "smallint", nullable: false),
                    powerSourceId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vehicules_carTypologies_typologyId",
                        column: x => x.typologyId,
                        principalTable: "carTypologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicules_powerSources_powerSourceId",
                        column: x => x.powerSourceId,
                        principalTable: "powerSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_powerSourceId",
                table: "Vehicules",
                column: "powerSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_typologyId",
                table: "Vehicules",
                column: "typologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "carTypologies");

            migrationBuilder.DropTable(
                name: "powerSources");
        }
    }
}
