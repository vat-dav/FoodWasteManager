using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class FoodTypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodTypeId",
                table: "FoodPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    FoodTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.FoodTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodPosts_FoodTypeId",
                table: "FoodPosts",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPosts_FoodTypes_FoodTypeId",
                table: "FoodPosts",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "FoodTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPosts_FoodTypes_FoodTypeId",
                table: "FoodPosts");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropIndex(
                name: "IX_FoodPosts_FoodTypeId",
                table: "FoodPosts");

            migrationBuilder.DropColumn(
                name: "FoodTypeId",
                table: "FoodPosts");
        }
    }
}
