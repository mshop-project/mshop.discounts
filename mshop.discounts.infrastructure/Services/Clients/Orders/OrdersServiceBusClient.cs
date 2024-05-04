using mshop.discounts.application.Services.Clients.Orders;
using MassTransit;
using mshop.sharedkernel.messaging.Data.Response.Orders;
using mshop.sharedkernel.messaging.Data.Request.Orders;

namespace mshop.discounts.infrastructure.Services.Clients.Orders
{
    internal sealed class OrdersServiceBusClient(IRequestClient<GetOrdersByEmailRequest> orderClient) : IOrdersServiceClient
    {
        public async Task<OrdersResponse> GetOrdersByEmailAsync(string email)
        {
            var ordersResponse = await orderClient.GetResponse<OrdersResponse>(new GetOrdersByEmailRequest(email));

            return ordersResponse.Message;
        }
    }
}