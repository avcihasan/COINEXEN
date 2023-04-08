using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COINEXEN.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellCoins_AspNetUsers_AppUserId1",
                table: "SellCoins");

            migrationBuilder.DropIndex(
                name: "IX_SellCoins_AppUserId1",
                table: "SellCoins");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "SellCoins");

            migrationBuilder.RenameColumn(
                name: "KısaKod",
                table: "Coins",
                newName: "ShortName");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "SellCoins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellCoins_AppUserId",
                table: "SellCoins",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellCoins_AspNetUsers_AppUserId",
                table: "SellCoins",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellCoins_AspNetUsers_AppUserId",
                table: "SellCoins");

            migrationBuilder.DropIndex(
                name: "IX_SellCoins_AppUserId",
                table: "SellCoins");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Coins",
                newName: "KısaKod");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "SellCoins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId1",
                table: "SellCoins",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellCoins_AppUserId1",
                table: "SellCoins",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SellCoins_AspNetUsers_AppUserId1",
                table: "SellCoins",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
