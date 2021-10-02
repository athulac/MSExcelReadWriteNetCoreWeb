using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticalTest.Domain.Migrations
{
    public partial class initialccsdfccex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Exclusion",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exclusion",
                table: "Student");
        }
    }
}
