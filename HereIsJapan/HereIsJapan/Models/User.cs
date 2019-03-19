using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HereIsJapan.Models
{
    public class User : IdentityUser
    {
        private List<TravelStory> travelStories = new List<TravelStory>();
        private List<Comment> comments = new List<Comment>();

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<TravelStory> TravelStories => travelStories;
        public ICollection<Comment> Comments => comments;
    }
}
