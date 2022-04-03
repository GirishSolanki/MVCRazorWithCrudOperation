using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACMESOFT.Data.Migrations
{
    public partial class schemaupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Person_PersonId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PersonId",
                table: "Employee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TerminationDate",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonId",
                table: "Employee",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Person_PersonId",
                table: "Employee",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Person_PersonId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PersonId",
                table: "Employee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TerminationDate",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonId",
                table: "Employee",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Person_PersonId",
                table: "Employee",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
