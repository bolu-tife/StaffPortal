using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Locals");

            migrationBuilder.AddColumn<int>(
                name: "StatesId",
                table: "Locals",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locals_State_StatesId",
                table: "Locals");

            migrationBuilder.DropIndex(
                name: "IX_Locals_StatesId",
                table: "Locals");

            migrationBuilder.DropColumn(
                name: "StatesId",
                table: "Locals");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Locals",
                nullable: false,
                defaultValue: 0);
        }
    }
}
