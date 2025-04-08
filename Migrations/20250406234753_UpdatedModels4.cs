using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganisationHours_AspNetUsers_FoodWasteManagerUserId",
                table: "OrganisationHours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganisationHours",
                table: "OrganisationHours");

            migrationBuilder.RenameTable(
                name: "OrganisationHours",
                newName: "OrgHour");

            migrationBuilder.RenameIndex(
                name: "IX_OrganisationHours_FoodWasteManagerUserId",
                table: "OrgHour",
                newName: "IX_OrgHour_FoodWasteManagerUserId");

            migrationBuilder.AddColumn<int>(
                name: "HolidayId",
                table: "OrgHour",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgHour",
                table: "OrgHour",
                column: "OrgHourId");

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.HolidayId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrgHour_HolidayId",
                table: "OrgHour",
                column: "HolidayId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrgHour_AspNetUsers_FoodWasteManagerUserId",
                table: "OrgHour");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgHour_Holiday_HolidayId",
                table: "OrgHour");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgHour",
                table: "OrgHour");

            migrationBuilder.DropIndex(
                name: "IX_OrgHour_HolidayId",
                table: "OrgHour");

            migrationBuilder.DropColumn(
                name: "HolidayId",
                table: "OrgHour");

            migrationBuilder.RenameTable(
                name: "OrgHour",
                newName: "OrganisationHours");

            migrationBuilder.RenameIndex(
                name: "IX_OrgHour_FoodWasteManagerUserId",
                table: "OrganisationHours",
                newName: "IX_OrganisationHours_FoodWasteManagerUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganisationHours",
                table: "OrganisationHours",
                column: "OrgHourId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganisationHours_AspNetUsers_FoodWasteManagerUserId",
                table: "OrganisationHours",
                column: "FoodWasteManagerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
