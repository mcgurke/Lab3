using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var currentTime = DateTime.Now;
            if (currentTime.Hour < 12)
                ViewData["Greeting"] = "Good Morning!";
            else if (currentTime.Hour < 18)
                ViewData["Greeting"] = "Good Afternoon!";
            else
                ViewData["Greeting"] = "Good Evening!";
            ViewData["Time"] = String.Format("{0:h:mm tt}", currentTime);
            ViewData["Date"] = String.Format("{0:dddd, MMMM d, yyyy}", currentTime);
            DateTime nextYear = new DateTime(DateTime.Today.Year + 1, 1, 1);
            TimeSpan duration = nextYear - DateTime.Today;
            ViewData["TimeLeft"] = duration.Days;
            return View();
        }

        public IActionResult ShowPerson(Person p)
        {
            Console.Write("egg " + p.FirstName);
            ViewData["Heading"] = "Person";
            if (p.FirstName == "" || p.FirstName == null || p.FirstName == "") 
            {
                p = new Person
                {
                    FirstName = "Default",
                    LastName = "Defaultson",
                    BirthDate = new DateTime(1950, 1, 1)
                };
            }
            return View(p);
        }
        

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ShowPerson", person);
            }
            else
            {
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
