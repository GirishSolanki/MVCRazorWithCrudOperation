using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACMESOFT.Data.Migrations
{
    public partial class IsDeletedColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Person",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employee",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employee");
        }
    }
}
