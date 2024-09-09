using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAgroTempDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alarms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.CreateTable(
                name: "ReadingModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CommunicationType = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Port_or_AddressIP = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    Baudrate = table.Column<int>(type: "int", nullable: false),
                    BitsOfSign = table.Column<int>(type: "int", nullable: false),
                    StopBit = table.Column<int>(type: "int", nullable: false),
                    ModuleType = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingModules", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.CreateTable(
                name: "Silos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false),
                    OrderSensors = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Login = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeOfUser = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.CreateTable(
                name: "Probes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SensorsCount = table.Column<int>(type: "int", nullable: false),
                    NrFirstSensor = table.Column<int>(type: "int", nullable: false),
                    SiloId = table.Column<int>(type: "int", nullable: false),
                    ReadingModuleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Probes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Probes_ReadingModules_ReadingModuleId",
                        column: x => x.ReadingModuleId,
                        principalTable: "ReadingModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Probes_Silos_SiloId",
                        column: x => x.SiloId,
                        principalTable: "Silos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_polish_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Probes_Name",
                table: "Probes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Probes_ReadingModuleId",
                table: "Probes",
                column: "ReadingModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Probes_SiloId",
                table: "Probes",
                column: "SiloId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingModules_ModuleID",
                table: "ReadingModules",
                column: "ModuleID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReadingModules_Name",
                table: "ReadingModules",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Silos_Name",
                table: "Silos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarms");

            migrationBuilder.DropTable(
                name: "Probes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ReadingModules");

            migrationBuilder.DropTable(
                name: "Silos");
        }
    }
}
