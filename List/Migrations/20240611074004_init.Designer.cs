﻿// <auto-generated />
using System;
using List.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace List.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240611074004_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("List.Models._List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BoardId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Lists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BoardId = 1,
                            CreatedAt = new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8152),
                            Description = "Description 1",
                            Name = "List 1",
                            UpdatedAt = new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8197)
                        },
                        new
                        {
                            Id = 2,
                            BoardId = 1,
                            CreatedAt = new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8200),
                            Description = "Description 2",
                            Name = "List 2",
                            UpdatedAt = new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8201)
                        },
                        new
                        {
                            Id = 3,
                            BoardId = 1,
                            CreatedAt = new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8204),
                            Description = "Description 3",
                            Name = "List 3",
                            UpdatedAt = new DateTime(2024, 6, 11, 9, 40, 4, 56, DateTimeKind.Local).AddTicks(8206)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}