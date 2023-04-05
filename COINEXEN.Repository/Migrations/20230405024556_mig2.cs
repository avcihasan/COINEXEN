using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COINEXEN.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CoinWallets_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "CoinWallets");

            migrationBuilder.DropColumn(
                name: "CoinWalletId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinWallets_AspNetUsers_Id",
                table: "CoinWallets",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinWallets_AspNetUsers_Id",
                table: "CoinWallets");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "CoinWallets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoinWalletId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CoinWallets_Id",
                table: "AspNetUsers",
                column: "Id",
                principalTable: "CoinWallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
