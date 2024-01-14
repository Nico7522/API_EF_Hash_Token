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
    [Migration("20240114085809_modif orders et users")]
    partial class modifordersetusers
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

                    b.ToTable("Adresses");
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

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.ProductEntity", b =>
                {
                    b.Property<int>("PrdoductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrdoductId"), 1L, 1);

                    b.HasKey("PrdoductId");

                    b.ToTable("Products");
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
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

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

            modelBuilder.Entity("API_EF_Hash_Token.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
