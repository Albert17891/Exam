﻿// <auto-generated />
using System;
using Booking.PersistanceDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.PersistanceDB.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20220731084244_Ini")]
    partial class Ini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Booking.Domain.Booking.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistanceToCenter")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("NumbOfBeds")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HostId")
                        .IsUnique();

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("Booking.Domain.Booking.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Booking.Domain.Booking.Profile", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Booking.Domain.Booking.Apartment", b =>
                {
                    b.HasOne("Booking.Domain.Booking.Profile", "Profile")
                        .WithOne("Apartment")
                        .HasForeignKey("Booking.Domain.Booking.Apartment", "HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Booking.Domain.Booking.Order", b =>
                {
                    b.HasOne("Booking.Domain.Booking.Profile", "Profile")
                        .WithMany("Order")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Booking.Domain.Booking.Profile", b =>
                {
                    b.Navigation("Apartment");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
