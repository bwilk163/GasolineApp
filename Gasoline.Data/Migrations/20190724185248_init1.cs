using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gasoline.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: new Guid("1b4da7c2-df0c-4e61-9e57-b39123b335db"),
                column: "FuelName",
                value: "Benzyna 95");

            migrationBuilder.UpdateData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: new Guid("2b29eff4-77c5-42d3-9ad4-dd32d4ccb41e"),
                column: "FuelName",
                value: "Benzyna 98");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: new Guid("1b4da7c2-df0c-4e61-9e57-b39123b335db"),
                column: "FuelName",
                value: "95");

            migrationBuilder.UpdateData(
                table: "FuelType",
                keyColumn: "Id",
                keyValue: new Guid("2b29eff4-77c5-42d3-9ad4-dd32d4ccb41e"),
                column: "FuelName",
                value: "98");
        }
    }
}
