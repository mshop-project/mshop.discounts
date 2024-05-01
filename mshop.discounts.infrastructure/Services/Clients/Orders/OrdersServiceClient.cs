using mshop.discounts.application.Services.Clients.Orders;
using mshop.discounts.domain.models.Clients.Orders;
using System.Net.Http.Json;

namespace mshop.discounts.infrastructure.Services.Clients.Orders
{
    internal class OrdersServiceClient : IOrdersServiceClient
    {
        private readonly HttpClient _httpClient;

        public OrdersServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Order>> GetOrdersByEmailAsync(string email)
        {
            List<Order> orderList = new();

            string productsApiUrl = $"https://localhost:7269/Order/{email}";

            HttpResponseMessage response = await _httpClient.GetAsync(productsApiUrl);

            if (response.IsSuccessStatusCode)
            {
                orderList = await response.Content.ReadFromJsonAsync<List<Order>>();
            }

            return orderList ?? new();
        }
    }
}
