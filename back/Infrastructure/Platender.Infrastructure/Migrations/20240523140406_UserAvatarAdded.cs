using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserAvatarAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "users",
                type: "longblob",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "users");
        }
    }
}
