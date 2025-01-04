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

        public ToolsContext(DbContextOptions<ToolsContext> options) : base(options) => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        public ToolsContext() : base() => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json").Build();
                var connectionString = config.GetConnectionString("ToolsConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckSite>()
               .Property(c => c.CheckType)
               .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<CheckTypeEnum>());
        }

    }
}
