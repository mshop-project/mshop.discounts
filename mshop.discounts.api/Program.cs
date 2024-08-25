using MassTransit;
using Microsoft.EntityFrameworkCore;
using mshop.discounts.api;
using mshop.discounts.infrastructure.Persistence;
using mshop.sharedkernel.messaging.Data.Request.Orders;
using mshop.sharedkernel.messaging.Data.Request.Products;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Consul;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDiscountExtensions(builder.Configuration);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddDiscountsBusConfig();

    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("rabbitmq", "/", hostConfigurator =>
        {
            hostConfigurator.Username("guest");
            hostConfigurator.Password("guest");
        });

        config.ConfigureEndpoints(context);
    });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceDiscovery(o => o.UseConsul());

builder.Services.AddCors(options =>
    options.AddPolicy(name: "CORS",
            policy =>
            {
                policy.WithOrigins("*")
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin();
            }));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DiscountsDbContext>();
    try
    {
        await dbContext.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        // Logowanie lub obs³uga b³êdów
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
    }
}

app.UseCors("CORS");
// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
