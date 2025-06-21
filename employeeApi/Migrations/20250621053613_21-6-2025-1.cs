using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employeeApi.Migrations
{
    /// <inheritdoc />
    public partial class _21620251 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "inTime",
                table: "employees",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "outTime",
                table: "employees",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "reportingId",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "roleType",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "totalHrs",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_employees_reportingId",
                table: "employees",
                column: "reportingId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_employees_reportingId",
                table: "employees",
                column: "reportingId",
                principalTable: "employees",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_employees_reportingId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_reportingId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "inTime",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "outTime",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "reportingId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "roleType",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "totalHrs",
                table: "employees");
        }
    }
}
