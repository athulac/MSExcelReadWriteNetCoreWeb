using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticalTest.Domain.Migrations
{
    public partial class initialccsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SatId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_SatId",
                table: "Student",
                column: "SatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Sat_SatId",
                table: "Student",
                column: "SatId",
                principalTable: "Sat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Sat_SatId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SatId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SatId",
                table: "Student");
        }
    }
}
