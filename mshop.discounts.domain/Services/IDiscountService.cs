using mshop.sharedkernel.coredata.Orders;
using mshop.sharedkernel.coredata.Products;

namespace mshop.discounts.domain.Services
{
    public interface IDiscountService
    {
        public Task<decimal> CalculateDiscount(IEnumerable<Product> products, IEnumerable<Order> userOrders);
    }
}
