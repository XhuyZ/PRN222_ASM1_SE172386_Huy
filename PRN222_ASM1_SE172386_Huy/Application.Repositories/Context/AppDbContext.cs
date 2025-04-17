using System;
using System.Collections.Generic;
using Application.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Repositories.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<System_UserAccount?> System_UserAccounts { get; set; }

    public virtual DbSet<Vaccine> Vaccines { get; set; }

    public virtual DbSet<VaccinePackage> VaccinePackages { get; set; }

    public virtual DbSet<VaccinePackageDetail> VaccinePackageDetails { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VaccinePackage>(entity =>
        {
            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.VaccinePackages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VaccinePackage_UserAccount");
        });

        modelBuilder.Entity<VaccinePackageDetail>(entity =>
        {
            entity.HasOne(d => d.Package).WithMany(p => p.VaccinePackageDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VaccinePackageDetail_Package");

            entity.HasOne(d => d.Vaccine).WithMany(p => p.VaccinePackageDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VaccinePackageDetail_Vaccine");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
