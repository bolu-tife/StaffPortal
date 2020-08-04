using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffPortal.Migrations
{
    public partial class userProfUpdateLatest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "LGAs",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "NewStates",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<int>(
                name: "LGAId",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewStatesId",
                table: "UserProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles",
                column: "LGAId",
                principalTable: "LGAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "NewStatesId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<int>(
                name: "LGAId",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "LGAs",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewStates",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_LGAs_LGAId",
                table: "UserProfiles",
                column: "LGAId",
                principalTable: "LGAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
