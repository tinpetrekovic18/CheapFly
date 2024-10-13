﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheapFly.Migrations
{
    [DbContext(typeof(CheapFlyDbContext))]
    [Migration("20241013101252_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CheapFly.Models.PretragaLeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("brojPresjedanja")
                        .HasColumnType("int");

                    b.Property<int>("brojPutnika")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumPolaska")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumPovratka")
                        .HasColumnType("datetime2");

                    b.Property<string>("odredisniAerodrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("polazniAerodrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ukupnaCijena")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("valuta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PretragaLeta");
                });
#pragma warning restore 612, 618
        }
    }
}