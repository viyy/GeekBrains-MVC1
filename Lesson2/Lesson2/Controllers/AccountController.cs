using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View(Account.GenerateTestData());
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}