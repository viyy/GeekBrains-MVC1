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
    }
}