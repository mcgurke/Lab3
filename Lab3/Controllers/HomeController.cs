﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        public IActionResult ShowPerson(int? id)
        {
            ViewData["Heading"] = "Person";
            Person p = _context.People
                    .SingleOrDefault(person => person.PersonID == id);
            
            return View("ShowPerson", p);
        }
        

        public IActionResult AddPerson()
        {
            return View();
        }

        public IActionResult EditPerson(int? id)
        {
            if (id != null)
            { 
                Person p = _context.People
                    .SingleOrDefault(person => person.PersonID == id);
                return View(p);
            }
            return View();
        }

        [HttpPost]
        public IActionResult SubmitEditPerson(int id, [Bind("PersonID,FirstName,LastName,BirthDate")] Person p)
        {
            if (p != null) {
                if (ModelState.IsValid)
                {
                    
                    _context.Update(p);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View("EditPerson", p);
        }

        public IActionResult DeletePerson(int? id)
        {
            Person p;
            if (id != null)
            {
                p = _context.People
                    .SingleOrDefault(person => person.PersonID == id);
                _context.Remove(p);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
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
