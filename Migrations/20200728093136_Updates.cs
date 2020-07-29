using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "NewLocals");

            migrationBuilder.DropTable(
                name: "NewState");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FacultyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Locals");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "StatesId",
                table: "Locals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locals_StatesId",
                table: "Locals",
                column: "StatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locals_State_StatesId",
                table: "Locals",
                column: "StatesId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locals_State_StatesId",
                table: "Locals");

            migrationBuilder.DropIndex(
                name: "IX_Locals_StatesId",
                table: "Locals");

            migrationBuilder.DropColumn(
                name: "StatesId",
                table: "Locals");

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "State",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Locals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NewState",
                columns: table => new
                {
                    NewStateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewStateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewState", x => x.NewStateId);
                });

            migrationBuilder.CreateTable(
                name: "NewLocals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocalName = table.Column<string>(nullable: true),
                    NewStatesNewStateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewLocals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewLocals_NewState_NewStatesNewStateId",
                        column: x => x.NewStatesNewStateId,
                        principalTable: "NewState",
                        principalColumn: "NewStateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FacultyId",
                table: "AspNetUsers",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_NewLocals_NewStatesNewStateId",
                table: "NewLocals",
                column: "NewStatesNewStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
