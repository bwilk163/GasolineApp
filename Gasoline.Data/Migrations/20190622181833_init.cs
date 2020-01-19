using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gasoline.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GasStation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasStation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GasStationFuel",
                columns: table => new
                {
                    FuelTypeId = table.Column<Guid>(nullable: false),
                    GasStationId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    LastUpdateUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasStationFuel", x => new { x.GasStationId, x.FuelTypeId });
                    table.ForeignKey(
                        name: "FK_GasStationFuel_FuelType_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GasStationFuel_GasStation_GasStationId",
                        column: x => x.GasStationId,
                        principalTable: "GasStation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FuelType",
                columns: new[] { "Id", "FuelName" },
                values: new object[,]
                {
                    { new Guid("1b4da7c2-df0c-4e61-9e57-b39123b335db"), "95" },
                    { new Guid("2b29eff4-77c5-42d3-9ad4-dd32d4ccb41e"), "98" },
                    { new Guid("0fbaa67e-ce11-4e71-bb00-5a9c10701b34"), "Diesel" },
                    { new Guid("fb46fb8f-010c-4d05-b102-baae43dac348"), "LPG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GasStationFuel_FuelTypeId",
                table: "GasStationFuel",
                column: "FuelTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GasStationFuel");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "GasStation");
        }
    }
}
