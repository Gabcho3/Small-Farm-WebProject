using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFarm.Data.Migrations
{
    public partial class AddPhoneNumberMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("4105b2c2-05a4-4732-b274-ec5479001031"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("8f36be0a-d10b-4c6f-804b-e2d552389aa0"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("a38bde57-e37f-4540-be0e-ef3100909d2d"));

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("740c8311-e84c-4b4d-97a1-443de0f102bf"), "Sunny Valley Farms is a family-owned agricultural business located in the heart of Bulgaria's fertile countryside near Veliko Tarnovo. Specializing in organic fruit and vegetable production, we pride ourselves on delivering the freshest, highest-quality produce to local markets and restaurants. From juicy peaches to crisp cucumbers, our farm-fresh offerings are sure to delight your taste buds.", "info@sunnyvalleyfarms.bg", 1, "Sunny Valley Farms", "+359 62 123 456" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("a21c9bd0-5ab1-45ce-8129-2a95b0ab4b30"), "Golden Fields Honey is a beekeeping enterprise nestled in the sun-drenched valleys of Bulgaria's Rose Valley region. Our beekeepers lovingly tend to our hives, ensuring that our pure, raw honey captures the essence of Bulgaria's diverse floral landscapes. From fragrant acacia honey to robust wildflower varieties, each jar of Golden Fields Honey is a testament to nature's bounty and our dedication to artisanal craftsmanship.", "sales@goldenfieldshoney.bg", 3, "Golden Fields Honey", "+359 31 234 567" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("f9f061cc-2610-4853-b4c7-aecfb1abcc71"), "Balkan Dairy Co-op is a cooperative of small-scale dairy farmers located in the picturesque Rhodope Mountains of Bulgaria. Our passionate farmers work tirelessly to produce the finest organic dairy products, including creamy yogurt, artisanal cheeses, and rich, velvety milk. With a commitment to sustainability and animal welfare, we strive to provide wholesome, nutritious dairy products straight from our pastures to your table.", "info@balkandairycoop.com", 2, "Balkan Dairy Co-op", "+359 88 765 4321" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("740c8311-e84c-4b4d-97a1-443de0f102bf"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("a21c9bd0-5ab1-45ce-8129-2a95b0ab4b30"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("f9f061cc-2610-4853-b4c7-aecfb1abcc71"));

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("4105b2c2-05a4-4732-b274-ec5479001031"), "Golden Fields Honey is a beekeeping enterprise nestled in the sun-drenched valleys of Bulgaria's Rose Valley region. Our beekeepers lovingly tend to our hives, ensuring that our pure, raw honey captures the essence of Bulgaria's diverse floral landscapes. From fragrant acacia honey to robust wildflower varieties, each jar of Golden Fields Honey is a testament to nature's bounty and our dedication to artisanal craftsmanship.", "sales@goldenfieldshoney.bg", 3, "Golden Fields Honey", "+359 31 234 567" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("8f36be0a-d10b-4c6f-804b-e2d552389aa0"), "Sunny Valley Farms is a family-owned agricultural business located in the heart of Bulgaria's fertile countryside near Veliko Tarnovo. Specializing in organic fruit and vegetable production, we pride ourselves on delivering the freshest, highest-quality produce to local markets and restaurants. From juicy peaches to crisp cucumbers, our farm-fresh offerings are sure to delight your taste buds.", "info@sunnyvalleyfarms.bg", 1, "Sunny Valley Farms", "+359 62 123 456" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("a38bde57-e37f-4540-be0e-ef3100909d2d"), "Balkan Dairy Co-op is a cooperative of small-scale dairy farmers located in the picturesque Rhodope Mountains of Bulgaria. Our passionate farmers work tirelessly to produce the finest organic dairy products, including creamy yogurt, artisanal cheeses, and rich, velvety milk. With a commitment to sustainability and animal welfare, we strive to provide wholesome, nutritious dairy products straight from our pastures to your table.", "info@balkandairycoop.com", 2, "Balkan Dairy Co-op", "+359 88 765 4321" });
        }
    }
}
