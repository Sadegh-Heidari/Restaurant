﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.MainApp.Infrastructure.EFCORE6.Context;

#nullable disable

namespace Resturan.Infrastructure.EFCORE6.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220924142234_addMenuItem")]
    partial class addMenuItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Resturan.Domain.Category.CategoryModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("DisplayOrder")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Guid");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Resturan.Domain.FoodType.FoodTypeModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Guid");

                    b.ToTable("FoodType", (string)null);
                });

            modelBuilder.Entity("Resturan.Domain.MenuItem.MenuItemModel", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriptaion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FoodTypeId");

                    b.ToTable("MenuItem", (string)null);
                });

            modelBuilder.Entity("Resturan.Domain.MenuItem.MenuItemModel", b =>
                {
                    b.HasOne("Resturan.Domain.Category.CategoryModel", "Category")
                        .WithMany("MenuItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturan.Domain.FoodType.FoodTypeModel", "FoodType")
                        .WithMany("MenuItems")
                        .HasForeignKey("FoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("FoodType");
                });

            modelBuilder.Entity("Resturan.Domain.Category.CategoryModel", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("Resturan.Domain.FoodType.FoodTypeModel", b =>
                {
                    b.Navigation("MenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}