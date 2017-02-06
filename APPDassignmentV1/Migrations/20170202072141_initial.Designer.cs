using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using APPDassignmentV1.Models;

namespace APPDassignmentV1.Migrations
{
    [DbContext(typeof(APPD_Assignment_V2Context))]
    [Migration("20170202072141_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APPDassignmentV1.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bookingId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnName("bookingDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("BookingEndDate")
                        .HasColumnName("bookingEndDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("BookingStartDate")
                        .HasColumnName("bookingStartDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ResourceId")
                        .IsRequired()
                        .HasColumnName("resourceId")
                        .HasColumnType("varchar(4)");

                    b.HasKey("BookingId");

                    b.HasIndex("ResourceId");

                    b.ToTable("booking");
                });

            modelBuilder.Entity("APPDassignmentV1.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .HasColumnName("regionId");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnName("regionName")
                        .HasColumnType("varchar(100)");

                    b.HasKey("RegionId");

                    b.ToTable("region");
                });

            modelBuilder.Entity("APPDassignmentV1.Models.Resource", b =>
                {
                    b.Property<string>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("resourceId")
                        .HasColumnType("varchar(4)");

                    b.Property<byte>("Aircon")
                        .HasColumnName("aircon");

                    b.Property<string>("Fulladdress")
                        .IsRequired()
                        .HasColumnName("fulladdress")
                        .HasColumnType("varchar(200)");

                    b.Property<byte[]>("Picture")
                        .HasColumnName("picture");

                    b.Property<int>("PostalCode")
                        .HasColumnName("postalCode");

                    b.Property<short>("Price")
                        .HasColumnName("price");

                    b.Property<int>("RegionId")
                        .HasColumnName("regionId");

                    b.Property<short>("ResourceSize")
                        .HasColumnName("resourceSize");

                    b.Property<int>("ResourceTypeId")
                        .HasColumnName("resourceTypeId");

                    b.HasKey("ResourceId");

                    b.HasIndex("RegionId");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("resource");
                });

            modelBuilder.Entity("APPDassignmentV1.Models.ResourceType", b =>
                {
                    b.Property<int>("ResourceTypeId")
                        .HasColumnName("resourceTypeId");

                    b.Property<string>("ResourceTypeName")
                        .IsRequired()
                        .HasColumnName("resourceTypeName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ResourceTypeId");

                    b.ToTable("resourceType");
                });

            modelBuilder.Entity("APPDassignmentV1.Models.Booking", b =>
                {
                    b.HasOne("APPDassignmentV1.Models.Resource", "Resource")
                        .WithMany("Booking")
                        .HasForeignKey("ResourceId")
                        .HasConstraintName("FK__booking__resourc__0C85DE4D");
                });

            modelBuilder.Entity("APPDassignmentV1.Models.Resource", b =>
                {
                    b.HasOne("APPDassignmentV1.Models.Region", "Region")
                        .WithMany("Resource")
                        .HasForeignKey("RegionId")
                        .HasConstraintName("FK__resource__region__0E6E26BF");

                    b.HasOne("APPDassignmentV1.Models.ResourceType", "ResourceType")
                        .WithMany("Resource")
                        .HasForeignKey("ResourceTypeId")
                        .HasConstraintName("FK__resource__resour__0F624AF8");
                });
        }
    }
}
