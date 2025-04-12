using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OStatus",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "OrgPhone",
                table: "AspNetUsers",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "OrgName",
                table: "AspNetUsers",
                newName: "UserLastName");

            migrationBuilder.RenameColumn(
                name: "OrgLandline",
                table: "AspNetUsers",
                newName: "UserLandline");

            migrationBuilder.RenameColumn(
                name: "OrgDescription",
                table: "AspNetUsers",
                newName: "UserDescription");

            migrationBuilder.RenameColumn(
                name: "OrgAddress",
                table: "AspNetUsers",
                newName: "UserAddress");

            migrationBuilder.AlterColumn<string>(
                name: "FoodName",
                table: "FoodPosts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FoodImage",
                table: "FoodPosts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FoodPrice",
                table: "FoodPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodQuantity",
                table: "FoodPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodPrice",
                table: "FoodPosts");

            migrationBuilder.DropColumn(
                name: "FoodQuantity",
                table: "FoodPosts");

            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "AspNetUsers",
                newName: "OrgPhone");

            migrationBuilder.RenameColumn(
                name: "UserLastName",
                table: "AspNetUsers",
                newName: "OrgName");

            migrationBuilder.RenameColumn(
                name: "UserLandline",
                table: "AspNetUsers",
                newName: "OrgLandline");

            migrationBuilder.RenameColumn(
                name: "UserDescription",
                table: "AspNetUsers",
                newName: "OrgDescription");

            migrationBuilder.RenameColumn(
                name: "UserAddress",
                table: "AspNetUsers",
                newName: "OrgAddress");

            migrationBuilder.AlterColumn<string>(
                name: "FoodName",
                table: "FoodPosts",
                type: "nvarchar(50)",
                maxLength: 50,
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

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OStatus",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
