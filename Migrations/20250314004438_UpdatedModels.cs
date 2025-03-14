using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charity",
                columns: table => new
                {
                    CharityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CharityPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharityEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharityAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charity", x => x.CharityId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RestaurantPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurauntAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "FoodPost",
                columns: table => new
                {
                    FoodPostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestauarantId = table.Column<int>(type: "int", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FoodImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodBestBefore = table.Column<DateOnly>(type: "date", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPost", x => x.FoodPostId);
                    table.ForeignKey(
                        name: "FK_FoodPost_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "RestaurantId");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantHour",
                columns: table => new
                {
                    RestaurantHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpeningHours = table.Column<TimeOnly>(type: "time", nullable: false),
                    ClosingHours = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantHour", x => x.RestaurantHourId);
                    table.ForeignKey(
                        name: "FK_RestaurantHour_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "RestaurantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodPostId = table.Column<int>(type: "int", nullable: false),
                    CharityId = table.Column<int>(type: "int", nullable: false),
                    AStatus = table.Column<int>(type: "int", nullable: false),
                    OStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Application_Charity_CharityId",
                        column: x => x.CharityId,
                        principalTable: "Charity",
                        principalColumn: "CharityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Application_FoodPost_FoodPostId",
                        column: x => x.FoodPostId,
                        principalTable: "FoodPost",
                        principalColumn: "FoodPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application_CharityId",
                table: "Application",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_FoodPostId",
                table: "Application",
                column: "FoodPostId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPost_RestaurantId",
                table: "FoodPost",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantHour_RestaurantId",
                table: "RestaurantHour",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "RestaurantHour");

            migrationBuilder.DropTable(
                name: "Charity");

            migrationBuilder.DropTable(
                name: "FoodPost");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
