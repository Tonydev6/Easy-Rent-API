using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Easy_Rent_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTransmitionValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "transmitions",
                columns: new[] { "Id", "description" },
                values: new object[,]
                {
                    { 1, "manual" },
                    { 2, "automatic" },
                    { 3, "semiAutomatic" },
                    { 4, "Continuosly Variable Transmission" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "transmitions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "transmitions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "transmitions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "transmitions",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
