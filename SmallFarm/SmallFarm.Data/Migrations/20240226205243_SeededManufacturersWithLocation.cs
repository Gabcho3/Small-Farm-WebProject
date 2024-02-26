using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallFarm.Data.Migrations
{
    public partial class SeededManufacturersWithLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("08c95909-3e2e-4f43-b482-cc6ab78c9a94"), "Balkan Dairy Co-op is a cooperative of small-scale dairy farmers located in the picturesque Rhodope Mountains of Bulgaria. Our passionate farmers work tirelessly to produce the finest organic dairy products, including creamy yogurt, artisanal cheeses, and rich, velvety milk. With a commitment to sustainability and animal welfare, we strive to provide wholesome, nutritious dairy products straight from our pastures to your table.", "info@balkandairycoop.com", 2, "Balkan Dairy Co-op", "+359 88 765 4321" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("6a5bd1e2-bed2-480b-8158-64a78b0476d0"), "Golden Fields Honey is a beekeeping enterprise nestled in the sun-drenched valleys of Bulgaria's Rose Valley region. Our beekeepers lovingly tend to our hives, ensuring that our pure, raw honey captures the essence of Bulgaria's diverse floral landscapes. From fragrant acacia honey to robust wildflower varieties, each jar of Golden Fields Honey is a testament to nature's bounty and our dedication to artisanal craftsmanship.", "sales@goldenfieldshoney.bg", 3, "Golden Fields Honey", "+359 31 234 567" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Description", "Email", "LocationId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("76861aac-065f-42a1-96fb-b903e1bfd5a2"), "Sunny Valley Farms is a family-owned agricultural business located in the heart of Bulgaria's fertile countryside near Veliko Tarnovo. Specializing in organic fruit and vegetable production, we pride ourselves on delivering the freshest, highest-quality produce to local markets and restaurants. From juicy peaches to crisp cucumbers, our farm-fresh offerings are sure to delight your taste buds.", "info@sunnyvalleyfarms.bg", 1, "Sunny Valley Farms", "+359 62 123 456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("08c95909-3e2e-4f43-b482-cc6ab78c9a94"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("6a5bd1e2-bed2-480b-8158-64a78b0476d0"));

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: new Guid("76861aac-065f-42a1-96fb-b903e1bfd5a2"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
