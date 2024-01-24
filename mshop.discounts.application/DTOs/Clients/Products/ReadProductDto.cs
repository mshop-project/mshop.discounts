using mshop.discounts.application.DTOs.Clients.Categories;

namespace mshop.discounts.application.DTOs.Clients.Products
{
    public class ReadProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public ReadCategoryDto Category { get; set; } = null!;
    }
}
