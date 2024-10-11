using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSettingsTableToAgroTempDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HourOfReading = table.Column<int>(type: "int", nullable: false),
                    FrequencyOfReading = table.Column<int>(type: "int", nullable: false),
                    EnableSMSNotificationMode = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EnableEmailNotificationMode = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedAt", "EnableEmailNotificationMode", "EnableSMSNotificationMode", "FrequencyOfReading", "HourOfReading", "Language", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2024, 10, 11, 14, 55, 46, 101, DateTimeKind.Local).AddTicks(4239), false, false, 24, 12, "ENG", new DateTime(2024, 10, 11, 14, 55, 46, 101, DateTimeKind.Local).AddTicks(4299) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
