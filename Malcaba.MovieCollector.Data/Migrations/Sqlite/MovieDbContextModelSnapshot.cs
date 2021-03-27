﻿// <auto-generated />
using System;
using Malcaba.MovieCollector.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Malcaba.MovieCollector.Data.Migrations.Sqlite
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13");

            modelBuilder.Entity("Malcaba.MovieCollector.Data.Models.Format", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Format");
                });

            modelBuilder.Entity("Malcaba.MovieCollector.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Actors")
                        .HasColumnType("TEXT");

                    b.Property<string>("Collection")
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Dolby")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FormatId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FullScreen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImdbID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Plot")
                        .HasColumnType("TEXT");

                    b.Property<string>("Poster")
                        .HasColumnType("TEXT");

                    b.Property<int>("RateId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Released")
                        .HasColumnType("TEXT");

                    b.Property<int>("RunTime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("TitleSort")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FormatId");

                    b.HasIndex("RateId");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("Malcaba.MovieCollector.Data.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("Malcaba.MovieCollector.Data.Models.Movie", b =>
                {
                    b.HasOne("Malcaba.MovieCollector.Data.Models.Format", "Format")
                        .WithMany("Movie")
                        .HasForeignKey("FormatId")
                        .HasConstraintName("FK_Movie_Format")
                        .IsRequired();

                    b.HasOne("Malcaba.MovieCollector.Data.Models.Rate", "Rate")
                        .WithMany("Movie")
                        .HasForeignKey("RateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
