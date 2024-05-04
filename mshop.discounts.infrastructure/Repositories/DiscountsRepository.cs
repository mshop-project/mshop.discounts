using Microsoft.EntityFrameworkCore;
using mshop.discounts.domain.Repositories;
using mshop.discounts.infrastructure.Persistence;
using mshop.sharedkernel.coredata.Discounts;
using mshop.sharedkernel.coredata.Discounts.Enums;

namespace mshop.discounts.infrastructure.Repositories
{
    public sealed class DiscountsRepository : IDiscountsRepository
    {
        private readonly DiscountsDbContext _discountsDbContext;

        public DiscountsRepository(DiscountsDbContext discountsDbContext)
        {
            _discountsDbContext = discountsDbContext;
        }

        public async Task<Discount?> ChooseDiscountAsync(Guid categoryId, int productsCount)
        {
            return await _discountsDbContext.Discounts.Where(d => d.DiscountType == DiscountType.ProductsCategories && d.MinimumNumberProductsPerCategory <= productsCount)
                .OrderByDescending(d => d.DiscountPercentValue).FirstOrDefaultAsync();
        }

        public async Task<Discount?> ChooseDiscountAsync(int userOrdersCount)
        {
            return await _discountsDbContext.Discounts.Where(d => d.DiscountType == DiscountType.UserOrders && d.MinimumNumberOrdersPerUser <= userOrdersCount)
                .OrderByDescending(d => d.DiscountPercentValue).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Discount discount)
        {
            await _discountsDbContext.Discounts.AddAsync(discount);
            await _discountsDbContext.SaveChangesAsync();
        }
    }
}
