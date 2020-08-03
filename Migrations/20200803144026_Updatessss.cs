using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Updatessss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_AspNetUsers_ApplicationUserId1",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_ApplicationUserId1",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Salaries");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_ApplicationUserId",
                table: "Salaries",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_ApplicationUserId",
                table: "Salaries",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_AspNetUsers_ApplicationUserId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_ApplicationUserId",
                table: "Salaries");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Salaries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_ApplicationUserId1",
                table: "Salaries",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_AspNetUsers_ApplicationUserId1",
                table: "Salaries",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
