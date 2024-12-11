using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Colors = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palettes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Palettes",
                columns: new[] { "Id", "Colors" },
                values: new object[] { 1, "[\"#e24511\",\"#534b68\",\"#3c73a0\",\"#e75db5\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Palettes");
        }
    }
}
