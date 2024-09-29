using MassTransit;
using Service02.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    // Registrar el consumidor
    x.AddConsumer<ServiceTwoConsumer>();

    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("BusConnection"));
        //cfg.ConfigureEndpoints(ctx); // Configura los endpoints automáticamente

        cfg.ReceiveEndpoint("service-02", e =>
        {
            e.ConfigureConsumer<ServiceTwoConsumer>(ctx);
        });
    });
});

builder.Services.AddMassTransitHostedService(); // Para iniciar MassTransit como servicio

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



app.Run();
