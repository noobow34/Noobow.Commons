using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using EnumStringValues;
using SiteUpdateChecker.Constants;
using Noobow.Commons.EF.Tools;
using Noobow.Commons.Constants;

namespace Noobow.Commons.EF
{
    public class ToolsContext : DbContext
    {

        public virtual DbSet<CheckSite> CheckSites { get; set; }
        public virtual DbSet<NotificationTask> NotificationTasks { get; set; }

        public ToolsContext(DbContextOptions<ToolsContext> options) : base(options) { }

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
                var connectionString = config.GetConnectionString("ToolsConnection");
                optionsBuilder./*UseLoggerFactory(loggerFactory).EnableSensitiveDataLogging().*/UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckSite>()
               .Property(c => c.CheckType)
               .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<CheckTypeEnum>());

            modelBuilder.Entity<NotificationTask>()
                .Property(n => n.Status)
                .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<NotificationTaskStatusEnum>());
        }

    }
}
