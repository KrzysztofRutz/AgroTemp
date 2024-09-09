using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMaxLengthForOrderSensorsInSiloTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderSensors",
                table: "Silos",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                collation: "utf8mb4_polish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_polish_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderSensors",
                table: "Silos",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                collation: "utf8mb4_polish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_polish_ci");
        }
    }
}
