using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LikesFKFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plateLike_plates_Id",
                table: "plateLike");

            migrationBuilder.DropForeignKey(
                name: "FK_spottLike_Spotts_Id",
                table: "spottLike");

            migrationBuilder.DropForeignKey(
                name: "FK_Spotts_plates_PlateId",
                table: "Spotts");

            migrationBuilder.DropForeignKey(
                name: "FK_Spotts_users_UserId",
                table: "Spotts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Spotts",
                table: "Spotts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spottLike",
                table: "spottLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_plateLike",
                table: "plateLike");

            migrationBuilder.DropColumn(
                name: "LikeRatio",
                table: "plates");

            migrationBuilder.RenameTable(
                name: "Spotts",
                newName: "spotts");

            migrationBuilder.RenameTable(
                name: "spottLike",
                newName: "SpottLike");

            migrationBuilder.RenameTable(
                name: "plateLike",
                newName: "PlateLike");

            migrationBuilder.RenameIndex(
                name: "IX_Spotts_UserId",
                table: "spotts",
                newName: "IX_spotts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Spotts_PlateId",
                table: "spotts",
                newName: "IX_spotts_PlateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spotts",
                table: "spotts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpottLike",
                table: "SpottLike",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlateLike",
                table: "PlateLike",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpottLike_SpottId",
                table: "SpottLike",
                column: "SpottId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateLike_PlateId",
                table: "PlateLike",
                column: "PlateId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlateLike_plates_PlateId",
                table: "PlateLike",
                column: "PlateId",
                principalTable: "plates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpottLike_spotts_SpottId",
                table: "SpottLike",
                column: "SpottId",
                principalTable: "spotts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spotts_plates_PlateId",
                table: "spotts",
                column: "PlateId",
                principalTable: "plates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spotts_users_UserId",
                table: "spotts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlateLike_plates_PlateId",
                table: "PlateLike");

            migrationBuilder.DropForeignKey(
                name: "FK_SpottLike_spotts_SpottId",
                table: "SpottLike");

            migrationBuilder.DropForeignKey(
                name: "FK_spotts_plates_PlateId",
                table: "spotts");

            migrationBuilder.DropForeignKey(
                name: "FK_spotts_users_UserId",
                table: "spotts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_spotts",
                table: "spotts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpottLike",
                table: "SpottLike");

            migrationBuilder.DropIndex(
                name: "IX_SpottLike_SpottId",
                table: "SpottLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlateLike",
                table: "PlateLike");

            migrationBuilder.DropIndex(
                name: "IX_PlateLike_PlateId",
                table: "PlateLike");

            migrationBuilder.RenameTable(
                name: "spotts",
                newName: "Spotts");

            migrationBuilder.RenameTable(
                name: "SpottLike",
                newName: "spottLike");

            migrationBuilder.RenameTable(
                name: "PlateLike",
                newName: "plateLike");

            migrationBuilder.RenameIndex(
                name: "IX_spotts_UserId",
                table: "Spotts",
                newName: "IX_Spotts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_spotts_PlateId",
                table: "Spotts",
                newName: "IX_Spotts_PlateId");

            migrationBuilder.AddColumn<int>(
                name: "LikeRatio",
                table: "plates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Spotts",
                table: "Spotts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_spottLike",
                table: "spottLike",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_plateLike",
                table: "plateLike",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plateLike_plates_Id",
                table: "plateLike",
                column: "Id",
                principalTable: "plates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spottLike_Spotts_Id",
                table: "spottLike",
                column: "Id",
                principalTable: "Spotts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spotts_plates_PlateId",
                table: "Spotts",
                column: "PlateId",
                principalTable: "plates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spotts_users_UserId",
                table: "Spotts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
