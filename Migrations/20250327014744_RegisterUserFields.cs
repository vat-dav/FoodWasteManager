using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class RegisterUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPost_Restaurant_RestaurantId",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "RestaurantEmail",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestaurantPhone",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestaurauntAddress",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "RestauarantId",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "CharityAddress",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "CharityEmail",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "CharityName",
                table: "Charity");

            migrationBuilder.RenameColumn(
                name: "CharityPhone",
                table: "Charity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "AspNetUsers",
                newName: "OrgPhone");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Restaurant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Restaurant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Restaurant",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Restaurant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Restaurant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "FoodPost",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Charity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Charity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Charity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Charity",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Charity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Charity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgAddress",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrgLandline",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPost_Restaurant_RestaurantId",
                table: "FoodPost",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPost_Restaurant_RestaurantId",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Charity");

            migrationBuilder.DropColumn(
                name: "CharityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrgAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrgLandline",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrgName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Charity",
                newName: "CharityPhone");

            migrationBuilder.RenameColumn(
                name: "OrgPhone",
                table: "AspNetUsers",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantEmail",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "Restaurant",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantPhone",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RestaurauntAddress",
                table: "Restaurant",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "FoodPost",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RestauarantId",
                table: "FoodPost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CharityAddress",
                table: "Charity",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CharityEmail",
                table: "Charity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CharityName",
                table: "Charity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPost_Restaurant_RestaurantId",
                table: "FoodPost",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId");
        }
    }
}
