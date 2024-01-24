using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mshop.discounts.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MinimumNumberOrdersPerUser = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    MinimumNumberProductsPerCategory = table.Column<int>(type: "integer", nullable: true),
                    DiscountType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
