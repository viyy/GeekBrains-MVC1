using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers
{
    public class HomeController : Controller
    {
        private List<Students> list = Students.LoadFromCsv("db.csv");
        public IActionResult Index()
        {
            return View(list);
        }

        public IActionResult Details(string id)
        {
            var t = list.FirstOrDefault(i => i.Id == id);
            if (t == null) return NotFound();
            return View(t);
        }
    }
}