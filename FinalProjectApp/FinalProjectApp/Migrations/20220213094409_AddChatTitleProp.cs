using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsForAll.Migrations
{
    public partial class AddChatTitleProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChatTitle",
                table: "Chat",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatTitle",
                table: "Chat");
        }
    }
}
