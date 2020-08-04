using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class SalaryMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LGAId",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewStateId",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_LGAId",
                table: "UserProfiles",
                column: "LGAId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_NewStateId",
                table: "UserProfiles",
                column: "NewStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles",
                column: "LGAId",
                principalTable: "LGAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles",
                column: "NewStateId",
                principalTable: "NewStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_NewStates_NewStateId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_LGAId",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_NewStateId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "LGAId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "NewStateId",
                table: "UserProfiles");
        }
    }
}
