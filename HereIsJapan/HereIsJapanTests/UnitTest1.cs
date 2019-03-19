using HereIsJapan.Controllers;
using HereIsJapan.Repositories;
using HereIsJapan.Models;
using System;
using Xunit;
using System.Linq;

namespace HereIsJapanTests
{
    public class UnitTest1
    {       
        [Fact]
        public void AddCityTest()
        {
            // Arrange
            var repo = new FakeCityRepository();
            var cityController = new CityController(repo);

            // Act
            cityController.AddCity
                ("Tokyo",
                "Tokyo",
                "1/1/2012");

            // Assert
            Assert.Equal("Tokyo",
                repo.Cities.Last().PrefectureName);
        }

        [Fact]
        public void AddTravelStoryTest()
        {
            // Arrange

            var repo = new FakeCityRepository();
            var cityController = new CityController(repo);

            // Act
            const string CITY = "Hiroshima";
            const string DESCRIPTION = "The greatest city in Japan!";
            cityController.AddTravelStory(CITY, DESCRIPTION, "James");

            // Assert
            City city = repo.GetCityByPrefecture(CITY);
            Assert.Equal(DESCRIPTION, city.TravelStories.Last<TravelStory>().Description);
        }






    }
}
