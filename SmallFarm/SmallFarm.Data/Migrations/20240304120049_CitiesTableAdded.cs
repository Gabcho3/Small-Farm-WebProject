using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFarm.Data.Migrations
{
    public partial class CitiesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Locations_LocationId",
                table: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("12bc5798-63a1-4216-8fe2-d32bcc9fe834"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("a82078ce-1ebc-42d3-9940-a628393c1523"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("de1644d8-1d5c-4763-8d7b-a62c38f93255"));

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Manufacturers",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturers_LocationId",
                table: "Manufacturers",
                newName: "IX_Manufacturers_CityId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Manufacturers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Manufacturers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Cities_CityId",
                table: "Manufacturers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Cities_CityId",
                table: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Manufacturers");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Manufacturers",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Manufacturers_CityId",
                table: "Manufacturers",
                newName: "IX_Manufacturers_LocationId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Manufacturers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City" },
                values: new object[] { 1, "123 Sunny Street", "Veliko Tarnovo" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City" },
                values: new object[] { 2, "456 Dairy Lane", "Rhodope Mountains" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "City" },
                values: new object[] { 3, "789 Honey Farm Road", "Rose Valley" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("12bc5798-63a1-4216-8fe2-d32bcc9fe834"), "Balkan Dairy Co-op is a cooperative of small-scale dairy farmers located in the picturesque Rhodope Mountains of Bulgaria. Our passionate farmers work tirelessly to produce the finest organic dairy products, including creamy yogurt, artisanal cheeses, and rich, velvety milk. With a commitment to sustainability and animal welfare, we strive to provide wholesome, nutritious dairy products straight from our pastures to your table.", "info@balkandairycoop.com", 2, "Balkan Dairy Co-op", "+359 88 765 4321" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("a82078ce-1ebc-42d3-9940-a628393c1523"), "Sunny Valley Farms is a family-owned agricultural business located in the heart of Bulgaria's fertile countryside near Veliko Tarnovo. Specializing in organic fruit and vegetable production, we pride ourselves on delivering the freshest, highest-quality produce to local markets and restaurants. From juicy peaches to crisp cucumbers, our farm-fresh offerings are sure to delight your taste buds.", "info@sunnyvalleyfarms.bg", 1, "Sunny Valley Farms", "+359 62 123 456" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("de1644d8-1d5c-4763-8d7b-a62c38f93255"), "Golden Fields Honey is a beekeeping enterprise nestled in the sun-drenched valleys of Bulgaria's Rose Valley region. Our beekeepers lovingly tend to our hives, ensuring that our pure, raw honey captures the essence of Bulgaria's diverse floral landscapes. From fragrant acacia honey to robust wildflower varieties, each jar of Golden Fields Honey is a testament to nature's bounty and our dedication to artisanal craftsmanship.", "sales@goldenfieldshoney.bg", 3, "Golden Fields Honey", "+359 31 234 567" });

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Locations_LocationId",
                table: "Manufacturers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
