using Microsoft.EntityFrameworkCore;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using EnumStringValues;
using Noobow.Commons.Constants;

namespace Noobow.Commons.EF.Twitter
{
    public class TwitterContext : DbContext
    {

        public virtual DbSet<FollowsUser> FollowsUsers { get; set; }
        public virtual DbSet<FollowsEvent> FollowsEvents { get; set; }
        public virtual DbSet<FollowsSummary> FollowsSummarys { get; set; }
        public virtual DbSet<FollowsView> FollowsView { get; set; }
        public TwitterContext(DbContextOptions<TwitterContext> options) : base(options) { }

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
                var connectionString = config.GetConnectionString("TwitterConnection");
                optionsBuilder.UseMySql(connectionString,
                        mySqlOptions =>
                        {
                            mySqlOptions.ServerVersion(new Version(10, 3), ServerType.MariaDb);
                        }
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FollowsUser>()
               .Property(c => c.FollowsType)
               .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<FollowsTypeEnum>());

            modelBuilder.Entity<FollowsUser>()
               .Property(c => c.Status)
               .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<FollowsStatusEnum>());

            modelBuilder.Entity<FollowsEvent>()
                .Property(n => n.EventType)
                .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<FollowsEventTypeEnum>());
        }

    }
}
