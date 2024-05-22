using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mshop.discounts.application.Services.Clients.Orders;
using mshop.discounts.application.Services.Clients.Products;
using mshop.discounts.domain.Repositories;
using mshop.discounts.infrastructure.Persistence;
using mshop.discounts.infrastructure.Repositories;
using mshop.discounts.infrastructure.Services.Clients.Orders;
using mshop.discounts.infrastructure.Services.Clients.Products;

namespace mshop.discounts.infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<DiscountsDbContext>()
                .AddScoped<IProductsServiceClient, ProductsServiceBusClient>()
                .AddScoped<IOrdersServiceClient, OrdersServiceBusClient>()
                .AddScoped<IDiscountsRepository, DiscountsRepository>();
        }
    }
}