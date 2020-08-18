using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class UserProfilesals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BasicSalary",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Housing",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HousingPercent",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lunch",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LunchPercent",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Medical",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MedicalPercent",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TaxPercent",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Transport",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TransportPercent",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeptName",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeptCode",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Name_Code",
                table: "Faculties",
                columns: new[] { "Name", "Code" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeptCode_DeptName",
                table: "Departments",
                columns: new[] { "DeptCode", "DeptName" },
                unique: true,
                filter: "[DeptCode] IS NOT NULL AND [DeptName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faculties_Name_Code",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DeptCode_DeptName",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Housing",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "HousingPercent",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "LunchPercent",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Medical",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "MedicalPercent",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TransportPercent",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeptName",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeptCode",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
