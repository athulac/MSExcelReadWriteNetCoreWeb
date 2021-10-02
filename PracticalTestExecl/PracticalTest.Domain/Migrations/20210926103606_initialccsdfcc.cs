using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticalTest.Domain.Migrations
{
    public partial class initialccsdfcc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Zip",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Gpa",
                table: "Student",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gpa",
                table: "Student");

            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
