using mshop.discounts.domain.Enums;

namespace mshop.discounts.domain.Entities
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? MinimumNumberOrdersPerUser {  get; set; }
        public Guid? CategoryId { get; set; }   
        public int? MinimumNumberProductsPerCategory { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountPercentValue { get; set; }
    }
}
