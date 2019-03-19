using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HereIsJapan.Models
{
    public partial class City
    {
        public City()
        {
            TravelStory = new HashSet<TravelStory>();
        }

        public int CityID { get; set; }
        public string Name { get; set; }
        public string Prefecture { get; set; }

        public virtual ICollection<TravelStory> TravelStory { get; set; }
    }
}
