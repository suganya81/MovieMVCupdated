using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMVC.Migrations
{
    public partial class AddAliasToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "AspNetUsers");
        }
    }
}
