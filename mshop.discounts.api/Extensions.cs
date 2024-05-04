using mshop.discounts.application;
using mshop.discounts.domain;
using mshop.discounts.infrastructure;


namespace mshop.discounts.api
{
    public static class Extensions
    {
        public static IServiceCollection AddDiscountExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddInfrastructure(configuration)
                .AddApplication()
                .AddDomain();
        }
    }
}
