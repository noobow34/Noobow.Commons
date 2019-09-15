using Microsoft.EntityFrameworkCore;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;
using EnumStringValues;
using SiteUpdateChecker.Constants;
using Noobow.Commons.EF.Workshop;
using Noobow.Commons.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

                var config = new ConfigurationBuilder().SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
                var connectionString = config.GetConnectionString("WorkshopConnection");
                optionsBuilder./*UseLoggerFactory(loggerFactory).EnableSensitiveDataLogging().*/UseMySql(connectionString,
                        mySqlOptions =>
                        {
                            mySqlOptions.ServerVersion(new Version(10, 3), ServerType.MariaDb);
                        }
                );
            }
        }
    }
}
