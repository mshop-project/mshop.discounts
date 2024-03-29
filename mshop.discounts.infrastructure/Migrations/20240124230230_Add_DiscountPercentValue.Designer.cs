﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using mshop.discounts.infrastructure.Persistence;

#nullable disable

namespace mshop.discounts.infrastructure.Migrations
{
    [DbContext(typeof(DiscountsDbContext))]
    [Migration("20240124230230_Add_DiscountPercentValue")]
    partial class Add_DiscountPercentValue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("mshop.discounts.domain.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("DiscountPercentValue")
                        .HasColumnType("numeric");

                    b.Property<int>("DiscountType")
                        .HasColumnType("integer");

                    b.Property<int?>("MinimumNumberOrdersPerUser")
                        .HasColumnType("integer");

                    b.Property<int?>("MinimumNumberProductsPerCategory")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Discounts", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
