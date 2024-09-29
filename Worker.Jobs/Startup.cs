using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Worker.Application;
using Worker.Infrastructure;

[assembly: FunctionsStartup(typeof(Worker.Jobs.Startup))]
namespace Worker.Jobs
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var context = builder.GetContext();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(context.ApplicationRootPath)
                //.AddJsonFile($"appsettings.{appEnvName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true) // Este archivo es opcional y solo se usa en desarrollo
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddWorkerApplicationLayer();
            builder.Services.AddWorkerInfrastructureLayer(configuration);

            // Agregar configuración como singleton
            builder.Services.AddSingleton(configuration);
        }
    }
}
