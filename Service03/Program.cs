using System.Xml;
using Worker.Application;
using Worker.Application.Interfaces;
using Worker.Infrastructure;
using Worker.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddWorkerApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/files-readed", async (IFileInformationRepository fileInformationRepository,
    int pageNumber = 1, int pageSize = 10, string? regex = null) =>
{
    var files = await fileInformationRepository.GetAllPaginated(pageNumber, pageSize, regex);
    return Results.Ok(files); 
})
.WithOpenApi();

app.Run();

