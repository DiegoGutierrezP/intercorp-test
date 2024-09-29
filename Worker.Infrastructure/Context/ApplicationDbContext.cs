using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Domain.Entities;

namespace Worker.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura otras entidades si es necesario
            modelBuilder.Entity<FileInformation>()
                .Property(e => e.Elt)
                .HasColumnType("jsonb");

            modelBuilder.Entity<FileInformation>()
                .Property(e => e.Person)
                .HasColumnType("jsonb");
        }

        public DbSet<FileInformation> FileInformations { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
