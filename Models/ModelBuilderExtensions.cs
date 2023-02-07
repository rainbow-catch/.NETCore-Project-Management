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
        }
    }
}
