using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class UserProf_Salary_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Locals");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropColumn(
                name: "NewStatesId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<int>(
                name: "NewStateId",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewStates",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles",
                column: "NewStateId",
                principalTable: "NewStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "NewStates",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<int>(
                name: "NewStateId",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "NewStatesId",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StatesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locals_State_StatesId",
                        column: x => x.StatesId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locals_StatesId",
                table: "Locals",
                column: "StatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles",
                column: "NewStateId",
                principalTable: "NewStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
