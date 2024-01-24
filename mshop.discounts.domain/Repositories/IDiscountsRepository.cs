using mshop.discounts.domain.Entities;

namespace mshop.discounts.domain.Repositories
{
    public interface IDiscountsRepository
    {
        public Task CreateAsync(Discount discount);
    }
}
