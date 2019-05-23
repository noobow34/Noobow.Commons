using Microsoft.EntityFrameworkCore;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;
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
                var config = new ConfigurationBuilder().SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
                var connectionString = config.GetConnectionString("ToolsConnection");
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
            modelBuilder.Entity<CheckSite>()
               .Property(c => c.CheckType)
               .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<CheckTypeEnum>());

            modelBuilder.Entity<NotificationTask>()
                .Property(n => n.Status)
                .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<NotificationTaskStatusEnum>());
        }

    }
}
