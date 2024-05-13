﻿// <auto-generated />
using System;
using Account.Service.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Account.Service.Infrastructure.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    [Migration("20240513102244_CompanyMigration")]
    partial class CompanyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AccountModule")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Account.Service.Domain.DataModels.AccountDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Accounts", "AccountModule");
                });

            modelBuilder.Entity("Account.Service.Domain.DataModels.CompanyAccountRelationDataModel", b =>
                {
                    b.Property<int>("AccountDataModelId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyDataModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountDataModelId", "CompanyDataModelId");

                    b.HasIndex("CompanyDataModelId");

                    b.ToTable("CompaniesRelation", "AccountModule");
                });

            modelBuilder.Entity("Account.Service.Domain.DataModels.CompanyDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies", "AccountModule");
                });

            modelBuilder.Entity("Account.Service.Domain.DataModels.CompanyAccountRelationDataModel", b =>
                {
                    b.HasOne("Account.Service.Domain.DataModels.AccountDataModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountDataModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Account.Service.Domain.DataModels.CompanyDataModel", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyDataModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}