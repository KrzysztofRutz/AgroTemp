using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataTypeForDescriptionOnAlarmsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Alarms",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_polish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 19, 15, 41, 53, 351, DateTimeKind.Local).AddTicks(2907), new DateTime(2024, 12, 19, 15, 41, 53, 351, DateTimeKind.Local).AddTicks(2949) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Alarms",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_polish_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 3, 15, 17, 31, 671, DateTimeKind.Local).AddTicks(4623), new DateTime(2024, 11, 3, 15, 17, 31, 671, DateTimeKind.Local).AddTicks(4664) });
        }
    }
}
