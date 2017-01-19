using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APPDassignmentV1.Models
{
    public partial class APPD_Assignment_V2Context : DbContext
    {
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:appd-assignment-v2.database.windows.net,1433;Initial Catalog=APPD_Assignment_V2;Persist Security Info=False;User ID=appdassignmenttwo;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.Property(e => e.BookingId)
                    .HasColumnName("bookingId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookingDate)
                    .HasColumnName("bookingDate")
                    .HasColumnType("date");

                entity.Property(e => e.BookingEndDate)
                    .HasColumnName("bookingEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.BookingStartDate)
                    .HasColumnName("bookingStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ResourceId)
                    .IsRequired()
                    .HasColumnName("resourceId")
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__booking__resourc__0C85DE4D");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("picture");

                entity.Property(e => e.PictureId)
                    .HasColumnName("pictureId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Picturee)
                    .IsRequired()
                    .HasColumnName("picturee");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.Property(e => e.RegionId)
                    .HasColumnName("regionId")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("regionName")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("resource");

                entity.Property(e => e.ResourceId)
                    .HasColumnName("resourceId")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Aircon).HasColumnName("aircon");

                entity.Property(e => e.Fulladdress)
                    .IsRequired()
                    .HasColumnName("fulladdress")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.PictureId).HasColumnName("pictureId");

                entity.Property(e => e.PostalCode).HasColumnName("postalCode");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RegionId).HasColumnName("regionId");

                entity.Property(e => e.ResourceSize).HasColumnName("resourceSize");

                entity.Property(e => e.ResourceTypeId).HasColumnName("resourceTypeId");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("FK__resource__pictur__0D7A0286");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__resource__region__0E6E26BF");

                entity.HasOne(d => d.ResourceType)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.ResourceTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__resource__resour__0F624AF8");
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.ToTable("resourceType");

                entity.Property(e => e.ResourceTypeId)
                    .HasColumnName("resourceTypeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ResourceTypeName)
                    .IsRequired()
                    .HasColumnName("resourceTypeName")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}