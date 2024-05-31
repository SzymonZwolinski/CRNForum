using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserFavouritePlates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFavouritePlates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PlateId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavouritePlates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavouritePlates_plates_PlateId",
                        column: x => x.PlateId,
                        principalTable: "plates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavouritePlates_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouritePlates_PlateId",
                table: "UserFavouritePlates",
                column: "PlateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavouritePlates_UserId",
                table: "UserFavouritePlates",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavouritePlates");
        }
    }
}
