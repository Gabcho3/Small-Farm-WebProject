using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFarm.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ManufacturerDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ManufacturerPhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ManufacturerAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    PricePerKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.ClientId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsOrders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrders", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "48ed0d70-f2d3-4261-98d4-7a4e7d0fa917", 0, "08a1db5c-1380-4bcd-ba42-6a67f38db648", "example@gmail.com", false, "Ivan", "Ivanov", false, null, "EXAMPLE@GMAIL.COM", "EXAMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAEAA9j0XmLdi4Xz7IAzI9pbkR3xkqzId5+zPiqB+5Pj/xEkiK0ABUnnKLCMPKxd0/HQ==", null, false, "1ef9725b-e276-4db4-b35f-91f2742030a5", false, "example@gmail.com" },
                    { "6593342c-52a9-46a7-879d-54e992c2913d", 0, "9d3a90ec-91c1-497a-94c3-c62f471fafe8", "guest@gmail.com", false, "Todor", "Ivanov", false, null, "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAEAACcQAAAAELzfwXOYHff3XXBSS7qP3Zro80/TZd/ZcvRJuC+KeEBRbswQTlAMjQEoGaDx0dyIcQ==", null, false, "24be890f-2b8a-480e-931c-f6cac3f51991", false, "guest@gmail.com" },
                    { "cdbec9af-bc74-46c3-9547-a83e4bc8691e", 0, "28abfbfd-75c2-4a90-8251-cdafa8a41f18", "admin@gmail.com", false, "Gabriel", "Dimitrov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEKJTdrfoqMuwQe7F2akagXsufIbGPQvBL6Dc2QiwDEN0oLgiJ5bbflIKfY5XCzK1/w==", null, false, "54629c1f-10f8-4fd7-b685-cef002d32c7a", false, "admin@gmail.com" },
                    { "f61b7997-5b5b-4b60-89f2-eba32d1a3d29", 0, "dd711f71-9e22-470f-9e4c-f45e0837ac66", "manu@gmail.com", false, "Ivan", "Dragiev", false, null, "MANU@GMAIL.COM", "MANU@GMAIL.COM", "AQAAAAEAACcQAAAAEDRUiUnzJIjXto+VZDYNqsueRZxqOKMkKgdUhiafFUC+S4F0CPCkAZfNB3obs2d1Lw==", null, false, "d701790c-e545-41f5-95e3-ba7b7e30ee6e", false, "manu@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Alfatar" },
                    { 2, "Antonovo" },
                    { 3, "Apriltsi" },
                    { 4, "Aytos" },
                    { 5, "Batak" },
                    { 6, "Belene" },
                    { 7, "Belitsa" },
                    { 8, "Belogradchik" },
                    { 9, "Beloslav" },
                    { 10, "Berkovitsa" },
                    { 11, "Blagoevgrad" },
                    { 12, "Bobov Dol" },
                    { 13, "Botevgrad" },
                    { 14, "Bozhurishte" },
                    { 15, "Bregovo" },
                    { 16, "Breznik" },
                    { 17, "Brusartsi" },
                    { 18, "Burgas" },
                    { 19, "Byala Slatina" },
                    { 20, "Chernomorets" },
                    { 21, "Cherven Bryag" },
                    { 22, "Chirpan" },
                    { 23, "Dalgopol" },
                    { 24, "Devin" },
                    { 25, "Dimitrovgrad" },
                    { 26, "Dobrich" },
                    { 27, "Dolni Chiflik" },
                    { 28, "Dospat" },
                    { 29, "Dryanovo" },
                    { 30, "Dulovo" },
                    { 31, "Dupnitsa" },
                    { 32, "Dve Mogili" },
                    { 33, "Elena" },
                    { 34, "Elhovo" },
                    { 35, "Elin Pelin" },
                    { 36, "Etropole" },
                    { 37, "Gabrovo" },
                    { 38, "General Toshevo" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 39, "Glavinitsa" },
                    { 40, "Gorna Oryahovitsa" },
                    { 41, "Gotse Delchev" },
                    { 42, "Gramada" },
                    { 43, "Gulubovo" },
                    { 44, "Gulyantsi" },
                    { 45, "Gurkovo" },
                    { 46, "Harmanli" },
                    { 47, "Haskovo" },
                    { 48, "Isperih" },
                    { 49, "Ivaylovgrad" },
                    { 50, "Kableshkovo" },
                    { 51, "Kalofer" },
                    { 52, "Kardzhali" },
                    { 53, "Karnobat" },
                    { 54, "Kavarna" },
                    { 55, "Kazanlak" },
                    { 56, "Kirkovo" },
                    { 57, "Knezha" },
                    { 58, "Kostenets" },
                    { 59, "Kozloduy" },
                    { 60, "Kuklen" },
                    { 61, "Kurdzhali" },
                    { 62, "Kyustendil" },
                    { 63, "Laki" },
                    { 64, "Letnitsa" },
                    { 65, "Levski" },
                    { 66, "Lovech" },
                    { 67, "Loznitsa" },
                    { 68, "Madan" },
                    { 69, "Madzharovo" },
                    { 70, "Malko Tarnovo" },
                    { 71, "Merichleri" },
                    { 72, "Mizia" },
                    { 73, "Momchilgrad" },
                    { 74, "Montana" },
                    { 75, "Nessebar" },
                    { 76, "Nikolaevo" },
                    { 77, "Nikopol" },
                    { 78, "Nova Zagora" },
                    { 79, "Omurtag" },
                    { 80, "Opaka" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 81, "Panagyurishte" },
                    { 82, "Parvomay" },
                    { 83, "Pavel Banya" },
                    { 84, "Pazardzhik" },
                    { 85, "Pernik" },
                    { 86, "Petrich" },
                    { 87, "Pirdop" },
                    { 88, "Pleven" },
                    { 89, "Plovdiv" },
                    { 90, "Pomorie" },
                    { 91, "Popovo" },
                    { 92, "Radnevo" },
                    { 93, "Radomir" },
                    { 94, "Rakitovo" },
                    { 95, "Razgrad" },
                    { 96, "Rila" },
                    { 97, "Roman" },
                    { 98, "Rudozem" },
                    { 99, "Ruse" },
                    { 100, "Samokov" },
                    { 101, "Sandanski" },
                    { 102, "Sarnitsa" },
                    { 103, "Satovcha" },
                    { 104, "Septemvri" },
                    { 105, "Sevlievo" },
                    { 106, "Shumen" },
                    { 107, "Silistra" },
                    { 108, "Simeonovgrad" },
                    { 109, "Slavyanovo" },
                    { 110, "Sliven" },
                    { 111, "Smyadovo" },
                    { 112, "Sofia" },
                    { 113, "Sopot" },
                    { 114, "Stamboliyski" },
                    { 115, "Stara Zagora" },
                    { 116, "Straldzha" },
                    { 117, "Strazhitsa" },
                    { 118, "Strumyani" },
                    { 119, "Sungurlare" },
                    { 120, "Suvorovo" },
                    { 121, "Sveti Vlas" },
                    { 122, "Svilengrad" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 123, "Svishtov" },
                    { 124, "Targovishte" },
                    { 125, "Tervel" },
                    { 126, "Teteven" },
                    { 127, "Topolovgrad" },
                    { 128, "Tran" },
                    { 129, "Troyan" },
                    { 130, "Tsarevo" },
                    { 131, "Tutrakan" },
                    { 132, "Tvarditsa" },
                    { 133, "Ugarchin" },
                    { 134, "Valchedram" },
                    { 135, "Varbitsa" },
                    { 136, "Varna" },
                    { 137, "Varshets" },
                    { 138, "Veliko Tarnovo" },
                    { 139, "Vetovo" },
                    { 140, "Vidin" },
                    { 141, "Vratsa" },
                    { 142, "Yambol" },
                    { 143, "Zavet" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vegetable" },
                    { 2, "Fruit" },
                    { 3, "Drink" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Address", "CityId", "Description", "Email", "Name", "PhoneNumber" },
                values: new object[] { new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "bul. Todor Kableshkov", 1, "We are one of the best on the market!", "manu@gmail.com", "BestProducts OOD", "+359885118198" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsActive", "ManufacturerId", "Name", "PricePerKg", "Quantity" },
                values: new object[,]
                {
                    { new Guid("58495409-61b9-4e64-b42d-4050880fe54f"), 2, "Very delicious western bulgarian bananas!", "https://images.unsplash.com/photo-1603833665858-e61d17a86224?q=80&w=1854&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Bananas", 3.10m, 20.0 },
                    { new Guid("685f6f08-eff3-477d-924e-6534f89da30e"), 1, "Very delicious western bulgarian tomatoes!", "https://images.unsplash.com/photo-1582284540020-8acbe03f4924?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Big red tomatoes", 3.30m, 9.0 },
                    { new Guid("6ac83a45-52d9-43d5-82b3-ca89cb209545"), 2, "Very delicious western bulgarian apples!", "https://images.unsplash.com/photo-1576179635662-9d1983e97e1e?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Red Apples", 3.90m, 10.0 },
                    { new Guid("8740e8b4-82e9-4e42-b024-4252a391ed31"), 1, "Very delicious western bulgarian potatoes!", "https://images.unsplash.com/photo-1590165482129-1b8b27698780?q=80&w=1854&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Small Potatoes", 5.20m, 12.0 },
                    { new Guid("dc93fef4-d080-4772-a73c-314d56382716"), 1, "Very delicious western bulgarian cucumbers!", "https://images.unsplash.com/photo-1449300079323-02e209d9d3a6?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Cucumbers", 1.90m, 7.0 },
                    { new Guid("f104d36e-d953-43f9-8623-b40103e8cc2f"), 3, "Milk form domestic cow!", "https://images.unsplash.com/photo-1601436423474-51738541c1b1?q=80&w=1854&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Cow milk", 1.60m, 25.0 }
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
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_CityId",
                table: "Manufacturers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_ProductId",
                table: "ProductsOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CityId",
                table: "Requests",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");
        }

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
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductsOrders");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
