using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPosts_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPosts");

            migrationBuilder.DropTable(
                name: "OrgHours");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropColumn(
                name: "UserDescription",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FoodWasteManagerUserId",
                table: "FoodPosts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPosts_FoodWasteManagerUserId",
                table: "FoodPosts",
                newName: "IX_FoodPosts_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "FoodName",
                table: "FoodPosts",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FoodImage",
                table: "FoodPosts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UserAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<DateTime>(
                name: "EarliestPickup",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LatestPickup",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPosts_AspNetUsers_UserId",
                table: "FoodPosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPosts_AspNetUsers_UserId",
                table: "FoodPosts");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "EarliestPickup",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "LatestPickup",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FoodPosts",
                newName: "FoodWasteManagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPosts_UserId",
                table: "FoodPosts",
                newName: "IX_FoodPosts_FoodWasteManagerUserId");

            migrationBuilder.AlterColumn<string>(
                name: "FoodName",
                table: "FoodPosts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FoodImage",
                table: "FoodPosts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserAddress",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserDescription",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "OrgHours",
                columns: table => new
                {
                    OrgHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClosingHours = table.Column<TimeOnly>(type: "time", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    FoodWasteManagerUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HolidayId = table.Column<int>(type: "int", nullable: true),
                    OpeningHours = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgHours", x => x.OrgHourId);
                    table.ForeignKey(
                        name: "FK_OrgHours_AspNetUsers_FoodWasteManagerUserId",
                        column: x => x.FoodWasteManagerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrgHours_Holiday_HolidayId",
                        column: x => x.HolidayId,
                        principalTable: "Holiday",
                        principalColumn: "HolidayId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrgHours_FoodWasteManagerUserId",
                table: "OrgHours",
                column: "FoodWasteManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrgHours_HolidayId",
                table: "OrgHours",
                column: "HolidayId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPosts_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPosts",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
