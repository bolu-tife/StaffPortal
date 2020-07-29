using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Everything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Local_LocalId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local",
                table: "Local");

            migrationBuilder.RenameTable(
                name: "Local",
                newName: "Locals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locals",
                table: "Locals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Locals_LocalId",
                table: "UserProfiles",
                column: "LocalId",
                principalTable: "Locals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Locals_LocalId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locals",
                table: "Locals");

            migrationBuilder.RenameTable(
                name: "Locals",
                newName: "Local");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Local",
                table: "Local",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Local_LocalId",
                table: "UserProfiles",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
