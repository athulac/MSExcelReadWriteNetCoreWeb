﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticalTest.Domain;

namespace PracticalTest.Domain.Migrations
{
    [DbContext(typeof(ApplicaitonDbContext))]
    [Migration("20210926093229_initialcc")]
    partial class initialcc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PracticalTest.Domain.Entity.Acadamic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnglishSecondLang")
                        .HasColumnType("int");

                    b.Property<decimal>("EntryAge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FirsGeneration")
                        .HasColumnType("int");

                    b.Property<int>("Ged")
                        .HasColumnType("int");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Acadamic");
                });

            modelBuilder.Entity("PracticalTest.Domain.Entity.Act", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Composite")
                        .HasColumnType("int");

                    b.Property<int>("English")
                        .HasColumnType("int");

                    b.Property<int>("Math")
                        .HasColumnType("int");

                    b.Property<int>("Reading")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Act");
                });

            modelBuilder.Entity("PracticalTest.Domain.Entity.Ethnicity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ethnicity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hispanic"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Race/ethnicity unknown"
                        },
                        new
                        {
                            Id = 3,
                            Name = "White"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Asian"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hispanic"
                        });
                });

            modelBuilder.Entity("PracticalTest.Domain.Entity.Sat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Combined")
                        .HasColumnType("int");

                    b.Property<int>("Math")
                        .HasColumnType("int");

                    b.Property<int>("Reading")
                        .HasColumnType("int");

                    b.Property<int>("Verbal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sat");
                });

            modelBuilder.Entity("PracticalTest.Domain.Entity.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "FT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TRANSFER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "FTFT"
                        },
                        new
                        {
                            Id = 4,
                            Name = "FTGRAD"
                        });
                });

            modelBuilder.Entity("PracticalTest.Domain.Entity.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcadamicId")
                        .HasColumnType("int");

                    b.Property<int?>("ActId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EthnicityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcadamicId");

                    b.HasIndex("ActId");

                    b.HasIndex("EthnicityId");

                    b.HasIndex("StatusId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("PracticalTest.Domain.Entity.Student", b =>
                {
                    b.HasOne("PracticalTest.Domain.Entity.Acadamic", "Acadamic")
                        .WithMany()
                        .HasForeignKey("AcadamicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticalTest.Domain.Entity.Act", "Act")
                        .WithMany()
                        .HasForeignKey("ActId");

                    b.HasOne("PracticalTest.Domain.Entity.Ethnicity", "Ethnicity")
                        .WithMany()
                        .HasForeignKey("EthnicityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PracticalTest.Domain.Entity.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acadamic");

                    b.Navigation("Act");

                    b.Navigation("Ethnicity");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
