using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HereIsJapan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HereIsJapan.Controllers
{
    public class CityController : Controller
    {



        ICityRepository repo;

        public CityController(ICityRepository r)
        {
            repo = r;
        }

        [AllowAnonymous]
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            List<TravelStory> travelStories = repo.TravelStories.ToList();
            travelStories.Sort((b1, b2) => DateTime.Compare(b1.DateVisited, b2.DateVisited));
            return View(travelStories);
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "User")]
        public IActionResult GetTravelStoryByDateVisited(DateTime dateVisited)
        {
            List<TravelStory> travelStories = (from c in repo.TravelStories
                                                where c.DateVisited == dateVisited
                                                select c).ToList();
            return View(travelStories);
        }

        [Authorize(Roles = "User")]
        public IActionResult AddTravelStory()
        {
            ViewData["TravelStory.CityID"] = new SelectList(repo.Cities, "CityID", "City");
            
            return View("AddTravelStory");
        }

        [Authorize(Roles = "User")]
        public  IActionResult AddComment()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public RedirectToActionResult AddTravelStory(string title, string dateVisited, string description)
        {
            TravelStory travelStory = new TravelStory { Title = title };
            travelStory.DateVisited = DateTime.Parse(dateVisited);
            travelStory.Description = description;
            repo.AddTravelStory(travelStory);
           
            return RedirectToAction("Index");
        }


    }
}
