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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Orders_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "43bd9ac8-bf3c-4270-8948-0a18d04e4d87", 0, "19efff25-e6f1-468f-b466-d0b7fb4fa451", "example@gmail.com", false, "Ivan", "Ivanov", false, null, "EXAMPLE@GMAIL.COM", "EXAMPLE@GMAIL.COM", "AQAAAAEAACcQAAAAECqvPLaPWtBQdQr6+Fg68OCkI+jktqEL86bPzN3fXmiYx2zQ+k+HBobyuQWtXr044w==", "08888888888", false, "11fccb05-e063-4806-847a-45945a9d4f31", false, "example@gmail.com" },
                    { "8fed1b6a-57b4-40f0-95cb-ae6b8501043d", 0, "1af142ad-c639-428f-b124-20e3567325d6", "guest@gmail.com", false, "Todor", "Ivanov", false, null, "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAEAACcQAAAAEAb7aqbTul9Ah68CKtFoJQdKP5LnRXTAReigODws4pWhmBV0c++yIECbNIFKdllrjQ==", "08888888888", false, "52c6ea85-9ed4-4058-a0d2-d61831b7eb1c", false, "guest@gmail.com" },
                    { "d924af54-ac3f-4ef6-87a6-6a7894e1c0a0", 0, "0ad78ec0-5351-490c-b461-fd7f10e3a16e", "admin@gmail.com", false, "Gabriel", "Dimitrov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJqN/kk31BfrIkGHHb0wZT1M+QDZz/iR1Bj2llBnaOC7cf2/z42SJ7CQpWhYt6RcTA==", "08888888888", false, "79236981-f668-4bf0-932c-cf2b4190dc55", false, "admin@gmail.com" },
                    { "f61b7997-5b5b-4b60-89f2-eba32d1a3d29", 0, "81893276-d4ea-4651-97de-d0499953acdf", "manu@gmail.com", false, "Ivan", "Dragiev", false, null, "MANU@GMAIL.COM", "MANU@GMAIL.COM", "AQAAAAEAACcQAAAAEPLfpFxAGSjy+/Zo77a6Fc0/CfKt2FYfz0QTKBxC5N2P7UerimCse8UD8G3mbjTUDg==", "08888888888", false, "50f2e037-84d7-4304-b158-391869b180cc", false, "manu@gmail.com" }
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
                    { new Guid("3aa05743-af2d-4669-a121-d0d25908a500"), 3, "Milk from domestic cow!", "https://cdn.pixabay.com/photo/2016/05/07/16/09/milk-1377564_1280.jpg", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Cow milk", 1.60m, 25.0 },
                    { new Guid("4235e003-a1be-4df6-b624-dd1a5a1817d2"), 1, "Enjoy crisp cucumbers, harvested fresh and delivered conveniently to you!", "https://cdn.pixabay.com/photo/2015/07/17/13/44/cucumbers-849269_1280.jpg", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Cucumbers", 1.90m, 7.0 },
                    { new Guid("512527e8-ad79-431b-99dd-b400d7284ab0"), 1, "Very delicious western bulgarian potatoes!", "https://cdn.pixabay.com/photo/2014/08/06/20/32/potatoes-411975_1280.jpg", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Small Potatoes", 5.20m, 12.0 },
                    { new Guid("6ca65456-4e64-4fdd-8f75-fb210c1fe00f"), 2, "Fresh, handpicked red apples delivered straight to your doorstep!", "https://cdn.pixabay.com/photo/2016/08/12/22/38/apple-1589874_1280.jpg", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Red Apples", 3.90m, 10.0 },
                    { new Guid("7f2e25cf-1604-4950-9664-2bd5924ba3de"), 1, "Very delicious western bulgarian tomatoes!", "https://cdn.pixabay.com/photo/2022/09/05/09/50/tomatoes-7433786_1280.jpg", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Red Tomatoes", 3.30m, 9.0 },
                    { new Guid("fd1143a0-23ac-4fa8-bc02-f66bd82362d1"), 2, "Premium bananas, handpicked for freshness, delivered to your doorstep!", "https://cdn.pixabay.com/photo/2016/09/03/20/48/bananas-1642706_1280.jpg", true, new Guid("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"), "Bananas", 3.10m, 20.0 }
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
                name: "IX_Orders_ManufacturerId",
                table: "Orders",
                column: "ManufacturerId");

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
