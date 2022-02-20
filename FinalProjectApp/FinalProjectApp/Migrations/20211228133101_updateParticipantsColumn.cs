using Microsoft.EntityFrameworkCore.Migrations;

namespace JobsForAll.Migrations
{
    public partial class updateParticipantsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Chat_ChatID",
                table: "Participants");

            migrationBuilder.RenameColumn(
                name: "ChatID",
                table: "Participants",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_ChatID",
                table: "Participants",
                newName: "IX_Participants_ChatId");

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Chat_ChatId",
                table: "Participants",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Chat_ChatId",
                table: "Participants");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Participants",
                newName: "ChatID");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_ChatId",
                table: "Participants",
                newName: "IX_Participants_ChatID");

            migrationBuilder.AlterColumn<int>(
                name: "ChatID",
                table: "Participants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Chat_ChatID",
                table: "Participants",
                column: "ChatID",
                principalTable: "Chat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
