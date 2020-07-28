using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Faculties_FacultyID",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_FacultyID",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "FacultyID",
                table: "Salaries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultyID",
                table: "Salaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_FacultyID",
                table: "Salaries",
                column: "FacultyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Faculties_FacultyID",
                table: "Salaries",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
