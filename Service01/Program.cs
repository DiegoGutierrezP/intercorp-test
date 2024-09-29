using MassTransit;
using Microsoft.Extensions.Configuration;
using Service01.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    // Registrar el consumidor
    x.AddConsumer<ServiceOneConsumer>();
    //x.AddConsumer<ServiceOneConsumer>()
    //    .Endpoint(e => e.Name = "service-01");

    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("BusConnection"));
        //cfg.ConfigureEndpoints(ctx); // Configura los endpoints automáticamente

        cfg.ReceiveEndpoint("service-01", e =>
        {
            e.ConfigureConsumer<ServiceOneConsumer>(ctx);
        });
    });

    // Configurar la cola específica "service-01"
    

    // Configurar RabbitMQ
    //x.UsingRabbitMq((context, cfg) =>
    //{
    //    cfg.Host("rabbitmq://localhost", h =>
    //    {
    //        h.Username("guest");
    //        h.Password("guest");
    //    });

    //    // Configurar la cola (queue) para consumir mensajes
    //    cfg.ReceiveEndpoint("file-information-queue", e =>
    //    {
    //        e.ConfigureConsumer<FileInformationConsumer>(context);
    //    });
    //});
});

builder.Services.AddMassTransitHostedService(); // Para iniciar MassTransit como servicio

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.Run();
