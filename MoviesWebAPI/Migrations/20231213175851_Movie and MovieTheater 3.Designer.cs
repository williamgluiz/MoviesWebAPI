﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesWebAPI.Data;

#nullable disable

namespace MoviesWebAPI.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20231213175851_Movie and MovieTheater 3")]
    partial class MovieandMovieTheater3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MoviesWebAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MoviesWebAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesWebAPI.Models.MovieTheater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("MovieTheaters");
                });

            modelBuilder.Entity("MoviesWebAPI.Models.Session", b =>
                {
                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieTheaterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "MovieTheaterId");

                    b.HasIndex("MovieTheaterId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("MoviesWebAPI.Models.MovieTheater", b =>
                {
                    b.HasOne("MoviesWebAPI.Models.Address", "Address")
                        .WithOne("MovieTheater")
                        .HasForeignKey("MoviesWebAPI.Models.MovieTheater", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("MoviesWebAPI.Models.Session", b =>
                {
                    b.HasOne("MoviesWebAPI.Models.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesWebAPI.Models.MovieTheater", "MovieTheater")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieTheaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("MovieTheater");
                });

            modelBuilder.Entity("MoviesWebAPI.Models.Address", b =>
                {
                    b.Navigation("MovieTheater")
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesWebAPI.Models.Movie", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("MoviesWebAPI.Models.MovieTheater", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
