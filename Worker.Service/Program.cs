//using Worker.Service;

//var builder = Host.CreateApplicationBuilder(args);
//builder.Services.AddHostedService<Worker>();

//var host = builder.Build();
//host.Run();

using MassTransit;
using Worker.Application;
using Worker.Infrastructure;
using Worker.Service;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWorkerApplicationLayer();
builder.Services.AddWorkerInfrastructureLayer(builder.Configuration);

// Agregar el Worker como servicio hospedado
builder.Services.AddHostedService<ReadXMLFileWorker>();

var host = builder.Build();
host.Run();