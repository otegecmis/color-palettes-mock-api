﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ColorPalettes.MockAPI.Data;

#nullable disable

namespace ColorPalettes.MockAPI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241212184246_UpdateColorsProp")]
    partial class UpdateColorsProp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ColorPalettes.MockAPI.Entities.Palette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.PrimitiveCollection<string>("Colors")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Highlighted")
                        .HasColumnType("INTEGER");

                    b.PrimitiveCollection<string>("Tags")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Palettes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Colors = "[\"#e24511\",\"#534b68\",\"#3c73a0\",\"#e75db5\"]",
                            Highlighted = true,
                            Tags = "[\"warm\",\"modern\",\"bold\"]"
                        },
                        new
                        {
                            Id = 2,
                            Colors = "[\"#ffffff\",\"#000000\",\"#ff0000\",\"#00ff00\"]",
                            Highlighted = false,
                            Tags = "[\"contrast\",\"classic\",\"bold\"]"
                        },
                        new
                        {
                            Id = 3,
                            Colors = "[\"#123456\",\"#654321\",\"#abcdef\",\"#fedcba\"]",
                            Highlighted = true,
                            Tags = "[\"unique\",\"vibrant\",\"modern\"]"
                        },
                        new
                        {
                            Id = 4,
                            Colors = "[\"#0f0f0f\",\"#f0f0f0\",\"#aabbcc\",\"#ccbbaa\"]",
                            Highlighted = false,
                            Tags = "[\"neutral\",\"soft\",\"classic\"]"
                        },
                        new
                        {
                            Id = 5,
                            Colors = "[\"#ff5733\",\"#c70039\",\"#900c3f\",\"#581845\"]",
                            Highlighted = true,
                            Tags = "[\"vibrant\",\"bold\",\"warm\"]"
                        },
                        new
                        {
                            Id = 6,
                            Colors = "[\"#f4e04d\",\"#f2a541\",\"#f08a5d\",\"#b83b5e\"]",
                            Highlighted = false,
                            Tags = "[\"warm\",\"modern\",\"soft\"]"
                        },
                        new
                        {
                            Id = 7,
                            Colors = "[\"#6a0572\",\"#a40a3c\",\"#ff1e56\",\"#ffc93c\"]",
                            Highlighted = true,
                            Tags = "[\"bold\",\"unique\",\"vibrant\"]"
                        },
                        new
                        {
                            Id = 8,
                            Colors = "[\"#283c63\",\"#928a97\",\"#f2f4f3\",\"#e2dfd2\"]",
                            Highlighted = false,
                            Tags = "[\"neutral\",\"classic\",\"modern\"]"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
