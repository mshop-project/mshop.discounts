using MassTransit;
using mshop.discounts.api;
using mshop.sharedkernel.messaging.Data.Request.Orders;
using mshop.sharedkernel.messaging.Data.Request.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDiscountExtensions(builder.Configuration);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddDiscountsBusConfig();

    busConfigurator.UsingRabbitMq((context, config) =>
    {
        config.Host("localhost", "/", hostConfigurator =>
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
app.UseCors("CORS");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
