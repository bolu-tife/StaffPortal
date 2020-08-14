using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class AvoidingDuplicate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Name_Code",
                table: "Faculties",
                columns: new[] { "Name", "Code" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faculties_Name_Code",
                table: "Faculties");

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
        }
    }
}
