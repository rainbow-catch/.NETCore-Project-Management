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
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Sothun Thay", Email = "sothun.thay@icloud.com", Department = Departments.IT },
                new Employee { Id = 2, Name = "Sreyneth Khorn", Email = "sreyneth.khorn@icloud.com", Department = Departments.FINANCE },
                new Employee { Id = 3, Name = "Nisa Thay", Email = "nisa.thay@icloud.com", Department = Departments.HR },
                new Employee { Id = 4, Name = "Bosba Thay", Email = "bosba.sthay@icloud.com", Department = Departments.HR }
                );

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7211", Name = "Owner", NormalizedName = "Owner".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7212", Name = "Bidder", NormalizedName = "Bidder".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                // Admin
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "ADMIN@EMAIL.COM",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                // Owners
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdba",
                    UserName = "owner1@email.com",
                    Email = "owner1@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "OWNER1@EMAIL.COM",
                    NormalizedEmail = "OWNER1@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbb",
                    UserName = "owner2@email.com",
                    Email = "owner2@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "OWNER2@EMAIL.COM",
                    NormalizedEmail = "OWNER2@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                // Bidders
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbc",
                    UserName = "bidder1@email.com",
                    Email = "bidder1@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER1@EMAIL.COM",
                    NormalizedEmail = "BIDDER1@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbd",
                    UserName = "bidder2@email.com",
                    Email = "bidder2@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER2@EMAIL.COM",
                    NormalizedEmail = "BIDDER2@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbe",
                    UserName = "bidder3@email.com",
                    Email = "bidder3@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER3@EMAIL.COM",
                    NormalizedEmail = "BIDDER3@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                },
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdbf",
                    UserName = "bidder4@email.com",
                    Email = "bidder4@email.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "BIDDER4@EMAIL.COM",
                    NormalizedEmail = "BIDDER4@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
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
            modelBuilder.Entity<BidderProject>()
                .HasOne(pt => pt.Bidder)
                .WithMany(p => p.BidderProjects)
                .HasForeignKey(pt => pt.BidderId);

            modelBuilder.Entity<BidderProject>()
                .HasOne(pt => pt.Project)
                .WithMany(t => t.BidderProjects)
                .HasForeignKey(pt => pt.ProjectId);
        }
    }
}
