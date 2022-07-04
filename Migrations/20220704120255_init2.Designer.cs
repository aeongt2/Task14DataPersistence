﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task14DataPersistence;

namespace Task14DataPersistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220704120255_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Task14DataPersistence.APIModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MainTempId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MainTempId");

                    b.ToTable("APIModel");
                });

            modelBuilder.Entity("Task14DataPersistence.MainTemp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("feels_like")
                        .HasColumnType("REAL");

                    b.Property<int>("grnd_level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("humidity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pressure")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sea_level")
                        .HasColumnType("INTEGER");

                    b.Property<float>("temp")
                        .HasColumnType("REAL");

                    b.Property<float>("temp_max")
                        .HasColumnType("REAL");

                    b.Property<float>("temp_min")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("MainTemp");
                });

            modelBuilder.Entity("Task14DataPersistence.APIModel", b =>
                {
                    b.HasOne("Task14DataPersistence.MainTemp", "MainTemp")
                        .WithMany()
                        .HasForeignKey("MainTempId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainTemp");
                });
#pragma warning restore 612, 618
        }
    }
}
