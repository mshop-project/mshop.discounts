using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mshop.discounts.infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
