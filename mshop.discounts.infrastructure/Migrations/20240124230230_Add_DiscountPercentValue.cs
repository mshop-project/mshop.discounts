using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mshop.discounts.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_DiscountPercentValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentValue",
                table: "Discounts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentValue",
                table: "Discounts");
        }
    }
}
