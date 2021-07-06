using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcWeb.Migrations
{
    public partial class EmployeeModelCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    employeeIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    employeerName = table.Column<string>(type: "TEXT", nullable: false),
                    employeeIntro = table.Column<string>(type: "TEXT", nullable: true),
                    employeeDegree = table.Column<string>(type: "TEXT", nullable: true),
                    employeeBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    employeePicture = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
