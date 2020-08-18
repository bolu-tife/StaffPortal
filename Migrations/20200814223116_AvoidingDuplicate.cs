using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class AvoidingDuplicate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_Departments_DeptCode_DeptName",
                table: "Departments",
                columns: new[] { "DeptCode", "DeptName" },
                unique: true,
                filter: "[DeptCode] IS NOT NULL AND [DeptName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_DeptCode_DeptName",
                table: "Departments");

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
