﻿// <auto-generated />
using System;
using Easy_Rent_API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Easy_Rent_API.Migrations
{
    [DbContext(typeof(EasyRentContext))]
    partial class EasyRentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Easy_Rent_API.Entities.Vehicules.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("transmitions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            description = "manual"
                        },
                        new
                        {
                            Id = 2,
                            description = "automatic"
                        },
                        new
                        {
                            Id = 3,
                            description = "semiAutomatic"
                        },
                        new
                        {
                            Id = 4,
                            description = "Continuosly Variable Transmission"
                        });
                });

            modelBuilder.Entity("Easy_Rent_API.Models.Vehicules.PowerSource", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("powerSources");
                });

            modelBuilder.Entity("Easy_Rent_API.Models.Vehicules.Vehicule", b =>
                {
                    b.Property<decimal>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("id"));

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("places")
                        .HasColumnType("int");

                    b.Property<string>("plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("powerSourceId")
                        .HasColumnType("smallint");

                    b.Property<int>("transmissionId")
                        .HasColumnType("int");

                    b.Property<short>("typologyId")
                        .HasColumnType("smallint");

                    b.HasKey("id");

                    b.HasIndex("powerSourceId");

                    b.HasIndex("transmissionId");

                    b.HasIndex("typologyId");

                    b.ToTable("Vehicules");
                });

            modelBuilder.Entity("Easy_Rent_API.Models.Vehicules.carTypology", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<DateTimeOffset>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("sysdatetimeoffset()");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("carTypologies");
                });

            modelBuilder.Entity("Easy_Rent_API.Models.Vehicules.Vehicule", b =>
                {
                    b.HasOne("Easy_Rent_API.Models.Vehicules.PowerSource", "powerSource")
                        .WithMany()
                        .HasForeignKey("powerSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easy_Rent_API.Entities.Vehicules.Transmission", "transmission")
                        .WithMany()
                        .HasForeignKey("transmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easy_Rent_API.Models.Vehicules.carTypology", "typology")
                        .WithMany()
                        .HasForeignKey("typologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("powerSource");

                    b.Navigation("transmission");

                    b.Navigation("typology");
                });
#pragma warning restore 612, 618
        }
    }
}
