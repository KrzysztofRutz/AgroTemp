using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNrOfCircleColumnOnProbes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NrOfCircle",
                table: "Probes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_polish_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Language", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 12, 41, 30, 590, DateTimeKind.Local).AddTicks(9305), "PL", new DateTime(2025, 5, 31, 12, 41, 30, 590, DateTimeKind.Local).AddTicks(9346) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfCircle",
                table: "Probes");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Language", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 15, 53, 50, 298, DateTimeKind.Local).AddTicks(3499), "ENG", new DateTime(2024, 12, 19, 15, 53, 50, 298, DateTimeKind.Local).AddTicks(3539) });
        }
    }
}
