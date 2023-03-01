using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom.ViewModels
{
    public class EditProjectViewModel
    {
        public EditProjectViewModel()
        {
            ProjectBidders = new List<string>();
        }

        public string Id { get; set; }
        public string OwnerId { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Boolean IsActive { get; set; }

        public IList<string> ProjectBidders { get; set; }
    }
}
