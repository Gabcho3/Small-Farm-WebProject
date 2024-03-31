using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFarm.Data.Migrations
{
    public partial class ChangedCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa68eea0-7afb-4a2d-8808-023de951e23b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f61b7997-5b5b-4b60-89f2-eba32d1a3d29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4cc36df-8fdc-4474-92bf-59d3d8df3c48", "AQAAAAEAACcQAAAAECf1qTNhtYlIxXbJJ+Qz4SCZnJoa2P5/EaYiRNiFwZfaaczl6vDMI7pXt/H0TxvOFw==", "98d2e41b-0f3b-4b01-943b-a8fcbef92b38" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "85c1b7b3-2415-4cad-aeb3-c50a3481d2a8", 0, "ee21965a-0e82-4c77-889d-26699134adc8", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENtTc100SS9A0DZzcqeriTVLYVh/oCL7++fPBAUy5QXmVcG45LXvV44uLUyetFUmwg==", null, false, "ed92e353-df39-4012-b314-b5fee48e6b5d", false, "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Drink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85c1b7b3-2415-4cad-aeb3-c50a3481d2a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f61b7997-5b5b-4b60-89f2-eba32d1a3d29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35044c87-ded7-4f01-8421-b0f4ea12ba2f", "AQAAAAEAACcQAAAAEN6eKw3l3s0lzHI7yiedRdsjSqJ1JnQCEP93+IvX+lYtCw7UeNHYGO+lQIq0hSiNXg==", "d5637196-b31f-40b1-901c-2e72b650608f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa68eea0-7afb-4a2d-8808-023de951e23b", 0, "a1d48099-2d1c-459b-9449-55424d7586e7", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGenVNoRj6tve6nuK+ZJkLO6uch736VCaEjoFefbc9NRa9Iifa8nk3Dok2PMHZ3Wcg==", null, false, "bd8a1e6d-c64b-4717-848c-c46fe36541d7", false, "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Drinks");
        }
    }
}
