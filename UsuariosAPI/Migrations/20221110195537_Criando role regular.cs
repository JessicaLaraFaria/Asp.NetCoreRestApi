using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class Criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "e56742f5-7350-4436-98c1-71ef2651c2e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "1052d616-63a8-431e-9349-8d2619d78372", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "947d47e0-4c56-4568-9e02-66889c63e21f", "AQAAAAEAACcQAAAAEEWuaOGXUY3q4otCnQMFr30sEUJvg7xCw6fq/Er9VaOBPVL8s/uGd6GLBkeWAcMuUw==", "af661ca4-699a-43c6-9cf3-68aef619aa6c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "ae9884e0-08c0-49c2-899b-80c5dd5f2b6d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b978ed-5564-4dd8-8200-1ed941ee2919", "AQAAAAEAACcQAAAAELYC98Fh1SGOz6I+WMb3ZAbAemAjFCVTiYoDbqpUX0s4rfs6hXIpBmn+OmaAmiQllg==", "5c9c61f2-b3be-4636-b728-7433dc120777" });
        }
    }
}
