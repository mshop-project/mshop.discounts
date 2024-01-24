using mshop.discounts.domain.models.Clients.Products;

namespace mshop.discounts.application.Services.Clients.Products
{
    public interface IProductsServiceClient
    {
        public Task<IEnumerable<Product>> GetProductsByIdsAsync(IEnumerable<Guid> ids);
    }
}
