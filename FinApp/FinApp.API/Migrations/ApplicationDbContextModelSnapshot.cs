﻿// <auto-generated />
using System;
using FinApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinApp.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinApp.API.Models.Domain.Agreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("RiskLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.HasIndex("RiskLevelId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.FinancialStatement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgreementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Expenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NetIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.ToTable("FinancialStatements");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.RiskAnalysis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgreementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("RiskScore")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.ToTable("RiskAnalyses");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.RiskLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RiskLevels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9c3a85c1-09bb-4742-9d05-e4e1d6db7dd3"),
                            Name = "Low"
                        },
                        new
                        {
                            Id = new Guid("f2ea49ae-1384-4f24-a0fb-6aac27ae76fb"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("0b427ccc-94cd-47ed-b1e1-a2324c0ba332"),
                            Name = "High"
                        });
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgreementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.Agreement", b =>
                {
                    b.HasOne("FinApp.API.Models.Domain.Partner", "Partner")
                        .WithMany("Agreements")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinApp.API.Models.Domain.RiskLevel", "RiskLevel")
                        .WithMany()
                        .HasForeignKey("RiskLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("RiskLevel");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.FinancialStatement", b =>
                {
                    b.HasOne("FinApp.API.Models.Domain.Agreement", "Agreement")
                        .WithMany("FinancialStatements")
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.RiskAnalysis", b =>
                {
                    b.HasOne("FinApp.API.Models.Domain.Agreement", "Agreement")
                        .WithMany("RiskAnalyses")
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.Subject", b =>
                {
                    b.HasOne("FinApp.API.Models.Domain.Agreement", "Agreement")
                        .WithMany("Subjects")
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.Agreement", b =>
                {
                    b.Navigation("FinancialStatements");

                    b.Navigation("RiskAnalyses");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("FinApp.API.Models.Domain.Partner", b =>
                {
                    b.Navigation("Agreements");
                });
#pragma warning restore 612, 618
        }
    }
}
