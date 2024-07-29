using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Olbrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SemiStaticContentItems",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemiStaticContentItems", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "SemiStaticContentItems",
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
                name: "SemiStaticContentItems");
        }
    }
}
