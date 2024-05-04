using mshop.sharedkernel.messaging.Data.Response.Orders;

namespace mshop.discounts.application.Services.Clients.Orders
{
    public interface IOrdersServiceClient
    {
        public Task<OrdersResponse> GetOrdersByEmailAsync(string email);
    }
}
