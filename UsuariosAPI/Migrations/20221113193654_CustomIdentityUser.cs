using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class CustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "aeffa06a-f162-4689-a9fb-d4ea45a246c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "7244321f-a097-4eb2-985f-f2011817eee7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64fa53d8-3619-46be-9049-492459a2478f", "AQAAAAEAACcQAAAAEP5fWQ+JxRQg/mHo0ene2oIPnkfiY6B9KEW6mAPvk/YvBb2PLV16fnmj39kQIZInxQ==", "61802ab3-4d8d-4cac-981e-a96df54a1c26" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

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
    }
}
