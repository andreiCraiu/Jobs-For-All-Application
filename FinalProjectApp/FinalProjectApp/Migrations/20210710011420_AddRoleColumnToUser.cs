using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectApp.Migrations
{
    public partial class AddRoleColumnToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoleForUses_RoleID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RoleForUses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoleForUses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleForUses", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleID",
                table: "AspNetUsers",
                column: "RoleID");

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
