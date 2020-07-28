using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Salary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeName = table.Column<string>(nullable: true),
                    departmentId = table.Column<int>(nullable: true),
                    gradeId = table.Column<int>(nullable: true),
                    facultyId = table.Column<int>(nullable: true),
                    BasicSalary = table.Column<double>(nullable: false),
                    Housing = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    Lunch = table.Column<double>(nullable: false),
                    Transport = table.Column<double>(nullable: false),
                    Medical = table.Column<double>(nullable: false),
                    NetSalary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Salaries_Departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salaries_Faculties_facultyId",
                        column: x => x.facultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salaries_Grades_gradeId",
                        column: x => x.gradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_departmentId",
                table: "Salaries",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_facultyId",
                table: "Salaries",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_gradeId",
                table: "Salaries",
                column: "gradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");
        }
    }
}
