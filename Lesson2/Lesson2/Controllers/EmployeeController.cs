using System;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeDataService _emplData;

        public EmployeeController(IEmployeeDataService emplData)
        {
            _emplData = emplData;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(_emplData.GetAll());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var t = _emplData.GetById(id);
            if (t is null)
                return NotFound();
            return View(t);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Employee model;
            if (id.HasValue)
            {
                model = _emplData.GetById(id.Value);
                if (model is null)
                    return NotFound();// возвращаем результат 404 Not Found
            }
            else
            {
                model = new Employee();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (CalculateAge(model.Birth) < 18) ModelState.AddModelError("Age", "Сотрудник должен быть старше 18 лет.");
            if (!ModelState.IsValid) return View(model);
            if (model.Id > 0)
            {
                var dbItem = _emplData.GetById(model.Id);

                if (dbItem is null)
                    return NotFound();// возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.LastName = model.LastName;
                dbItem.Birth = model.Birth;
                dbItem.Department = model.Department;
            }
            else
            {
                _emplData.AddNew(model);
            }
            _emplData.Commit();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            _emplData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //utility
        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}