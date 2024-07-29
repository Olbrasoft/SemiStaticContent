using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoSemiStaticContent.AspNetCore.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaticContentItems",
                columns: table => new
                {
                    Key = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticContentItems", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "StaticContentItems",
                columns: new[] { "Key", "Text" },
                values: new object[,]
                {
                    { "privacy", "This is my _privacy policy_." },
                    { "welcome", "# Welcome" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaticContentItems");
        }
    }
}
