using Microsoft.Extensions.DependencyInjection;
using mshop.discounts.domain.Services;

namespace mshop.discounts.domain
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services       
                .AddScoped<IDiscountService, DiscountService>();
        }
    }
}