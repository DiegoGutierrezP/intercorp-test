using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Worker.Application.Features.Commands;

namespace Worker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWorkerApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly()); // Asegúrate de que el assembly es el correcto
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddMediatR(typeof(ReadXMLFileCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
