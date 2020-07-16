using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Entitychange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeptCode",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DeptCode",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
