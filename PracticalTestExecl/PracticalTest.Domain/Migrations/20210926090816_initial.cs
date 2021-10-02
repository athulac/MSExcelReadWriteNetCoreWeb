using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticalTest.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acadamic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryAge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ged = table.Column<bool>(type: "bit", nullable: false),
                    EnglishSecondLang = table.Column<bool>(type: "bit", nullable: false),
                    FirsGeneration = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acadamic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Act",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Composite = table.Column<int>(type: "int", nullable: false),
                    Math = table.Column<int>(type: "int", nullable: false),
                    English = table.Column<int>(type: "int", nullable: false),
                    Reading = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Act", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Combined = table.Column<int>(type: "int", nullable: false),
                    Math = table.Column<int>(type: "int", nullable: false),
                    Verbal = table.Column<int>(type: "int", nullable: false),
                    Reading = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EthnicityId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    AcadamicId = table.Column<int>(type: "int", nullable: false),
                    ActId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Acadamic_AcadamicId",
                        column: x => x.AcadamicId,
                        principalTable: "Acadamic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Act_ActId",
                        column: x => x.ActId,
                        principalTable: "Act",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Ethnicity_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ethnicity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hispanic" },
                    { 2, "Race/ethnicity unknown" },
                    { 3, "White" },
                    { 4, "Asian" },
                    { 5, "Hispanic" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "FT" },
                    { 2, "TRANSFER" },
                    { 3, "FTFT" },
                    { 4, "FTGRAD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AcadamicId",
                table: "Student",
                column: "AcadamicId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ActId",
                table: "Student",
                column: "ActId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_EthnicityId",
                table: "Student",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StatusId",
                table: "Student",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sat");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Acadamic");

            migrationBuilder.DropTable(
                name: "Act");

            migrationBuilder.DropTable(
                name: "Ethnicity");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
