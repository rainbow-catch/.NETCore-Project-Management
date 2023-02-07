using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.Models
{
    public class Project
    {
        public string Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [ForeignKey("OwnerId")]
        public string OwnerId { get; set; }
        public List<BidderProject> BidderProjects { get; set; }
    }
}
