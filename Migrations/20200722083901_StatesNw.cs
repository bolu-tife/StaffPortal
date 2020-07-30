using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class StatesNw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Local_LocalId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Local",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Local");

            migrationBuilder.RenameTable(
                name: "Local",
                newName: "Locals");

            migrationBuilder.AddColumn<int>(
                name: "StatesId",
                table: "Locals",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locals",
                table: "Locals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Locals_StatesId",
                table: "Locals",
                column: "StatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locals_State_StatesId",
                table: "Locals",
                column: "StatesId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Locals_State_StatesId",
                table: "Locals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Locals_LocalId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locals",
                table: "Locals");

            migrationBuilder.DropIndex(
                name: "IX_Locals_StatesId",
                table: "Locals");

            migrationBuilder.DropColumn(
                name: "StatesId",
                table: "Locals");

            migrationBuilder.RenameTable(
                name: "Locals",
                newName: "Local");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Local",
                nullable: false,
                defaultValue: 0);

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
