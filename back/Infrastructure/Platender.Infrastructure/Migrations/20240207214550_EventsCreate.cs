using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventsCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userStatus",
                table: "users",
                newName: "UserStatus");

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(63)", maxLength: 63, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Longtitude = table.Column<decimal>(type: "decimal(5)", precision: 5, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(5)", precision: 5, nullable: false),
                    EventAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeZone = table.Column<decimal>(type: "decimal(2)", precision: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "eventUser",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventUser", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_eventUser_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventUser_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_events_CreatorId",
                table: "events",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_eventUser_UserId",
                table: "eventUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventUser");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.RenameColumn(
                name: "UserStatus",
                table: "users",
                newName: "userStatus");
        }
    }
}
