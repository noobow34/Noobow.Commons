﻿using EnumStringValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Noobow.Commons.Constants;

namespace Noobow.Commons.EF.Multi;

public partial class MultiContext : DbContext
{
    public MultiContext() => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    public MultiContext(DbContextOptions<MultiContext> options) : base(options) => AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookMachida> BookMachidas { get; set; }
    public virtual DbSet<FurikaeCheck> FurikaeChecks { get; set; }
    public virtual DbSet<Magazine> Magazines { get; set; }
    public virtual DbSet<MagazineSchedule> MagazineSchedules { get; set; }
    public virtual DbSet<MagazineHistory> MagazineHistories { get; set; }
    public virtual DbSet<LibraryStatus> LibraryStatuses { get; set; }
    public virtual DbSet<CheckSite> CheckSites { get; set; }
    public virtual DbSet<MegalosUserInfo> MegalosUserInfos { get; set; }
    public virtual DbSet<SchedulerJob> SchedulerJobs { get; set; }
    public virtual DbSet<SchedulerSchedule> SchedulerSchedules { get; set; }

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

        modelBuilder.Entity<MagazineSchedule>()
            .HasOne(ms => ms.Magazine)
            .WithMany(m => m.MagazineSchedules)
            .HasForeignKey(ms => ms.MagazineId);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
