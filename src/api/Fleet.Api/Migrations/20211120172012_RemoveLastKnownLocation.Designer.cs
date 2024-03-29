﻿// <auto-generated />
using System;
using Fleet.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fleet.Api.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20211120172012_RemoveLastKnownLocation")]
    partial class RemoveLastKnownLocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Fleet.Vehicles.Models.Fleet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fleets");
                });

            modelBuilder.Entity("Fleet.Vehicles.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Truck#1",
                            Type = "Truck"
                        });
                });

            modelBuilder.Entity("Fleet.Vehicles.Models.VehicleFleet", b =>
                {
                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FleetId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("TEXT");

                    b.HasKey("VehicleId", "FleetId");

                    b.HasIndex("FleetId");

                    b.ToTable("VehicleFleets");
                });

            modelBuilder.Entity("Fleet.Vehicles.Models.VehicleLogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleLogItems");
                });

            modelBuilder.Entity("Fleet.Vehicles.Models.VehicleFleet", b =>
                {
                    b.HasOne("Fleet.Vehicles.Models.Fleet", "Fleet")
                        .WithMany("VehicleFleets")
                        .HasForeignKey("FleetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fleet.Vehicles.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleFleets")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fleet");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Fleet.Vehicles.Models.VehicleLogItem", b =>
                {
                    b.HasOne("Fleet.Vehicles.Models.Vehicle", "Vehicle")
                        .WithMany("Log")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Fleet.Common.Location", "Location", b1 =>
                        {
                            b1.Property<int>("VehicleLogItemId")
                                .HasColumnType("INTEGER");

                            b1.Property<double>("Latitude")
                                .HasColumnType("REAL");

                            b1.Property<double>("Longitude")
                                .HasColumnType("REAL");

                            b1.Property<DateTime>("Timestamp")
                                .HasColumnType("TEXT");

                            b1.HasKey("VehicleLogItemId");

                            b1.ToTable("VehicleLogItems");

                            b1.WithOwner()
                                .HasForeignKey("VehicleLogItemId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Fleet.Vehicles.Models.Fleet", b =>
                {
                    b.Navigation("VehicleFleets");
                });

            modelBuilder.Entity("Fleet.Vehicles.Models.Vehicle", b =>
                {
                    b.Navigation("Log");

                    b.Navigation("VehicleFleets");
                });
#pragma warning restore 612, 618
        }
    }
}
