using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsForAll.Migrations
{
    public partial class UpdateChatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Chat",
                newName: "SenderChatName");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverChatName",
                table: "Chat",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverChatName",
                table: "Chat");

            migrationBuilder.RenameColumn(
                name: "SenderChatName",
                table: "Chat",
                newName: "Name");
        }
    }
}
