using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPosts_AspNetUsers_UserId",
                table: "FoodPosts");

            migrationBuilder.DropIndex(
                name: "IX_FoodPosts_UserId",
                table: "FoodPosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoodPosts");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "FoodPosts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPosts_Id",
                table: "FoodPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPosts_AspNetUsers_Id",
                table: "FoodPosts",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPosts_AspNetUsers_Id",
                table: "FoodPosts");

            migrationBuilder.DropIndex(
                name: "IX_FoodPosts_Id",
                table: "FoodPosts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoodPosts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FoodPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodPosts_UserId",
                table: "FoodPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPosts_AspNetUsers_UserId",
                table: "FoodPosts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
