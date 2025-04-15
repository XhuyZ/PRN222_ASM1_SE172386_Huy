using System;
using System.Collections.Generic;
using Application.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Repositories.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<System_UserAccount> System_UserAccounts { get; set; }

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
        modelBuilder.Entity<Vaccine>(entity =>
        {
            entity.HasKey(e => e.VaccineId).HasName("PK__Vaccines__45DC6889121D0127");

            entity.Property(e => e.VaccineId).ValueGeneratedNever();
        });

        modelBuilder.Entity<VaccinePackage>(entity =>
        {
            entity.HasKey(e => e.VaccinePackageID).HasName("PK__VaccineP__BEA96C823A1F8BBE");

            entity.Property(e => e.VaccinePackageID).ValueGeneratedNever();
        });

        modelBuilder.Entity<VaccinePackageDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VaccineP__3214EC07FE918F11");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Vaccine).WithMany(p => p.VaccinePackageDetails).HasConstraintName("FK__VaccinePa__Vacci__60A75C0F");

            entity.HasOne(d => d.VaccinePackage).WithMany(p => p.VaccinePackageDetails).HasConstraintName("FK__VaccinePa__Vacci__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
