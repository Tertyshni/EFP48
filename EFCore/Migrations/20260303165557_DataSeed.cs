using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFP48.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "my_categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0d5d102d-e7b0-4a2e-a4fa-076deb014547"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Mice" },
                    { new Guid("34c0032d-9a67-40a8-b6c4-8c0d15b23650"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Computers" },
                    { new Guid("4af1ce03-b37c-40a5-8462-28494820f53f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Monitors" },
                    { new Guid("561ac3ea-6374-4b26-b422-4c619bdc26fa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Smartphones" },
                    { new Guid("6c179026-9a44-4eca-b75a-811ebb8a577a"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Keyboards" },
                    { new Guid("89bd4978-0429-4913-8c74-843f24e35cb6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Laptops" },
                    { new Guid("8e1b8de7-421b-4020-ac41-3e96b01ba8d3"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "TV-sets" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-4aaa-8aaa-111111111111"), new Guid("561ac3ea-6374-4b26-b422-4c619bdc26fa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "iPhone 15", 999.99000000000001 },
                    { new Guid("a1111111-1111-4aaa-8aaa-111111111112"), new Guid("561ac3ea-6374-4b26-b422-4c619bdc26fa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Samsung Galaxy S24", 899.99000000000001 },
                    { new Guid("a1111111-1111-4aaa-8aaa-111111111113"), new Guid("561ac3ea-6374-4b26-b422-4c619bdc26fa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Google Pixel 8", 799.99000000000001 },
                    { new Guid("a1111111-1111-4aaa-8aaa-111111111114"), new Guid("561ac3ea-6374-4b26-b422-4c619bdc26fa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Xiaomi 14", 699.99000000000001 },
                    { new Guid("a1111111-1111-4aaa-8aaa-111111111115"), new Guid("561ac3ea-6374-4b26-b422-4c619bdc26fa"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "OnePlus 12", 749.99000000000001 },
                    { new Guid("b2222222-2222-4bbb-8bbb-222222222221"), new Guid("34c0032d-9a67-40a8-b6c4-8c0d15b23650"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Dell OptiPlex 7010", 1200.0 },
                    { new Guid("b2222222-2222-4bbb-8bbb-222222222222"), new Guid("34c0032d-9a67-40a8-b6c4-8c0d15b23650"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "HP Pavilion Desktop", 950.0 },
                    { new Guid("b2222222-2222-4bbb-8bbb-222222222223"), new Guid("34c0032d-9a67-40a8-b6c4-8c0d15b23650"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lenovo ThinkCentre", 1100.0 },
                    { new Guid("b2222222-2222-4bbb-8bbb-222222222224"), new Guid("34c0032d-9a67-40a8-b6c4-8c0d15b23650"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "iMac 24", 1800.0 },
                    { new Guid("b2222222-2222-4bbb-8bbb-222222222225"), new Guid("34c0032d-9a67-40a8-b6c4-8c0d15b23650"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Asus ExpertCenter", 1050.0 },
                    { new Guid("c3333333-3333-4ccc-8ccc-333333333331"), new Guid("89bd4978-0429-4913-8c74-843f24e35cb6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "MacBook Air M3", 1500.0 },
                    { new Guid("c3333333-3333-4ccc-8ccc-333333333332"), new Guid("89bd4978-0429-4913-8c74-843f24e35cb6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Dell XPS 15", 1700.0 },
                    { new Guid("c3333333-3333-4ccc-8ccc-333333333333"), new Guid("89bd4978-0429-4913-8c74-843f24e35cb6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "HP Spectre x360", 1600.0 },
                    { new Guid("c3333333-3333-4ccc-8ccc-333333333334"), new Guid("89bd4978-0429-4913-8c74-843f24e35cb6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lenovo Legion 5", 1400.0 },
                    { new Guid("c3333333-3333-4ccc-8ccc-333333333335"), new Guid("89bd4978-0429-4913-8c74-843f24e35cb6"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Asus ROG Zephyrus", 1900.0 },
                    { new Guid("d4444444-4444-4ddd-8ddd-444444444441"), new Guid("8e1b8de7-421b-4020-ac41-3e96b01ba8d3"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Samsung QLED 55", 1300.0 },
                    { new Guid("d4444444-4444-4ddd-8ddd-444444444442"), new Guid("8e1b8de7-421b-4020-ac41-3e96b01ba8d3"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "LG OLED C3", 2100.0 },
                    { new Guid("d4444444-4444-4ddd-8ddd-444444444443"), new Guid("8e1b8de7-421b-4020-ac41-3e96b01ba8d3"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sony Bravia XR", 2000.0 },
                    { new Guid("d4444444-4444-4ddd-8ddd-444444444444"), new Guid("8e1b8de7-421b-4020-ac41-3e96b01ba8d3"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Philips Ambilight 65", 1700.0 },
                    { new Guid("d4444444-4444-4ddd-8ddd-444444444445"), new Guid("8e1b8de7-421b-4020-ac41-3e96b01ba8d3"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "TCL 4K UHD", 900.0 },
                    { new Guid("e5555555-5555-4eee-8eee-555555555551"), new Guid("4af1ce03-b37c-40a5-8462-28494820f53f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Dell UltraSharp 27", 600.0 },
                    { new Guid("e5555555-5555-4eee-8eee-555555555552"), new Guid("4af1ce03-b37c-40a5-8462-28494820f53f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "LG UltraGear 32", 750.0 },
                    { new Guid("e5555555-5555-4eee-8eee-555555555553"), new Guid("4af1ce03-b37c-40a5-8462-28494820f53f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Samsung Odyssey G7", 800.0 },
                    { new Guid("e5555555-5555-4eee-8eee-555555555554"), new Guid("4af1ce03-b37c-40a5-8462-28494820f53f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Asus ProArt Display", 950.0 },
                    { new Guid("e5555555-5555-4eee-8eee-555555555555"), new Guid("4af1ce03-b37c-40a5-8462-28494820f53f"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Acer Predator XB", 850.0 },
                    { new Guid("e7777777-7777-4aaa-8aaa-777777777771"), new Guid("6c179026-9a44-4eca-b75a-811ebb8a577a"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Logitech MX Keys", 130.0 },
                    { new Guid("e7777777-7777-4aaa-8aaa-777777777772"), new Guid("6c179026-9a44-4eca-b75a-811ebb8a577a"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Razer BlackWidow V4", 180.0 },
                    { new Guid("e7777777-7777-4aaa-8aaa-777777777773"), new Guid("6c179026-9a44-4eca-b75a-811ebb8a577a"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Corsair K95 RGB", 200.0 },
                    { new Guid("e7777777-7777-4aaa-8aaa-777777777774"), new Guid("6c179026-9a44-4eca-b75a-811ebb8a577a"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "SteelSeries Apex Pro", 210.0 },
                    { new Guid("e7777777-7777-4aaa-8aaa-777777777775"), new Guid("6c179026-9a44-4eca-b75a-811ebb8a577a"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Keychron K8", 110.0 },
                    { new Guid("f6666666-6666-4fff-8fff-666666666661"), new Guid("0d5d102d-e7b0-4a2e-a4fa-076deb014547"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Logitech MX Master 3", 120.0 },
                    { new Guid("f6666666-6666-4fff-8fff-666666666662"), new Guid("0d5d102d-e7b0-4a2e-a4fa-076deb014547"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Razer DeathAdder V3", 99.989999999999995 },
                    { new Guid("f6666666-6666-4fff-8fff-666666666663"), new Guid("0d5d102d-e7b0-4a2e-a4fa-076deb014547"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "SteelSeries Rival 5", 79.989999999999995 },
                    { new Guid("f6666666-6666-4fff-8fff-666666666664"), new Guid("0d5d102d-e7b0-4a2e-a4fa-076deb014547"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "HyperX Pulsefire", 69.989999999999995 },
                    { new Guid("f6666666-6666-4fff-8fff-666666666665"), new Guid("0d5d102d-e7b0-4a2e-a4fa-076deb014547"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Corsair Dark Core", 89.989999999999995 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_my_categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "my_categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_my_categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-4aaa-8aaa-111111111111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-4aaa-8aaa-111111111112"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-4aaa-8aaa-111111111113"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-4aaa-8aaa-111111111114"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-4aaa-8aaa-111111111115"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-4bbb-8bbb-222222222221"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-4bbb-8bbb-222222222222"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-4bbb-8bbb-222222222223"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-4bbb-8bbb-222222222224"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-4bbb-8bbb-222222222225"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-4ccc-8ccc-333333333331"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-4ccc-8ccc-333333333332"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-4ccc-8ccc-333333333333"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-4ccc-8ccc-333333333334"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-4ccc-8ccc-333333333335"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4444444-4444-4ddd-8ddd-444444444441"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4444444-4444-4ddd-8ddd-444444444442"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4444444-4444-4ddd-8ddd-444444444443"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4444444-4444-4ddd-8ddd-444444444444"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d4444444-4444-4ddd-8ddd-444444444445"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5555555-5555-4eee-8eee-555555555551"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5555555-5555-4eee-8eee-555555555552"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5555555-5555-4eee-8eee-555555555553"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5555555-5555-4eee-8eee-555555555554"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5555555-5555-4eee-8eee-555555555555"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7777777-7777-4aaa-8aaa-777777777771"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7777777-7777-4aaa-8aaa-777777777772"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7777777-7777-4aaa-8aaa-777777777773"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7777777-7777-4aaa-8aaa-777777777774"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7777777-7777-4aaa-8aaa-777777777775"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6666666-6666-4fff-8fff-666666666661"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6666666-6666-4fff-8fff-666666666662"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6666666-6666-4fff-8fff-666666666663"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6666666-6666-4fff-8fff-666666666664"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6666666-6666-4fff-8fff-666666666665"));

            migrationBuilder.DeleteData(
                table: "my_categories",
                keyColumn: "Id",
                keyValue: new Guid("0d5d102d-e7b0-4a2e-a4fa-076deb014547"));

            migrationBuilder.DeleteData(
                table: "my_categories",
                keyColumn: "Id",
                keyValue: new Guid("34c0032d-9a67-40a8-b6c4-8c0d15b23650"));

            migrationBuilder.DeleteData(
                table: "my_categories",
                keyColumn: "Id",
                keyValue: new Guid("4af1ce03-b37c-40a5-8462-28494820f53f"));

            migrationBuilder.DeleteData(
                table: "my_categories",
                keyColumn: "Id",
                keyValue: new Guid("561ac3ea-6374-4b26-b422-4c619bdc26fa"));

            migrationBuilder.DeleteData(
                table: "my_categories",
                keyColumn: "Id",
                keyValue: new Guid("6c179026-9a44-4eca-b75a-811ebb8a577a"));

            migrationBuilder.DeleteData(
                table: "my_categories",
                keyColumn: "Id",
                keyValue: new Guid("89bd4978-0429-4913-8c74-843f24e35cb6"));

            migrationBuilder.DeleteData(
                table: "my_categories",
                keyColumn: "Id",
                keyValue: new Guid("8e1b8de7-421b-4020-ac41-3e96b01ba8d3"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");
        }
    }
}
