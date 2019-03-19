using System.Collections.Generic;
using System.Linq;
using HereIsJapan.Models;

namespace HereIsJapan.Models
{
    public interface ICityRepository
    {
        IQueryable<TravelStory> TravelStories { get; }

        List<City> Cities { get; }

        void AddTravelStory(TravelStory travelstory);

        void AddComment(TravelStory travelStory, Comment comment);
        
    }
}
