using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_Rent_API.Migrations
{
    /// <inheritdoc />
    public partial class AddCreationDateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "Vehicules",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "powerSources",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "carTypologies",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "sysdatetimeoffset()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Vehicules");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "powerSources");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "carTypologies");
        }
    }
}
