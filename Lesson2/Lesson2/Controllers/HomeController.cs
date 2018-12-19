using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private IValuesService _vs;
        public HomeController(IValuesService valuesService)
        {
            _vs = valuesService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _vs.GetAsync();
            return View(values);
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult BlogSingle()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult ErrorStatus(string id)
        {
            if (id == "404")
                return RedirectToAction("NotFound");
            return Content($"Статуcный код ошибки: {id}");
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}