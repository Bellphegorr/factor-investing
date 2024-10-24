using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FactorInvesting.Modules.Assets.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Security : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "assets");

            migrationBuilder.CreateTable(
                name: "Securities",
                schema: "assets",
                columns: table => new
                {
                    SecurityId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecurityName = table.Column<string>(type: "text", nullable: false),
                    SecurityType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Securities", x => x.SecurityId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Securities",
                schema: "assets");
        }
    }
}
