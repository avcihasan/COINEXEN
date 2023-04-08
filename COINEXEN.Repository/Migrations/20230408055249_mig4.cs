using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COINEXEN.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyCoins");

            migrationBuilder.DropTable(
                name: "SellCoins");

            migrationBuilder.CreateTable(
                name: "CoinTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Transaction = table.Column<int>(type: "int", nullable: false),
                    CoinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CoinPrice = table.Column<double>(type: "float", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinTransactions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinTransactions_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinTransactions_AppUserId",
                table: "CoinTransactions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinTransactions_CoinId",
                table: "CoinTransactions",
                column: "CoinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinTransactions");

            migrationBuilder.CreateTable(
                name: "BuyCoins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoinId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    CoinPrice = table.Column<double>(type: "float", nullable: false),
                    DateOfBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyCoins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyCoins_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuyCoins_Coins_CoinId1",
                        column: x => x.CoinId1,
                        principalTable: "Coins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SellCoins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoinPrice = table.Column<double>(type: "float", nullable: false),
                    DateOfSell = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellCoins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellCoins_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellCoins_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyCoins_AppUserId1",
                table: "BuyCoins",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BuyCoins_CoinId1",
                table: "BuyCoins",
                column: "CoinId1");

            migrationBuilder.CreateIndex(
                name: "IX_SellCoins_AppUserId",
                table: "SellCoins",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SellCoins_CoinId",
                table: "SellCoins",
                column: "CoinId");
        }
    }
}
