namespace mshop.discounts.application.DTOs.Discounts
{
    public class CalculateDiscountDto
    {
        public IEnumerable<Guid>? ProductIds { get; set; }
        public string? CustomerEmail { get; set; }
    }
}
