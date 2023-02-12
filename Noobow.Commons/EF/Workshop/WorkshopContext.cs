using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using Noobow.Commons.EF.Workshop;

namespace Noobow.Commons.EF
{
    public class WorkshopContext : DbContext
    {

        public virtual DbSet<PerformanceTest> PerformanceTests { get; set; }

        public WorkshopContext(DbContextOptions<WorkshopContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*IServiceCollection serviceCollection = new ServiceCollection();
                serviceCollection.AddLogging(builder => builder
                .AddConsole()
                .AddFilter(level => level >= LogLevel.Information)
                );
                var loggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();*/

                var config = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json").Build();
                var connectionString = config.GetConnectionString("WorkshopConnection");
                optionsBuilder.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 4)));
            }
        }
    }
}
