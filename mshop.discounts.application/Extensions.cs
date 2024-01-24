using Microsoft.Extensions.DependencyInjection;

namespace mshop.discounts.application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(Extensions).Assembly;

            return services
                .AddSingleton<HttpClient>()
                .AddMediatR(configuration =>
                {
                    configuration.RegisterServicesFromAssemblies(assembly);
                }); ;
        }
    }
}
