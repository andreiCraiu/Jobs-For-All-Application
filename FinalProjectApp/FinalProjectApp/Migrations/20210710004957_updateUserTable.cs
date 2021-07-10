using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectApp.Migrations
{
    public partial class updateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoleForUses_RoleID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleForUses",
                table: "RoleForUses");

            migrationBuilder.RenameTable(
                name: "RoleForUses",
                newName: "RoleForUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleForUsers",
                table: "RoleForUsers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RoleForUsers_RoleID",
                table: "AspNetUsers",
                column: "RoleID",
                principalTable: "RoleForUsers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoleForUsers_RoleID",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleForUsers",
                table: "RoleForUsers");

            migrationBuilder.RenameTable(
                name: "RoleForUsers",
                newName: "RoleForUses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleForUses",
                table: "RoleForUses",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RoleForUses_RoleID",
                table: "AspNetUsers",
                column: "RoleID",
                principalTable: "RoleForUses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
