using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_FoodPost_FoodPostId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPost_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPost");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgHour_AspNetUsers_FoodWasteManagerUserId",
                table: "OrgHour");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgHour_Holiday_HolidayId",
                table: "OrgHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgHour",
                table: "OrgHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodPost",
                table: "FoodPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "CharityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "OrgHour",
                newName: "OrgHours");

            migrationBuilder.RenameTable(
                name: "FoodPost",
                newName: "FoodPosts");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_OrgHour_HolidayId",
                table: "OrgHours",
                newName: "IX_OrgHours_HolidayId");

            migrationBuilder.RenameIndex(
                name: "IX_OrgHour_FoodWasteManagerUserId",
                table: "OrgHours",
                newName: "IX_OrgHours_FoodWasteManagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPost_FoodWasteManagerUserId",
                table: "FoodPosts",
                newName: "IX_FoodPosts_FoodWasteManagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_FoodPostId",
                table: "Applications",
                newName: "IX_Applications_FoodPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgHours",
                table: "OrgHours",
                column: "OrgHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodPosts",
                table: "FoodPosts",
                column: "FoodPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_FoodPosts_FoodPostId",
                table: "Applications",
                column: "FoodPostId",
                principalTable: "FoodPosts",
                principalColumn: "FoodPostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPosts_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPosts",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgHours_AspNetUsers_FoodWasteManagerUserId",
                table: "OrgHours",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgHours_Holiday_HolidayId",
                table: "OrgHours",
                column: "HolidayId",
                principalTable: "Holiday",
                principalColumn: "HolidayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_FoodPosts_FoodPostId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPosts_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgHours_AspNetUsers_FoodWasteManagerUserId",
                table: "OrgHours");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgHours_Holiday_HolidayId",
                table: "OrgHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgHours",
                table: "OrgHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodPosts",
                table: "FoodPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "OrgHours",
                newName: "OrgHour");

            migrationBuilder.RenameTable(
                name: "FoodPosts",
                newName: "FoodPost");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_OrgHours_HolidayId",
                table: "OrgHour",
                newName: "IX_OrgHour_HolidayId");

            migrationBuilder.RenameIndex(
                name: "IX_OrgHours_FoodWasteManagerUserId",
                table: "OrgHour",
                newName: "IX_OrgHour_FoodWasteManagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPosts_FoodWasteManagerUserId",
                table: "FoodPost",
                newName: "IX_FoodPost_FoodWasteManagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_FoodPostId",
                table: "Application",
                newName: "IX_Application_FoodPostId");

            migrationBuilder.AddColumn<int>(
                name: "CharityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "OrgHour",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "OrgHour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "OrgHour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "OrgHour",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "OrgHour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "OrgHour",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "OrgHour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "FoodPost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "FoodPost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "FoodPost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "FoodPost",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "FoodPost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "FoodPost",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "FoodPost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Application",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Application",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgHour",
                table: "OrgHour",
                column: "OrgHourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodPost",
                table: "FoodPost",
                column: "FoodPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_FoodPost_FoodPostId",
                table: "Application",
                column: "FoodPostId",
                principalTable: "FoodPost",
                principalColumn: "FoodPostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPost_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPost",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgHour_AspNetUsers_FoodWasteManagerUserId",
                table: "OrgHour",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgHour_Holiday_HolidayId",
                table: "OrgHour",
                column: "HolidayId",
                principalTable: "Holiday",
                principalColumn: "HolidayId");
        }
    }
}
