using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HereIsJapan.Models
{
    public class TravelStory 
    {
        private List<Comment> comments = new List<Comment>();

        [Key]
        public int StoryID { get; set; }

        [ForeignKey("Cities")]
        public int? CityID { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please tell us when you visted")]
        public DateTime DateVisited { get; set; }

        [Required(ErrorMessage = "Please enter a description of your journey")]
        public string Description { get; set; }

        public virtual City City { get; set; }

        public ICollection<Comment> Comments { get { return comments; } }

    }
}
