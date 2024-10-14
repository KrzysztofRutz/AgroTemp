using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExtremeValuesTableToAgroTempDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtremeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MaxTemperature = table.Column<int>(type: "int", nullable: true),
                    MinTemperature = table.Column<int>(type: "int", nullable: true),
                    MaxDeltaTemperature = table.Column<int>(type: "int", nullable: true),
                    SiloId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtremeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtremeValues_Silos_SiloId",
                        column: x => x.SiloId,
                        principalTable: "Silos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 14, 12, 55, 47, 505, DateTimeKind.Local).AddTicks(4848), new DateTime(2024, 10, 14, 12, 55, 47, 505, DateTimeKind.Local).AddTicks(4911) });

            migrationBuilder.CreateIndex(
                name: "IX_ExtremeValues_SiloId",
                table: "ExtremeValues",
                column: "SiloId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtremeValues");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 10, 11, 14, 55, 46, 101, DateTimeKind.Local).AddTicks(4239), new DateTime(2024, 10, 11, 14, 55, 46, 101, DateTimeKind.Local).AddTicks(4299) });
        }
    }
}
