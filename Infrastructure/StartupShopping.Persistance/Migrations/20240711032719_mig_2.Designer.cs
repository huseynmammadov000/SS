﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StartupShopping.Persistance.Contexts;

#nullable disable

namespace StartupShopping.Persistance.Migrations
{
    [DbContext(typeof(StartupShoppingDbContext))]
    [Migration("20240711032719_mig_2")]
    partial class mig_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StartupShopping.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid?>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RefreshTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RefreshTokenValidationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StartupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Models.RefreshTokenValidation", b =>
                {
                    b.Property<string>("RefreshTokenValidationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RefreshTokenValidationId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokenValidations");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Models.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<string>("ClientRealIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clientRealIp");

                    b.Property<string>("ClientUserAgent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("clientUserAgent");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("expiredAt");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Radar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Radars");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b34ffa64-64da-4645-a1b6-cfc3ad5fcad0"),
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Admin",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4d03944e-679c-4361-b38e-a9f06db991bb"),
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Entrepreneur",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("fa85f078-d903-47f6-8bf5-352bbe9fca91"),
                            CreatedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Investor",
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Startup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FoundationYear")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PortfolioId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartupDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("UploadedFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UploadedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WebAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Startups");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.AppUser", b =>
                {
                    b.HasOne("StartupShopping.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("StartupShopping.Domain.Entities.Portfolio", "Portfolio")
                        .WithMany()
                        .HasForeignKey("PortfolioId");

                    b.Navigation("Company");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.AppUserRole", b =>
                {
                    b.HasOne("StartupShopping.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupShopping.Domain.Entities.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Models.RefreshTokenValidation", b =>
                {
                    b.HasOne("StartupShopping.Domain.Entities.AppUser", null)
                        .WithOne("RefreshTokenValidation")
                        .HasForeignKey("StartupShopping.Domain.Entities.Models.RefreshTokenValidation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Models.Session", b =>
                {
                    b.HasOne("StartupShopping.Domain.Entities.AppUser", null)
                        .WithOne("Session")
                        .HasForeignKey("StartupShopping.Domain.Entities.Models.Session", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("StartupShopping.Domain.Entities.AppUser", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("StartupShopping.Domain.Entities.RefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Startup", b =>
                {
                    b.HasOne("StartupShopping.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupShopping.Domain.Entities.AppUser", "User")
                        .WithOne("Startup")
                        .HasForeignKey("StartupShopping.Domain.Entities.Startup", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("RefreshToken")
                        .IsRequired();

                    b.Navigation("RefreshTokenValidation");

                    b.Navigation("Session");

                    b.Navigation("Startup");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("StartupShopping.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
