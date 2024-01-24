using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mshop.discounts.application.Services.Clients;
using mshop.discounts.infrastructure.Services.Clients.Products;

namespace mshop.discounts.infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient<IProductsServiceClient, ProductsServiceClient>();
        }
    }
}
