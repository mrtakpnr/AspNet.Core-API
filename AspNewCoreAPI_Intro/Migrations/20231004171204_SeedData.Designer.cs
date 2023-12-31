﻿// <auto-generated />
using AspNewCoreAPI_Intro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNewCoreAPI_Intro.Migrations
{
    [DbContext(typeof(CityDbContext))]
    [Migration("20231004171204_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNewCoreAPI_Intro.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "34",
                            Name = "İstanbul",
                            Region = "Marmara"
                        },
                        new
                        {
                            Id = 2,
                            Code = "35",
                            Name = "İzmir",
                            Region = "Ege"
                        },
                        new
                        {
                            Id = 3,
                            Code = "06",
                            Name = "Ankara",
                            Region = "İç Anadolu"
                        },
                        new
                        {
                            Id = 4,
                            Code = "07",
                            Name = "Antalya",
                            Region = "Akdeniz"
                        },
                        new
                        {
                            Id = 5,
                            Code = "16",
                            Name = "Bursa",
                            Region = "Marmara"
                        },
                        new
                        {
                            Id = 6,
                            Code = "52",
                            Name = "Ordu",
                            Region = "Karadeniz"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
