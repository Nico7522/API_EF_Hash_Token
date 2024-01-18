﻿// <auto-generated />
using System;
using API_EF_Hash_Token.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_EF_Hash_Token.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240118085119_test entitysd")]
    partial class testentitysd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.AdressEntity", b =>
                {
                    b.Property<int>("AdressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdressId"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("AdressId");

                    b.HasIndex("Number", "Street", "CityName", "Country")
                        .IsUnique();

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.OrderEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<decimal>("TotalReduction")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.ProductCategoryEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.ProductEntity", b =>
                {
                    b.Property<int>("PrdoductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrdoductId"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)")
                        .HasDefaultValue(0m);

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrdoductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.ProductOrderEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("ReductionPerProduct")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(3, 2)
                        .HasColumnType("decimal(3,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductOrder");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.SizeEntity", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"), 1L, 1);

                    b.Property<int>("Size")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("SizeId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.SizeProductEntity", b =>
                {
                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("SizeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SizeProduct");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.UserAdressEntity", b =>
                {
                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AdressId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAdress");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasMaxLength(300)
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("User");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.OrderEntity", b =>
                {
                    b.HasOne("API_EF_Hash_Token.DAL.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.ProductCategoryEntity", b =>
                {
                    b.HasOne("API_EF_Hash_Token.DAL.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_EF_Hash_Token.DAL.Entities.ProductEntity", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.ProductOrderEntity", b =>
                {
                    b.HasOne("API_EF_Hash_Token.DAL.Entities.OrderEntity", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_EF_Hash_Token.DAL.Entities.ProductEntity", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.SizeProductEntity", b =>
                {
                    b.HasOne("API_EF_Hash_Token.DAL.Entities.ProductEntity", "Product")
                        .WithMany("Sizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_EF_Hash_Token.DAL.Entities.SizeEntity", "Size")
                        .WithMany("Products")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.UserAdressEntity", b =>
                {
                    b.HasOne("API_EF_Hash_Token.DAL.Entities.AdressEntity", "Adress")
                        .WithMany("Users")
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_EF_Hash_Token.DAL.Entities.UserEntity", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.AdressEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.OrderEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.ProductEntity", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Orders");

                    b.Navigation("Sizes");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.SizeEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
