using mshop.discounts.domain.models.Clients.Orders;

namespace mshop.discounts.application.Services.Clients.Orders
{
    public interface IOrdersServiceClient
    {
        public Task<IEnumerable<Order>> GetOrdersByEmailAsync(string email);
    }
}
