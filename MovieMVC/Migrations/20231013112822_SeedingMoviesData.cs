using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMVC.Migrations
{
    public partial class SeedingMoviesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9623));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 13, 28, 21, 569, DateTimeKind.Local).AddTicks(9676));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4321));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4335));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 12, 23, 59, 42, 383, DateTimeKind.Local).AddTicks(4341));
        }
    }
}
