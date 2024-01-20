using Microsoft.Extensions.DependencyInjection;

namespace mshop.discounts.application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
