using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using mshop.discounts.application.Mapper;

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
                })
                .AddScoped(provider => new MapperConfiguration(cfg =>
                {
                    var scope = provider.CreateScope();
                    cfg.AddProfile(new DiscountProfile());
                }).CreateMapper());
        }
    }
}
