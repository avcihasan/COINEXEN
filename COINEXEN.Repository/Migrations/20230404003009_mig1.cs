using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace COINEXEN.Repository.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoinWalletId = table.Column<int>(type: "int", nullable: false),
                    UserWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicTitle = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoinWallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinWallets_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWallets_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KısaKod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coins_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId1 = table.Column<int>(type: "int", nullable: true),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Baskets_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyCoins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CoinPrice = table.Column<double>(type: "float", nullable: false),
                    DateOfBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_BuyCoins_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoinWalletLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CoinWalletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinWalletLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinWalletLines_CoinWallets_CoinWalletId",
                        column: x => x.CoinWalletId,
                        principalTable: "CoinWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoinWalletLines_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellCoins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CoinPrice = table.Column<double>(type: "float", nullable: false),
                    DateOfSell = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellCoins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellCoins_AspNetUsers_AppUserId1",
                        column: x => x.AppUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SellCoins_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "1494a227-b5f3-479a-a240-e6654ac10a2b", "admin", null },
                    { 2, "ccc93892-9f7e-41c6-8597-0eb32110fc05", "user", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "City", "CoinWalletId", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "UserWalletId" },
                values: new object[,]
                {
                    { 1, 0, "11/07/1999", 33, 0, "2e9091ec-a367-43c3-87c1-882b4e86a7a4", "hsnavci7@gmail.com", false, 0, false, null, "Hasan", null, null, "AQAAAAEAACcQAAAAEGjk8fuzISEoF0KXJU7NUm9M1zTBQNNs0QuenujkfkFiK3UGdO+W00hgxZGHhjA35w==", "5380614193", false, null, "Avcı", false, "hasanavci", null },
                    { 2, 0, "11/07/1999", 33, 0, "563300e8-dda4-4c79-a4ad-e7870be7767e", "hsnavci7@gmail.com", false, 0, false, null, "Hasan1", null, null, "AQAAAAEAACcQAAAAENLi8jcuMeLNw6aAPMhW0V/cEUcrcRKYYA1Es740INh5P6deJ0DdlNk9/wukey/TQg==", "5380614193", false, null, "Avcı", false, "hasanavci1", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Sanat" },
                    { 2, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Spor" },
                    { 3, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Teknoloji" },
                    { 4, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Bilim" },
                    { 5, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Ticaret" },
                    { 6, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Müzik" },
                    { 7, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Seyehat" }
                });

            migrationBuilder.InsertData(
                table: "Coins",
                columns: new[] { "Id", "CategoryId", "Description", "KısaKod", "Name", "PhotoPath", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "A", "Acoin", null, 1.2, 10000000 },
                    { 2, 2, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "B", "Bcoin", null, 1.8999999999999999, 10000000 },
                    { 3, 3, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "C", "Ccoin", null, 2.3999999999999999, 10000000 },
                    { 4, 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "D", "Dcoin", null, 5.4000000000000004, 10000000 },
                    { 5, 5, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "E", "Ecoin", null, 15.4, 10000000 },
                    { 6, 6, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "F", "Fcoin", null, 6.4000000000000004, 10000000 },
                    { 7, 2, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "G", "Gcoin", null, 1.4299999999999999, 10000000 },
                    { 8, 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "H", "Hcoin", null, 1.55, 10000000 },
                    { 9, 6, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "I", "Icoin", null, 1.98, 10000000 },
                    { 10, 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "J", "Jcoin", null, 11.24, 10000000 },
                    { 11, 2, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "K", "Kcoin", null, 1.24, 10000000 },
                    { 12, 5, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "L", "Lcoin", null, 12.4, 10000000 },
                    { 13, 5, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "M", "Mcoin", null, 31.399999999999999, 10000000 },
                    { 14, 2, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "N", "Ncoin", null, 16.399999999999999, 10000000 },
                    { 15, 3, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "O", "Ocoin", null, 1.9399999999999999, 10000000 },
                    { 16, 3, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "P", "Pcoin", null, 1.49, 10000000 },
                    { 17, 4, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "R", "Rcoin", null, 1.3999999999999999, 10000000 },
                    { 18, 3, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "S", "Scoin", null, 31.399999999999999, 10000000 },
                    { 19, 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "T", "Tcoin", null, 13.43, 10000000 },
                    { 20, 1, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "U", "Ucoin", null, 15.4, 10000000 },
                    { 21, 6, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "V", "Vcoin", null, 1.4399999999999999, 10000000 },
                    { 22, 5, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Y", "Ycoin", null, 1.3999999999999999, 10000000 },
                    { 23, 4, "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae voluptate fugiat dolore. Eos deleniti iste rerum doloremque veniam, autem culpa est laborum reiciendis placeat. Cum, ullam! Quo perferendis a nemo molestiae vitae ipsum tempore corrupti nihil magnam, dignissimos officiis, enim similique. Autem laborum cupiditate repudiandae sint ipsa voluptas iusto praesentium??", "Z", "Zcoin", null, 1.3999999999999999, 10000000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_AppUserId1",
                table: "Baskets",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CoinId",
                table: "Baskets",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyCoins_AppUserId1",
                table: "BuyCoins",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BuyCoins_CoinId",
                table: "BuyCoins",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Coins_CategoryId",
                table: "Coins",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinWalletLines_CoinId",
                table: "CoinWalletLines",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_CoinWalletLines_CoinWalletId",
                table: "CoinWalletLines",
                column: "CoinWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_SellCoins_AppUserId1",
                table: "SellCoins",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SellCoins_CoinId",
                table: "SellCoins",
                column: "CoinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "BuyCoins");

            migrationBuilder.DropTable(
                name: "CoinWalletLines");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "SellCoins");

            migrationBuilder.DropTable(
                name: "UserWallets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CoinWallets");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
