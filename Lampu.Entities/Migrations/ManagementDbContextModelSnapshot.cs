﻿// <auto-generated />
using System;
using Lampu.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lampu.Entities.Migrations
{
    [DbContext(typeof(ManagementDbContext))]
    partial class ManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Lampu.Entities.Lampu", b =>
                {
                    b.Property<Guid>("IdLampu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("NamaLampu")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(7);

                    b.Property<int>("StockLampu")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdLampu");

                    b.ToTable("lampu");
                });
#pragma warning restore 612, 618
        }
    }
}
