﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZAD_REK.Models;

#nullable disable

namespace ZAD_REK.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ZAD_REK.Models.Account", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"), 1L, 1);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefrestTokenExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ZAD_REK.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdProduct");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            IdProduct = 1,
                            CreatedAt = new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7314),
                            EditedAt = new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7346),
                            Price = 1111.0,
                            ProductDesc = "Desc1",
                            ProductName = "Prod1"
                        },
                        new
                        {
                            IdProduct = 2,
                            CreatedAt = new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7352),
                            EditedAt = new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7353),
                            Price = 2222.0,
                            ProductName = "Prod2"
                        },
                        new
                        {
                            IdProduct = 3,
                            CreatedAt = new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7355),
                            EditedAt = new DateTime(2023, 4, 19, 20, 7, 11, 499, DateTimeKind.Local).AddTicks(7356),
                            Price = 3333.0,
                            ProductDesc = "Desc3",
                            ProductName = "Prod3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
