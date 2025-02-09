using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddObjectNameColumnOnAlarmsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ObjectName",
                table: "Alarms",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_polish_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 15, 53, 50, 298, DateTimeKind.Local).AddTicks(3499), new DateTime(2024, 12, 19, 15, 53, 50, 298, DateTimeKind.Local).AddTicks(3539) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ObjectName",
                table: "Alarms");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 15, 41, 53, 351, DateTimeKind.Local).AddTicks(2907), new DateTime(2024, 12, 19, 15, 41, 53, 351, DateTimeKind.Local).AddTicks(2949) });
        }
    }
}
