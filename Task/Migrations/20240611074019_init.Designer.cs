﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.Models;

#nullable disable

namespace Task.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240611074019_init")]
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

            modelBuilder.Entity("Task.Models._Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deadline = new DateTime(2024, 6, 11, 9, 40, 19, 720, DateTimeKind.Local).AddTicks(4590),
                            Description = "Description 1",
                            ListId = 1,
                            State = "To Do",
                            Title = "Task 1"
                        },
                        new
                        {
                            Id = 2,
                            Deadline = new DateTime(2024, 6, 11, 9, 40, 19, 720, DateTimeKind.Local).AddTicks(4636),
                            Description = "Description 2",
                            ListId = 1,
                            State = "To Do",
                            Title = "Task 2"
                        },
                        new
                        {
                            Id = 3,
                            Deadline = new DateTime(2024, 6, 11, 9, 40, 19, 720, DateTimeKind.Local).AddTicks(4639),
                            Description = "Description 3",
                            ListId = 1,
                            State = "To Do",
                            Title = "Task 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
