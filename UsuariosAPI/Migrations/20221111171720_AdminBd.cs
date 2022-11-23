using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class AdminBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "2042cc2d-42a9-4dff-912d-1ab0e8990b81");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "bb4bb272-6625-40d6-9e8b-bff9c65cc175");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5064201-91c7-46be-b573-af98acce6448", "AQAAAAEAACcQAAAAEM+E+bNFKes79OfnnclZJUM5D827KnQMMFbdw9Aib3PSd+Qee/RXTfCvHPJzCVvNmg==", "590f94b3-b67d-4baa-92ef-8c1b6df2e156" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "1052d616-63a8-431e-9349-8d2619d78372");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "e56742f5-7350-4436-98c1-71ef2651c2e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "947d47e0-4c56-4568-9e02-66889c63e21f", "AQAAAAEAACcQAAAAEEWuaOGXUY3q4otCnQMFr30sEUJvg7xCw6fq/Er9VaOBPVL8s/uGd6GLBkeWAcMuUw==", "af661ca4-699a-43c6-9cf3-68aef619aa6c" });
        }
    }
}
