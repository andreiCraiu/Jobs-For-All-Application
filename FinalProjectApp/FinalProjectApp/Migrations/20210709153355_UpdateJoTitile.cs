using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectApp.Migrations
{
    public partial class UpdateJoTitile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "job",
                table: "Jobs",
                newName: "JobTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Jobs",
                newName: "job");
        }
    }
}
