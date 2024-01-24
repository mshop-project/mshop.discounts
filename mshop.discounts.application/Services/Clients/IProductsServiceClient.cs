namespace mshop.discounts.application.Services.Clients
{
    public interface IProductsServiceClient
    {
        public Task GetProductsByIdsAsync(IEnumerable<Guid> ids);
    }
}
