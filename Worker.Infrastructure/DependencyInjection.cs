using EventBus.Messages;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Worker.Application.Interfaces;
using Worker.Infrastructure.Context;
using Worker.Infrastructure.Repositories;

namespace Worker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWorkerInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));


            services.AddMassTransit(config =>
            {
                config.AddRequestClient<ServiceOneMessage>(new Uri("exchange:service-01"));

                config.AddRequestClient<ServiceTwoMessage>(new Uri("exchange:service-02"));

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("BusConnection"));
                    //cfg.ConfigureEndpoints(ctx); // Configura los endpoints automáticamente
                });
            });

            services.AddMassTransitHostedService();

            //Repositories
            services.AddScoped<IFileInformationRepository, FileInformationRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();

            return services;
        }

        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            services.AddScoped<IFileInformationRepository, FileInformationRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();

            return services;
        }
    }
}
