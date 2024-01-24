using mshop.discounts.domain.models.Clients.Categories;

namespace mshop.discounts.domain.models.Clients.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public Category Category { get; set; } = null!;
    }
}
