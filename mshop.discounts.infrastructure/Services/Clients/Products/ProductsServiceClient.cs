using mshop.discounts.application.DTOs.Clients.Products;
using mshop.discounts.application.Services.Clients;
using System.Net.Http.Json;

namespace mshop.discounts.infrastructure.Services.Clients.Products
{
    internal class ProductsServiceClient : IProductsServiceClient
    {
        private readonly HttpClient _httpClient;

        public ProductsServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetProductsByIdsAsync(IEnumerable<Guid> ids)
        {
            string productsApiUrl = "https://localhost:7158/Products/Ids"; 

            string queryParameters = string.Join("&", ids.Select(id => $"ids={id}"));
            string fullUrl = $"{productsApiUrl}?{queryParameters}";

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                List<ReadProductDto>? productList = await response.Content.ReadFromJsonAsync<List<ReadProductDto>>();
            }
        }
    }
}
