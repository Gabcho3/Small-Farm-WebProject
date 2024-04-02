using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFarm.Data.Migrations
{
    public partial class CityAddedToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c0f6178-0503-4eeb-9e4b-0374ad277df3");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f61b7997-5b5b-4b60-89f2-eba32d1a3d29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8ea71e7-094e-4bb0-a098-881f209a698e", "AQAAAAEAACcQAAAAEIa7wsxejurRf672npPahqr9KQ+Vtcj0fqzSjnOLfoLGv+i2R/Q/XERkdfE7bae+6w==", "cdf45d5a-4af0-4e03-8459-12636a7c9165" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e937f5f-46eb-484c-bb65-cbb6aee9ea5b", 0, "cb1246b5-7a68-43a4-b578-e7f4ed8335b0", "admin@gmail.com", false, "Gabriel", "Dimitrov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBqM31lCZNHCHUat/hO6jpRPU4NPtVLk9086DAEUt3huFGf2gzUnxZKyE9yHorhaQA==", null, false, "62ced376-c7bf-443b-ab92-a4f75da08001", false, "admin@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CityId",
                table: "Requests",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Cities_CityId",
                table: "Requests",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Cities_CityId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CityId",
                table: "Requests");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e937f5f-46eb-484c-bb65-cbb6aee9ea5b");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f61b7997-5b5b-4b60-89f2-eba32d1a3d29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2da2d8c-ae40-429f-9304-92aa2c78c1d5", "AQAAAAEAACcQAAAAEM4okSB/uenoG+t7kMiSbEOCKTD+xKG8gaMSUSZkuQsvHWpfQjGBGryHvkIfSyipcQ==", "f2c0e0a8-33d4-4314-8efa-c512c7cd2378" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c0f6178-0503-4eeb-9e4b-0374ad277df3", 0, "b1017a05-4a41-4282-a5e7-98676a9f934c", "admin@gmail.com", false, "Gabriel", "Dimitrov", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEOAe9LzrbAOWHHUXmWx5t3aajb93+LRazSeLIS7zpaQEmye3Tq/9qPp7TMFYc1sdtA==", null, false, "408f28b2-8673-4c68-b3ca-c6e7bb2458ce", false, "admin@gmail.com" });
        }
    }
}
