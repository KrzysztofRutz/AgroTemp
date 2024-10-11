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
                    CommunicationType = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Port_or_AddressIP = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    Baudrate = table.Column<int>(type: "int", nullable: false),
                    BitsOfSign = table.Column<int>(type: "int", nullable: false),
                    Parity = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StopBit = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    OrderSensors = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
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
                    TypeOfUser = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_polish_ci")
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
                    sensor1 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor2 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor3 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor4 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor5 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor6 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor7 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor8 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor9 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor10 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor11 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor12 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor13 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor14 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor15 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor16 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor17 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor18 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor19 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor20 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor21 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor22 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor23 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor24 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor25 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor26 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor27 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor28 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor29 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor30 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor31 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor32 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor33 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor34 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor35 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor36 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor37 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor38 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor39 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor40 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor41 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor42 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor43 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor44 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor45 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor46 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor47 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor48 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor49 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor50 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor51 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor52 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor53 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor54 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor55 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor56 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor57 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor58 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor59 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor60 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor61 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor62 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor63 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor64 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor65 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor66 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor67 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor68 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor69 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor70 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor71 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor72 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor73 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor74 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor75 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor76 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor77 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor78 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor79 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor80 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor81 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor82 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor83 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor84 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor85 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor86 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor87 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor88 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor89 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor90 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor91 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor92 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor93 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor94 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor95 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor96 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor97 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor98 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor99 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
                    sensor100 = table.Column<ushort>(type: "smallint unsigned", nullable: true),
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
