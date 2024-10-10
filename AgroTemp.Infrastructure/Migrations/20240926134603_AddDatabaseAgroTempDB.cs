using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroTemp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseAgroTempDB : Migration
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
                    Parity = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    OrderSensors = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false, collation: "utf8mb4_polish_ci")
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
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_polish_ci")
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
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReadingModuleId = table.Column<int>(type: "int", nullable: false),
                    sensor1 = table.Column<short>(type: "smallint", nullable: true),
                    sensor2 = table.Column<short>(type: "smallint", nullable: true),
                    sensor3 = table.Column<short>(type: "smallint", nullable: true),
                    sensor4 = table.Column<short>(type: "smallint", nullable: true),
                    sensor5 = table.Column<short>(type: "smallint", nullable: true),
                    sensor6 = table.Column<short>(type: "smallint", nullable: true),
                    sensor7 = table.Column<short>(type: "smallint", nullable: true),
                    sensor8 = table.Column<short>(type: "smallint", nullable: true),
                    sensor9 = table.Column<short>(type: "smallint", nullable: true),
                    sensor10 = table.Column<short>(type: "smallint", nullable: true),
                    sensor11 = table.Column<short>(type: "smallint", nullable: true),
                    sensor12 = table.Column<short>(type: "smallint", nullable: true),
                    sensor13 = table.Column<short>(type: "smallint", nullable: true),
                    sensor14 = table.Column<short>(type: "smallint", nullable: true),
                    sensor15 = table.Column<short>(type: "smallint", nullable: true),
                    sensor16 = table.Column<short>(type: "smallint", nullable: true),
                    sensor17 = table.Column<short>(type: "smallint", nullable: true),
                    sensor18 = table.Column<short>(type: "smallint", nullable: true),
                    sensor19 = table.Column<short>(type: "smallint", nullable: true),
                    sensor20 = table.Column<short>(type: "smallint", nullable: true),
                    sensor21 = table.Column<short>(type: "smallint", nullable: true),
                    sensor22 = table.Column<short>(type: "smallint", nullable: true),
                    sensor23 = table.Column<short>(type: "smallint", nullable: true),
                    sensor24 = table.Column<short>(type: "smallint", nullable: true),
                    sensor25 = table.Column<short>(type: "smallint", nullable: true),
                    sensor26 = table.Column<short>(type: "smallint", nullable: true),
                    sensor27 = table.Column<short>(type: "smallint", nullable: true),
                    sensor28 = table.Column<short>(type: "smallint", nullable: true),
                    sensor29 = table.Column<short>(type: "smallint", nullable: true),
                    sensor30 = table.Column<short>(type: "smallint", nullable: true),
                    sensor31 = table.Column<short>(type: "smallint", nullable: true),
                    sensor32 = table.Column<short>(type: "smallint", nullable: true),
                    sensor33 = table.Column<short>(type: "smallint", nullable: true),
                    sensor34 = table.Column<short>(type: "smallint", nullable: true),
                    sensor35 = table.Column<short>(type: "smallint", nullable: true),
                    sensor36 = table.Column<short>(type: "smallint", nullable: true),
                    sensor37 = table.Column<short>(type: "smallint", nullable: true),
                    sensor38 = table.Column<short>(type: "smallint", nullable: true),
                    sensor39 = table.Column<short>(type: "smallint", nullable: true),
                    sensor40 = table.Column<short>(type: "smallint", nullable: true),
                    sensor41 = table.Column<short>(type: "smallint", nullable: true),
                    sensor42 = table.Column<short>(type: "smallint", nullable: true),
                    sensor43 = table.Column<short>(type: "smallint", nullable: true),
                    sensor44 = table.Column<short>(type: "smallint", nullable: true),
                    sensor45 = table.Column<short>(type: "smallint", nullable: true),
                    sensor46 = table.Column<short>(type: "smallint", nullable: true),
                    sensor47 = table.Column<short>(type: "smallint", nullable: true),
                    sensor48 = table.Column<short>(type: "smallint", nullable: true),
                    sensor49 = table.Column<short>(type: "smallint", nullable: true),
                    sensor50 = table.Column<short>(type: "smallint", nullable: true),
                    sensor51 = table.Column<short>(type: "smallint", nullable: true),
                    sensor52 = table.Column<short>(type: "smallint", nullable: true),
                    sensor53 = table.Column<short>(type: "smallint", nullable: true),
                    sensor54 = table.Column<short>(type: "smallint", nullable: true),
                    sensor55 = table.Column<short>(type: "smallint", nullable: true),
                    sensor56 = table.Column<short>(type: "smallint", nullable: true),
                    sensor57 = table.Column<short>(type: "smallint", nullable: true),
                    sensor58 = table.Column<short>(type: "smallint", nullable: true),
                    sensor59 = table.Column<short>(type: "smallint", nullable: true),
                    sensor60 = table.Column<short>(type: "smallint", nullable: true),
                    sensor61 = table.Column<short>(type: "smallint", nullable: true),
                    sensor62 = table.Column<short>(type: "smallint", nullable: true),
                    sensor63 = table.Column<short>(type: "smallint", nullable: true),
                    sensor64 = table.Column<short>(type: "smallint", nullable: true),
                    sensor65 = table.Column<short>(type: "smallint", nullable: true),
                    sensor66 = table.Column<short>(type: "smallint", nullable: true),
                    sensor67 = table.Column<short>(type: "smallint", nullable: true),
                    sensor68 = table.Column<short>(type: "smallint", nullable: true),
                    sensor69 = table.Column<short>(type: "smallint", nullable: true),
                    sensor70 = table.Column<short>(type: "smallint", nullable: true),
                    sensor71 = table.Column<short>(type: "smallint", nullable: true),
                    sensor72 = table.Column<short>(type: "smallint", nullable: true),
                    sensor73 = table.Column<short>(type: "smallint", nullable: true),
                    sensor74 = table.Column<short>(type: "smallint", nullable: true),
                    sensor75 = table.Column<short>(type: "smallint", nullable: true),
                    sensor76 = table.Column<short>(type: "smallint", nullable: true),
                    sensor77 = table.Column<short>(type: "smallint", nullable: true),
                    sensor78 = table.Column<short>(type: "smallint", nullable: true),
                    sensor79 = table.Column<short>(type: "smallint", nullable: true),
                    sensor80 = table.Column<short>(type: "smallint", nullable: true),
                    sensor81 = table.Column<short>(type: "smallint", nullable: true),
                    sensor82 = table.Column<short>(type: "smallint", nullable: true),
                    sensor83 = table.Column<short>(type: "smallint", nullable: true),
                    sensor84 = table.Column<short>(type: "smallint", nullable: true),
                    sensor85 = table.Column<short>(type: "smallint", nullable: true),
                    sensor86 = table.Column<short>(type: "smallint", nullable: true),
                    sensor87 = table.Column<short>(type: "smallint", nullable: true),
                    sensor88 = table.Column<short>(type: "smallint", nullable: true),
                    sensor89 = table.Column<short>(type: "smallint", nullable: true),
                    sensor90 = table.Column<short>(type: "smallint", nullable: true),
                    sensor91 = table.Column<short>(type: "smallint", nullable: true),
                    sensor92 = table.Column<short>(type: "smallint", nullable: true),
                    sensor93 = table.Column<short>(type: "smallint", nullable: true),
                    sensor94 = table.Column<short>(type: "smallint", nullable: true),
                    sensor95 = table.Column<short>(type: "smallint", nullable: true),
                    sensor96 = table.Column<short>(type: "smallint", nullable: true),
                    sensor97 = table.Column<short>(type: "smallint", nullable: true),
                    sensor98 = table.Column<short>(type: "smallint", nullable: true),
                    sensor99 = table.Column<short>(type: "smallint", nullable: true),
                    sensor100 = table.Column<short>(type: "smallint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_ReadingModules_ReadingModuleId",
                        column: x => x.ReadingModuleId,
                        principalTable: "ReadingModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Temperatures_ReadingModuleId",
                table: "Temperatures",
                column: "ReadingModuleId");

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
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Silos");

            migrationBuilder.DropTable(
                name: "ReadingModules");
        }
    }
}
