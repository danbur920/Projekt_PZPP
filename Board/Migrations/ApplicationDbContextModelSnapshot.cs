﻿// <auto-generated />
using System;
using Board.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Board.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Board.Models._Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Boards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(6993),
                            Description = "Description 1",
                            Name = "Board 1",
                            UpdatedAt = new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7054)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7058),
                            Description = "Description 2",
                            Name = "Board 2",
                            UpdatedAt = new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7209)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7214),
                            Description = "Description 3",
                            Name = "Board 3",
                            UpdatedAt = new DateTime(2024, 6, 10, 22, 55, 0, 424, DateTimeKind.Local).AddTicks(7217)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}