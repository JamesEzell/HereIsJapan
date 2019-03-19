using HereIsJapan.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HereIsJapan.Repositories
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            if (!context.Cities.Any())
            {
                User user = new User { FirstName = "James ", LastName = "Ezell" };
                context.Users.Add(user);

                TravelStory travelStory = new TravelStory()
                {
                    Title = "My Story",
                    DateVisited = DateTime.Parse("30 Oct 2012"),
                    Description = "The ancient capital of Japan",
                };
                user.TravelStories.Add(travelStory);
                context.TravelStories.Add(travelStory);

                Comment comment = new Comment()
                {
                    CommentText = "A lovely city!",
                    Commentator = user
                };

                City city = new City
                {
                    Name = "Nara",
                    Prefecture = "Nara"   
                };
                context.Cities.Add(city);

                City city1 = new City
                {
                    Name = "Yamatotakada",
                    Prefecture= "Nara",
                  
                };
               
                context.Cities.Add(city1);

                City city2 = new City
                {
                    Name = "Sapporo",
                    Prefecture = "Hokkaido",
                   
                };
              
                context.Cities.Add(city2);

                City city3 = new City
                {
                    Name = "Iwamizawa",
                    Prefecture= "Hokkaido",
                    
                };
                
                context.Cities.Add(city3);



                context.SaveChanges();
            }
        }
    }
}
