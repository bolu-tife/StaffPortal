using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "NewStateId",
                table: "UserProfiles",
                newName: "GradeId");

            migrationBuilder.RenameColumn(
                name: "LGAId",
                table: "UserProfiles",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_NewStateId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_LGAId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeLevel",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NetPay",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotAllowance",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotDeduction",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Departments_DepartmentId",
                table: "UserProfiles",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Grades_GradeId",
                table: "UserProfiles",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Departments_DepartmentId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Grades_GradeId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "GradeLevel",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "NetPay",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TotAllowance",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TotDeduction",
                table: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "UserProfiles",
                newName: "NewStateId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "UserProfiles",
                newName: "LGAId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_GradeId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_NewStateId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfiles_DepartmentId",
                table: "UserProfiles",
                newName: "IX_UserProfiles_LGAId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles",
                column: "LGAId",
                principalTable: "LGAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles",
                column: "NewStateId",
                principalTable: "NewStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
