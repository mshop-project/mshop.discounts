using MassTransit;
using MongoDB.Bson;
using mshop.discounts.application.Services.Clients.Products;
using mshop.sharedkernel.messaging.Data.Request.Products;
using mshop.sharedkernel.messaging.Data.Response.Products;

namespace mshop.discounts.infrastructure.Services.Clients.Products
{
    internal class ProductsServiceBusClient(IRequestClient<GetProductsByIdsRequest> productClient) : IProductsServiceClient
    {
        public async Task<ProductsResponse> GetProductsByIdsAsync(IEnumerable<Guid> ids)
        {
             var productsResponse = await productClient
                .GetResponse<ProductsResponse>(new GetProductsByIdsRequest(ids));

            return productsResponse.Message; 
        }
    }
}