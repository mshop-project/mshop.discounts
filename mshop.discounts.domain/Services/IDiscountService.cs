using mshop.discounts.domain.models.Clients.Orders;
using mshop.discounts.domain.models.Clients.Products;

namespace mshop.discounts.domain.Services
{
    public interface IDiscountService
    {
        public Task<decimal> CalculateDiscount(IEnumerable<Product> products, IEnumerable<Order> userOrders);
    }
}
