using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class SalaryUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HousingItemType",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HousingPercent",
                table: "Salaries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "LunchItemType",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LunchPercent",
                table: "Salaries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MedicalItemType",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MedicalPercent",
                table: "Salaries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TaxItemType",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TaxPercent",
                table: "Salaries",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TransportItemType",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TransportPercent",
                table: "Salaries",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HousingItemType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "HousingPercent",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "LunchItemType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "LunchPercent",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "MedicalItemType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "MedicalPercent",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TaxItemType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TransportItemType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TransportPercent",
                table: "Salaries");
        }
    }
}
