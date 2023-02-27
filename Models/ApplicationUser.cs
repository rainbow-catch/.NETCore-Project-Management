using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }

        public List<Project> Projects { get; set; }
        public List<BidderProject> BidderProjects { get; set; }
    }
}
