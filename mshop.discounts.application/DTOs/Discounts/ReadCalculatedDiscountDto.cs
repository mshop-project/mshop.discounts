namespace mshop.discounts.application.DTOs.Discounts
{
    public class ReadCalculatedDiscountDto
    {
        public decimal Discount { get; set; } = 25;

        public ReadCalculatedDiscountDto(decimal discount)
        {
            Discount = discount;
        }
    }
}
