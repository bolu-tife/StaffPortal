using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class SalUpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LGAs",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeLevel",
                table: "Salaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeStep",
                table: "Salaries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "LGAs",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "GradeLevel",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "GradeStep",
                table: "Salaries");
        }
    }
}
