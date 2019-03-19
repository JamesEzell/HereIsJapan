using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HereIsJapan.Controllers
{
    public class QuizController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BballQuiz()
        {
            ViewBag.Answer1 = "Hokkaido";
            ViewBag.Answer2 = "Chunichi";
            ViewBag.Answer3 = "Hiroshima";
            return View();
        }

        public IActionResult BballQuizAnswer(string answer1, string answer2, string answer3, string rightAnswer)
        {
            string check = "Iie, chigaimasu (No, Incorrect)";
            if (rightAnswer == answer1)
            {
                check = "Hai, soo desu!(Yes, that's right!)";
            }
            return Content(check);
        }

        public IActionResult GeoQuiz()
        {
            ViewBag.Answer1 = "Hokkaido";
            ViewBag.Answer2 = "Honshu";
            ViewBag.Answer3 = "Shikoku";
            return View();
        }

        public IActionResult GeoQuizAnswer(string answer1, string answer2, string answer3, string rightAnswer)
        {
            string check = "Iie, chigaimasu (No, Incorrect)";
            if (rightAnswer == answer2)
            {
                check = "Hai, soo desu!(Yes, that's right!)";
            }
            return Content(check);
        }

    }
}
