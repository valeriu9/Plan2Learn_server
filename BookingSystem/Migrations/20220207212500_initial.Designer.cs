﻿// <auto-generated />
using System;
using BookingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingSystem.Migrations
{
    [DbContext(typeof(AuthDbContext))]
    [Migration("20220207212500_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("BookingSystem.Model.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookedQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateFrom")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTo")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("ResourceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookedQuantity = 2,
                            DateFrom = new DateTime(2022, 2, 7, 22, 25, 0, 737, DateTimeKind.Local).AddTicks(1922),
                            DateTo = new DateTime(2022, 2, 8, 22, 25, 0, 737, DateTimeKind.Local).AddTicks(1952),
                            ResourceId = 1
                        });
                });

            modelBuilder.Entity("BookingSystem.Model.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Resource1",
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "Resource2",
                            Quantity = 4
                        },
                        new
                        {
                            Id = 3,
                            Name = "Resource3",
                            Quantity = 6
                        },
                        new
                        {
                            Id = 4,
                            Name = "Resource4",
                            Quantity = 8
                        },
                        new
                        {
                            Id = 5,
                            Name = "Resource5",
                            Quantity = 10
                        },
                        new
                        {
                            Id = 6,
                            Name = "Resource6",
                            Quantity = 12
                        });
                });
#pragma warning restore 612, 618
        }
    }
}