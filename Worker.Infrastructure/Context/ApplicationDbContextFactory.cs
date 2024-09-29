using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Infrastructure.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Configuración en tiempo de diseño
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseNpgsql("Host=postgres.database;Database=postgres;Port=5432;Username=postgres;Password=pass123");

            return new ApplicationDbContext(builder.Options);
        }
    }
}
