using mshop.sharedkernel.messaging.Data.Response.Products;

namespace mshop.discounts.application.Services.Clients.Products
{
    public interface IProductsServiceClient
    {
        public Task<ProductsResponse> GetProductsByIdsAsync(IEnumerable<Guid> ids);
    }
}
