﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ReFeelRepository.Models.Entitites;

namespace ReFeelRepository.Models
{
    public partial class RefeelContext : DbContext
    {
        public RefeelContext()
        {
        }

        public RefeelContext(DbContextOptions<RefeelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<DriverRating> DriverRating { get; set; }
        public virtual DbSet<GeoLocation> GeoLocation { get; set; }
        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<LocalUser> LocalUser { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<SysBrand> SysBrand { get; set; }
        public virtual DbSet<SysModel> SysModel { get; set; }
        public virtual DbSet<SysRating> SysRating { get; set; }
        public virtual DbSet<SysType> SysType { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<ZipCode> ZipCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.LicensePlate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SysBrandId).HasColumnName("SysBrandID");

                entity.Property(e => e.SysModelId).HasColumnName("SysModelID");

                entity.Property(e => e.SysTypeId).HasColumnName("SysTypeID");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_CityCounty");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.Property(e => e.ZipCodeId).HasColumnName("ZipCodeID");

                entity.HasOne(d => d.ZipCode)
                    .WithMany(p => p.County)
                    .HasForeignKey(d => d.ZipCodeId)
                    .HasConstraintName("FK_CountyZipCode");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.LicenseId).HasColumnName("LicenseID");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<DriverRating>(entity =>
            {
                entity.Property(e => e.DriverRatingId).HasColumnName("DriverRatingID");
            });

            modelBuilder.Entity<GeoLocation>(entity =>
            {
                entity.Property(e => e.GeoLocationId).HasColumnName("GeoLocationID");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.Property(e => e.LicenseId).HasColumnName("LicenseID");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<LocalUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(320);

                entity.Property(e => e.Firstname).HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.Lastname).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(35);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.Property(e => e.GeoLocationId).HasColumnName("GeoLocationID");

                entity.Property(e => e.IsLandMark).HasDefaultValueSql("((0))");

                entity.Property(e => e.RelatedLocationId).HasColumnName("RelatedLocationID");

                entity.HasOne(d => d.GeoLocation)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.GeoLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationGeoLocation");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(320);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.PhoneNumber).HasMaxLength(35);

                entity.Property(e => e.RiderId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("RiderID");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.BaseAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CardAccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SurgeAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            });

            modelBuilder.Entity<SysBrand>(entity =>
            {
                entity.Property(e => e.SysBrandId).HasColumnName("SysBrandID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysModel>(entity =>
            {
                entity.Property(e => e.SysModelId).HasColumnName("SysModelID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRating>(entity =>
            {
                entity.Property(e => e.SysRatingId).HasColumnName("SysRatingID");
            });

            modelBuilder.Entity<SysType>(entity =>
            {
                entity.Property(e => e.SysTypeId).HasColumnName("SysTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LocationsId).HasColumnName("LocationsID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.SysRatingId).HasColumnName("SysRatingID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripCar");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Trip)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripPaymentID");
            });

            modelBuilder.Entity<ZipCode>(entity =>
            {
                entity.Property(e => e.ZipCodeId).HasColumnName("ZipCodeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}