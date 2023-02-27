using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee { Id = 1, Name = "Sothun Thay", Email = "sothun.thay@icloud.com", Department = Departments.IT },
            //    new Employee { Id = 2, Name = "Sreyneth Khorn", Email = "sreyneth.khorn@icloud.com", Department = Departments.FINANCE },
            //    new Employee { Id = 3, Name = "Nisa Thay", Email = "nisa.thay@icloud.com", Department = Departments.HR },
            //    new Employee { Id = 4, Name = "Bosba Thay", Email = "bosba.sthay@icloud.com", Department = Departments.HR }
            //    );

            //Seeding a 'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admins", NormalizedName = "Admins".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "Owners", NormalizedName = "Owners".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7212", Name = "Bidders", NormalizedName = "Bidders".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                // Admin
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    Name="Admin",
                    CompanyName="Ministry of Finance",
                    StreetAddress="Main Street",
                    City="Dili",
                    Country="Timor-Leste",

                    UserName = "admin",
                    LastName = "admin",
                    PhoneNumber = "123456789",
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                // Owners
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdba",
                    Name = "Project Owner1",
                    CompanyName = "Ministry of Finance",
                    StreetAddress = "Main Street",
                    City = "Dili",
                    Country = "Timor-Leste",

                    UserName = "owner1",
                    LastName = "owner1",
                    PhoneNumber = "123456789",
                    Email = "owner1@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "OWNER1",
                    NormalizedEmail = "OWNER1@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbb",
                    Name = "Project Owner2",
                    CompanyName = "Ministry of Finance",
                    StreetAddress = "Main Street",
                    City = "Dili",
                    Country = "Timor-Leste",

                    UserName = "owner2",
                    LastName = "owner2",
                    PhoneNumber = "123456789",
                    Email = "owner2@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "OWNER2",
                    NormalizedEmail = "OWNER2@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                // Bidders
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbc",
                    Name = "Bidder1",
                    CompanyName = "Ministry of Finance",
                    StreetAddress = "Main Street",
                    City = "Dili",
                    Country = "Timor-Leste",

                    UserName = "bidder1",
                    LastName = "bidder1",
                    PhoneNumber = "123456789",
                    Email = "bidder1@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER1",
                    NormalizedEmail = "BIDDER1@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbd",
                    Name = "Bidder2",
                    CompanyName = "Ministry of Finance",
                    StreetAddress = "Main Street",
                    City = "Dili",
                    Country = "Timor-Leste",

                    UserName = "bidder2",
                    LastName = "bidder2",
                    PhoneNumber = "123456789",
                    Email = "bidder2@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER2",
                    NormalizedEmail = "BIDDER2@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbe",
                    Name = "Bidder3",
                    CompanyName = "Ministry of Finance",
                    StreetAddress = "Main Street",
                    City = "Dili",
                    Country = "Timor-Leste",

                    UserName = "bidder3",
                    LastName = "bidder3",
                    PhoneNumber = "123456789",
                    Email = "bidder3@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER3",
                    NormalizedEmail = "BIDDER3@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbf",
                    Name = "Bidder4",
                    CompanyName = "Ministry of Finance",
                    StreetAddress = "Main Street",
                    City = "Dili",
                    Country = "Timor-Leste",

                    UserName = "bidder4",
                    LastName = "bidder4",
                    PhoneNumber = "123456789",
                    Email = "bidder4@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER4",
                    NormalizedEmail = "BIDDER4@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );


            // Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdba"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdbb"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdbc"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdbd"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdbe"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdbf"
                }
            );

            // Set foreign keys to implements many-to-many relationship between user model and project model
            modelBuilder.Entity<BidderProject>()
                .HasOne(pt => pt.Bidder)
                .WithMany(p => p.BidderProjects)
                .HasForeignKey(pt => pt.BidderId);

            modelBuilder.Entity<BidderProject>()
                .HasOne(pt => pt.Project)
                .WithMany(t => t.ProjectBidders)
                .HasForeignKey(pt => pt.ProjectId);
        }
    }
}
