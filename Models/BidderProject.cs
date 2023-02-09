using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.Models
{
    public class BidderProject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime PublicationDate { get; set; }

        public string BidderId { get; set; }
        public ApplicationUser Bidder{ get; set; }

        public string ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
