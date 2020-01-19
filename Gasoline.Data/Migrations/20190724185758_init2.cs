using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gasoline.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GasStation",
                columns: new[] { "Id", "City", "Name", "PostalCode", "Street" },
                values: new object[] { new Guid("60a4ef9c-7664-440e-804c-a5acf530a529"), "Czciana", "Lotos", "69-666", "Czciana" });

            migrationBuilder.InsertData(
                table: "GasStation",
                columns: new[] { "Id", "City", "Name", "PostalCode", "Street" },
                values: new object[] { new Guid("e64e5e92-9701-4f5f-95db-d55f20d20210"), "Wysoka Gogolowska", "BP", "36-061", "Strumykowa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GasStation",
                keyColumn: "Id",
                keyValue: new Guid("60a4ef9c-7664-440e-804c-a5acf530a529"));

            migrationBuilder.DeleteData(
                table: "GasStation",
                keyColumn: "Id",
                keyValue: new Guid("e64e5e92-9701-4f5f-95db-d55f20d20210"));
        }
    }
}
