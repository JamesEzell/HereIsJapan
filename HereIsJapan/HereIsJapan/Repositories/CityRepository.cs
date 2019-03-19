using System;
using System.Collections.Generic;
using HereIsJapan.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HereIsJapan.Repositories;

namespace HereIsJapan.Models
{
    public class CityRepository : ICityRepository
    {
        private AppDbContext context;

        public IQueryable<TravelStory> TravelStories => context.TravelStories.Include("Comments");

        public List<City> Cities => context.Cities.ToList();  


        public CityRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public void AddTravelStory(TravelStory travelStory)
        {
            context.TravelStories.Add(travelStory);
            context.SaveChanges();
        }

        public void AddComment(TravelStory travelStory, Comment comment)
        {
            travelStory.Comments.Add(comment);
            context.TravelStories.Update(travelStory);
            context.SaveChanges();
        }

    }
}
