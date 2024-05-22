using MassTransit;
using mshop.discounts.application;
using mshop.discounts.domain;
using mshop.discounts.infrastructure;
using mshop.sharedkernel.messaging.Data.Request.Orders;
using mshop.sharedkernel.messaging.Data.Request.Products;


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

        public static IBusRegistrationConfigurator AddDiscountsBusConfig(this IBusRegistrationConfigurator config)
        {
            config.AddRequestClient<GetProductsByIdsRequest>();
            config.AddRequestClient<GetOrdersByEmailRequest>();
            return config;
        }
    }
}
