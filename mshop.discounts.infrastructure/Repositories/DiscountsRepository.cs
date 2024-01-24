using mshop.discounts.domain.Entities;
using mshop.discounts.domain.Repositories;
using mshop.discounts.infrastructure.Persistence;

namespace mshop.discounts.infrastructure.Repositories
{
    public sealed class DiscountsRepository : IDiscountsRepository
    {
        private readonly DiscountsDbContext _discountsDbContext;

        public DiscountsRepository(DiscountsDbContext discountsDbContext)
        {
            _discountsDbContext = discountsDbContext;
        }

        public async Task CreateAsync(Discount discount)
        {
            await _discountsDbContext.Discounts.AddAsync(discount);
            await _discountsDbContext.SaveChangesAsync();
        }
    }
}
