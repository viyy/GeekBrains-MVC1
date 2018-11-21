using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
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