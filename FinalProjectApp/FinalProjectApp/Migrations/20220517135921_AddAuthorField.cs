using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsForAll.Migrations
{
    public partial class AddAuthorField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageAuthor",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageAuthor",
                table: "Messages");
        }
    }
}
