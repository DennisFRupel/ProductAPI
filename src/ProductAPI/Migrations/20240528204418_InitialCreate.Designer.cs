﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAPI.Data;

#nullable disable

namespace ProductAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240528204418_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductAPI.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Celular",
                            Price = 2999.99m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Notebook",
                            Price = 4999.99m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Tablet",
                            Price = 1999.99m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Relógio Inteligente",
                            Price = 999.99m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Fone de Ouvido",
                            Price = 299.99m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Caixa de Som Bluetooth",
                            Price = 499.99m,
                            Stock = 70
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Teclado",
                            Price = 149.99m,
                            Stock = 40
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Mouse",
                            Price = 99.99m,
                            Stock = 80
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Monitor",
                            Price = 899.99m,
                            Stock = 25
                        },
                        new
                        {
                            Id = 10L,
                            Name = "HD Externo",
                            Price = 399.99m,
                            Stock = 60
                        });
                });
#pragma warning restore 612, 618
        }
    }
}