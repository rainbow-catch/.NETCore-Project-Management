﻿// <auto-generated />
using System;
using DataRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataRoom.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230301002849_add_isActive_field_to_project")]
    partial class add_isActive_field_to_project
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataRoom.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            City = "Dili",
                            CompanyName = "Ministry of Finance",
                            ConcurrencyStamp = "724506fa-69c3-47e9-99b6-3c25f59a8372",
                            Country = "Timor-Leste",
                            Email = "admin@email.com",
                            EmailConfirmed = true,
                            LastName = "admin",
                            LockoutEnabled = false,
                            Name = "Admin",
                            NormalizedEmail = "ADMIN@EMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEN+PJTVY/FGzvLZO9n/pSaiswiE/yUKCNzgOynuSoCjiK8VQXZhoTw7pQ3i7zzrWzw==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3135a4d6-a7f1-4689-a0e7-3c359f9c6e1d",
                            StreetAddress = "Main Street",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdba",
                            AccessFailedCount = 0,
                            City = "Dili",
                            CompanyName = "Ministry of Finance",
                            ConcurrencyStamp = "7d200ab9-e940-4238-96df-02204245ba77",
                            Country = "Timor-Leste",
                            Email = "owner1@email.com",
                            EmailConfirmed = true,
                            LastName = "owner1",
                            LockoutEnabled = false,
                            Name = "Project Owner1",
                            NormalizedEmail = "OWNER1@EMAIL.COM",
                            NormalizedUserName = "OWNER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEPlcjiraDj9B9lo6uNMql7n5QNd3C0aERLB2WGQiqCJkMgVaQEJ+w3F1GsH6mIQ2Ew==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ac437afa-1277-45a8-9ea1-11e6af0fecc8",
                            StreetAddress = "Main Street",
                            TwoFactorEnabled = false,
                            UserName = "owner1"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdbb",
                            AccessFailedCount = 0,
                            City = "Dili",
                            CompanyName = "Ministry of Finance",
                            ConcurrencyStamp = "0f21381b-e12b-4d0b-adbe-d285369647db",
                            Country = "Timor-Leste",
                            Email = "owner2@email.com",
                            EmailConfirmed = true,
                            LastName = "owner2",
                            LockoutEnabled = false,
                            Name = "Project Owner2",
                            NormalizedEmail = "OWNER2@EMAIL.COM",
                            NormalizedUserName = "OWNER2",
                            PasswordHash = "AQAAAAEAACcQAAAAEOgrZqQ9rLdmQ233cyo/GdvN9Vr/XSWRapEdbIG+wWNLNKDWo9U9BgzZDVh9hEdzZw==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5cc92178-963f-44a7-8514-4255745d4b7c",
                            StreetAddress = "Main Street",
                            TwoFactorEnabled = false,
                            UserName = "owner2"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdbc",
                            AccessFailedCount = 0,
                            City = "Dili",
                            CompanyName = "Ministry of Finance",
                            ConcurrencyStamp = "a2617355-10be-4ffe-b4ae-15ef0b20e41d",
                            Country = "Timor-Leste",
                            Email = "bidder1@email.com",
                            EmailConfirmed = true,
                            LastName = "bidder1",
                            LockoutEnabled = false,
                            Name = "Bidder1",
                            NormalizedEmail = "BIDDER1@EMAIL.COM",
                            NormalizedUserName = "BIDDER1",
                            PasswordHash = "AQAAAAEAACcQAAAAELZgDGzZi+2WkGEKsWbctO2jYF5W9KMWd24o7paBId0JIP8Jh6log7ekztId5XOrVA==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "31cc2702-577c-4eea-ac43-cd3c53a29f3a",
                            StreetAddress = "Main Street",
                            TwoFactorEnabled = false,
                            UserName = "bidder1"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdbd",
                            AccessFailedCount = 0,
                            City = "Dili",
                            CompanyName = "Ministry of Finance",
                            ConcurrencyStamp = "1fbeda75-045e-4821-ba1a-033a95ef3199",
                            Country = "Timor-Leste",
                            Email = "bidder2@email.com",
                            EmailConfirmed = true,
                            LastName = "bidder2",
                            LockoutEnabled = false,
                            Name = "Bidder2",
                            NormalizedEmail = "BIDDER2@EMAIL.COM",
                            NormalizedUserName = "BIDDER2",
                            PasswordHash = "AQAAAAEAACcQAAAAEKCFDPkAQZ7C9vBFrQA3/QUaoqK2bv11WPxxKxPJ6RTmZi0onEP1BSo0FG68cuFrKg==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ca6aea69-7a3d-4359-95e6-1235eda1b79e",
                            StreetAddress = "Main Street",
                            TwoFactorEnabled = false,
                            UserName = "bidder2"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdbe",
                            AccessFailedCount = 0,
                            City = "Dili",
                            CompanyName = "Ministry of Finance",
                            ConcurrencyStamp = "a9d2a50d-5861-478a-9d1f-94e0e68356c7",
                            Country = "Timor-Leste",
                            Email = "bidder3@email.com",
                            EmailConfirmed = true,
                            LastName = "bidder3",
                            LockoutEnabled = false,
                            Name = "Bidder3",
                            NormalizedEmail = "BIDDER3@EMAIL.COM",
                            NormalizedUserName = "BIDDER3",
                            PasswordHash = "AQAAAAEAACcQAAAAEBR7JkSMQ3Bds/6v7Ia7z83jmkdXUS4WJJgHXW2aT6y53ceWInGLY3s3jwsA7BFDow==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "122325b4-658a-4223-85ec-b89aaee90df5",
                            StreetAddress = "Main Street",
                            TwoFactorEnabled = false,
                            UserName = "bidder3"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdbf",
                            AccessFailedCount = 0,
                            City = "Dili",
                            CompanyName = "Ministry of Finance",
                            ConcurrencyStamp = "a37182b6-5495-4bf7-ae47-ec992cbd28eb",
                            Country = "Timor-Leste",
                            Email = "bidder4@email.com",
                            EmailConfirmed = true,
                            LastName = "bidder4",
                            LockoutEnabled = false,
                            Name = "Bidder4",
                            NormalizedEmail = "BIDDER4@EMAIL.COM",
                            NormalizedUserName = "BIDDER4",
                            PasswordHash = "AQAAAAEAACcQAAAAEIafEDL9aSkcuTl0QC6Zv7CasV+sHkIz7umQyA2AJVFst7QdydIQonaOtajU/+wRBQ==",
                            PhoneNumber = "123456789",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5b303728-cf5b-47a5-8e10-86fcee85c222",
                            StreetAddress = "Main Street",
                            TwoFactorEnabled = false,
                            UserName = "bidder4"
                        });
                });

            modelBuilder.Entity("DataRoom.Models.BidderProject", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BidderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BidderId");

                    b.HasIndex("ProjectId");

                    b.ToTable("BidderProjects");
                });

            modelBuilder.Entity("DataRoom.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DataRoom.Models.Project", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "49204648-d4d5-4e65-9b2e-515f59b0bb96",
                            Name = "Admins",
                            NormalizedName = "ADMINS"
                        },
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                            ConcurrencyStamp = "e2840944-80d2-4b77-b3df-2d503ae94b08",
                            Name = "Owners",
                            NormalizedName = "OWNERS"
                        },
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                            ConcurrencyStamp = "f8a9c126-db9b-443f-9ba0-6d2e6f97f8c1",
                            Name = "Bidders",
                            NormalizedName = "BIDDERS"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdba",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdbb",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdbc",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdbd",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdbe",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdbf",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DataRoom.Models.BidderProject", b =>
                {
                    b.HasOne("DataRoom.Models.ApplicationUser", "Bidder")
                        .WithMany("BidderProjects")
                        .HasForeignKey("BidderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataRoom.Models.Project", "Project")
                        .WithMany("ProjectBidders")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Bidder");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DataRoom.Models.Project", b =>
                {
                    b.HasOne("DataRoom.Models.ApplicationUser", null)
                        .WithMany("Projects")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataRoom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataRoom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataRoom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataRoom.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DataRoom.Models.ApplicationUser", b =>
                {
                    b.Navigation("BidderProjects");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DataRoom.Models.Project", b =>
                {
                    b.Navigation("ProjectBidders");
                });
#pragma warning restore 612, 618
        }
    }
}