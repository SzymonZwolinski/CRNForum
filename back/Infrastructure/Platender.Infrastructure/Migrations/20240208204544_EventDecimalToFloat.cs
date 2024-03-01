using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventDecimalToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TimeZone",
                table: "events",
                type: "float",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,30)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<float>(
                name: "Longtitude",
                table: "events",
                type: "float",
                precision: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,30)",
                oldPrecision: 5);

            migrationBuilder.AlterColumn<float>(
                name: "Latitude",
                table: "events",
                type: "float",
                precision: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,30)",
                oldPrecision: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TimeZone",
                table: "events",
                type: "decimal(2,30)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longtitude",
                table: "events",
                type: "decimal(5,30)",
                precision: 5,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float",
                oldPrecision: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "events",
                type: "decimal(5,30)",
                precision: 5,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float",
                oldPrecision: 5);
        }
    }
}
