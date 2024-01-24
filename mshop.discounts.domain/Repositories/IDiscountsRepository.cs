using mshop.discounts.domain.Entities;

namespace mshop.discounts.domain.Repositories
{
    public interface IDiscountsRepository
    {
        public Task CreateAsync(Discount discount);

        public Task<Discount?> ChooseDiscountAsync(Guid categoryId, int productsCount);
        public Task<Discount?> ChooseDiscountAsync(int userOrdersCount);
    }
}
