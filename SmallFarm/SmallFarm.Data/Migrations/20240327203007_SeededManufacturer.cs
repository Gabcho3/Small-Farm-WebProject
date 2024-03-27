using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFarm.Data.Migrations
{
    public partial class SeededManufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "61a89e69-2df8-4b08-ab49-2f3d98a8516f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0d921142-95b0-4fdc-920b-ed1c6558adf2", 0, "47f8f12b-1ebe-4aaf-9c82-c5835456570f", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEG7oK8XFme1gIbjGRHhhhg7y+7ugThnxSm7gLllQIpN5ocuN1TTQblZtqRDfS9LACA==", null, false, "86a4ab15-b6f2-4ebb-97f8-697fd43acb26", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7172a5b3-34c7-4af5-9c2b-6da17a0ed8c7", 0, "b0982764-be8d-4e45-a255-32c3de3c2040", "manu@gmail.com", false, false, null, "MANU@GMAIL.COM", "MANU@GMAIL.COM", "AQAAAAEAACcQAAAAELMZmg4rVjwzoA5qil7n7QrkSUjjcT1ocmTPRuh+GbGrG/9X0esWsLOvqdVX3LQvlg==", null, false, "eec97c48-db74-4ef3-82d3-dfc957ab9839", false, "manu@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d921142-95b0-4fdc-920b-ed1c6558adf2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7172a5b3-34c7-4af5-9c2b-6da17a0ed8c7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "61a89e69-2df8-4b08-ab49-2f3d98a8516f", 0, "e906b546-304f-4f44-b2f8-8af62eda6961", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEHKOa/W8txhIM3LNKkes0SY3gtwmIM0MV8lb5aIXowZvuNM1Ea8e+e9jvlgROK6THg==", null, false, "19fb2ad3-1b42-4fb4-aebd-5b87878ea46f", false, "admin@gmail.com" });
        }
    }
}
