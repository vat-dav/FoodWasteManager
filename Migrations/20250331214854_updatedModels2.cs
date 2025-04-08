using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodWasteManager.Migrations
{
    /// <inheritdoc />
    public partial class updatedModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Charity_CharityId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPost_Restaurant_RestaurantId",
                table: "FoodPost");

            migrationBuilder.DropTable(
                name: "Charity");

            migrationBuilder.DropTable(
                name: "RestaurantHour");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_FoodPost_RestaurantId",
                table: "FoodPost");

            migrationBuilder.DropIndex(
                name: "IX_Application_CharityId",
                table: "Application");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "FoodPost",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "CharityId",
                table: "Application",
                newName: "AccessFailedCount");

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

            migrationBuilder.CreateTable(
                name: "OrganisationHours",
                columns: table => new
                {
                    OrgHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpeningHours = table.Column<TimeOnly>(type: "time", nullable: false),
                    ClosingHours = table.Column<TimeOnly>(type: "time", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationHours", x => x.OrgHourId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationHours");

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

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "FoodPost",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "Application",
                newName: "CharityId");

            migrationBuilder.CreateTable(
                name: "Charity",
                columns: table => new
                {
                    CharityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.RestaurantId);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantHour",
                columns: table => new
                {
                    RestaurantHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClosingHours = table.Column<TimeOnly>(type: "time", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpeningHours = table.Column<TimeOnly>(type: "time", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_FoodPost_RestaurantId",
                table: "FoodPost",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_CharityId",
                table: "Application",
                column: "CharityId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantHour_RestaurantId",
                table: "RestaurantHour",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Charity_CharityId",
                table: "Application",
                column: "CharityId",
                principalTable: "Charity",
                principalColumn: "CharityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPost_Restaurant_RestaurantId",
                table: "FoodPost",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
