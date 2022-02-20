using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsForAll.Migrations
{
    public partial class AddChatIdsProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverChatId",
                table: "Chat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderChatId",
                table: "Chat",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverChatId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "SenderChatId",
                table: "Chat");
        }
    }
}
