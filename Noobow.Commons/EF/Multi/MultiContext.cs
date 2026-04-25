using EnumStringValues;
using Microsoft.EntityFrameworkCore;
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
    public virtual DbSet<SagamiharaLibraryUserInfo> SagamiharaLibraryUserInfos { get; set; }
    public virtual DbSet<BloodDonationUserInfo> BloodDonationUserInfos { get; set; }
    public virtual DbSet<BloodDonationCenter> BloodDonationCenters { get; set; }
    public virtual DbSet<BloodDonationReserveCheck> BloodDonationReserveChecks { get; set; }
    public virtual DbSet<RadioTaisoHistory> RadioTaisoHistories { get; set; }
    public virtual DbSet<RadioTaisoVideo> RadioTaisoVideos { get; set; }
    public virtual DbSet<RadioTaisoSetting> RadioTaisoSettings { get; set; }
    public virtual DbSet<YogaChannel> YogaChannels { get; set; }
    public virtual DbSet<YogaVideo> YogaVideos { get; set; }
    public virtual DbSet<YogaHistory> YogaHistories { get; set; }
    public virtual DbSet<YogaSetting> YogaSettings { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = Environment.GetEnvironmentVariable("MULTI_CONNECTION_STRING") ?? "";
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

        modelBuilder.Entity<BloodDonationReserveCheck>()
           .Property(c => c.DonationType)
           .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<BloodDonationTypeEnum>());

        modelBuilder.Entity<BloodDonationReserveCheck>()
           .Property(c => c.CheckType)
           .HasConversion(v => v.GetStringValue(), v => ((string)v).ParseToEnum<BloodDonationCheckTypeEnum>());

        modelBuilder.Entity<RadioTaisoHistory>()
            .HasOne(h => h.RadioTaisoVideo)
            .WithMany(v => v.RadioTaisoHistories)
            .HasForeignKey(h => h.RadioTaisoVideoId);

        modelBuilder.Entity<YogaVideo>()
            .HasOne(v => v.YogaChannel)
            .WithMany(c => c.YogaVideos)
            .HasForeignKey(v => v.YogaChannelId);

        modelBuilder.Entity<YogaHistory>()
            .HasOne(h => h.YogaVideo)
            .WithMany(v => v.YogaHistories)
            .HasForeignKey(h => h.YogaVideoId);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
