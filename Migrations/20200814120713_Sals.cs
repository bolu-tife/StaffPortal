using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Sals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Departments_DepartmentId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_DepartmentId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "UserProfiles");

            migrationBuilder.AddColumn<double>(
                name: "BasicSalary",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Housing",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HousingPercent",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lunch",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LunchPercent",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Medical",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MedicalPercent",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NetSalary",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Tax",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TaxPercent",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotAllowance",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotDeduction",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Transport",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TransportPercent",
                table: "Grades",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicSalary",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Housing",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "HousingPercent",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "LunchPercent",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Medical",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "MedicalPercent",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TotAllowance",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TotDeduction",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TransportPercent",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BasicSalary = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    GradeId = table.Column<int>(nullable: false),
                    GradeLevel = table.Column<int>(nullable: false),
                    GradeName = table.Column<string>(nullable: true),
                    GradeStep = table.Column<int>(nullable: false),
                    Housing = table.Column<double>(nullable: false),
                    HousingItemType = table.Column<string>(nullable: true),
                    HousingPercent = table.Column<double>(nullable: false),
                    Lunch = table.Column<double>(nullable: false),
                    LunchItemType = table.Column<string>(nullable: true),
                    LunchPercent = table.Column<double>(nullable: false),
                    Medical = table.Column<double>(nullable: false),
                    MedicalItemType = table.Column<string>(nullable: true),
                    MedicalPercent = table.Column<double>(nullable: false),
                    NetSalary = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    TaxItemType = table.Column<string>(nullable: true),
                    TaxPercent = table.Column<double>(nullable: false),
                    TotAllowance = table.Column<double>(nullable: false),
                    TotDeduction = table.Column<double>(nullable: false),
                    Transport = table.Column<double>(nullable: false),
                    TransportItemType = table.Column<string>(nullable: true),
                    TransportPercent = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Salaries_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salaries_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_DepartmentId",
                table: "UserProfiles",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_ApplicationUserId",
                table: "Salaries",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_GradeId",
                table: "Salaries",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Departments_DepartmentId",
                table: "UserProfiles",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
