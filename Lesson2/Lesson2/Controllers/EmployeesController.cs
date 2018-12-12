using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels;
using WebStore.DomainModels.Models;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    [Route("users")]
    [Authorize(Roles = WebStoreConstants.Roles.Admin)]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }

        /// <summary>
        /// Вывод списка
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_employeesData.GetAll());
        }

        /// <summary>
        /// Детали о сотруднике
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            //Получаем сотрудника по Id
            var employee = _employeesData.GetById(id);

            //Если такого не существует
            if (employee is null)
                return NotFound();//возвращаем результат 404 Not Found

            //Иначе возвращаем сотрудника
            return View(employee);
        }

        /// <summary>
        /// Добавление или редактирование сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("edit/{id?}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            Employee model;
            if (id.HasValue)
            {
                model = _employeesData.GetById(id.Value);
                if (model is null)
                    return NotFound();//возвращаем результат 404 Not Found
            }
            else
            {
                model = new Employee();
            }
            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Employee model)
        {
            if (model.Age < 18 && model.Age > 75)
            {
                ModelState.AddModelError("Age", "Ошибка возраста!");
            }
            //Проверяем модель на валидность
            if (!ModelState.IsValid) return View(model);
            if (model.Id > 0)
            {
                var dbItem = _employeesData.GetById(model.Id);

                if (dbItem is null)
                    return NotFound();//возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Position = dbItem.Position;
            }
            else
            {
                _employeesData.AddNew(model);
            }

            return RedirectToAction(nameof(Index));
            //если не валидна, возвращаем её на представление
        }


        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [Route("delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            _employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}