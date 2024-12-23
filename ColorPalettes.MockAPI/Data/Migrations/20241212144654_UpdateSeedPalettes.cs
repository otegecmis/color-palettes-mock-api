using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ColorPalettes.MockAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedPalettes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Palettes",
                columns: new[] { "Id", "Colors", "Highlighted", "Tags" },
                values: new object[,]
                {
                    { 2, "[\"#ffffff\",\"#000000\",\"#ff0000\",\"#00ff00\"]", false, "[\"contrast\",\"classic\",\"bold\"]" },
                    { 3, "[\"#123456\",\"#654321\",\"#abcdef\",\"#fedcba\"]", true, "[\"unique\",\"vibrant\",\"modern\"]" },
                    { 4, "[\"#0f0f0f\",\"#f0f0f0\",\"#aabbcc\",\"#ccbbaa\"]", false, "[\"neutral\",\"soft\",\"classic\"]" },
                    { 5, "[\"#ff5733\",\"#c70039\",\"#900c3f\",\"#581845\"]", true, "[\"vibrant\",\"bold\",\"warm\"]" },
                    { 6, "[\"#f4e04d\",\"#f2a541\",\"#f08a5d\",\"#b83b5e\"]", false, "[\"warm\",\"modern\",\"soft\"]" },
                    { 7, "[\"#6a0572\",\"#a40a3c\",\"#ff1e56\",\"#ffc93c\"]", true, "[\"bold\",\"unique\",\"vibrant\"]" },
                    { 8, "[\"#283c63\",\"#928a97\",\"#f2f4f3\",\"#e2dfd2\"]", false, "[\"neutral\",\"classic\",\"modern\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Palettes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Palettes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Palettes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Palettes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Palettes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Palettes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Palettes",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
