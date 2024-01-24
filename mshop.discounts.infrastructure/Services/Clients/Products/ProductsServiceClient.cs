using mshop.discounts.application.Services.Clients.Products;
using mshop.discounts.domain.models.Clients.Products;
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

        public async Task<IEnumerable<Product>> GetProductsByIdsAsync(IEnumerable<Guid> ids)
        {
            List<Product>? productList = new();

            string productsApiUrl = "https://localhost:7158/Products/Ids"; 

            string queryParameters = string.Join("&", ids.Select(id => $"ids={id}"));
            string fullUrl = $"{productsApiUrl}?{queryParameters}";

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                productList = await response.Content.ReadFromJsonAsync<List<Product>>();
            }

            return productList;
        }
    }
}
