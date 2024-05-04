using mshop.discounts.domain.Repositories;
using mshop.sharedkernel.coredata.Discounts;
using mshop.sharedkernel.coredata.Orders;
using mshop.sharedkernel.coredata.Products;

namespace mshop.discounts.domain.Services
{
    internal class DiscountService : IDiscountService
    {
        private readonly IDiscountsRepository _discountsRepository;

        public DiscountService(IDiscountsRepository discountsRepository)
        {
            _discountsRepository = discountsRepository;
        }

        public async Task<decimal> CalculateDiscount(IEnumerable<Product> products, IEnumerable<Order> userOrders)
        {
            var productsDiscount = await GetDiscountsForProductsAsync(products);
            var userDiscount = await GetDiscountForUserAsync(userOrders);

            decimal calculatedDiscount = productsDiscount.Sum(discount => discount.DiscountPercentValue);

            if (userDiscount != null)
                calculatedDiscount += userDiscount.DiscountPercentValue;

            if (calculatedDiscount > 60)
                calculatedDiscount = 60;

            return calculatedDiscount;
        }

        private async Task<IEnumerable<Discount>> GetDiscountsForProductsAsync(IEnumerable<Product> products)
        {
            List<Discount> discounts = new();
            var categories = products.Select(p => p.Category.Id).Distinct();
            
            foreach (var categoryId in categories)
            {            
                var productsCount = products.Select(p => p.Category.Id == categoryId).Count();
                var disc = await _discountsRepository.ChooseDiscountAsync(categoryId, productsCount);
                if (disc is not null)
                    discounts.Add(disc);
            }

            return discounts;
        }

        private async Task<Discount?> GetDiscountForUserAsync(IEnumerable<Order> userOrders) =>
            await _discountsRepository.ChooseDiscountAsync(userOrders.Count());
    }
}
