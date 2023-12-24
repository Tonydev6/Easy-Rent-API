using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_Rent_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTransmition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "transmissionId",
                table: "Vehicules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "transmitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "sysdatetimeoffset()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transmitions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_transmissionId",
                table: "Vehicules",
                column: "transmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicules_transmitions_transmissionId",
                table: "Vehicules",
                column: "transmissionId",
                principalTable: "transmitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicules_transmitions_transmissionId",
                table: "Vehicules");

            migrationBuilder.DropTable(
                name: "transmitions");

            migrationBuilder.DropIndex(
                name: "IX_Vehicules_transmissionId",
                table: "Vehicules");

            migrationBuilder.DropColumn(
                name: "transmissionId",
                table: "Vehicules");
        }
    }
}
