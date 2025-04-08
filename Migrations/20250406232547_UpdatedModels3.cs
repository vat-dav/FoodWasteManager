using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoodWasteManagerUserId",
                table: "OrganisationHours",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FoodWasteManagerUserId",
                table: "FoodPost",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgDescription",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationHours_FoodWasteManagerUserId",
                table: "OrganisationHours",
                column: "FoodWasteManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPost_FoodWasteManagerUserId",
                table: "FoodPost",
                column: "FoodWasteManagerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPost_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPost",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationHours_AspNetUsers_FoodWasteManagerUserId",
                table: "OrganisationHours",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPost_AspNetUsers_FoodWasteManagerUserId",
                table: "FoodPost");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationHours_AspNetUsers_FoodWasteManagerUserId",
                table: "OrganisationHours");

            migrationBuilder.DropIndex(
                name: "IX_OrganisationHours_FoodWasteManagerUserId",
                table: "OrganisationHours");

            migrationBuilder.DropIndex(
                name: "IX_FoodPost_FoodWasteManagerUserId",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "FoodWasteManagerUserId",
                table: "OrganisationHours");

            migrationBuilder.DropColumn(
                name: "FoodWasteManagerUserId",
                table: "FoodPost");

            migrationBuilder.DropColumn(
                name: "OrgDescription",
                table: "AspNetUsers");
        }
    }
}
