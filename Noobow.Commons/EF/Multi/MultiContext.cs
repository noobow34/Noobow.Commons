using EnumStringValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Noobow.Commons.Constants;
using System.ComponentModel.DataAnnotations;

namespace Noobow.Commons.EF.Multi;

public partial class MultiContext : DbContext
{
    public MultiContext() => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    public MultiContext(DbContextOptions<MultiContext> options) : base(options) => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookMachida> BookMachidas { get; set; }
    public virtual DbSet<FurikaeCheck> FurikaeChecks { get; set; }
    public virtual DbSet<Magazine> Magazines { get; set; }
    public virtual DbSet<MagazineHistory> MagazineHistories { get; set; }
    public virtual DbSet<SchedulerDef> SchedulerDefs { get; set; }
    public virtual DbSet<LibraryStatus> LibraryStatuses { get; set; }
    public virtual DbSet<CheckSite> CheckSites { get; set; }

    public virtual DbSet<MegalosUserInfo> MegalosUserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json").Build();
        var connectionString = config.GetConnectionString("MultiConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckSite>()
           .Property(c => c.CheckType)
           .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<CheckTypeEnum>());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
